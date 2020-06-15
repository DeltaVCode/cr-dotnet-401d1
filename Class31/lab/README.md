# LAB - Component Based UI

Create and style a counter application using React components.

## Before you begin

Refer to *Getting Started*  in the [lab submission instructions](../../../reference/submission-instructions/labs/README.md) for complete setup, configuration, deployment, and submission instructions.

## Getting Started

Open [Code Sandbox](http://codesandbox.io) and Create a new application titled with your course code and this lab number (i.e. js-401n15-class-10)

You will be submitting the URL to this working sandbox as part of your assignment.

## Requirements

Write a **counter** application with the following features

- A Header with the style and text of your choosing
- A Footer with the style and text of your choosing
- A Count Display that starts at 0 and updates as the count changes
- An Increment Button that increases the count by 1
- An Decrement Button that decreases the count by 1

### Implementation Details

- Write an `App` component that serves as the container for all sub-components of this application
- The `Header`, `Footer`, and `Counter` components should be managed in separate files/modules
  - Properly `export` them as defaults
  - Import them into the `App` Component using ES6 `import` statement
- In the `Counter` component, manage state (current count) appropriately
  - Start the value at 0
  - Increase/Decrease the count by handling clicks on each of the buttons in the component
  - Ensure that the display of the current count happens dynamically with the state changes

### Design Implementation

- Create a file called `app.scss` and `import` that into the `App` component
- Add some creative styling for the header, making use of SASS nesting
- Alter the `app.scss` as follows:
  - Alter your css rules to use a variable (i.e. $backgroundColor)
  - "Pin" the header and footer to the top/bottom with the main/counter section taking up all remaining space.
  - Get creative about styling the basic layout of the counter itself
    - Might things change visually when the counter is `> 0` or `< 0`?
    - Where would the buttons look best?
    - Can you make the number "pop"

### Stretch Goals

- Keep track of the "polarity" of the `count` and change your style accordingly
  - Be creative about how the display might change when the count is `> 0` or `< 0`?
- Add a form with an input field.
  - When a valid number is entered into the field, set the counter to the entered number and start the counting from there

### Assignment Submission Instructions

Refer to the the [Submitting React Apps Lab Submission Instructions](../../../reference/submission-instructions/labs/react-apps.md) for the complete lab submission process and expectations

> NOTE: For this assignment, **testing is not required**
