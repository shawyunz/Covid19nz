# <img src="./assets/epidemic_512.png" alt="Icon" width="64" />  Covid-19 nz map App

A Xamarin.Forms app for checking locations and cases published by [Ministry of Health](https://www.health.govt.nz/our-work/diseases-and-conditions/covid-19-novel-coronavirus/covid-19-current-cases) in New Zealand.

Backend API provided by [simeonmiteff](https://github.com/simeonmiteff)/[nzcovid19cases](https://github.com/simeonmiteff/nzcovid19cases).



## Screenshots:

|                      Listing                      |                       Cases                       |                        Map                        |
| :-----------------------------------------------: | :-----------------------------------------------: | :-----------------------------------------------: |
| <img src=".\assets\screenshot1.png" width="200" > | <img src=".\assets\screenshot2.png" width="200" > | <img src=".\assets\screenshot3.png" width="200" > |




## Usage:

[Xamarin.Forms Shell](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/shell/)

[Xamarin maps](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/map/)

[Google map for android](https://developers.google.com/maps/documentation/android-sdk/intro)



## Features:

### Site map:

* Check locations and cases published by [Ministry of Health](https://www.health.govt.nz/our-work/diseases-and-conditions/covid-19-novel-coronavirus/covid-19-current-cases).
* Check cases detail.
* Check Covid19 map for NZ.
* Check alert level.
* Check stats?

### TODO:

#### General:

- [ ] move api loading to init page and app cache stored
- [ ] Security updated

#### List page

- [ ] Header api implementation
- [ ] detail info for Header
- [ ] refresh time stated

#### Cases page:

- [ ] Detail page UI
- [ ] Filters and sorters for the listing
- [ ] cases full list with search
- [ ] cases confirmed or probable


#### Map page:

- [ ] pins on the map
- [ ] overlay on the map
- [ ] personal location need or not? (the only difference from web?) 



## Versions

​	v0.1	Implemented with location list and case list.

​	v0.2	Alert page added. Listing UI updated. Detail view fixed.



## License

* This project is licensed under the MIT License.
* Backend API provided by [simeonmiteff](https://github.com/simeonmiteff)/[nzcovid19cases](https://github.com/simeonmiteff/nzcovid19cases).
* App Icon made by [Nhor Phai](https://www.flaticon.com/authors/nhor-phai) from www.flaticon.com
* Icons in app from https://materialdesignicons.com/

