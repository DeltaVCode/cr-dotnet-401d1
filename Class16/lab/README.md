# Lab 16 : Dependency Injection & Repository Pattern

## The Problem Domain

Continue working on your hotel management application.  As a developer, you would like to follow modern design principles by implementing the repository and singleton design patterns, and by using dependency injection.


## Application Specifications

Building off of your current project for the `AsyncInn`:
1. Implement the repository architectural design pattern using dependency injection into your current code base.
1. Create three interfaces to contract minimum CRUD operations that are required for functionality and maintenance of Hotels, Rooms, and Amenities. 
1. Build out a service for each of the interfaces and implement them appropriately.
1. Within each service, don't forget to inject the your `DbContext` into your services, so that you have access to the database.
1. Register each of the services with the appropriate Dependency Injection Lifetime in the `Startup.cs` class.
1. Refactor all of your scaffolded controllers to utilize the newly created services. Remove the need for the database in the controllers, inject the services as needed, and keep the controllers "loosely coupled" by offloading the CRUD functionality to the services you previously defined. (Do not have your `DBContext` injected into your controllers, make it the appropriate interface(s) instead!)

1. Within your HotelRoom Interface, be sure include CRUD operations, as well as `GetByRoomNumber(int hotelID, int roomNumber)`
1. Your RoomAmenities controller will only be able to add and delete associations. No need to allow for updating or retrieving. The room controller will "Retrieve" for you.
1. Test and make sure that each of these actions still work in Postman when complete. 

## Tests

We will cover testing in Class 18. 

I **strongly** encourage you to research how to write tests for a .NET Core MVC application. Attempt to write some tests, as they will eventually be required.  Research, start here: [Testing a Controller](https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/testing){:target="_blank"}. 


## Stretch Goals

There are no Stretch Goals for this assignment.


## README

Create a well structured README that outlines and introduces the web app. Include in your README your database ERD.

Your job is to:

1. Tell them what it is (with context)
1. Show them what it looks like in action
1. Show them how they use it
1. Tell them any other relevant details
<br />

This is ***your*** job. It's up to the module creator to prove that their work is a shining gem in the sea of slipshod modules. Since so many developers' eyes will find their way to your README before anything else, quality here is your public-facing measure of your work.
 <br />
 Refer to the sample-README in the class repo for an example. 

- [Reference](https://github.com/noffle/art-of-readme){:target="_blank"}

## Rubric

The lab rubric can be found [Here](../../Resources/rubric){:target="_blank"} 

## To Submit this Assignment

- Create a new branch named `NAME-DependencyInjection` in your `AsyncInn` repository
- Write your code
- Commit often
- Push to your repository
- Create a pull request from your branch back your `master` branch.
- Submit a link to your PR in Canvas
- Merge your PR back into master
- In Canvas, Include the actual time it took you to complete the assignment as a comment (**REQUIRED**)
- Include a `README.md` (contents described above)


