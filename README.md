# CoraCorpCM

An ASP.NET Core 2.0 MVC museum collections management application.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

- [Visual Studio](https://www.visualstudio.com/downloads/), which should come with:
    - [.NET Core 2 SDK](https://www.microsoft.com/net/download/windows)
    - [NPM](https://www.npmjs.com/)
- Your own [SendGrid](https://sendgrid.com/) account

### Setup

To get a development environment running:

1. Install dependencies. 

NuGet dependencies should restore automatically when you open the project with Visual Studio. To restore them manually, execute the following using a command prompt from the project directory:

```
dotnet restore
```

Client-side packages can be installed by executing the following using a command prompt from the project directory:

```
npm install
```

Alternatively, you can right-click on the npm folder under Dependencies within the project in Visual Studio and select 'Restore Packages'.

2. Create the database.

This can be accomplished via entity framework's cli tool from the project directory:

```
dotnet ef database update
```

Alternatively, you can use the Package Manager Console in Visual Studio to execute the powershell cmd-let:

```
Update-Database
```

3. Load scripts into wwwroot.

This can be accomplished with gulp by executing the following using a command prompt from the project directory:

```
gulp
```

4. Configure SendGrid.

The project uses SendGrid to send emails. You will need to store your own API key by executing the following using a command prompt from the project directory:

```
dotnet user-secrets set SendGridUser <your username>
dotnet user-secrets set SendGridKey <your key>
```
