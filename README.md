# WP8Bootstrap
#### Gage Ames (gage@gageames.com)

WP8Bootstrap is a bootstrapper for Windows Phone 8 apps that aims to aggregate everything you need to get started on a basic Windows Phone app. It extends the default Databound App project type from Visual Studio, thus implementing a basic Model-View-ViewModel (MVVM) architecture.  In fact, this template implements MVVM more completely by replacing code-behind with Commands in the ViewModel when feasible (including navigation).  It also comes configured for basic page transitions, animated UI elements, data binding, and example code for extracting data from JSON on the web (including error handling).  While there are still many great features of Windows Phone that are not exemplified in this template, it should be enough to get started with any app that pulls data from a REST API.

### Getting Started
To get started using WP8Bootstrap for a new Windows Phone 8 app, begin by downloading or cloning this repository. Inside the root folder, there is a script called `setup.bat` that should be run to replace all instances of "WP8Bootstrap" with your app's name. Once the rename is complete, you are ready to start working on your Windows Phone 8 app.
[Microsoft Visual Studio](http://msdn.microsoft.com/vstudio) and the [Windows Phone 8 SDK](http://dev.windowsphone.com/downloadsdk) are prerequisites.

### NuGet Packages
* [The Window Phone Toolkit](http://phone.codeplex.com)
* [Coding4Fun Toolkit](http://coding4fun.codeplex.com)
* [Json.NET](http://json.codeplex.com)
* [AppBarUtils](http://appbarutils.codeplex.com)

### Helper Classes and Extensions
* StorageHelper
* DefaultNotifyPropertyChanged
* SortableObservableCollection ([source](http://stackoverflow.com/a/11191500))
* DelegateCommand ([source](http://www.wpftutorial.net/DelegateCommand.html))
* INavigationHelper ([source](http://code.msdn.microsoft.com/wpapps/Sharing-CodeAdding-a4c4beb8))
* MathConverter ([source](http://rachel53461.wordpress.com/2011/08/20/the-math-converter))

### License
This software is distributed free of charge and licensed under the MIT License. For more information about this license and the terms of use of this software, please review the LICENSE file.
