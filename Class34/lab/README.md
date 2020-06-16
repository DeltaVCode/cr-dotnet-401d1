# LAB - Routing and Component Composition

**RESTy Phase 4:** Add routing and conditional rendering to RESTy

## Before you begin

Refer to *Getting Started*  in the [lab submission instructions](../../../reference/submission-instructions/labs/README.md) for complete setup, configuration, deployment, and submission instructions.

> Continue working in your 'resty' repository, in a branch called 'composition'

## Business Requirements

Refer to the [RESTy System Overview](../../apps-and-libraries/resty/README.md) for a complete review of the application, including Business and Technical requirements along with the development roadmap.

## Phase 4 Requirements

In this final phase of the RESTy build, we will be adding some more fidelity to the application, including a menu, history, and an "in-progress" spinner.

The following user stories detail the major functionality for this phase of the project.

- As a user, I want to be able to use all REST methods so that I can do more than just **get** data
- As a user, I want a simple list of all previous queries I've run so that I can easily see which queries I've run before
- As a user, I want to click on an old query and have my selections appear in the form for me, so I don't have to re-type them
- As a user, I want to see all of my previous queries as a separate page so that I can browse them in greater detail
- As a user, I want to see a "loading" indicator while RESTy is fetching data so that I know it's working on my request

## Technical Requirements / Note

Update the RESTy application as follows:

- Add support for **PUT**, **POST**, and **DELETE** in your remote calls
- Add a menu bar to the header
  - Link labeled "Home" that links to '/' and shows the search form/results page
  - Link labeled "History" that links to '/history' and loads the history page
- Whenever a query is successful (results come back), store the query parameters in local storage
  - Store the URL, Method, and the Body (if any)
  - Store only unique, successful queries

Home Page

- Add a simple history list to the left side of the application
  - List all previous queries, showing the method and the URL
  - When a user clicks a previous query, populate the RESTy forms with the query information
- Completely hide the output area (Headers & Results) when there are none to display
- Display any fetch/load errors in place of the results area, if they occur
- Add a "Loading" indicator while fetching
  - When the user clicks the "Go!" button, show a loading icon on the page
  - When the fetching of results is complete, remove the loading icon and show the results

History Page

- Maintain a list of every unique and successful API call the user has made
- On the History page, show a list of ever previous API call
  - Clicking on an entry shows the full details of that query
    - URL, Method, Body
    - Optionally, you can store other metadata about the query (time ran, bytes returned, etc) to show your users
  - Show a button labeled "Re-Run" that would execute that API call again and shows the home page with the form pre-filled

### Application Architecture Notes

- Import `BrowserRouter` into your index, and wrap the `<App />` with it
- In the `<App />`, use routes to display the correct components, based on the route
- Alter the `<Results />` component as follows:
  - Add support for all REST methods
  - Use a conditional component such as `<If>` to hide/show the results pane when there are none
  - Use a conditional component such as `<If>` to hide/show a loading image during the fetch process
- Create `<Header />` that has the nav bar, and uses `<NavLink />` components to route the user the Home or History pages
- Create a new `<History/>` inline component that will:
  - Show a simple history list on the main page
  - Allow a user to click and re-run any previous query
- Create a new `<History/>` page component that will:
  - Show a list of URLs you've loaded before
  - Show full details of each search
  - Add a button to each to re-run the search
  - Redirect to the home page to show the results

### Testing

- Complete basic render testing on the application
- Test state changes
- Modal visibility on state change
  - Is it rendered?
  - Is the correct to do item in it?

## Stretch Goal

Add support for **basic** and **bearer** authorization headers

### Assignment Submission Instructions

Refer to the the [Submitting React Apps Lab Submission Instructions](../../../reference/submission-instructions/labs/react-apps.md) for the complete lab submission process and expectations
