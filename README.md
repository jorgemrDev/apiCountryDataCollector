## About

The application, "CountriesController," is a powerful tool for accessing and manipulating data about countries worldwide. Developed using ASP.NET Core, it leverages the power of the REST Countries API to provide users with a comprehensive set of functionalities for exploring and analyzing country data. With a user-friendly API endpoint, users can easily retrieve information on countries based on various criteria, such as name, population, and sorting order. Whether one is looking to filter countries by name, limit the results by population, or sort them in ascending or descending order, this application offers the flexibility to cater to diverse research and analysis needs. Moreover, it handles exceptions gracefully, ensuring that users receive clear error messages in case of any issues.

Underneath its user-friendly interface lies a well-structured codebase, equipped with unit tests that rigorously validate the correctness of its functionalities. By using unit tests, the application ensures the reliability of its core components, including filtering, sorting, and pagination. This makes it a robust and maintainable solution that can be easily extended and integrated into various projects. Whether it's for educational purposes, data analysis, or any other use case requiring country data retrieval and manipulation, the "CountriesController" application stands as a dependable tool for accessing, filtering, and analyzing global country information with ease.

## To run locally

To run the developed "CountriesController" application locally, follow these steps:

Prerequisites:

    Ensure you have the .NET SDK installed on your local machine. You can download it from the official .NET website: https://dotnet.microsoft.com/download/dotnet.

    Make sure you have an integrated development environment (IDE) like Visual Studio or Visual Studio Code installed if you prefer using an IDE. You can also use the command line for running the application.

Instructions:

    Clone the Project:

        Open your command prompt or terminal.

        Navigate to the directory where you want to clone the project.

        Run the following command to clone the project repository:

        bash

    git clone <repository_url>

Navigate to the Project Directory:

    Change your current directory to the "CountriesController" project folder:

    bash

    cd CountriesController

Build the Project:

    Run the following command to build the project:

    bash

    dotnet build

Run the Application:

    To run the application, use the following command:

    bash

    dotnet run

    This command will start the application, and you should see output indicating that the application is running locally.

Access the Application:

    Once the application is running, open your web browser and go to the following URL:

    bash

    https://localhost:5001/api/Countries/getCountry

    You can use this URL to access the application's API endpoint for retrieving country data.

Testing the Application:

    If you want to run unit tests for the application, you can use the following command from the project directory:

    bash

        dotnet test

        This command will execute the unit tests and provide feedback on the test results.

That's it! You've successfully run the "CountriesController" application locally. You can now explore its API by making HTTP requests to the specified endpoint, and if needed, modify the query parameters to filter, sort, and paginate the country data as per your requirements.



## Examples to use endpoint

    Get All Countries (Default):
        Endpoint: https://localhost:5001/api/Countries/getCountry
        This request retrieves all countries with default parameters (searchQuery = "st", maxPopulation = 1111111, sortOrder = "ascend", numberOfRecords = 10).

    Filter by Name:
        Endpoint: https://localhost:5001/api/Countries/getCountry?searchQuery=ger
        This request filters countries with names containing "ger" (case-insensitive).

    Filter by Maximum Population:
        Endpoint: https://localhost:5001/api/Countries/getCountry?maxPopulation=5000000
        This request filters countries with a population less than 5 million.

    Sort in Descending Order:
        Endpoint: https://localhost:5001/api/Countries/getCountry?sortOrder=descend
        This request retrieves countries sorted in descending order by name.

    Limit Number of Records:
        Endpoint: https://localhost:5001/api/Countries/getCountry?numberOfRecords=5
        This request retrieves the first 5 countries based on default sorting.

    Filter and Sort:
        Endpoint: https://localhost:5001/api/Countries/getCountry?searchQuery=can&sortOrder=descend
        This request filters countries with names containing "can" (case-insensitive) and sorts them in descending order by name.

    Filter, Sort, and Limit Records:
        Endpoint: https://localhost:5001/api/Countries/getCountry?searchQuery=us&sortOrder=ascend&numberOfRecords=3
        This request filters countries with names containing "us" (case-insensitive), sorts them in ascending order by name, and limits the result to the first 3 countries.

    Filter by Population and Sort:
        Endpoint: https://localhost:5001/api/Countries/getCountry?maxPopulation=20000000&sortOrder=ascend
        This request filters countries with a population less than 20 million and sorts them in ascending order by name.

    Filter by Name with Special Characters:
        Endpoint: https://localhost:5001/api/Countries/getCountry?searchQuery=ç
        This request filters countries with names containing the special character "ç."

    Pagination - Get Second Page:

    Endpoint: https://localhost:5001/api/Countries/getCountry?pageNumber=2
    This request retrieves the second page of countries with 5 records per page based on default sorting.

You can modify the query parameters as needed to tailor your requests and obtain specific country data from the API.