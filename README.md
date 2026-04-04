# Thursday Evening Calendar

A booking calendar application built with ASP.NET Core and Blazor.

## Prerequisites

- .NET 10.0 SDK
- MySQL database (remote or local)

## Database Configuration

This application uses **MySQL** as its database. To protect sensitive credentials, we use **user-secrets** instead of committing passwords to source control.

### First-Time Setup

1. **Copy the example configuration files:**
   ```bash
   cd booking_calendar
   copy appsettings.json.example appsettings.json
   copy appsettings.Development.json.example appsettings.Development.json
   ```

2. **Initialize user-secrets:**
   ```bash
   dotnet user-secrets init
   ```

3. **Set your MySQL connection string using user-secrets:**
   ```bash
   dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=cse325project-booking-calendar.d.aivencloud.com;Database=CSE325Project;User=avnadmin;Password=YOUR_PASSWORD;Port=24959;SslMode=Required;"
   ```
   
   **Important:** Replace `YOUR_PASSWORD` with the actual database password (ask your team lead for credentials).

### InMemory Database Fallback (Testing Only)

If no connection string is configured, the app will automatically fall back to an in-memory database. This is useful for local testing, but **data will not persist** after the app restarts.

### Verifying Your Configuration

When you run the app, check the console output for these messages:
- `[Database] Using MySQL connection` - MySQL is configured correctly ✅
- `[Database] WARNING: No connection string found...` - App is using InMemory fallback ⚠️

**Important:** The app will NEVER print your password to the console.

## Running the Application

1. **Restore packages** (first time only):
   ```bash
   dotnet restore
   ```

2. **Build the project**:
   ```bash
   dotnet build
   ```

3. **Run the application**:
   ```bash
   dotnet run
   ```

4. Open your browser to `https://localhost:5001` (or the URL shown in the console).

## Project Structure

- `Components/` - Blazor components and pages
- `Controllers/` - API controllers for HTTP endpoints
- `Model/` - Data models (Event, Course, etc.)
- `SQL/` - Database scripts
- `wwwroot/` - Static assets (CSS, JS, etc.)

## Security Notes

- **Never commit real passwords** to `appsettings.json` or `appsettings.Development.json`
- Use `dotnet user-secrets` for local development
- Use environment variables or Azure Key Vault for production deployments
- The appsettings files in this repo contain only placeholders

## Troubleshooting

### "Access denied for user..."
- Check your connection string is correct
- Verify your database credentials
- Ensure your IP is whitelisted on the remote database host

### "Connect timeout expired"
- Verify the database host and port are correct
- Check your internet connection
- Confirm the database server is running

### App runs but data doesn't persist
- You're likely using the InMemory fallback
- Configure MySQL connection string using user-secrets (see above)