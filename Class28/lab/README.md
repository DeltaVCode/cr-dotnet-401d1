# Lab 28: Authentication

## Instructions:

Build off of your lab 27 and add:
1. JWT Bearer Authentication with [Microsoft.AspNetCore.Authentication.JwtBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer)
2. Some use of `User` and `[Authorize]` in your controllers/actions. Ideas:
    - Limit create/update/delete to authorized users
    - Capture who created/modified a model entity and when
    - Limit get/update/delete to model entities created by `User`
    - Allow a task or list to be shared with another user

### Additional

A few things to keep in mind:

1. Use the demo code as a resource
2. Test all routes with Postman and breakpoints to ensure you are receiving expected behavior.

## Stretch Goals

- Implement Basic Authentication ([tutorial](https://jasonwatmore.com/post/2019/10/21/aspnet-core-3-basic-authentication-tutorial-with-example-api))
- Tests for routes — how can you set `User`?

## Tests

No additional tests required for today


## To Submit this Assignment

