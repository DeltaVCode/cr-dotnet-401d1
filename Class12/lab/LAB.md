# Lab 12: Databases and ERDs

## Problem Domain

Today will the be the beginning of a multi-lab project where you will build out the API server for a Hotel Asset Management system.

The owners of "Async Inn" have approached you with plans to renovate their hotel chain. Currently they are tracking all the different locations and rooms in spreadsheets and binders. They currently have about 10 binders full of paperwork that consists of the difference between each location and the pricing for each room. The amount of time and paperwork it takes to manage the rooms and locations is costing the company both time and money. They are currently looking for a  "better way" to maintain their business model. 

They are currently looking for a RESTful API server that will allow them to better manage the assets in their hotels. They are anticipating the ability to modify and manage rooms, amenities, and new hotel locations as they are built. They have turned to you to assist them in persisting their data across a relational database and maintain its integrity as they make changes to the system. 

After your meeting with the team, you have extracted some basic requirements about the data and how it should be represented in a database. You are going to attempt a first draft at a database diagram to share with the team later on today. 

To the best of your ability, create a system design of a database ERD diagram that meets all of the requirements below. The diagram should take all of the requirements into consideration and allow a baseline for starting the creation of the web application. 

## Application Specifications

- You have been tasked with creating a web based API for a local hotel chain. Here are the requirements that you obtained from your client during your exploration and requirements meeting.

	- The hotel is named "Async Inn" and has many nationwide locations. Each location will have a name, city, state, address, and phone number.
	- Async Inn prides themselves on their unique layout designs of each hotel room. They advertise as it being your "apartment for the night". This means they have invested a lot of resources into how each room looks and feels. Some have one bedroom, others have 2 bedrooms, while a few are more of a cozy studio. The team mentioned that they like to label each room with a nickname to better tell the difference between each of the layouts and amenities each room has to offer. (for example, the Seattle location has two 2-bedroom suites, but one is named "Seahawks Snooze" while the other is named "Restful Rainier", each with their own amenities.) 
	- They also take pride in the amenities that each room has to offer. This can consist of features like "air conditioning", "coffee maker", "ocean view", "mini bar", the list goes on...They requested that they would like the amenities associated with each of the rooms as they do vary. 
	- The rooms vary in price, per location, as well as per room number. They also have a few rooms that they want to advertise as pet friendly.
	- The number of rooms for each hotel varies. Some hotels have only a few rooms, while others may have dozens.

## Guidance

There are 2 parts to this assignment

### Part 1

Build your ERD (Entity Relationship Diagram) so that it has at least:
1. (1) Joint Entity Table with Payload
1. (1) Pure Join Table
1. (1) Enum 

Within your ERD identify/label the following as necessary:
1. Primary Keys
1. Foreign Keys 
1. Composite Keys (where they exist)
1. Navigation Properties (What other entities are related? Why?)
1. Relationships between tables (1:1, 1:Many, Many:1, Many:Many etc...)

In a external document, please provide an explanation of the components in your database ERD diagram. 

The ERD Design is **attempt based**. Submit, before the next class start, a healthy attempt on the database design must be completed with all of the required details described.

You may work together and collaborate on this ERD, but everyone is responsible for turning in their own DB diagram and explanation. 2-3 sentences for each table is sufficient for an explanation. 

Your ERD diagram must be digital. You may take a picture of your diagram from a white board, but if you decide to stick with your db diagram, and not use the solution provided for your web application, you will be required to transfer your white board image into a cleaner format. 

### Part 2

Create a brand new "empty" web application project in Visual Studio. 

1. Set up the routing for an MVC project 
1. Make a "Data" folder
1. Create a DBContext for your database in your "Data" folder
   - No models required
   - Don't forget the constructor!
1. Set your connection string into your "appsettings.json" file
1. Register your DBContext in your startup file
1. Setup your application to accept Dependency Injection (hint: Don't forget to add the "IConfiguration" to your constructor)
1. If your UseSqlServer library is not registering as a library, install the `Microsoft.EntityFrameworkCore.SqlServer` package on your project.
1. Add a migration `add-migration nameOfMigration`
1. Create the database through an `update-database` command

** Don't forget summary comments where appropriate. 

## Stretch Goals

1. No stretch goals for this lab

## Additional Resources

Refer to the class GH repo for the reference sheet on how to create an MVC site

## ReadMe

Create a basic README with:
1. The name of your project
2. Your Name
3. Today's date
4. Place an image of your ERD with explanation of each of the tables
   - Don't worry, we will fix this later :) 

## Rubric

### Part 1

5 points: ERD created, explanation provided for each table. 

3 points: Only ERD is present. No explanation for tables

1 point: Only explanation of tables, no ERD diagram present

0 points: No Submission. 

No late submissions will be accepted for Part 1. Submit your diagram before the posted due date.

### Part 2

5 points: Part 2 completed in it's entirety. Tests not required.

3 points: Part 2 mostly completed

1 point: Part 2 partially completed

0 points: No Submission


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
