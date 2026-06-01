# CallExternalApi

A .NET 10 ASP.NET Core project demonstrating my practice for integrating and consuming external APIs.

## Overview

This project serves as a reference implementation for calling external APIs in a maintainable and secure way. It integrates with the SurveyBasket API and demonstrates proper patterns for HTTP client management, authentication, error handling, and dependency injection.

## Key Practices Demonstrated

### 1. Dependency Injection
- Uses built-in `IHttpClientFactory` for efficient HTTP client management
- Implements constructor injection for loose coupling
- Configures services in `Program.cs` using the service container

### 2. External API Client Pattern
- Abstracts external API calls through an interface (`ISurveyBasketClient`)
- Uses Refit for declarative REST client definitions
- Centralizes API configuration and versioning

### 3. Authentication Handling
- Implements `AuthHeadderHandler` (HTTP message handler) for automatic token injection
- Separates authentication logic into `AuthTokenService`
- Automatically adds Bearer tokens to all outgoing requests
- Manages token lifecycle separately from API calls

### 4. Configuration Management
- Stores API endpoints and credentials in `appsettings.json`
- Uses `IConfiguration` for accessing settings
- Separates environment-specific configurations

### 5. Error Handling
- Checks `IsSuccessStatusCode` before processing responses
- Returns appropriate HTTP status codes to clients
- Handles API error responses gracefully
