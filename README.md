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
