# LAB - Routing and Component Composition

Implement routing and composed components into the To Do Application.

## Before you begin

Refer to *Getting Started*  in the [lab submission instructions](../../../reference/submission-instructions/labs/README.md) for complete setup, configuration, deployment, and submission instructions.

## Getting Started

## Requirements

Update the RESTy application as follows:

- Add a menu bar to the header
  - Link labeled "Home" that links to '/' and shows the search form/results page
  - Link labeled "History" that links to '/history' and loads the history page

Home Page

- Completely hide the output (Headers & Results) when there are none to display
- Display any fetch/load errors in place of the results area, if they occur
- Add a "Loading" indicator while fetching
  - When the user clicks the "Go!" button, show a loading icon on the page
  - When the fetching of results is complete, remove the loading icon and show the results

History Page

- Maintain a list of every API call the user has made
- On the History page, show a list of ever previous API call
  - Clicking on an entry shows more details
  - Show a button labeled "Re-Run" that would execute that API call again and shows the home page

## Implementation Notes/Details

- Import `BrowserRouter` into your index, and wrap the `<App />` with it
- In the `<App />`, use routes to display the correct components, based on the route
- Alter the `<Results />` component to use a conditional component such as `<If>` to hide/show the results pane when there are none, and to show/hide the loading image during the fetch process
- Create `<Header />` that has the nav bar, and uses `<NavLink />` components to route the user the Home or History pages
- Create a new `<History/>` component that will:
  - Show a list of URLs you've loaded before
  - Add a button to each to re-run the search
  - Redirect to the home page to show the results

### Testing

- Complete basic render testing on the application
- Test state changes
- Modal visibility on state change
  - Is it rendered?
  - Is the correct to do item in it?

### Stretch Goals

- Create an `npm` account and an organization
- Write tests for an publish your `<If />` component set to `npm`
- Now, you can `npm install` and `import` them in any project.

### Assignment Submission Instructions

Refer to the the [Submitting React Apps Lab Submission Instructions](../../../reference/submission-instructions/labs/react-apps.md) for the complete lab submission process and expectations
