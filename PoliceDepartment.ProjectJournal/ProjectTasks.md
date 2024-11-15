### [PD] PoliceDepartment Task Tracker

- [X] **[PD-1]** Replace custom exception Handler with .NET8 `IExceptionHandler`
- [X] **[PD-2]** Replace API responses with `ProblemDetails`
- [X] **[PD-3]** Review logging: see if I can use a free tier NewRelic
  - [X] [PD-3-1] Use Serilog
  - [X] [PD-3-2] Add File and Console sinks
  - [ ] [PD-3-3] Add NewRelic Agents
- [X] **[PD-4]** Review JWT user authorization
- [X] **[PD-5]** Deploy to Azure
  - [X] **[PD-5-1]** Create the build pipeline
  - [X] **[PD-5-2]** Create the deploy pipeline
  - [X] **[PD-5-3]** Set up Azure App Service
- [X] **[PD-6]** Replace `DateTimeProvider` with the .NET8 library
- [X] **[PD-7]** Add `CreatedDate` and `LastModifed` to all tables
- [X] **[PD-8]** Refactor handlers to use primary constructors
- [X] **[PD-9]** Review logging to file and colouring the output
- [ ] **[PD-10]** Implement some sort of document upload 
  - [ ] **[PD-10-1]** Implement custom template for PDFs
- [ ] **[PD-11]** Implement a background job that will send out e-mails
- [ ] **[PD-12]** Implement caching with Redis
- [X] **[PD-13]** Fix data seeding on startup
- [ ] **[PD-14]** Replace manual seeder with Faker or Mocker or whatever
- [X] **[PD-15]** Implement transactions in the handler with `UnitOfWork`
- [ ] **[PD-16]** Fix binding of object in command; introduce mapping
- [ ] **[PD-17]** Read signing key from KeyVault
- [ ] **[PD-18]** Implement generic options pattern
- [X] **[PD-19]** Add `CurrentUser` service
- [X] **[PD-20]** Add *Swagger*'s `ProducesResponseType` attributes on controllers
- [X] **[PD-21]** Add *Serilog*
- [ ] **[PD-22]** Replace exceptions with *ErrorOr* where possible
- [X] **[PD-23]** Implement Azure KeyVault connection
- [ ] **[PD-24]** Implement caching (MemoryCache) and test perfrmance
- 

### [PD] Infrastructure Tracker

[Infrastructure Diagram](./Static/Diagram1.png)
