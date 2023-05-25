# User Management Technical Exercise

The exercise is an ASP.NET Core web application backed by Entity Framework Core, which faciliates management of some fictional users.
We recommend that you use [Visual Studio (Community Edition)](https://visualstudio.microsoft.com/downloads) or [Visual Studio Code](https://code.visualstudio.com/Download) to run and modify the application.

**The application uses an in-memory database, so changes will not be persisted between executions.**

## The Exercise
Complete as many of the tasks below as you can. These are split into 3 levels of difficulty
* **Standard** - Functionality that is common when working as a web developer
* **Advanced** - Slightly more technical tasks and problem solving
* **Expert** - Tasks with a higher level of problem solving and architecture needed

### 1. Filters Section (Standard) - (feature/filters-selection)

The users page contains 3 buttons below the user listing - **Show All**, **Active Only** and **Non Active**. Show All has already been implemented. Implement the remaining buttons using the following logic:
* Active Only – This should show only users where their `IsActive` property is set to `true`
* Non Active – This should show only users where their `IsActive` property is set to `false`

### 2. User Model Properties (Standard) - (feature/user-model-properties)

Add a new property to the `User` class in the system called `DateOfBirth` which is to be used and displayed in relevant sections of the app.

### 3. Actions Section (Standard) - (feature/adding-actions)

Create the code and UI flows for the following actions
* **Add** – A screen that allows you to create a new user and return to the list
* **View** - A screen that displays the information about a user
* **Edit** – A screen that allows you to edit a selected user from the list
* **Delete** – A screen that allows you to delete a selected user from the list

Each of these screens should contain appropriate data validation, which is communicated to the end user.

### 4. Data Logging (Advanced)

Extend the system to capture log information regarding primary actions performed on each user in the app.
* In the **View** screen there should be a list of all actions that have been performed against that user.
* There should be a new **Logs** page, containing a list of log entries across the application.
* In the Logs page, the user should be able to click into each entry to see more detail about it.
* In the Logs page, think about how you can provide a good user experience - even when there are many log entries.

### 5. Extend the Application (Expert)

Make a significant architectural change that improves the application.
Structurally, the user management application is very simple, and there are many ways it can be made more maintainable, scalable or testable.
Some ideas are:
* Re-implement the UI using a client side framework connecting to an API. Use of Blazor is preferred, but if you are more familiar with other frameworks, feel free to use them.
* Update the data access layer to support asynchronous operations.
* Implement authentication and login based on the users being stored.
* Implement bundling of static assets.
* Update the data access layer to use a real database, and implement database schema migrations. (feature/adding-real-database)

## Additional Notes

* Please feel free to change or refactor any code that has been supplied within the solution and think about clean maintainable code and architecture when extending the project.
* If any additional packages, tools or setup are required to run your completed version, please document these thoroughly.

## Instructions for running the application

I Have used VSCode as my IDE for this task and git bash as my terminal.

*You will need a few tools to run the application using the real database:

1. Docker - https://www.docker.com/get-started/
2. EF command line tools - https://learn.microsoft.com/en-us/ef/core/cli/dotnet
3. DBA Tool if wishing to visually see records (optional) - I used DBeaver: https://dbeaver.io/

*Once you have got all the tools installed, the first step is to get the database container running.
You can see the details of how the instance is set up in the docker-compose.yml file.

1. From the root directory of the repo run: **docker-compose up -d**
 -this will start the container
2. Next you need to wait approx 30 seconds for the container to settle. You can check to see
when it's ready to start accepting connections through Docker Desktop it will have a log of:
[1] LOG:  database system is ready to accept connections
3. Once it's started the postgres instance, we're ready for migrations

*The next step involves using the ef core cli tools to apply the ef migrations to our postgres instance

1. Navigate to the UserManagement.Data directory **pushd UserManagement.Data**
2. Run the command **dotnet ef database update --context PostgresDataContext**
3. (note if you get an error about password authentication you may have postgres installed locally. If you stop that service from task manager and then run this command again it should work)
4. (note if you get: Exception while reading from stream then the container has not booted up yet so wait a few more seconds before trying again)
5. If all goes well, the database should now be seeded

*I've added some extra configuration to appsettings.json to allow toggling between the in-memory
and the postgres context so we can now switch this over.

1. In appsettings.json of UserManagement.Web set the **UseInMemory** setting to **false**
2. hit f5 to start debugging in VSCode / **dotnet run** from the UserManagement.Web directory
3. if you have any issues you may need to update the global.json file to your specific version of .NET 7

*If all is well, the application should now be running against the real database.
If for any reason you want to clear out the database and start again, you can do the following:

1. stop the application
2. run: **docker-compose down** this should kill the container
4. delete the **data** directory in the root of the project to clear out the database
5. run **docker-compose up -d**
6. run **dotnet ef database update --context PostgresDataContext** from UserManagement.Data to re-seed with the initial data

*(optional) If you want to inspect the data in a DBA tool, the connection string is:
"Host=localhost;Database=users;Username=postgres;Password=postgres;Port=5432"

---------------------------------------------------------------------------------------------------

**Thank you again for this opportunity. I really enjoyed this task and there's**
**loads more I would have liked to have done with it to improve the solution.**
**I hope to discuss it more with you in an interview.**

**Cheers - Sam**
