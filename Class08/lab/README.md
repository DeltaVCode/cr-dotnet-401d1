# Lab 08: Phil's Lending Library 

## The Problem Domain
Build out Phil's Lending Library! Create your own Lending Library filled with Books.

Make your lending library a generic collection, and your `Book` a separate class that holds appropriate properties and behaviors. In addition, remove items from the newly created library and place them into another generic collection (such as a `List<T>`) to prove the movement of the individual objects. 

## Program Specifications

Your solution should include the following:

1. 2 properties in your `Program.cs` file
   - `Library<Book> Library`
   - `List<Book> BookBag`
1. Main method with the following:
   - Instantiates your new `Library` and `Bookbag`.
   - A method to `LoadBooks()` that adds books to your Library. Create a minimum of 5. 
   - Call to the `UserInterface` that prompts the user with different options:
     - View all Books
     - Add a Book
     - Borrow a book
     - Return a book
     - View Book Bag
     - Exit
1. Create a `Book` class that has:
    - Title
	- Author (Make Author it's own class with the appropriate properties)
	- Genre (This should be an enum)
1. Appropriate methods for each of the options that the user interface is prompting for


## Guidance
- Create a custom generic collection named `Library<T>`.
- As we learned, under the hood, generic collections are arrays. Utilizing this concept, create a new generic collection (`Library<T>`) that dynamically resizes an array for all the specified methods described below.
- Your Generic collection should hold `Book`s.
- Create an Enum to hold the different genres of book types
- The methods within your `Library<T>` class should contain at minimum:
	1. Add
	1. Remove
	1. Count (the total number of books in the library)

- In your `Program.cs` have a method named `Borrow` that gets called from the user interface. 
  - The `Borrow` method should bring in the title of the book
  - Traverse through the library until you find the book that you are looking for
  - Add the book to your `BookBag`
  - Remove the item from the library 
  - You could possibly use similar logic for this as you do in `ReturnBook` (see below)
- In your `Program.cs` have a method named `ReturnBook` that gets called from the user interface
  - Create a `Dictionary<int, Book>` that adds each of the books in your BookBag into the dictionary with a counter as the key, and the book as the value. Output each of the titles to the console and have the user select which "number" they want to return. Add that `Book` back to your Library, and remove it from your BookBag.

### Code Snippets

Here is my logic for my "ReturnBook". If you choose to use it, please comment the code explicitly on what is going on. 

```csharp
     static void ReturnBook()
        {
            Dictionary<int, Book> books = new Dictionary<int, Book>();
            Console.WriteLine("Which book would you like to return");
            int counter = 1;
            foreach (var item in BookBag)
            {
                books.Add(counter, item);
                Console.WriteLine($"{counter++}. {item.Title} - {item.Author.FirstName} {item.Author.LastName}");

            }

            string response = Console.ReadLine();
            int.TryParse(response, out int selection);
            books.TryGetValue(selection, out Book returnedBook);
            BookBag.Remove(returnedBook);
             Library.Add(returnedBook);
        }

```

Here is my logic of "AddABook": 
```csharp
        static void AddABook(string title, string firstName, string lastName, int numberOfPages, Genre genre)
        {
            Book book = new Book()
            { Title = title,
              Author = new Author()
              {
                  FirstName = firstName,
                  LastName = lastName
              },
              NumberOfPages = numberOfPages,
              Genre = genre
            };

            Library.Add(book);
        }
```

## Unit Tests
Test that your program has the following functionality:
1. Add a Book to your Library that exists
1. Remove a book from your library
1. Cannot remove a book from the library that doesn't exist. 
1. Getter/Setters of your properties from your `Book` class
1. Getter/Setters of your properties from your `Author` class.
1. Accurate count of books within the library
1. One edge case of your choice

## Stretch Goals

1. A method with the signature of: `public bool IsAvailable(T book)` that determines if a book is available. (Hint: use the `.Equals()` helper)
1. Add the ability to find a specific book by "Author" or "Title" of the book.(You may need to set a restriction on `T`)

## README
**A Readme is a requirement. No Readme == No Grade.**

Here are the requirements for a valid readme: <br />

A README is a module consumer's first -- and maybe only -- look into your creation. The consumer wants a module to fulfill their need, so you must explain exactly what need your module fills, and how effectively it does so.

Your job is to:

1. tell them what it is (with context, provide a summary)
1. show them what it looks like in action (Visuals)
1. show them how they use it (Step by step directions, "Happy Path" walk through)
1. tell them any other relevant details

This is ***your*** job. It's up to the module creator to prove that their work is a shining gem in the sea of slipshod modules. Since so many developers' eyes will find their way to your README before anything else, quality here is your public-facing measure of your work.

Refer to the sample-README in the class repo `Resources` folder for an example. 
- [Reference](https://github.com/noffle/art-of-readme){:target="_blank"} 

## Rubric

The lab rubric can be found [HERE](../../Resources/rubric){:target="_blank"}

## To Submit this Assignment
- Create a new repo on your personal GitHub account
- Name your repo `Lab##-TITLE`
- Create a branch named `NAME-LAB##`
- Write your code
- Commit often
- Push to your repository
- Create a pull request from your branch back your `master` branch.
- Submit a link to your PR in canvas
- Merge your PR back into master
- In Canvas, Include the actual time it took you to complete the assignment as a comment (**REQUIRED**)
- Include a `README.md` (contents described above)