# LAB - Context API

Create a React application that wraps the entire `<App/>` with a context provider, created using Context API. Then, create multiple components that act as consumers to your context, using it in various ways.

## Before you begin

Refer to *Getting Started*  in the [lab submission instructions](../../../reference/submission-instructions/labs/README.md) for complete setup, configuration, deployment, and submission instructions.

## Getting Started

Open [Code Sandbox](http://codesandbox.io) and Create a new application titled with your course code and this lab number (i.e. js-401n15-class-10)

You will be submitting the URL to this working sandbox as part of your assignment.

## Assignment: To Do Application

Write a React application that will be able to manage your personal To Do List

For this assignment, we'll be using the Context API to add a few "settings" to the To Do application to make it work differently based on configuration.

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
    - Items should have a delete button associated with them
      - When clicked, remove the item from the list
  - Based on configuration
    - Show a maximum of a certain number of items per screen
    - Hide completed items from the list **OR** display them (with a style that indicates their status)

### Implementation Notes/Details

> Your application should be connected to a remote API

- Create a `context` for managing application settings
  - Display or Hide completed items (boolean)
  - Number of items to display per screen (number)
  - You may manually set (hard code) those state settings in the context provider

Pagination

- Only display the first `n` items in the list, where `n` is the number to display per screen in your context.
  - If you have more than `n` items in the list, add a button labeled `Next` that will replace the list with the next `n` items in the list.
  - If you are past the first `n` items (i.e. on page 2 or higher), add a button labeled `Previous` that will replace the list with the previous `n` items in the list.
- Filter the completed items out of the list (or not) based on the appropriate setting in context.

### Testing

- Do a deep mount of the app, and set tests to make assertions on the child components that consume context from the Provider.
  - Can they see context?
  - Can they interact via published functions?

### Stretch Goal

- Provide a "Settings" page for your users (Use Routing!)
- Allow the user to change the number change the context settings
  - Your context will need to expose methods in state...
- Save their settings in local storage

### Assignment Submission Instructions

Refer to the the [Submitting React Apps Lab Submission Instructions](../../../reference/submission-instructions/labs/react-apps.md) for the complete lab submission process and expectations
