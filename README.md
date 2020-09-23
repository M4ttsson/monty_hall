# monty_hall
Simulation for the Monty Hall problem

![image of the website](https://github.com/M4ttsson/monty_hall/raw/master/image.png)

# Project

## monty.core
Contains core logic. Is a dependency for the other projects. 

### Game.cs
Game is the main class with all methods for running a "game" of the monty hall problem. 
"Main" method in the Game class is Run() that will return a prize depending on which door was chosen.

Right now a game is run immediately but it should be easy to add a game loop instead and waiting for input. 

Might be an easier way to switch doors than the linq expression below (but it works).

```csharp

var otherDoor = Doors.Select((door, index) => new {door, index}).First(x => !x.door.isOpen && x.index != chosenDoor).index;
chosenDoor = otherDoor;

```

Testing is done in GameTest.cs in monty.test project. 
A couple of the tests might contain a bit of randomness due to usage of Random.Next if they break after a future code change. 

### Simulation.cs
Run method will run a number of simulations. Properties will contain results. 

```csharp

public void Run(int totalSimulations, int chosenDoor, bool changeDoor)

```

## monty.web
Web page in react with a dotnet web api backend. 
Created using the dotnet core React template. 
Also contains basic testing of the rendered web page.

### API
SimulationController contains a simple Get just to check for connection. 
All work is done when posting. 
A Post request is handled async just in case the user request a lot of simulations.
I have not put an upper limit on how many simulations the user can request, it will probably time out if too high.
A couple of tests with larger number shows that about 1 million takes 3 seconds to respond, 10 million 30 seconds and 100 million about 5 minutes. 

Post method expect a json body with a SimulationRequest containing all required values. Automatic model validation is handled by the APIController, invalid values will return 400 errors. 

One basic unit test exists in monty.test, but it is probably not the best way to test the api. 
It can't handle model validation since the code is called "from the side" and not through a web request. 
In future, maybe test from react tests?

### ClientApp
React web app from the template. 
Component for the MontyHall is in components/MontyHall.js. 
MontyHall component contains a form for the user to fill in simulation data.
After pressing the submit button, the api are contacted and simulations run then the result is presented as two progress bars. 

Unless using very high number of simulations the API responds immediately.
If the user submits a high number so it takes time an animated progressbar will be shown. 

There are room for improvements, the error handling when calling the api is not very good.
The form validation could also probably be better and more intuitive. 
As well as more testing. 

Some basic testing of the webpage is in App.test.js and MontyHall.test.js. Testing is done using jest and testing-library/react. The tests for the MontyHall component does only check if it renders as expected. It could be good to add mocking and test clicking the button and verify that the result shows as expected etc. 

#### Known bugs
* When changing number of simulations, the "Result" progress bars change immediately. 
* Validation of the form is not very good.

## monty.test
XUnit test project, mainly for testing the core project and some basic testing of api-controllers. Some of the features of the API controller does not work since calling the code from the side. 

## Things to consider
* Most methods are public for easier testing. It might be wise to consider which methods should be public/internal/private instead and rewrite some of the tests to handle it. 
* Api testing is lacking coverage.

# Usage
To run the project locally, run command:
```

dotnet run --project monty.web

```

To run the dotnet unit tests, run command:
```

dotnet test

```

To run the npm test, navigate to the ClientApp folder:
```

cd monty.web/ClientApp
npm test

```

Please note that this project was created in VSCode on Linux (Fedora) using dotnet core cli. It should work in any editor on any OS but please let me know if it does not. 

# Github Actions
Building and running tests using github actions. 
It is just a basic dotnet build/test and npm test that runs for every commit on master. 
