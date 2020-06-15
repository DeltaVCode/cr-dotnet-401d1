# LAB - Hooks API

Using the React "Hooks" API, refactor a functioning application, upgrading the implementation from a class-based component state driven system in a more modern functional hooks-based state system.

## Before you begin

Refer to *Getting Started*  in the [lab submission instructions](../../../reference/submission-instructions/labs/README.md) for complete setup, configuration, deployment, and submission instructions.

## Getting Started

Open [Code Sandbox](http://codesandbox.io) and Create a new application titled with your course code and this lab number (i.e. js-401n15-class-10)

You will be submitting the URL to this working sandbox as part of your assignment.

## Assignment: To Do Application

Write a React application that will be able to manage your personal To Do List

### Requirements

- Design your application with a header, main section, and a footer
- The overall styling is up to you
- The header should present the application title
- The main section must have:
  - A Form where the user can a new item to the todo list
    - Items should have the following fields:
      - To Do Item Text
      - Assigned To
      - Status (complete/incomplete)
      - Difficulty (number between 1 and 5)
  - The list of items in the to do list
    - Each item in list should show the text of the item as well as the assignee
    - When clicked, toggle the "complete" status of the item.
    - Items should be styled differently when complete/incomplete making their status visually obvious

### Implementation Notes/Details

- Create separate components for each visual part of the application
  - Header
  - Footer
  - To Do List
- Each function must be a function component (no classes!)
- Use a `useEffect()` hook to change the title of the browser with the complete/incomplete counts
- Optional
  - Separate the Form and List display elements into separate components within a wrapper component
  - Use the wrapper to hold the state and methods

### Stretch Goals

- Implement persistence with the live API to save data to the server
- Start the application with the initial list of items pulled from the server
  - Use the `useEffect()` hook to call the API on the initial render to get data from the API
- Update the list state with these items from the server
- When you add a note, in addition to displaying it on screen, POST it to the API
- When you change the status of a note, in addition to displaying it on screen, PUT that change to the API

### Testing

- Tests should assert all behavioral functionality

### Assignment Submission Instructions

Refer to the the [Submitting React Apps Lab Submission Instructions](../../../reference/submission-instructions/labs/react-apps.md) for the complete lab submission process and expectations
