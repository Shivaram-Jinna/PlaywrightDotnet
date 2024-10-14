# Test Automation Framework
 
## Overview

This repository contains a Test Automation framework built using Playwright, NUnit, and C#. The framework is designed to support robust, scalable, and maintainable automated testing with the following key features:

- Playwright for browser automation.
- NUnit as the testing framework, utilizing TestFixture attributes for structuring test cases.
- Parallel Test Execution for optimizing test run times.
- Environment Config file for flexible configuration of browser types and modes (headless/headed).
    

## Key Features
    1. Cross-browser Testing: The framework allows testing across multiple browsers, including Chrome, Firefox, and Edge. This is achieved by specifying the desired browser in the environment configuration file.
    2. Headless/Headed Mode: Tests can be run in headless or headed mode depending on the need, with the mode configurable through the environment file.
    3. Parallel Execution: Using NUnit’s built-in parallel execution capabilities, multiple tests can run simultaneously, reducing overall test execution time.
    4. Page Object Model (POM): The framework follows the POM design pattern, promoting better code organization and maintenance by separating page actions from the actual test cases.


## Technology Stack

- Playwright: For end-to-end web automation.
- NUnit: A unit testing framework for .NET, used to structure and manage test cases.
- C#: The programming language used to develop the framework.

## Prerequisites

Before running the tests, make sure you have the following tools installed:

- .NET SDK (Version 6.0 or higher)
- Playwright for .NET
- NUnit for testing

## Installing Prerequisites
- Install .NET SDK
    * Download and install the .NET SDK from the official Microsoft .NET website.

### To verify the installation, run the following command in your terminal:

```bash
  dotnet --Version
```
- Install Playwright

### Once .NET is installed, install Playwright by running the following command in your project directory:

```bash
  dotnet add package Microsoft.Playwright
```
- Install NUnit
    * Install NUnit and NUnit Console Runner:

```bash
  dotnet add package NUnit
  dotnet add package NUnit.Console
```
- Install NUnit Test Adapter (for running tests in IDE)
    * If you're using Visual Studio or JetBrains Rider, install the NUnit Test Adapter:

```bash
  dotnet add package NUnit3TestAdapter
```

## Configuration

The framework includes an environment configuration file where the following settings can be modified:

- Browser Type: Chrome, Firefox, Edge
- Execution Mode: Headless or headed

    ### Sample JSON File:
        
        {
            "browser": "chrome",
            "headless": true
        }

## Running Tests

To run tests, run the following command

```bash
  dotnet test
```
## Allure Reports

```bash
  dotnet add package Allure.Commons
  dotnet add package Allure.NUnit
```
  ### Generate Allure Reports
   * Run All your testcases
   * Genereate report: after tests are run, run the following command
     ```bash
     allure serve [path to your allure-results folder]
     ```
   * Results are opened in your Default browser.
## Future Enhancements

* Continuous Integration (CI): Set up a CI pipeline for automated test execution.
* Web-Based Test Case Management: Develop a web-based application where users can easily create and manage test cases. The application will provide an intuitive interface, allowing users to:  
  * Select a page or component from a list of predefined options.
  * Choose methods or input fields.
  * Input test data and parameters, automatically generating corresponding test steps.
  * Export or integrate these test cases directly into the automated test framework.

# Acknowledgments

### I would like to extend my gratitude to the YouTube channel that provided valuable tutorials on Playwright, which greatly helped me in developing this framework. I also appreciate the use of their web application for testing purposes.
### Special thanks to:
  * [ExecuteAutomation](https://www.youtube.com/@ExecuteAutomation) for their Playwright tutorials.
  * The web application [eaapp.somee.com](http://eaapp.somee.com) for providing a real-world environment to test this framework.
