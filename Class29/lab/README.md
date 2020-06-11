# Lab 29: Authorization

## Instructions:

Building off of your lab 28:
1. Seed/create at least two Roles (e.g. `admin` and `editor`)
2. Seed/create appropriate Role Claims (e.g. `create`, `update`, `delete`)
3. Use `AddPolicy()` in `UseAuthorization()` to create at least one claims-based Policy
4. Use `[Authorize]` with `Roles` or `Policy` to restrict access your API

### Additional

A few things to keep in mind:

1. Use the demo code as a resource
2. Test all routes with Postman and breakpoints to ensure you are receiving expected behavior.

## Stretch Goals

- Add API endpoints (with `[Authorize]`!) to manager user roles
- Implement Basic Authentication ([tutorial](https://jasonwatmore.com/post/2019/10/21/aspnet-core-3-basic-authentication-tutorial-with-example-api))
- Tests for routes — how can you set `User`?

## Tests

No additional tests required for today


## To Submit this Assignment

- Link to GitHub PR, as usual
