# **Business Requirement System**

## *Description*
I created this program to provide a simple program to facilitate the entry, review and storage of business requierements and high level requests for the BA(Buisiness Analysts) in my team.


## *Installation*

Make sure you are using Microsoft Visual Studio, found here: https://visualstudio.microsoft.com/downloads/

1. Clone the repository from
https://github.com/jacr777/brd/

2. In NuGet Package Manager, install the following packages
- Microsoft.AspNet.Identity.EntityFramework.

3. Now you will need to remake your Data Tables by doing the following:

Delete the Migrations Folder in you Data Layer
Open Package Manager
Change the Default Project to your Data Layer, or BusinessRequirements.Data\

Enter these three commands into Package Manager
 - Enable-Migrations
 - Add-Migration "your migration title here"
 - Update-Database

## *Usage*
When you run your application:
1. First create an account and sign into the application
2. Once you are logged in the first thing you need to do is create a Project
3. Once you have one or several projects created the navigation starts from the "Details" section of the proyect.
    * From here you can:
       * Create or View HLCs
         * To create a HLC  specify the Number and the HLC
       * View BRDs
       * Edit a Project
       * Go back to the list of project
4. In order to create BRDs you need to create HLCs first, you wont have the option to create BRDS if there is not a HLC in the project first, once you have one or several HLCs created the navigation starts from the "Details" section of the HLC.
    * From here you can:
      * Create or View BRDs
        * To create a BRD specify the Number and the BR
      * Edit an HLC
      * Go back to the list of HLCs
5. More navigation is present on the List/Index of both HLC and BR

## *Links*
* https://docs.google.com/document/d/18vfgH5QnEKqYGfoO_j6dl2r71eZOdj060EXy4cDfTRg/edit#heading=h.apyy2fblhnhk

* https://lucid.app/lucidchart/ca6918ee-5ae1-4970-8202-820cb1912019/edit?beaconFlowId=BDCA440E0FFCF652&page=0_0#?folder_id=home&browser=icon

* https://trello.com/b/Y86UGrf3/redbadgeproject#
      
      
## *Credits*
This Program was made by:
- Antonio Cordero

## *License*
Copyright: 2021 AC/BRS <jacr777@gmail.com> 




