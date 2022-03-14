# Real Cookies api :cookie:
- Used TDD to develop this service.
- Used  hexagonal architecture with DDD.
  - The DTO folder should be inside Application folder, and Controller inside Infrastructure.

- The benefit of implenting this is that we have test and its easy to mantain and scale.
- Didn't implement repositories for csv files, just in memory repos, but once you know how to connect database its easy because of the repository pattern.

## Domain
- The Order is an aggregate root, that has value object OrderLine wich contains list of cookie's id and quantities.
- Cookie and Client are Entities.

## Tests 
- Done unit test and integration test of repositories and oderService
- Integration test of the final API with Postman
  - The link to the collection: https://www.getpostman.com/collections/5b3b2b71d8f08f32f835

## Future improvements
- Implement repositories to connect with data base.
- Do unit test using Test double, moking dependencies
- Refactor with lambdas in array manipulation.
- Create object mappers.
- Create endpoints for making CRUD of Cookies.

## How to run 
- Just call the enpoint `/order`, with post and get methods.

## What I learned
- Learn a litlte bit of C# wich is very similar to Java.
- How the .Net works and the Visual Studio.

# Comments
Could have done this project with improvements in less than one day with Spring Boot.
Spend 2.5 days on this assigments, could have done more but I have other interviews and I'm focusing on Java and Spring Boot.

# Issues
- All the issues I had was related to C#, .Net and the VS IDE.
- New in C#, althought is similar to Java, but it has its own things.
- New in Visula Studio, it has its own things, like you can't edit files and folders while the app is running.
- Testing framework xUnit asserts aren't very semantic, couldn't use .Equals, I used only the .True which dificulted me to debug errors.
- Spend lot of time trying to connect database because i thought it would be easier than making crud with csv files.
