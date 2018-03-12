# CoraCorpCM

Popular collections management systems that museums use to manage their collections can be prohibitively expensive for smaller, non-profit organizations. I'm making this application to be a free and open-source alternative to such applications. As a bonus, I'm using this project as an opportunity to learn about ASP.NET Core MVC, Entity Framework Core, Angular, and other technologies.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

- [Visual Studio](https://www.visualstudio.com/downloads/), which should come with:
    - [.NET Core 2 SDK](https://www.microsoft.com/net/download/windows)
    - [NPM](https://www.npmjs.com/)
- Your own [SendGrid](https://sendgrid.com/) account

### Setup

To get a development environment running:


1. Install dependencies. 

NuGet dependencies should restore automatically when you open the project with Visual Studio. To restore them manually, execute the following using a command prompt from the project directories:

```
dotnet restore
```

Client-side packages can be installed by executing the following using a command prompt from the web project directory:

```
npm install
```

Alternatively, you can right-click on the npm folder under Dependencies within the web project in Visual Studio and select 'Restore Packages'.


2. Create the database.

The default (and currently only) connection string points to a localdb databse which needs to be instantiated on your machine. This can be accomplished via entity framework's cli tool from the data project directory:

```
dotnet ef database update
```

Alternatively, you can use the Package Manager Console in Visual Studio to execute the powershell cmd-let:

```
Update-Database
```


3. Load scripts into wwwroot.

I have excluded certain scripts from the repository as they are dynamically loaded into wwwroot/lib and wwwroot/dist using a task runner, so you'll need to load these scripts into those directories before running the application from a browser. This can be accomplished with gulp by executing the following using a command prompt from the web project directory:

```
gulp
```


4. Configure SendGrid.

The project uses SendGrid to send emails. You will need to use your own API key stored in user-secrets by executing the following using a command prompt from the web project directory:

```
dotnet user-secrets set SendGridUser <your username>
dotnet user-secrets set SendGridKey <your key>
```

### Running

When you run the application, a DbInitilizer class will load the database with enough data to allow you to "play" with the application as a registered user. Look to CoraCorpCM.Data\DbInitializer.cs for user login credentials with varying levels of access.
