# Class 26: Intro to Identity

## Learning Objectives
1. Students will be introduced to Azure Dev Ops Project Management Tool 
1. Students will be introduced to ASP.NET Core Identity and successfully integrate it into an existing codebase. 

## Lecture Outline

### Identity

**Authentication** : Authentication is the process of determining **Who you are**

**Authorization** : Authorization revolves around **what you are allowed to do** (Example is permissions) 
 

### Integration

Integrating identity into your web application only takes a few steps. Many of them, you already know how to do.
1. Add the `app.UseAuthentication` into your `Configure()` method within your `Startup.cs` file. 
1. Create your Application User and derive it from `IdentityUser`. Add any additional properties that you wish to include with your user
1. Create your identity DBContext (derive a new `DBContext` from `IdentityDbContext<TUser>` (`TUser` should be your application user you created earlier)
1. Register your new database in the `Startup.cs` file
1. In future days, you will add the register/login functionality.
