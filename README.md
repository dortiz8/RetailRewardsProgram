# RetailRewardsProgram
Dotnet Web Api with some server side rendering. 

This project was generated with .Net Core version 3.1 and Entity Framework version 3.1 

# Entity Framework
This project uses data contained in "~/Data/purchases.json" 
To seed the data before running the solution, use the Visual Studio menu by the "IIS Express" button, select debug properties, under IIS Express (if using it), add "/seed" 
to the command-line arguments and start the run the solution. 
Once the data is seeded, stop the solution, go back and clear the command-line arguments and start the solution again. 
This can also be done by running the solution with the CLI and passing in the argument mentioned above. 

# Migrations
Use "dotnet ef migrations add UpdateDb (or desired name)" to create a new entity migration if you wish to edit the models.
Use "dotnet ef database update" to update the database

# Running with Angular application 
The application will show some sample server side rendered pages while running. 
Run the Angular application.
The application will seek https://localhost:4200/ to call the api and retrieve the data. 


