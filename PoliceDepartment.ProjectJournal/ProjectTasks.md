### PoliceDepartment Task Tracker

- [ ] **[PD-1]** Replace custom exception Handler with .NET8 `IExceptionHandler`
- [ ] **[PD-2]** Replace API responses with `ProblemDetails`
- [ ] **[PD-3]** Review logging: see if I can use a free tier NewRelic
- [ ] **[PD-4]** Review JWT user authentication
- [ ] **[PD-5]** Deploy to Azure
  - [ ] **[PD-5-1]** Create the build pipeline
  - [ ] **[PD-5-2]** Create the deploy pipeline
  - [ ] **[PD-5-3]** Set up Azure App Service? Use K8 Cluster deployment?
- [X] **[PD-6]** Replace `DateTimeProvider` with the .NET8 library
- [ ] **[PD-7]** Add `CreatedDate` and `LastModifed` to all tables