# MentalEdu - Student Mental Health Support Platform
## Overview
MentalEdu is a comprehensive web application designed to support students' mental health by providing access to various support programs and resources. The platform connects students with mental health resources, allowing them to browse, enroll in, and participate in mental wellness programs.

## Features
- Support Programs : Browse and search through various mental health support programs
- Program Categories : Filter programs by categories to find relevant resources
- User Accounts : Create and manage user profiles
- Program Enrollment : Enroll in support programs that match your needs
- Admin Dashboard : Manage programs, categories, and user enrollments (admin only)
## Project Structure
The project is built using a multi-tier architecture:

- MentalEdu.BlazorApp.Client : Frontend Blazor WebAssembly application
- MentalEdu.BlazorApp.APIServices : Backend API services
- MentalEdu.Services : Business logic layer
- MentalEdu.Repositories : Data access layer
## Prerequisites
- .NET 8 SDK
- SQL Server (Local or Azure)
- Visual Studio 2022 
## Getting Started
### Database Setup
1. Create a new SQL Server database named MentalEduGroupProject
2. Update the connection string in appsettings.json if needed
### Configuration
1. Create a .env file in the MentalEdu.BlazorApp.APIServices directory with the following variables:
   
   ```plaintext
   DB_SERVER=YOUR_DATABASE
   DB_NAME=MentalEduGroupProject
   DB_USER=YOUR_USERNAME
   DB_PASSWORD=YOURPASSWORD
    ```
2. Create an appsettings.json file in the MentalEdu.BlazorApp.Client/wwwroot directory:
   
   ```json
   {
     "ApiBaseUrl": "https://localhost:based-on-your-device"
   }
    ```
### Running the Application Using Visual Studio 2022
1. Open the solution file MentalEduApp.sln in Visual Studio 2022
2. Set both MentalEdu.BlazorApp.APIServices and MentalEdu.BlazorApp.Client as startup projects
3. Press F5 to build and run the application Using Command Line
1. Open a command prompt and navigate to the solution directory:
   
   ```bash
   cd MentalEduApp\MentalEduApp
   
   ```
2. Run the API service:
   
   ```bash
   cd MentalEdu.BlazorApp.APIServices
   
    ```

    ```bash
   dotnet run
   ```
3. In a separate command prompt, run the client application:
   
   ```bash
   cd MentalEduApp\MentalEduApp\MentalEdu.BlazorApp.Client
   ```
   
   ```bash
   dotnet run
   ```
4. Open your browser and navigate to:
   
   - API: https://localhost:based-on-your-device
   - Client: https://localhost:based-on-your-device
## Troubleshooting
### SSL Certificate Issues
If you encounter SSL certificate errors, you can modify the connection string to include:

```plaintext
Encrypt=False;TrustServerCertificate=True
 ```

### API Connection Issues
If the client cannot connect to the API, verify:

1. The API is running
2. The ApiBaseUrl in the client's appsettings.json matches the API's URL
3. CORS is properly configured in the API
## Contributing
1. Fork the repository
2. Create a feature branch: git checkout -b feature/your-feature-name
3. Commit your changes: git commit -m 'Add some feature'
4. Push to the branch: git push origin feature/your-feature-name
5. Submit a pull request
## License
This project is licensed under the MIT License - see the LICENSE file for details.
