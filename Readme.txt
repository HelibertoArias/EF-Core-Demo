
#====================================
Packages
#====================================
Microsoft.EntityFrameworkCore.Tools
Microsoft.EntityFrameworkCore.SqlServer


#====================================
DatabaseFirst : EFCoreDatabaseFirst
#====================================

Scaffold-Dbcontext -provider Microsoft.EntityFrameworkCore.SQLServer -connection "Data source = localhost\SQLEXPRESS; Initial Catalog = Northwind; Integrated Security=True;" 


#====================================
EFCoreDatabaseFirst2
#====================================
Scaffold-Dbcontext -provider Microsoft.EntityFrameworkCore.SQLServer -connection "Data source = localhost\SQLEXPRESS; Initial Catalog = Northwind; Integrated Security=True;" -OutputDir "./Rocco.Domain.Entities" -ContextDir "./Rocco.Persistence" -Context "RoccoContext"  -UseDatabaseName -Namespace "Rocco.Domain.Entities" -ContextNamespace "Rocco.Persistence"




#====================================
Model first
#====================================