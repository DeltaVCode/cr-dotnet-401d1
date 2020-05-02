# Lab 04: Tic-Tac-Toe

Read this document, in it's entirety before starting the assignment. 
 
## Problem Domain
Create a two (2) person, turn based Tic-Tac-Toe program.
Building off of your starter code provided from the class repo, complete the Tic Tac Toe logic. Refer to the "Submit this Assignment" section below on instructions with the starter code. 

## Program Specifications
Your solution should include the following:
- Completed TO-DOs
- Add summary comments above all of the methods that do not currently have summary comments. Be 
sure to explain what the main purpose of the method is, in addition to where it is being called/used. Identify the parameters and 
returns in the appropriate xml tags. 

- You've received reports from other users that there is a bug in the system! When a user selects a position on the board that is already marked, it is not prompting the user to retake their turn. It is up to *You* to find and fix this bug!

***Do not add any additional methods to the existing code base, you are only allowed to work within the methods provided***

## Guidance
- Find the `TO-DO`s in the code (Hint: Go to your "view" menu and select "Task List", This will show you all of your TO-DOs within the starter code) and add additional logic to accomplish each task. 

A Game board, to a user, looks like this:

```
|1||2||3|
|4||5||6|
|7||8||9|
```
The numbers in each of the squares will indicate the position number. Prompt the user to 
select which position they wish to 
play and then replace that position with either an `X` or an `O`.

A winning board may look like this (O Wins!):

```
|X||X||O|
|4||O||X|
|O||X||9|
```
Remember that Tic-Tac-Toe is a 2 player game, so be sure to "switch" between players.
 
Make it known to the user that their turn is over and it's time for the next players turn. You will both play on 
the same board. 

 Here is an outline for different classes that you have:
- Game Board (this should construct/display the board after every turn with it's new state)
- Player (This will hold the players information such as name or marker, in addition to any 
actions that user may take)
- Game (This would hold the actions of the game. )
- Position (the individual game board positions )

Be sure to check for a winner after each turn. Be aware that it is possible to have a tie/draw if no winner can be determined and all 
marks on the board are occupied. 

Stay within scope of this project. Please only use concepts and resources that we have covered 
so far in previous labs/lectures/assigned pre-work. 
If you are unsure if it is within scope, please ask a TA or instructor.

## Tests
Test that your program has the following functionality:
1. Given a game board, test for winners
1. Test that there is a switch in players between turns
1. Test to confirm that the position the player inputs correlates to the correct index of the array
1. One other "unique" test of your own


## Stretch Goals
No Stretch goals.

## Additional Resources
Review/research these resources to assist you in the construction of your program:

- [Two Dimensional Arrays](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/multidimensional-arrays){:target="_blank"} 
- [Jagged Arrays](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/jagged-arrays){:target="_blank"} 


## README
**A Readme is a requirement. No Readme == No Grade.** 
Here are the requirements for a valid readme:

A README is a module consumer's first -- and maybe only -- look into your creation. The consumer wants a module to fulfill their need, so you must explain exactly what need your module fills, and how effectively it does so.

Your job is to

1. tell them what it is (with context, provide a summary)
1. show them what it looks like in action (Visuals)
1. show them how they use it (Step by step directions, "Happy Path" walk through)
1. tell them any other relevant details
<br />

This is ***your*** job. It's up to the module creator to prove that their work is a shining gem in the sea of slipshod modules. Since so many developers' eyes will find their way to your README before anything else, quality here is your public-facing measure of your work.

Refer to the README templates in the class repo `Resources` folder for an example. 
- [Reference](https://github.com/noffle/art-of-readme){:target="_blank"} 


## Rubric

The lab rubric can be found [HERE](../../Resources/rubric){:target="_blank"} 


## To Submit this Assignment
- If you have not done so already, clone the class repo
- Be sure to `pull` for updated content
- Copy the starter code in class 04 to a newly created git repo (`cp -r location/of/startercode/. location/of/new/git/repo) 
(**Don't forget about the "dot" at the end of code source**)
- Do an `initial commit` of the starter code
- Create a branch named `NAME-LAB##`
- Write your code
- Commit often
- Push to your repository
- Create a pull request from your branch back your `master` branch.
- Submit a link to your PR in canvas
- Merge your PR back into master
- In Canvas, Include the actual time it took you to complete the assignment as a comment (**REQUIRED**)
- Include a `README.md` (contents described above)
