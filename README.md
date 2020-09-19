# monty_hall
Simulation for the Monty Hall problem

# Project

## monty.core
Contains core logic. Is a dependency for the other projects. 

### Game.cs
Game is the main class with all methods for running a "game" of the monty hall problem. "Main" method in the Game class is Run() that will return a prize depending on which door was chosen.

Right now a game is run immediately but it should be easy to add a game loop instead and waiting for input. 

Might be an easier way to switch doors than the linq expression below (but it works).

```csharp

var otherDoor = Doors.Select((door, index) => new {door, index}).First(x => !x.door.isOpen && x.index != chosenDoor).index;
chosenDoor = otherDoor;

```

### Simulation.cs


## monty.web
Web page in react with a dotnet web api backend. Created using the dotnet core React template. Also contains basic testing.

## monty.test
XUnit test project, mainly for testing the core project. 

## Things to consider
* Most methods are public for easier testing. It might be wise to consider which methods should be public/internal/private instead and rewrite some of the tests to handle it. 

# Github Actions
Building and runnning tests using github actions. 
