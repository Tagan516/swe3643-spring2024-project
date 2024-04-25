# KSU SWE 3643 Software Testing and Quality Assurance Semester Project: Web-Based Calculator
This repository contains a Calculator web app project that has a web based UI built through C# Blazor Server and takes
numerical input from the user and performs basic calculations with the input based on the button clicked by the user.
Then, the application displays the full mathematical expression along with the answer in the result text output.
The application also contains unit tests that achieve 100% coverage of the calculator mathematical operations through
NUnit and performs end-to-end of the Calculator's UI testing through Playwright. The repository also contains a
CalculatorEngine project that contains all the calculator functionality.

## Table of Contents
- [Environment](#environment)
- [Executing the Web Application](#executing-the-web-application)
- [Executing Unit Tests](#executing-unit-tests)
- [Reviewing Unit Test Coverage](#reviewing-unit-test-coverage)
- [Executing End-To-End Tests](#executing-end-to-end-tests)
- [Final Video Presentation](#final-video-presentation)

## Team Members
- Tagan Williamson

## Architecture
The architecture is meant to be lightly coupled. The CalculatorEngine project contains a CalculatorFunctions class that
references the CalculationResult class to return an object type that is more usable. The CalculatorEngineUnitTests
project contains a class CalculatorFunctionUnitTests that references the CalculatorFunctions class for testing. 
The CalculatorWebApp project contains a single blazor page Calculator that references the CalculatorFunctions class
to perform calculations with user input. The CalculatorEndToEndTests project contains the EndToEndTests class that
references the Calculator blazor page through a headless browser to perform end to end testing.

![Project Architecture Diagram](/ReadmeAssets/CalculatorWebAppArchitecture_TaganWilliamson.png "Project Architecture Diagram")

## Environment
This is a cross-platform application and should work in Windows 10+, Mac OSx Ventura+, and Linux environments. Note that the application has only been carefully tested in Mac OS14 Sonoma.

To prepare your environment to execute this application:
1. <a href="dotnet.microsoft.com/en-us/download" target="_blank">Download .Net</a>
2. Navigate to the CalculatorWebApp directory in terminal/command prompt. (ex: C:\Users\\'user'\\RiderProjects\swe3643-spring2024-project\src\CalculatorWebApp)
3. Enter 'dotnet run' (without single-quotes) into the terminal. Hit enter.
4. Terminal will output the localhost address (typically http://localhost:5113)
5. Click the local host address link or type it into the address bar of your browser.
6. ctrl+c to terminate the application.

To configure Playwright for end-to-end testing:
1. Navigate to CalculatorEndToEndTests in the project directory in a terminal/command prompt.
2. Enter command 'dotnet add package Microsoft.Playwright.NUnit' without the single quotes, and hit enter
3. Enter command 'dotnet build'
4. Enter command 'pwsh bin/Debug/net8.0/playwright.ps1 install'. If this gives an error that pwsh is not recognized, then <a href="learn.microsoft.com/en-us/powershell/scripting/install/installing-powershell?view=powershell-7.4" target="_blank">download powershell</a>. After downloading, you may need to open a new terminal window.
5. In a new terminal window, navigate to CalculatorWebApp and enter 'dotnet run'
6. In the window that is in the CalculatorEndToEndTests, enter command 'dotnet test --filter "EndToEndTests'
7. If the the Add test fails rerun the tests. For some reason it fails, then passes.