# DTE Location API Client
## Table of Contents
- [DTE Location API Client](#dte-location-api-client)
  - [Project Description](#project-description)
  - [How to Install and Run the Project](#how-to-install-and-run-the-project)
  - [How to Use the Project](#how-to-use-the-project)

## Project Description
DTE Location API Client is a C#-based utility library designed to provide a standard interface for interacting with a location-based API. The library abstracts the complexities of making HTTP requests and allows developers to easily fetch health information and address data based on postcode.

This client library is built using .NET Core and follows the principle of loose coupling, which allows the calling application to be independent of the details of the API service. By using this library, developers can save time, reduce redundancy, and focus on core application logic rather than dealing with the intricacies of HTTP requests and API specifics.

## How to Install and Run the Project
Follow these steps to set up and use the DTE Location API Client in your local development environment:

1. Ensure you have the .NET SDK installed on your machine. If not, download and install it from the [.NET official website](https://dotnet.microsoft.com/download).

2. Clone the repository to your local machine:

    ```bash
    git clone https://github.com/PA-NIHR-CRN/dte-location-api-client.git
    ```

3. Navigate to the project folder:

    ```bash
    cd dte-location-api-client
    ```

4. Restore the required dependencies and build the project:

    ```bash
    dotnet restore
    dotnet build
    ```
5. The DTE Location API Client library can now be referenced in your .NET projects by adding a reference to the built dll or by directly including the project in your solution.

## How to Use the Project
The DTE Location API Client library is intended to be used in .NET applications that need to interact with a location-based API. The main interface, `ILocationApiClient`, exposes two methods:

- `GetHealthAsync(bool includeReady)`: This method fetches the health status of the Location API.
- `GetAddressesByPostcodeAsync(string postcode)`: This method retrieves a collection of address data associated with the provided postcode.

To use these methods in your application, create an instance of `LocationApiClient` and call the appropriate method. Ensure to handle any exceptions and manage response data according to the needs of your application.
