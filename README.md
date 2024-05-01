# KSU SWE 3643 Software Testing and Quality Assurance Semester Project: Web-Based Calculator
This repository contains a Calculator web app project that has a web based UI built through C# Blazor Server and takes
numerical input from the user and performs basic calculations with the input based on the button clicked by the user.
Then, the application displays the full mathematical expression along with the answer in the result text output.
The application also contains unit tests that achieve 100% coverage of the calculator mathematical operations through
NUnit and performs end-to-end testing through the Calculator's UI with Playwright. The repository also contains a
CalculatorEngine project that houses all the calculator functionality.

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
to request calculations. The CalculatorEndToEndTests project contains the EndToEndTests class that
references the Calculator blazor page through a headless browser to perform end to end testing.

![Project Architecture Diagram](/ReadmeAssets/CalculatorWebAppArchitecture_TaganWilliamson.png "Project Architecture Diagram")

## Environment
This is a cross-platform application and should work in Windows 10+, Mac OSx Ventura+, and Linux environments. Note that the application has only been carefully tested in Mac OS14 Sonoma.

To prepare your environment to execute this application:
1. <a href="dotnet.microsoft.com/en-us/download" target="_blank">Download .Net</a>
2. Navigate to the CalculatorWebApp directory in terminal/command prompt. (ex: C:\Users\\'user'\\RiderProjects\swe3643-spring2024-project\src\CalculatorWebApp)
3. Enter command `dotnet run` into the terminal.
4. Terminal will output the localhost address (typically http://localhost:5113)
5. Click the local host address link or type it into the address bar of your browser.
6. `ctrl+c` to terminate the application.

To configure Playwright for end-to-end testing:
1. Navigate to CalculatorEndToEndTests in the project directory in a terminal/command prompt.
2. Enter command `dotnet add package Microsoft.Playwright.NUnit` without the single quotes, and hit enter
3. Enter command `dotnet build`
4. Enter command `pwsh bin/Debug/net8.0/playwright.ps1 install`. If this gives an error that pwsh is not recognized, then <a href="learn.microsoft.com/en-us/powershell/scripting/install/installing-powershell?view=powershell-7.4" target="_blank">download powershell</a>. After downloading, you may need to open a new terminal window.
5. In a new terminal window, navigate to CalculatorWebApp and enter `dotnet run`
6. In the window that is in the CalculatorEndToEndTests, enter command `dotnet test --filter "EndToEndTests`
7. If the the Add test fails rerun the tests. For some reason it fails, then passes.

## Executing the Web Application
1. Navigate to the CalculatorWebApp directory in terminal/command prompt. (ex: C:\Users\\`user`\\RiderProjects\swe3643-spring2024-project\src\CalculatorWebApp)
2. Enter command `dotnet run` into the terminal.
3. Terminal will output the localhost address (typically http://localhost:5113)
```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5113
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /Users/tagan/Documents/SchoolFiles/SoftwareTestingQA/SemesterProject/WebApp/swe3643-spring2024-project/src/CalculatorWebApp
warn: Microsoft.AspNetCore.HttpsPolicy.HttpsRedirectionMiddleware[3]
      Failed to determine the https port for redirect.
```
4. Click the local host address link or type it into the address bar of your browser.
5. `ctrl+c` to terminate the application.

## Executing Unit Tests
1. Navigate to the CalculatorEngineUnitTests directory in a terminal.
2. Enter command `dotnet test`.
3. Should output similar: 
```
tagan@Tagans-MacBook-Pro CalculatorEngineUnitTests % dotnet test
   Determining projects to restore...
   All projects are up-to-date for restore.
   CalculatorEngine -> /Users/tagan/Documents/SchoolFiles/SoftwareTestingQA/SemesterProject/WebApp/swe3643-spring2024-project/src/CalculatorEngine/bin/Debug/net8.0/CalculatorEngine.dll
   CalculatorEngineUnitTests -> /Users/tagan/Documents/SchoolFiles/SoftwareTestingQA/SemesterProject/WebApp/swe3643-spring2024-project/src/CalculatorEngineUnitTests/bin/Debug/net8.0/CalculatorEngineUnitTests.dll
   Test run for /Users/tagan/Documents/SchoolFiles/SoftwareTestingQA/SemesterProject/WebApp/swe3643-spring2024-project/src/CalculatorEngineUnitTests/bin/Debug/net8.0/CalculatorEngineUnitTests.dll (.NETCoreApp,Version=v8.0)
   Microsoft (R) Test Execution Command Line Tool Version 17.8.0 (arm64)
   Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:    35, Skipped:     0, Total:    35, Duration: 14 ms - CalculatorEngineUnitTests.dll (net8.0)
```

## Reviewing Unit Test Coverage
Calculator Engine project has 100% coverage.

![Coverage Snapshot](/ReadmeAssets/Coverage_TaganWilliamson.png "CalculatorEngine Coverage")

## Executing End to End Tests
1. Navigate to the CalculatorWebApp directory in terminal/command prompt. (ex: C:\Users\\`user`\\RiderProjects\swe3643-spring2024-project\src\CalculatorWebApp)
2. Enter command `dotnet run` into the terminal.
3. Terminal will output the localhost address (should be http://localhost:5113)
   ```
       info: Microsoft.Hosting.Lifetime[14]
           Now listening on: http://localhost:5113
       info: Microsoft.Hosting.Lifetime[0]
           Application started. Press Ctrl+C to shut down.
       info: Microsoft.Hosting.Lifetime[0]
           Hosting environment: Development
       info: Microsoft.Hosting.Lifetime[0]
           Content root path: /Users/tagan/Documents/SchoolFiles/SoftwareTestingQA/SemesterProject/WebApp/swe3643-spring2024-project/src/CalculatorWebApp
       warn: Microsoft.AspNetCore.HttpsPolicy.HttpsRedirectionMiddleware[3]
           Failed to determine the https port for redirect.
    ```
4. Open a new terminal window.
5. Navigate to the CalculatorEndToEndTests directory.
6. Enter command `dotnet test`.
    ```
        Determining projects to restore...
        All projects are up-to-date for restore.
        CalculatorEndToEndTests -> /Users/tagan/Documents/SchoolFiles/SoftwareTestingQA/SemesterProject/WebApp/swe3643-spring2024-project/src/CalculatorEndToEndTests/bin/Debug/net8.0/CalculatorEndToEndTests.dll
    Test run for /Users/tagan/Documents/SchoolFiles/SoftwareTestingQA/SemesterProject/WebApp/swe3643-spring2024-project/src/CalculatorEndToEndTests/bin/Debug/net8.0/CalculatorEndToEndTests.dll (.NETCoreApp,Version=v8.0)
    Microsoft (R) Test Execution Command Line Tool Version 17.8.0 (arm64)
    Copyright (c) Microsoft Corporation.  All rights reserved.

    Starting test execution, please wait...
    A total of 1 test files matched the specified pattern.

    Passed!  - Failed:     0, Passed:     5, Skipped:     0, Total:     5, Duration: 1 s - CalculatorEndToEndTests.dll (net8.0)
    ```
7. Close the terminal window.
8. `ctrl+c` to terminate the application.


## Final Video Presentation
[Presentation Video](https://youtu.be/t_z4a4OM9p8 "Final Presentation Video")
