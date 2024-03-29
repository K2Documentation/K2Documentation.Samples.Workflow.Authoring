# K2Documentation.Samples.Workflow.Authoring
Use this code sample to author and deploy workflows using code. This code sample is relevant for K2 systems that were upgraded from K2 4.7 to K2 Five and still have access to the Silverlight Workflow designer. Clean installs of K2 Five do not currently have this functionality.

Find more information in the K2 Developers Reference here:
About Authoring Processes (Legacy): https://help.k2.com/onlinehelp/k2five/DevRef/current/default.htm#Designtime/WF-Authoring.html

Authoring processes programmatically allows you to automate the creation and deployment of workflows. You can open the processes you created in the K2 Designer for Visual Studio to validate it and for additional functionality.

This project contains sample code that demonstrate how to:
* Author a workflow
* Deploy a workflow
* Perform management tasks on a deployed workflow

## Prerequisites
* .NET Assemblies (both assemblies are included with K2 client-side tools install and are also included in the project's References folder)
  * SourceCode.Framework.dll
  * SourceCode.HostClientAPI.dll
  * SourceCode.ResolverFramework.dll
  * SourceCode.Workflow.Authoring.dll
  * SourceCode.Workflow.Client.dll
  * SourceCode.Workflow.Design.dll
  * SourceCode.Workflow.Management.dll
  * SourceCode.Workflow.VisualDesigners.dll

## Getting started
* Use these code snippets to learn about working with the legacy workflow.
* Note that as this project is only sample code, it may compile but will not actually run as-is. You will need to edit the code snippets to work in your environment and with your artifacts.
* Fetch or Pull the appropriate branch of this project for your version of K2.
* Consider the Master branch the latest, up-to-date version of the sample project. Branches contain older versions. For example, there may be a branch called K2-Five-5.0 that is specific to K2 Five version 5.0. There may be another branch called K2-Five-5.3 that is specific to K2 Five version 5.3. Assume that the master branch represents the latest release version of K2 Five.
* The Visual Studio project contains a folder called "References" where you can find the referenced .NET assemblies or other uncommon assemblies. By default, try to reference these assemblies from your own environment for consistency, but we provide the referenced assemblies as a convenience in case you are not able to locate or use the referenced assemblies in your environment.
* The Visual Studio project contains a folder called "Resources". This folder contains additional resources that may be required to use the same code, such as K2 deployment packages, sample files, SQL scripts and so on.
   
## License
This project is licensed under the MIT license. Find the MIT license in LICENSE.

## Notes
* The sample code is provided as-is without warranty.
* These sample code projects are not supported by K2 product support.
* The sample code is not necessarily comprehensive for all operations, features or functionality.
* We only accept code contributions that are compatible with the MIT license (essentially, MIT and Public Domain).
