FizzBuzz API
This project is a Web API that implements the classic FizzBuzz problem with additional functionalities such as invalid item handling and SOLID principles, dependency injection, and unit testing using Mock and nUnit.

Features
Processes a list of numbers and identifies if they are divisible by 3 (Fizz), 5 (Buzz), or both (FizzBuzz).
Handles invalid inputs and responds accordingly.
Unit tests implemented using nUnit and Mocking frameworks.
Follows SOLID principles and uses Dependency Injection and Factory Design Pattern.
How to Run the Project
Prerequisites
.NET 6.0 SDK or later
Visual Studio 2022 or any code editor that supports .NET Core (VS Code, JetBrains Rider)
Postman or Swagger to test the API
Git (to clone the repository)

API Request Details
Endpoint: /api/FizzBuzz
Method: POST

Request Body: Send a list of numbers or objects as a JSON array.
[1, 3, 5, 15, "A"]

Response
The API will return a list of strings based on the FizzBuzz logic.

Example Response:
[
  "Divided 1 by 3 and 5",
  "Fizz",
  "Buzz",
  "FizzBuzz",
  "Invalid item"
]
