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
1. 
2. ...

To configure Playwright for end-to-end testing:
1. ...