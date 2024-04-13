### PoliceDepartment Task Tracker

- .NET Core offers `ProblemDetails` support out-of-the-box
- .NET 7 allows for auto serialization of `DateTime`
- Controllers need to be public
- Private setters are required by EF Core 
- Migration naming convention is to use camel case e.g. `AddedPoliceOfficerTableConstraints`
- EF Core Design package is for building migrations. So you need three external libs: Connector, EF and Design
- Static class cannot be sealed
- DTO is a limited representation of the object 
- There are interceptors for that can extend the `SaveChanges()` functionality [here](https://learn.microsoft.com/en-us/ef/core/logging-events-diagnostics/interceptors)
- There are two main types of deployments in Azure: Container Apps and App Services. 
- The App Service deploy pipeline easily integrates with GitHub repo. You can set up the pipelines to build & deploy with a few clicks instead of writing the pipes from scratch
- You can stream logs from Azure App Service
- On App Service, you can also set up on-premise MySQL instance (this is for development only as it doesn't scale)


