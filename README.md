# EntityFramework Core Experiments #

This repository contains various experiments with EntityFramework Core.

## /EfCoreAudit ##

Audit trails are a very, very common requirement in software development. And if you are using 
SQL Server (or MySQL) it's really easy to use a Temporal Table and track everything, that happens 
to your data. Just let your expensive database handle it!

Now a common example in EntityFramework Core articles is to add auditing by overriding the `DbContext.SaveChanges` method 
and add the audit information by inspecting the `ChangeTracker`. Some tutorials also use an `SaveChangesInterceptor` to add 
it as a cross-cutting concern. 

The problem with this kind of approach to auditing is, that it already doesn't work for EF Core 7 `ExecuteUpdateAsync` 
methods, that basically bypass the `DbContext.SaveChangesAsync` method. So this example serves as a word of caution, so 
you don't run into a problem late in your EntityFramework Core application.

Please feel free to make a PR to fix this issue, because I don't know a EntityFramework Core-based solution.