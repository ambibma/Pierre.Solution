
# Pierres Treats

---
#### By Ambi Hidalgo
###### ambio.pk@gmail.com
---

#### Pierre's Treats
Utilizing EFC framework, this MVC application demonstrates many-to-many database relationships with user authentication. Using ASP .Net Core and Indentity this webapp is able to provide Pierre with tools to add Treats, Machines and joined relationships between them. This allows to Pierre to manage his treats only with user authentication
## Technologies Used
* C#
* EFC
* MySql
* Razor
* .NET SDK
* ASPNET Core MVC


## Setup/Installation Requirements
Note: In order for this application to work you will need to create called appsettings.JSON in the root directory as well as a Properties/launchSettings.Json.
* Clone this repository (https://github.com/ambibma/Pierre.Solution)
* using terminal to navigate to the program file (Pierre.Solution)
     ```bash
    $ cd Pierre
    ```
* Once in the Program directory
  ```bash
    $ dotnet restore
    ```
* Create appsettings.Json
    ```bash
    $ touch appseetings.Json
    ```
* Paste the following code and enter your mysql username and password
    ```JSON
    {
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=ambi_hidalgo_pierre;uid=[YOUR USERNAME];pwd=[YOUR PASSWORD];"
     }
    }
    ```
* Once that is finished you will need to create a migration in order create this program's schema. (*Note: The intial migration snapshot already exists in the program's directory, if the below command does not work for whatever reason, delete the migrations file and run* **$ dotnet ef migrations add intial**)
   ```bash
   $ dotnet ef database update
   ```
* Then the program is ready for a build and run!
    
    ```bash
    $ dotnet build
    ```

     ```bash
    $ dotnet watch run
    ```
* This Will open the application in your web browser!

## Known Bugs

* None at the moment
send bug concerns to ambio.pk@gmail.com

## License


Copyright (c) Ambi Hidalgo 2023