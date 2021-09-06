# FGB Insite Team Task

One of our clients requested us to build a small GUI that displays a list of members (season pass holders) and one-time game tickets that accessed the stadium given a season and a game, or a product code.

## Project details

Inside the `API` folder we have started a .NET Core solution which will be used to retrieve and return the data. For the purposes of this task, you can treat the `InsiteTeamTask.Data` project as an external package - we don't expect anything inside here to be edited. For the rest of the project you are free to structure however you see fit, as long as the exercise requirements are met.

The data is centered around `Product` objects (found in `InsiteTeamTask.Data.Models.Product.cs`). `Product` objects represent a product that a club can sell to fans and come in two categories:
- `ProductType.Ticket` - a ticket to a single game
- `ProductType.Member` - a ticket to all games in a season

This means that when analysing attendance for a game you will have to take into account tickets for the specific game, and season tickets for the given season.

## Exercise 1

The team has started on a .NET Core project (`InsiteTeamTask.API`) to get and return the data, but it has not been built correctly. In its current state, the action in `Controllers/AttendanceController` calls a method which is not implemented, on a service that is not currently injected or instantiated in the controller.

The task will require you to refactor the app. The initial implementation requirements are:

- Make sure all dependencies are resolved so that calling the endpoint doesn't throw any null reference exceptions
- Implement the `GetAttendance()` method
- Provide a way to get the attendance list both by:
  - A combination of Season ID and Game ID
  - Product Code

## Exercise 2

The team has also created a simple angular application inside the `UI` folder in order to display the API data, but is yet to implement anything.

This task comes in three parts:
- Create a service or set of services which retrieve data from the API
- Create a simple GUI to display a collection of attendance records
- Create an interface to allow the user to filter attendance by either:
  - A combination of season and game
  - A product code

Our preferred component package is [Angular Material](https://material.angular.io/), but you are welcome to use whatever components and styling you like.

## Additional considerations
If you'd like to show off your skills, there are a number of things the application could use to make it more complete:

- Front-end styling and usability - make sure the app is easy and intuitive to use, but also looks good.
- API Unit testing - there is currently a project (`InsiteTeamTask.Tests`) which contains a single test class.
- API security - currently anyone can access the API. This vulnerability needs to be addressed.

## Assessment
What we are looking for is code quality. That translates to project structure, clean coding practices, commenting, application of SOLID principles, and testing. We leave the details to you :)

## Submission
Create a fork of this repository. Branch off the master branch, and when you are done, create a pull request to merge the new branch in your fork into the master branch to submit your exercise. The branch should be named after your name.

## Potential issues
The C# API solution has target frameworks of .NET Core 2.1, meaning that machines without the 2.1 SDK will likely have issues starting the project. To fix this, you can either [download the .NET Core 2.1 SDK from Microsoft](https://dotnet.microsoft.com/download/dotnet/2.1), or change the `TargetFramework` property in each of the project `.csproj` files to whichever version of .NET Core your machine is working on.

Similarly, the Angular project is using Angular 8. Angular is a bit more forgiving, but any issues can usually be fixed by upgrading the project.
