# <img src="./assets/epidemic_512.png" alt="Icon" width="96" /> 

# Covid-19 NZ App

[![Build Status](https://dev.azure.com/shawyunz/Covid19NZApp/_apis/build/status/Covid19nz%20APK?branchName=master)](https://dev.azure.com/shawyunz/Covid19NZApp/_build/latest?definitionId=2&branchName=master)

A Xamarin.Forms app for checking locations and cases published by [Ministry of Health](https://www.health.govt.nz/our-work/diseases-and-conditions/covid-19-novel-coronavirus/covid-19-current-cases) in New Zealand.

Backend API provided by [simeonmiteff](https://github.com/simeonmiteff)/[nzcovid19cases](https://github.com/simeonmiteff/nzcovid19cases).



## APK releases:

APK access from [VS App Center](https://tinyurl.com/covid19nzapp), or this url: https://tinyurl.com/covid19nzapp



## Screenshots:

|                     Locations                     |                       Cases                       |                        Map                        |
| :-----------------------------------------------: | :-----------------------------------------------: | :-----------------------------------------------: |
| <img src=".\assets\screenshot1.png" width="200" > | <img src=".\assets\screenshot2.png" width="200" > | <img src=".\assets\screenshot3.png" width="200" > |




## Usage:

[Xamarin.Forms Shell](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/shell/)

[Xamarin maps](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/map/)

~~[Google map for android](https://developers.google.com/maps/documentation/android-sdk/intro)~~

[Azure pipeline](https://dev.azure.com/)

[VS App Center](https://appcenter.ms/)

[Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json)



## Features:

### Site map:

* Check locations and cases published by [Ministry of Health](https://www.health.govt.nz/our-work/diseases-and-conditions/covid-19-novel-coronavirus/covid-19-current-cases).
* Check cases detail.
* Check Covid19 map for NZ.
* Check alert level and other links.
* ~~Check official website.~~ (added in map page)

### TODO :

#### Refresh on March 27th:

- [ ] api updated based on the new formatting from MOH
- [ ] Geo location removed from api (no cities from MOH)
- [ ] new header information api pending
- [x] build a pipeline for the project releases

#### General (March 25th):

- [x] move api loading to init page and app cache stored
- [x] Splash screen?
- [ ] Security updated
- [x] file rename and code refactor

#### List page

- [ ] Header api implementation
- [ ] detail info for Header
- [ ] refresh time stated
- [ ] Filters and sorters for the listing

#### Cases page:

- [ ] Detail page UI
- [ ] cases listing with search
- [ ] cases confirmed or probable


####  ~~Map page:~~

- [x] pins on the map
- [x] init page no pin display
- [ ] overlay on the map
- [ ] personal location need or not? (the only difference from web?) 




## Versions

​	v1.0.1	Implemented with simeonmiteff API for locations, cases and map.

​	v1.0.2	Alert page added. Listing UI updated. Detail view fixed.

​	v1.0.3	Map pins fixed. RefreshView was back. Website added. UI updated. Readme big change.

​	v1.0.4	CasePage UI updated (check screenshot2 above). Menu changed to "List", "Map", "MOH" and "Info"

​	v1.0.5	(**STATIC** version) Pipeline set up. This version displays **STATIC** data on March 25th before API updated.

​	v1.0.6	(**STATIC** version) Loading data at beginning improve in-app experience. Splash screen added. Fixed map view init bug.

​	v1.0.7	Files renamed. Updated StatsPage with image from MOH. Cases page added.

​	v1.0.8	:construction:



## License

* This project is licensed under the MIT License.
* Backend API provided by [simeonmiteff](https://github.com/simeonmiteff)/[nzcovid19cases](https://github.com/simeonmiteff/nzcovid19cases).
* App Icon made by [Nhor Phai](https://www.flaticon.com/authors/nhor-phai) from www.flaticon.com
* Icons in app from https://materialdesignicons.com/

