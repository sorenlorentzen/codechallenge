# CodeChallenge

This project is split into two projects. The ConsoleApp project is responsible for running the code contained in the Core project.

### Main points: 
- A `Task` is not a thread. However, I fell that `Task`s represent a more modern approach to programming and for that reason I chose to use `Task` instead of `Thread`s directly.
- Following this reasoning, I have chosen to use json instead of xml for configuration.
- I have added DI using `Microsoft.Extensions.DependencyInjection` as I more comfortable with this library than Windsor, Autofac, NInject etc.
- Unit tests are written using MSTest.
- The project is developed on Windows, but should run on MacOS and Linux as well.
