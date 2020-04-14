# <img src="./assets/epidemic_512.png" alt="Icon" width="96" />      Covid-19 NZ App
[![Build Status](https://dev.azure.com/shawyunz/Covid19NZApp/_apis/build/status/Covid19nz%20APK?branchName=master)](https://dev.azure.com/shawyunz/Covid19NZApp/_build/latest?definitionId=2&branchName=master)

A Xamarin.Forms app for checking locations and cases published by [Ministry of Health](https://www.health.govt.nz/our-work/diseases-and-conditions/covid-19-novel-coronavirus/covid-19-current-cases) in New Zealand.

Backend API provided by [simeonmiteff](https://github.com/simeonmiteff)/[nzcovid19cases](https://github.com/simeonmiteff/nzcovid19cases).



## Demo:

### App demo gif (v1.1.5):
<img align="center" src=".\assets\demo_app.gif" width="340" />


### Case page details (v1.1.5):
<img align="center" src=".\assets\demo_case.gif" width="340"/>


### Screenshots (v1.1.5)
|                      Summary                      |                       Cases                       |                        Map                        |                       Info                        |
| :-----------------------------------------------: | :-----------------------------------------------: | :-----------------------------------------------: | :-----------------------------------------------: |
| <img src=".\assets\screenshot1.png" width="240" > | <img src=".\assets\screenshot2.png" width="240" > | <img src=".\assets\screenshot3.png" width="240" > | <img src=".\assets\screenshot4.png" width="240" > |



## App releases:

Android:	[VS App Center](https://tinyurl.com/covid19nzapp), or this url: https://tinyurl.com/covid19nzapp

iOS: 		[TODO]

Official store: [TODO]




## Usage:

[Xamarin.Forms Shell](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/shell/)

~~[Xamarin maps](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/map/)~~

~~[Google map for android](https://developers.google.com/maps/documentation/android-sdk/intro)~~

[Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json)

[Azure pipeline](https://dev.azure.com/)

[VS App Center](https://appcenter.ms/)



## Features:

### Site map:

* Check locations and cases published by [Ministry of Health](https://www.health.govt.nz/our-work/diseases-and-conditions/covid-19-novel-coronavirus/covid-19-current-cases).
* Check cases detail.
* Check Covid19 map for NZ.
* Check alert level and other links.
* ~~Check official website.~~ (added in map page)

### TODO :

Check [the project in this repo](https://github.com/shawyunz/Covid19nz/projects/1) from April 9th

#### Refresh on April 8th:

- [x] Stats image source relocated
- [x] Help info for Cases
- [x] Gif demo update for whole app
- [x] Alert level API
- [x] Info page updated


#### Refresh on April 2nd:

- [ ] publish apk to store
- [ ] iOS version publish
- [x] pinch to the picture
- [ ] implement Shell features.(Search done, navigation pending)

#### Refresh on April Fools' Day:

- [ ] Color redesign.
- [ ] Paging cases
- [x] icon converter for gender and color converter for case type
- [x] animation for summary page?


<details><summary><b>More previous tasks from March... </b></summary>
<p>

#### Refresh on March 31th:

- [x] New cases page UI
- [x] Header detail UI
- [x] Info page UI
- [ ] cluster information
- [x] icons not ready

#### Refresh on March 27th:

- [x] api updated based on the new formatting from MOH
- [x] Geo location removed from api (no cities from MOH)
- [x] new header information api pending
- [x] build a pipeline for the project releases

#### General (March 25th):

- [x] move api loading to init page and app cache stored
- [x] Splash screen?
- [ ] Security updated
- [x] file rename and code refactor

#### List page

- [x] Header api implementation
- [x] detail info for Header
- [ ] refresh time stated ([issue 10](https://github.com/simeonmiteff/nzcovid19cases/issues/10))
- [x] ~~Filters and sorters for the listing~~

#### Cases page:

- [x] Detail page UI
- [x] cases listing with search
- [x] cases confirmed or probable


####  ~~Map page:~~

- [x] pins on the map
- [x] init page no pin display
- [x] overlay on the map

</p>
</details>




## Versions

​	v1.1.7	:construction: Hide filter when scrolling.

​	v1.1.6	Fix a bug of number formatting. Refactor some code. Catch no internet crash. Copyright. Easter egg.

​	v1.1.5	Help info on case page updated. Demos updated.

​	v1.1.4	Filter applied. Icons on case page fixed. Info page UI improved.

​	v1.1.3	Stats image source relocated. Info page updated. Alert level API added. Allow zoom on Map page.

​	v1.1.2	Add search bar from Shell.

​	v1.1.1	Add expandable header (check demo above). Update accent color and info page.

​	v1.1.0	:tada: Case page updated. Icons updated.

<details><summary><b>More history... </b></summary>
<p>

​	v1.0.9	API updated (back to live). Readme and screenshots updated.

​	v1.0.8	(STATIC version) Files renamed. Updated StatsPage with image from MOH. Cases page added.

​	v1.0.6	(STATIC version) Loading data when launching. Splash screen added. Fixed map view init bug.

​	v1.0.5	(STATIC version) Pipeline set up. This version displays **STATIC** data on March 25th before API updated.

​	v1.0.4	CasePage UI updated (check screenshot2 above). Menu changed to "List", "Map", "MOH" and "Info"

​	v1.0.3	Map pins fixed. RefreshView was back. Website added. UI updated. Readme big change.

​	v1.0.2	Alert page added. Listing UI updated. Detail view fixed.

​	v1.0.1	(Init) Implemented with simeonmiteff API for locations, cases and map.

</p>
</details>



## License

* This project is licensed under the MIT License.
* Backend API provided by [simeonmiteff](https://github.com/simeonmiteff)/[nzcovid19cases](https://github.com/simeonmiteff/nzcovid19cases).
* App Icon made by [Nhor Phai](https://www.flaticon.com/authors/nhor-phai) from www.flaticon.com.
* Icons in app from https://materialdesignicons.com/.
* In-app images, "Total cases by DHB"  by the Ministry of Health and "UniteAgainstCovid-19" by NZ Government, are licensed under [CC BY 4.0](https://creativecommons.org/licenses/by/4.0/).
* Emojis in commits from [carloscuesta/gitmoji](https://github.com/carloscuesta/gitmoji) under MIT.

