# Data Migrations
A simple  prototype showing a couple ways to do migrations using Fluent Migrations and Evolve.
## Getting Started Fluent Migrations
* ```docker-compose up```
* Start the api project using your favorite method (Visual Studio F5, VS Code)
* Celebrate 🎉🎉

## What happened?
If everything worked you should now be able to view your sql server instance running in docker at ```localhost:1402``` and there should be multiple databases and tables created. Check out the migrations folder of the Data.FluentMigrations project to check it out. 

All of this is done in-process in our application. But it can also be done in a CI/CD process using a CLI or the dotnet fm package. See the [migration runners](https://fluentmigrator.github.io/articles/migration-runners.html?tabs=vs-pkg-manager-console) for more info. 