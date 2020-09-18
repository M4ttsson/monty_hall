# monty_hall
Simulation for the Monty Hall problem

# Project

## monty.core
Contains core logic. Is a dependency for the other projects. 

## monty.web
Web page in react with a dotnet web api backend. Created using the dotnet core React template. Also contains basic testing.

## monty.test
XUnit test project, mainly for testing the core project. 

## Things to consider
* Most methods are public for easier testing. It might be wise to consider which methods should be public/internal/private instead and rewrite some of the tests to handle it. 

# Github Actions
Building and runnning tests using github actions. 
