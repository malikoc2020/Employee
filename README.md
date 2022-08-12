# Employee
Repository Pattern Restfull API

# General Description
- Token Bearer mechanism is established in API.
- "Microsoft.AspNetCore.Identity.EntityFrameworkCore" package is used for "User - Role" operations.
- Two default roles; "Admin" and "User" are defined in the project.
- When the project is run for the first time, two users with Admin@Admin.com in the Admin role and user@user.com in the User role are created in the database. Their password is set as "Password%5". Tokens can be obtained from the system with these users.
- To create a database, the "DBConnection" field in the "appsettings.json" file in the API layer must be updated.
