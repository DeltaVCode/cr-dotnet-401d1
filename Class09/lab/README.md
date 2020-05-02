# Lab 09: LINQ in Manhattan

## The Problem Domain
Create a program that brings in data from an external file, reads the data, and can filter the data based on specified values.

## Program Specifications
Your solution should include the following:
- The data.json file to your solution root folder
- Read in the file and answer the questions below
- Each question and answer should be outputted to the console.

#### Questions
Each query builds off of the prior query. You should be chaining.

1. Output all of the neighborhoods in this data list (Final Total: 147 neighborhoods)
1. Filter out all the neighborhoods that do not have any names (Final Total: 143)
1. Remove the duplicates (Final Total: 39 neighborhoods)
1. Rewrite the queries from above and consolidate all into one single query.
1. Rewrite at least one of these questions only using the opposing method (example: Use LINQ Query statements instead of LINQ method calls and vice versa.)

You should have a total of 5 outputs. 

## Guidance
Provided is a JSON file that contains a data set of location information for properties in Manhattan.
- Use LINQ queries and Lambda statements (when appropriate) to find the answers. 
- Use a combination of both to answer the questions. 
- Explore the NuGet packages and install NewtonSoftJson
- Do some self research and find out how to read in JSON file (hint: JsonConvert.DeserializedOject is *part* of it)
- You will need to break up each section of the JSON file up into different classes, use your resources - ask the TA's if your stuck. (Maybe find a converter of some sort??)


## Unit Tests
Test that your program has the following functionality:
- No tests are required for this lab.

## Stretch Goals
No stretch goals are required for this lab

## Additional Resources
- [NewtonSoft LINQ to JSON](https://www.newtonsoft.com/json/help/html/LINQtoJSON.htm){:target="_blank"}
- [Serializing JSON](https://www.newtonsoft.com/json/help/html/SerializingJSON.htm){:target="_blank"}


## README
**A Readme is a requirement. No Readme == No Grade.** <br />
Here are the requirements for a valid readme: <br />

A README is a module consumer's first -- and maybe only -- look into your creation. The consumer wants a module to fulfill their need, so you must explain exactly what need your module fills, and how effectively it does so.
<br />
Your job is to

1. Tell them what it is (with context, provide a summary)
1. Show them what it looks like in action (Visuals)
1. Show them how they use it (Step by step directions, "Happy Path" walk through)
1. Tell them any other relevant details
<br />

This is ***your*** job. It's up to the module creator to prove that their work is a shining gem in the sea of slipshod modules. Since so many developers' eyes will find their way to your README before anything else, quality here is your public-facing measure of your work.

<br /> Refer to the sample-README in the class repo `Resources` folder for an example. 

- [Reference](https://github.com/noffle/art-of-readme){:target="_blank"} 


## Rubric

The lab rubric can be found [Here](../Resources/rubric){:target="_blank"} 

## To Submit this Assignment
- Create a new repository on your personal GitHub account
- Name your repo `Lab##-TITLE`
- Create a branch named `NAME-LAB##`
- Write your code
- Commit often
- Push to your repository
- Create a pull request from your branch back your `master` branch.
- Submit a link to your PR in Canvas
- Merge your PR back into master
- In Canvas, Include the actual time it took you to complete the assignment as a comment (**REQUIRED**)
- Include a `README.md` (contents described below)



