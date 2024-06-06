# Online Shop REST API

## Overview

The Online Shop REST API project marks the beginning of your journey in building backend services. This project provides a backend RESTful API for an online shopping application. It demonstrates how to design and implement RESTful APIs using .NET, Entity Framework Core, SQL Server, and Fluent Validation. It includes endpoints for managing products, users, orders, and authentication.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Installation](#installation)
  - [Prerequisites](#prerequisites)
  - [Clone the Repository](#clone-the-repository)
  - [Set up Database](#set-up-database)
  - [Start the Server](#start-the-server)
- [API Documentation](#api-documentation)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

## Features

- **CRUD Operations**: Endpoints for managing products, users, and orders, including Create, Read, Update, and Delete operations.
- **Authentication**: Secure endpoints using JWT-based authentication.
- **Authorization**: Restrict access to certain endpoints based on user roles.
- **Validation**: Validate request data using Fluent Validation library for .NET.

## Technologies Used

- .NET
- Entity Framework Core
- SQL Server
- Fluent Validation

## Installation

### Prerequisites

- .NET SDK
- SQL Server

### Clone the Repository

1. **Clone the repository:**
```
git clone https://github.com/sadegh15khedry/OnlineShopRESTApI.git
cd OnlineShopRESTApI
```
### Set up Database

2. **Set up the database:**
- Create a SQL Server database using the code first Entity Framework class implemented.
- Update the connection string in `appsettings.json` to point to your database.

### Start the Server

3. **Start the server:**
```
dotnet run
```

## Contributing

Contributions are welcome! If you'd like to contribute to the project, please follow these steps:
1. Fork the repository.
2. Create a new branch (`git checkout -b feature/YourFeature`).
3. Commit your changes (`git commit -m 'Add some feature'`).
4. Push to the branch (`git push origin feature/YourFeature`).
5. Create a new Pull Request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact

For questions or inquiries, please feel free to open an issue on the GitHub repository.
