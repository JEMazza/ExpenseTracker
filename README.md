# ExpenseTracker

A high-performance desktop expense tracker in NET 8 using Windows Forms, SQLite and Entity Framework Core 8, designed to provide clear and offline expense logging and a clearer analysis of financials beyond what a spreadsheet can offer.

## Technology used

* [.NET Core 8](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/)
* [Windows Forms](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/)
* [Entity Framework Core 8](https://learn.microsoft.com/en-us/ef/core/)
* [SQLite](https://www.sqlite.org/)
* [ScottPlot](https://github.com/scottplot/scottplot/)
* [ClosedXML](https://github.com/ClosedXML/ClosedXML)
* [Serilog](https://serilog.net/)

## Features

* Load expenses by adding a name, a date, a cost, a place and a type.
* View a list of expenses based on dates from and to, types and places.
* Update an expense.
* Remove an expense.
* Export the list of expenses to a spreadsheet based on the previous filter and a summary of the dates, detailing the total amount of expenses, the sum of the cost, and the place and type of the biggest expenses.
* Obtain a report detailing the expenses between a from and/or a to date, obtaining the expenses, the top 5 days with most expenses, the total cost of both types and expenses. (V1.1+)
* Export the report mentioned previously with all the data and the summary mentioned on the list of expenses. (V1.1+)

## Getting started

- NOTE: Version 1.0 only contains Spanish support. Versions 1.1 and onward provide English support.

### Running the application

1. Go to "Releases".

2. Download the version you desire.

3. Extract the .zip file.



4. Run ExpenseTracker.exe

### Compiling

Requirements:

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

Steps.

1. Clone the repository.

    ` git clone https://github.com/JEMazza/ExpenseTracker `

2. Navigate to the solution directory.

    ` cd ExpenseTracker `

3. Restore the NuGet packages

    ` dotnet restore ExpenseTracker/ExpenseTracker.sln `

4. Compile the solution

    ` dotnet build ExpenseTracker/ExpenseTracker.sln `

5. Run the project.

    ` dotnet run ExpenseTracker/ExpenseTracker.sln `

## Architecture

### Baseline 

Two projects for ease of manteinence.

- ExpenseService gives the business rule checks and the database access. 
- ExpenseTracker handles the form loads and the visual presentation.

Dependency Injection was used in order to provide the required services, DbContexts and Forms as needed, optimizing memory footprint for the end user.

### Pattern implementations

- Repository: Instead of applying an interface per repository, since that duplicates files and generates slower deployment and fix releases, I first defined an interface with the basic operations for any repository, those being Add(TEntity) and Delete(TEntity), being called IRepository. After that, I created an abstract class Repository that implemented IRepository, implementing the Add(TEntity) and Delete(TEntity) methods, defining the DbContext property as protected with a constructor. This decision leads to avoiding DRY by not repeating the Add() and Remove() calls. Finally, the concrete repositories inherit Repository, have their DbSet defined to avoid repeating _context.Set, implement their own methods as needed and optimize as needed.

- Unit Of Work: As with Repository, I defined the interface IUnitOfWork in order to set the basic operations any Unit Of Work should follow. Those being Save() in order to save the progress up until that moment, Commit(IDbTransaction) for commiting a transaction, Rollback(IDbTransaction) for rolling back a transaction and StartTransaction() in order to begin a transaction. Then, I implemented a UnitOfWork that implements the IUnitOfWork interface with the methods described, has the Context property alongside each Repository that is needed. Alongside that, there is a method in order to instantiate and/or retrieve the repositories that are needed. That way, it saves memory and processing time instantiating repositories that are not needed.

- Data Transfer Object (DTO): In order to make the database operations as fast as possible, I use a rule that states: "Every entity must at least have 1 DTO for read purposes". This gives the advantage of shaping the data as it is needed into an object, since you only retrieve the information that is needed for it and avoid tracking an entity. 

## FAQs

### Isn't DbContext a Unit Of Work? 

Yes and no. Yes, in the sense that it tracks DbSets and you can use that to query the tables directly and coordinate operations. No in the sense that if you want more control, like using transactions in specific operations, the code can get complex, leading to services having model code and making it harder to read. 

### Isn't DbSet a Repository?

As with DbContext, yes and no. Repository is used in order to mantain clean code and separate concerns between Business and Data layers, therefore keeping code scalable and mantainable. And it avoids DRY by just letting it be used in a method, instead of multiple calls.

### Why doesn't Repository have a GetEntity() or a method to return an entity?

I assume that I don't know the primary key for the entity itself. Therefore, it is the concrete repository's responsibility to implement it if needed. 

### Why manual transactions?

SaveChanges(), in both sync and async methods, will apply the changes done at the moment it is called. By implementing a transaction, I ensure that the changes made by that method are the ones that the only ones that are persisted in that instance. And, in case the SaveChanges() fails for any reason, I ensure database consistency.

## License

This is distributed under the GNU GPLv3 license. See `LICENSE` for more information.

## Third-Party Licences

Third-Party notices and licenses are described in `THIRD-PARTY-NOTICES.txt`.
