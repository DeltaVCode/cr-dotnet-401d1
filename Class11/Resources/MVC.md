# MVC

### Three Take-a-ways


1. MVC is an architectural pattern used in web applications. 
1. MVC is extremely helpful when it comes to separation of concerns. 
1. This allows us to make changes to the front-end (view) without 
affecting the business logic or the routes. 

### Model
The model holds the business logic. This is where
we will create new classes and "models" for any objects
we wish to use within our web application

### View
This is our front-end. HTML and CSS is displayed on 
the views. In addition, on the View, we reference the "Model"
that was sent to the view from the controller. 

A really cool feature in Views is that we can display the information
from the model on the .cshtml page by using very basic C# syntax.
This "Razor Syntax" allows us to use foreach loops and if statements
to manipulate how to display the information sent from the controller. 


### Controller
The controller is the routing part of MVC. A controller contains
Actions, that maps to specific views. Each unique action is it's own 
view page. 

## Demo

### Empty Site

### Program Class
The program class should look familiar with what you have seen in the older Console application. 
If you take a look in this class, you will see the familiar `Main()` method. Indirectly, this main method is calling the 
startup class to get the program running with all the proper middleware and requirements. 
You will make very little changes to the Program.cs class. 

### Startup Class
The startup class is where you will be putting in a majority of your changes and configuration in code. The startup class consists 
of where we register any required middleware of dependencies that required for our application to run the way we expect.
In addition to changes or settings to the HTTP pipeline. 

Get comfortable with the startup class, because you will be spending a lot of time in here. 

#### Middleware

Start the demo out by adding `.AddMVC`to the Configure() method. This will add the MVC dependencies to the application. 
Talk about how the alternative to this is to go into NuGet directly and find MVC and install the dependency from there. 

#### HTTP Pipeline
Within the http Pipeline we also have to tell the pipeline to expect the MVC model. what this means is we 
want to make sure that it knows it's looking for a "controller" (versus looking for a /page for Razor Pages). We do this by
addin the `.AddMVC` to the  ConfigureServices() method. 

In addition to actually letting the HTTP pipeline know about MVC, we also need to tell it what our default template will be. For example,
we have to tell it what is the default location to look for if no page, other than the root domain, is specified. 

we do this by adding a "Route Map". to the ConfigureServices. Set your Default route template to be a Home controller with an 'index' action.
and a nullable id. 

Make sure you break down each step of the template and confirm that the students understand why the template is there. 
They will be required to write out the template by hand for every lab assignment the first half and midterm. After the midterm, they
can use the pre-created default template if they wish. 

### Controller
Now that they have the default template created in the Startup class, this is a great segway into creating an actual controller. 
Start out the demo by walking through how to create a controller. 
1. Start by creating a class
1. Make the class inherit from `Controller`
1. Talk about how "methods" in controllers are called "Actions"
1. Create a nwe action, with the return type of string
1. return a string from the method. 
1. Go to the appropriate page on the site and see the string outputted

Pretty cool huh? 

Now play with the query strings in the url. Go back to your action and require that the action take in a string or an int. 
go to the url, and append to it the proper parameters and values using the url query syntax. Make the action within the controller
relay back out to the user the values they put in. 

Now show them what it looks like when you append a url, they should be able to see the values that are being brought in. 

This is called "Model Binding." the model is able to see the values it is supposed to accept, and then associates them to the correct parameters
from the query, assuming the names are exactly the same. 

It is important for the students to know that Controller are in charge of the routing. I like to put in the analogy of the "Traffic Cop".
They tell any requests coming in exactly where they need to go (which controller). 

### View
Now that we know how to output data back to the user, let's add a view into our 3 part cycle.
AS you can see, a View is not required to output data to our user, because we were able to do just that with just strings. 
But what if we want to give the user more than just a string? How about a list of strings, or objects, or misc data that
needs to be viewed? This is where views come in. We have the ability to not only output complex data to the user, but also 
style and design it with HTML, CSS, and JavaScript. 

Before we can get to designing our view page, we have to do some small changes to our controller action to allow the view page
to render. First, we need to change the return type, we are no longer returning a string to the user, but a View. Within the base
`Controller` class, we do this by making the return type `ViewResult` or `IActionResult`. 

Next, set your return statement of your action to be `return View()`. This will allow us to call the 
appropriate view to get rendered. The `View()` request flow does the following:
1. Looks for the "Views" folder
1. Finds the folder name of the matching controller
1. Finds the `.cshtml` file with the same name as the action

Within the view page, you can write c# by indicating a `@model` directive at the top of the page. 
This directive will define for us what type of data will be displayed on our view. the `@model` will declare the 
value of `Model` when used within the page. 

You only need to declare the @model directive if you are bringing information in. If you are only obtaining information
with no presentation, you do not need the directive. Here is an example of an intake form:

```csharp
<form method="post" action="/Home/Create">
    <div class="form-group">
        <label for="Name">Name:</label>
        <input class="form-control" name="Name" />
    </div>
    <div class="form-group">
        <label for="Country">Country:</label>
        <input class="form-control" name="Country" />
    </div>
    <div class="form-group">
        <label for="Population">Population:</label>
        <input class="form-control" name="Population" />
    </div>

    <button type="submit" bs-button-color="danger">Add</button>              
    <a class="btn btn-primary" href="/Home/Index">Cancel</a>
</form>
```

The intake form maps the name attribute and model binds that to the appropriate property.
1. If you did bring in a `@model`, then the for will bind to the property
1. If you did not, then the for will bind to the parameter that you have set in the controller within the `[HTTPPOST]` action. 


Once you add the submit button, you will need to make an additional action in the controller that has an
`HttpPost` flag at the top. This is in addition to the default `HTTPGET`. 


### Model

1. What is a Model?
    - The model in an MVC application represents the state of the application and any business logic or operations that should be performed by it. 
    - Business logic should be encapsulated in the model, along with any implementation logic for persisting the state of the application. 
    - strongly typed views will typically use ViewModel types specifically designed to contain data to display on that view. The controller will create and populate these ViewModels from the model. 

1. The model classes you'll create are known as POCO classes (from "plain-old CLR objects") because they don't have any dependency on EF Core. They just define the properties of the data that will be stored in the database.


Create a new folder named `Models` (The name of the folder doesn't actually matter, but convention tells us to call it Models).
Here you can create any class you want...standard to how you have been creating classes so far. For the demo, create a class named `Student`, and give
it some generic properties. 

```csharp

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string FavoriteColor { get; set; }
```

This model can be accessed from the controller to instantiate individual students or even create 
a list of students. 

Within your Controller, make one of your actions send a `List<Student> students` and have your  view accept  a list of students
as it's model directive. 

```csharp
@model IEnumerable<d8MVCDemo.Models.Student>
```

You can now traverse through the `Model` within the view:

```csharp
    @foreach (var item in Model)
    {
        <h2>@item.FirstName @item.LastName</h2>
        <span> @item.Age years old</span>
        <span> Favorite color is @item.FavoriteColor</span>
        <hr />
    }
```


### Redirects

Finally, show the redirect capability from one action to another

```csharp
      [HttpPost]
        public IActionResult Greeting(string firstName, string lastName, int age, string favoriteColor)
        {
            Student student = new Student
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                FavoriteColor = favoriteColor
            };

            return RedirectToAction("Results", student );
        }

        [HttpGet]
        public IActionResult Results(Student student)
        {
            return View(student);
        }
```

