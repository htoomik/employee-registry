# Overview

This project is a miniature REST API for an employee registry.

## Features

A basic API to manage employees
- GET endpoint to get all employees
- POST endpoint to add an employee
- DELETE endpoint to delete an employee

Under the hood:
- Data validation
- Thread-safe data storage

## Design principles

- Aiming at something that could be used as a basic template project for e.g. a microservice.
- Decoupling data types where decoupling will definitely be needed sooner or later, and will be painful to introduce if left too late
  - For example, objects exposed by the API need to be separate from database entities 
- Command/query pattern
- A minimum of external libraries ("manual" mapping instead of e.g. AutoMapper; no MediatR dispatching commands)

## Shortcuts taken

In a production project the following would need to be added/improved:

- Proper email validation
- Suitable libraries for validation, unit test assertions, etc 

## Try it out

### Prerequisites

- Install .NET 8

### Run the application

1. Run the application in your favourite IDE or using `dotnet run` from the `EmployeeRegistry.API` folder
2. Go to http://localhost:5000/swagger/index.html to see details for the endpoints and try them out