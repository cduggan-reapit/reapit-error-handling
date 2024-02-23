# Reapit.Packages.ErrorHandling

## Description

Package containing classes for consistent error handling and response models across Reapit APIs.

## Usage

This package contains middleware to intercept and return a sanitised response to unhandled exceptions.  To register the 
middleware in your application, use the `RegisterErrorHandlerServices` method:

```c#
using Reapit.Packages.ErrorHandling;
// ...
builder.Services.RegisterErrorHandlerServices();
// ...
app.UseExceptionHandler(_ => { });
```

> Note: the empty lambda is required due to a bug in dotnet.  If an InvalidOperationException is raised on startup with a description including "Either the 'ExceptionHandlingPath' or the 'ExceptionHandler' property must be set in 'UseExceptionHandler()'.", double-check that this lambda is present.

## Dependencies

| Dependency                           |          Version | Description                                                                                             |
|--------------------------------------|-----------------:|---------------------------------------------------------------------------------------------------------|
| FluentValidation                     |           11.9.0 | .NET Library for strongly-types validation rules.  We use its ValidationException type in this project. |
| coverlet.collector                   |            6.0.0 | Code coverage generation                                                                                |
| FluentAssertions                     |           6.12.0 | Human-readable TDD specifications                                                                       |
| xunit<br />xunit.runner.visualstudio | 2.4.2<br />2.4.5 | Tools for unit testing dotnet projects                                                                  |
| Microsoft.NET.Test.Sdk               |           6.12.0 | Required package for testing dotnet projects                                                            |
| NSubstitute                          |          5.1.0   | Mocking library                                                                                         |
