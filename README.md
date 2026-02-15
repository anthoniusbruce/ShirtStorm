# ShirtStorm

ShirtStorm is a subscription-based t-shirt store application that runs on Azure. This repository is structured as a monorepo containing multiple related projects.

## Repository Structure

```
ShirtStorm/
├── src/
│   ├── ShirtStormMvc/              - Main ASP.NET Core MVC web application
│   ├── ShirtStormCommon/           - Shared class library (models, utilities)
│   ├── ShirtStormBackOfStore/      - Blazor WebAssembly admin application
│   └── ShirtStormAddImages/        - Console utility for database image management
└── tests/
    ├── ShirtStormTests/            - Tests for ShirtStormMvc
    └── ShirtStormCommon.Tests/     - Tests for ShirtStormCommon
```

## Projects

- **ShirtStormMvc**: Main web application built with ASP.NET Core MVC and Entity Framework Core
- **ShirtStormCommon**: Shared class library containing common models and utilities
- **ShirtStormBackOfStore**: Admin interface built with Blazor WebAssembly
- **ShirtStormAddImages**: Command-line tool for managing product images
- **ShirtStormTests**: Unit and integration tests for the main web application
- **ShirtStormCommon.Tests**: Unit tests for the shared class library

## Building the Solution

```bash
dotnet restore
dotnet build
```

## Running Tests

```bash
dotnet test
```
## Azure Active Directory B2C Steps
Follow steps at https://blazorhelpwebsite.com/ViewBlogPost/55
## Add key for appsettings encryption/decryption
1. Resource groups, **Create** shirt\_storm
1. Key vaults
	1. **Create key vault**
	1. Resource group shirt\_storm
	1. Key vault name shirt-storm-vault
	1. **Review and create**
1. Key vaults, shirt-storm-vault
	1. Access configuration
	1. Go to Access contrl (IAM)
		1. Add role assignment
			1. Add Key Vault Secrets Officer
	1. Objects, Secrets, **Generate/Import**
		1. Name appsettingscipher
		1. Add value for appsettings cipher
## Appsettings Steps
1. Decrypt appsettings.json
1. Fill in "AzureAdB2C" section from values in Azure at **Azure AD B2C|App registrations**
1. Encrypt appsettings.json
## Program.cs Step
1. Replace value of **kvUri** with Azure Key vaults, shirt-storm-vault, **Vault URI**