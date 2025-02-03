# C# Entity Framework Introduction

This repository comes setup with a

## Setup


- Remove or rename the *appsettings.Example.json* so that you have an *appsettings.json, appsettings.Development.json* file in the root of the workshop.wwwapi project which contains:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

```

- Note the .gitignore file in the root of the project which prevents the build directories being uploaded:
```
*/**/bin/Debug   
*/**/bin/Release   
*/**/obj/Debug   
*/**/obj/Release   
/workshop.wwwapi/appsettings.json
/workshop.wwwapi/appsettings.Development.json
```


## Dependencies Installed
- Install-Package Scalar.AspNetCore
    - provides a /scalar endpoint 
- Install-Package Swashbuckle.AspNetCore
    - provides a /swagger endpoint
- Install-Package Microsoft.EntityFrameworkCore.Design
- Install-Package Microsoft.EntityFrameworkCore.InMemory

## The Many to Many Rabbit Hole

Click [here](https://learn.microsoft.com/en-us/ef/core/modeling/relationships/many-to-many) to see the Microsoft documentation on doing a Many to Many in Entity Framework.  Be aware that you'll need to be a bit careful on how you name your Id's AND Fk's in your classes.  Here I've kept things very simple and I think EF understands this when creating the migration script!

To view the constraints that have been added you 
## Seeding Data

See How I've seeded the data in the project.  

##
