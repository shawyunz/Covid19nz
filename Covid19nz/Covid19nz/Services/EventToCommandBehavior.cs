﻿using System;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Input;
using Xamarin.Forms;

namespace Covid19nz.Services
{
    /// <inheritdoc />
    public class EventToCommandBehavior : BehaviorBase<View>
    {
        /// <summary>
        /// BindableProperty for CommandParameter
        /// </summary>
        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(EventToCommandBehavior));

        /// <summary>
        /// BindableProperty for Command
        /// </summary>
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(EventToCommandBehavior));

        /// <summary>
        /// BindableProperty for EventArgsConverterParameter
        /// </summary>
        public static readonly BindableProperty EventArgsConverterParameterProperty =
            BindableProperty.Create(nameof(EventArgsConverterParameter), typeof(object),
                typeof(EventToCommandBehavior));

        /// <summary>
        /// BindableProperty for EventArgsConverter
        /// </summary>
        public static readonly BindableProperty EventArgsConverterProperty =
            BindableProperty.Create(nameof(EventArgsConverter), typeof(IValueConverter),
                typeof(EventToCommandBehavior));

        /// <summary>
        /// BindableProperty for EventArgsParameterPath
        /// </summary>
        public static readonly BindableProperty EventArgsParameterPathProperty =
            BindableProperty.Create(nameof(EventArgsParameterPath), typeof(string), typeof(EventToCommandBehavior));

        /// <summary>
        /// BindableProperty for EventName
        /// </summary>
        public static readonly BindableProperty EventNameProperty =
            BindableProperty.Create(nameof(EventName), typeof(string), typeof(EventToCommandBehavior));

        private EventInfo _eventInfo;
        private Delegate _handler;

        /// <summary>
        /// The command to execute
        /// </summary>
        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        /// <summary>
        /// Argument sent to <see cref="ICommand.Execute" />
        /// </summary>
        /// <para>
        /// If <see cref="EventArgsConverter" /> and <see cref="EventArgsConverterParameter" /> is set then the result of the
        /// conversion
        /// will be sent.
        /// </para>
        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        /// <summary>
        /// Instance of <see cref="IValueConverter" /> to convert the <see cref="EventArgs" /> for <see cref="EventName" />
        /// </summary>
        public IValueConverter EventArgsConverter
        {
            get => (IValueConverter)GetValue(EventArgsConverterProperty);
            set => SetValue(EventArgsConverterProperty, value);
        }

        /// <summary>
        /// Argument passed as parameter to <see cref="IValueConverter.Convert" />
        /// </summary>
        public object EventArgsConverterParameter
        {
            get => GetValue(EventArgsConverterParameterProperty);
            set => SetValue(EventArgsConverterParameterProperty, value);
        }

        /// <summary>
        /// Parameter path to extract property from <see cref="EventArgs"/> instance to pass to <see cref="ICommand.Execute"/>
        /// </summary>
        public string EventArgsParameterPath
        {
            get => (string)GetValue(EventArgsParameterPathProperty);
            set => SetValue(EventArgsParameterPathProperty, value);
        }

        /// <summary>
        /// Name of the event that will be forwarded to <see cref="Command" />
        /// </summary>
        /// <remarks>
        /// An event that is invalid for the attached <see cref="View" /> will result in <see cref="ArgumentException" /> thrown.
        /// </remarks>
        public string EventName
        {
            get => (string)GetValue(EventNameProperty);
            set => SetValue(EventNameProperty, value);
        }

        /// <inheritdoc />
        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);

            _eventInfo = AssociatedObject
                .GetType()
                .GetRuntimeEvent(EventName);

            if (_eventInfo is null)
            {
                throw new ArgumentException(
                    $"No matching event '{EventName}' on attached type '{bindable.GetType().Name}'");
            }

            AddEventHandler(_eventInfo, AssociatedObject, OnEventRaised);
        }

        /// <inheritdoc />
        protected override void OnDetachingFrom(BindableObject bindable)
        {
            if (_handler != null)
            {
                _eventInfo.RemoveEventHandler(AssociatedObject, _handler);
            }

            _handler = null;
            _eventInfo = null;
            base.OnDetachingFrom(bindable);
        }

        /// <summary>
        /// Execute Command when Event is Raised
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        protected virtual void OnEventRaised(object sender, EventArgs eventArgs)
        {
            if (Command is null)
            {
                return;
            }

            var parameter = CommandParameter;

            if (parameter is null && !string.IsNullOrEmpty(EventArgsParameterPath))
            {
                //Walk the ParameterPath for nested properties.
                var propertyPathParts = EventArgsParameterPath.Split('.');

                object propertyValue = eventArgs;

                foreach (var propertyPathPart in propertyPathParts)
                {
                    var propInfo = propertyValue.GetType().GetTypeInfo().GetDeclaredProperty(propertyPathPart);

                    propertyValue = propInfo.GetValue(propertyValue);

                    if (propertyValue is null)
                    {
                        break;
                    }
                }

                parameter = propertyValue;
            }

            if (parameter is null && eventArgs != null && eventArgs != EventArgs.Empty && EventArgsConverter != null)
            {
                parameter = EventArgsConverter.Convert(eventArgs, typeof(object), EventArgsConverterParameter,
                    CultureInfo.CurrentUICulture);
            }

            if (Command.CanExecute(parameter))
            {
                Command.Execute(parameter);
            }
        }

        private void AddEventHandler(EventInfo eventInfo, object item, Action<object, EventArgs> action)
        {
            var eventParameters = eventInfo.EventHandlerType
                .GetRuntimeMethods().First(m => m.Name == "Invoke")
                .GetParameters()
                .Select(p => Expression.Parameter(p.ParameterType))
                .ToArray();

            var actionInvoke = action.GetType()
                .GetRuntimeMethods().First(m => m.Name == "Invoke");

            _handler = Expression.Lambda(
                    eventInfo.EventHandlerType,
                    Expression.Call(Expression.Constant(action), actionInvoke, eventParameters[0], eventParameters[1]),
                    eventParameters)
                .Compile();

            eventInfo.AddEventHandler(item, _handler);
        }
    }
}