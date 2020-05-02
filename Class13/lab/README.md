# Lab 13: Async Inn Management System

## The Problem Domain

Now that you have a solid understanding of your database schema for your hotel management system, today you will build off of your initial web application from lab 12 and integrate into it our database tables from our ERD. 

## Application Specifications

Your application should include the following upon completion:

1. Startup File
	- Explicit routing of MVC 
	- MVC dependency in ConfigureServices
	- DBContext registered in ConfigureServices
1. Data
	- DBContext present and properly configured
	- DB Tables for each entity model (`DbSet<T>`)
	- Composite key association present in `OnModelCreating` override.
	- `appsettings.json` file present with name of database updated
    - Default data seeded
    
1. Models
	- Each Entity from the DB Table converted into a Model
	- Proper naming conventions of Primary keys
	- Navigation properties present in each Model where required
	- Enum present in appropriate model


## Guidance


Using your ERD Diagram, convert each entity into a model within your newly created MVC web application.

Within your DbContext, declare your Database tables and set your composite keys for the required tables

1. Add default data to your database by seeding your database. Be sure have at least:
    - 5 default Hotel Locations
   	- 6 Room Types
   	- 5 Amenities. 
1. Don't forget to add a new migration and update your database when completed!

## Steps:

1. For each Entity that you have in your ERD, create a new class in your Models folder. 
2. Inside your DbContext, create a new table/`DbSet<T>` for each of your created entity classes
3. Add your composite key associations to your overridden `OnModelCreating` method.
4. Run the command `add-migration {nameOfMigration}`
5. Run the command `Update-database` and confirm your database now has the appropriate tables.
6. Add Summary comments to your code where necessary.
 
 
##### README

Your README should be in introduction to your web app. Provide in your README, your ERD Diagram and an overview of the relationships and how each entity is related to another. 

## Tests

- No tests required for today. We will start testing in lab 16. 

## Stretch Goals

- There are no Stretch Goals for this assignment.

## Additional Resources

- Setup default MVC [simple steps](https://codefellows.github.io/code-401-dotnet-guide/Resources/MVCSetup){:target="_blank"}


## README

Update your ERD image in your README

## Rubric

The lab rubric can be found [Here](../../Resources/rubric){:target="_blank"} 


## To Submit this Assignment

- Create a new repository on your personal GitHub account
- Name your repo `Async-Inn`
- Create a branch named `NAME-LAB##`
- Write your code
- Commit often
- Push to your repository
- Create a pull request from your branch back your `master` branch.
- Submit a link to your PR in Canvas
- Merge your PR back into master
- In Canvas, Include the actual time it took you to complete the assignment as a comment (**REQUIRED**)
- Include a `README.md` (contents described above)



