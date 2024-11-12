### Tue 12 Nov 20:43

Added in-app MySQL database. The tables in the DB hadn't been created when the app was initialised, because this is 
normally handled by `ef` scripts.

So I've generated a SQL for all migration scripts `dotnet ef script -o migrationScript.sql
` and run it on the on-prem MySQL database which can be accessed through an in-built phpadmin
(e.g. [link](https://pd-api.scm.azurewebsites.net/phpMyAdmin/db_sql.php?db=localdb&server=2)).

### Tue 13 Nov 20:46

I've been playing around with implementing Azure Entra ID authentication. 

There are two methods of authenticating to a protected App:

One method will redirect you to the log in page in the browser. But if you don't have access to the browser, you can "implicitly" authenticate instead.

Needed to learn a thing or two about OAuth 2.0 as well.

The key benefits of these auth I understand to be as follows:

Authentication:

- App Service has an in-built authentication mechanism that requires no code (you configure it via Portal)
- By default, this feature only provides authentication, not authorization. Your application may still need to make authorization decisions, in addition to any checks you configure here.
- Restricting access in this way applies to all calls to your app, which may not be desirable for apps wanting a publicly available home page, as in many single-page applications.
- Eliminates the need to update auth library regularly
- You can easily switch it off and on
- Works against Azure Entra / Azure Entra External Id / Azure B2C (legacy)
