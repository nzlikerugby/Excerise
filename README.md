# My exercise
## Introduction 
This project will read original data from csv file and output payslip to console or file.

## Requirement
Input: format (first name, last name, annual salary, super rate (%), payment start date)
output: format (name, pay period, gross income, income tax, net income, super)

## Assumptions
1. Reading csv file content as input
2. All input data are string format. For example, annual salary and super rate(%) are all string format
3. System doesn't allow null or empty input. Otherwise it will throw exception
4. If annual salary or super rate cannot be parsed to correct format system will throw exception
5. If annual salary or super rate are not correct number(negative number) system will throw exception
6. Either first name or last name cannot exceed 30 characters
7. First name and last name only contains english letters
8. Payment period only starts from first day of monty to last day of same month
9. System support super rate using both percentage and decimal. For example 11% is same as 0.11

## Design
From top to bottom.
The application should contains following modules:
#### Data input and output module
#### Data pre-process module which converts original input to desired format
#### Data caculating module for payslip data

## Workflow
![image](https://user-images.githubusercontent.com/38408398/49339513-d511ac80-f697-11e8-88ab-6bc08b715448.png)

## Solution Implementation
![image](https://user-images.githubusercontent.com/38408398/49339086-3b470100-f691-11e8-997e-98ebaadadd47.png)

The solution includes seven seperate projects.
#### App project:
This project integrates all modules to output payslips
#### DataIO project:
This module is used for input and output process
#### DataPreProcessor:
This module is behind DataIO and used to convert string list to employee object which will be used by next module
#### Service
This module will consume the employee object and perform the caculation to generate payslip data
#### Model
This project includes all interface and business model definition
#### Payslip
This project is application entry. It should be set as startup project when you run this solution in vs
#### MYOB.Tests
This is unit test project including all business logic module tests

## Development Process
1. Requirement analysis
2. Make assumptions to restrict boundry
3. Design architecture from top level
4. Implement individual module by TDD
5. Integration
6. Continuous refactoring

## How to run application
1. Download source code from git:   https://github.com/nzlikerugby/Excerise/archive/master.zip
2. Unzip the download file
3. Run solution in visual studio (system require .netcore 2.1)
4. Set Payslip project as startup project for this is application entry
5. Input and output data at /payslip/data/ directory
