# LAB - Custom Hooks

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
    - Items should have a delete button associated with them
      - When clicked, remove the item from the list

### Implementation Notes/Details

- The application must be connected to a running API server
  - On load, display all of the to do items from the database, including styling for their status
  - When adding an item, issue a "POST" request to the API server
  - When marking items complete, issue a "PUT" request to the API server for the item
  - When deleting items, issue a "DELETE" request to the API server for the item
- Create separate components for each visual part of the application
  - Header
  - Footer
  - To Do List
- Each function must be a function component (no classes!)
- Use the `useForm()` hook to manage the "Add Item" form
- Create a new custom hook called `useFetch()` to abstract the API calls
  - This hook should accept the URL to the API server, the REST method, and (when relevant) the BODY (JSON) of the request
  - Additionally, your hook will likely have to handle CORS, Content-Type and possibly authentication
- Optional
  - Separate the Form and List display elements into separate components within a wrapper component
  - Use the wrapper to hold the state and methods

### Resources

- You will need a deployed API server to store your data
  - Augment your API server from earlier in the course by adding the 'todo' collection

If you are having issues or troubles getting these servers deployed on your own, you may connect to a shared API. We highly recommend using your own, however.

- [API Server](https://api-js401.herokuapp.com/api/v1)

## Assignment Submission Instructions

Refer to the the [Submitting React Apps Lab Submission Instructions](../../../reference/submission-instructions/labs/react-apps.md) for the complete lab submission process and expectations
