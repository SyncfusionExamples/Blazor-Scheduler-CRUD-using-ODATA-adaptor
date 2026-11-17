# How to perform CRUD operations in Blazor Scheduler using OData Adaptor

This project demonstrates batch CRUD operations in the [Blazor Scheduler](https://www.syncfusion.com/blazor-components/blazor-scheduler) using OData adaptor integration with .NET 10. It covers handling event data through Create, Read, Update, and Delete operations while leveraging the OData protocol for efficient data communication and synchronization. The sample serves as a practical reference for implementing scalable and enterprise-ready scheduling applications with Syncfusion Blazor components.

## Technologies

* **Blazor** - Modern web framework for building interactive web applications
* **.NET 10** - Latest .NET platform for building robust applications
* **Syncfusion Blazor Scheduler** - Enterprise-grade scheduling component
* **OData Adaptor** - Protocol for data access and manipulation

## Prerequisites

* Visual Studio 2026 or Visual Studio Code
* .NET 10 SDK or later

## Features

* Batch CRUD operations using OData adaptor
* Real-time event scheduling and management
* Integration with Syncfusion Blazor Scheduler
* Responsive design for multiple screen sizes
* Efficient data synchronization

## How to Run the Project

The solution has two projects: `Client` (Blazor WebAssembly app) and `Server` (OData service).

**Visual Studio 2026**:

* Checkout this project to a location on your disk.
* Open `BlazorSchedulerCrud.sln`.
* Set both `BlazorSchedulerCrud.Server` and `BlazorSchedulerCrud.Client` as startup projects.
* Restore the NuGet packages and run.

**Visual Studio Code**:

```shell
dotnet restore
dotnet run --project Server --launch-profile https
dotnet run --project Client --launch-profile https
```

Run the commands in separate terminals, then open the URL displayed by the Client project.

## Configuration

Configure the OData service endpoint (`Url` of `SfDataManager` in `Client/Pages/Home.razor`; the server allows the client origin through CORS in `Server/Program.cs`) to enable communication between the Blazor Scheduler and your backend data service. Ensure your OData service supports batch operations for optimal performance.

## Documentation Links

For more information on Syncfusion Blazor Scheduler and OData integration, refer to the following resources:

* [Blazor Introduction](https://blazor.syncfusion.com/documentation/introduction)
* [Blazor Scheduler Getting Started](https://blazor.syncfusion.com/documentation/schedule/getting-started)
* [General Syncfusion Documentation](https://help.syncfusion.com/)

## Support

For issues, questions, or feedback, please refer to the Syncfusion support portal or community forums.