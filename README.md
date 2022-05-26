## Description

This .NET 6 application provides a service that returns the final invoice amount including discount when a bill is given.

The following discounts apply:

1. If the user is an employee of the store, he gets a 30% discount
2. If the user is an affiliate of the store, he gets a 10% discount
3. If the user has been a customer for over 2 years, he gets a 5% discount.
4. For every `$`100 on the bill, there would be a `$` 5 discount (e.g. for `$` 990, you get `$` 45 as a discount).
5. The percentage based discounts do not apply on groceries.
6. A user can get only one of the percentage based discounts on a bill.

## Prerequisites

* .NET SDK 6
* .NET Runtime 6
* ASP.NET Core Runtime 6

## UML Class Diagram

![Class Diagram](/UMLClassDiagrams/RetailStore.png)

## Running

Open a terminal such as PowerShell, Command Prompt, or bash. Go to the ShopsRUsRetailStore folder and run the following command:

```ps
dotnet run
```

Post a JSON data in the following format to https://localhost:7193/api/Invoice/GetFinalInvoiceAmount

```json
{
    "customer": {
        "type": 0,
        "registrationDate": "2022-05-26T21:10:09.588Z",
        "name": "Name",
        "surname": "Surname"
    },
    "invoiceItems": [
        {
            "type": 0,
            "cost": 5.5
        },
        {
            "type": 1,
            "cost": 10
        }
    ]
}
```

Customer types: 0: Employee 1: Affiliate 2: Standard

InvoiceItem types: 0: Grocery 1: Technology 2: Clothing ...

## Running the Tests

Open a terminal such as PowerShell, Command Prompt, or bash. Go to the ShopsRUsRetailStore.UnitTests folder and run the following command:

```ps
dotnet test
```

## Analyzing Code

To see code analysis warnings, open a terminal such as PowerShell, Command Prompt, or bash, go to the ShopsRUsRetailStore folder and run the following commands:

```ps
dotnet clean
dotnet build
```

## Generating Coverage Report

To generate a coverage report file, open a terminal such as PowerShell, Command Prompt, or bash. Go to the ShopsRUsRetailStore.UnitTests folder and run the following command:

```ps
dotnet test --collect:"XPlat Code Coverage"
```

## SonarQube Report

Open a terminal such as PowerShell, Command Prompt, or bash. Go to the solution folder and run the following commands after replacing the project_token part with the SonarQube token:

```ps
dotnet sonarscanner begin /k:"ShopsRUsRetailStore" /d:sonar.host.url="http://localhost:9000"  /d:sonar.login="project_token" /d:sonar.cs.opencover.reportsPaths=**\*opencover.xml
dotnet build
dotnet test --collect:"XPlat Code Coverage" -- DataCollectionRunSettings.DataCollectors.DataCollector.Configuration.Format=opencover
dotnet sonarscanner end /d:sonar.login="project_token"
```

Screenshots of SonarQube report

![Dashboard](/SonarQubeReports/Dashboard.png)
![Coverage Report](/SonarQubeReports/CoverageReport.png)

