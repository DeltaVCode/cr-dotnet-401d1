# LAB - Props and State

Put your knowledge of state, component hierarchy, and `fetch()` together to create an API testing application, similar to Postman, called "RESTy"

## Before you begin

Refer to *Getting Started*  in the [lab submission instructions](../../../reference/submission-instructions/labs/README.md) for complete setup, configuration, deployment, and submission instructions.

## Getting Started

Open [Code Sandbox](http://codesandbox.io) and Create a new application titled with your course code and this lab number (i.e. js-401n15-class-10)

You will be submitting the URL to this working sandbox as part of your assignment.

## Requirements

Using the tools that we've demonstrated in the core demo, start to build out the RESTy app, which is a simple clone of Postman.

- User enters an API URL
- Chooses a REST Method
- Clicks the  "Go" button
- Application fetches data from the URL given, with the method specified
- Displays the response headers and results separately
- Both headers and results should be "pretty printed" JSON

> One possible design/layout. Please use your judgement and taste in styling your version of this application.

<img src="resty.png" width="600" >

### Implementation Details

- `index.js` - Entry Point
- `app.js` - Container
  - Holds state: Count and Results Array
  - A class method that can update state
  - Renders 2 Child Components
- `<Form />`
  - Expects a function to be sent to it as a prop
  - Renders a URL entry form
  - A selection of REST methods to choose from ("get" should be the default)
  - On submit
    - Send the API results back to the `<App>` using the method sent down in props
- `<Results />`
  - Expects the count, headers, results to be sent in as props
  - Renders the count
  - Renders the Result Headers as "pretty" JSON
  - Renders the Result Body as "pretty" JSON

## Tests

Write mount/enzyme tests for end to end testing

## Stretch Goal

- Add a "loading" indicator or icon in the Headers/Results area when the user submits the form
- Replace it with the results when they come in

## Assignment Submission Instructions

Refer to the the [Submitting React Apps Lab Submission Instructions](../../../reference/submission-instructions/labs/react-apps.md) for the complete lab submission process and expectations
