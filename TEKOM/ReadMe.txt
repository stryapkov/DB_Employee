Программа "Список сотрудников"
Взаимодействует с базой данных для сохранения результата работы программы.
При разработке был использован EntityFraemvork с подходом CodeFirs к уже созданной базе данных.

1. Название базы данных - EmployeeDB

2. Строка подключения для App.config
  <connectionStrings>
    <add name="Employes" connectionString="data source=(localdb)\MSSQLLocalDB;initial catalog=EmployeeDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />
  </connectionStrings>

3. Для создания таблицы базы данных используйте этот скрипт:
		CREATE TABLE [dbo].[Employees] (
    [Id]       INT        IDENTITY (1, 1) NOT NULL,
    [SurName]  NCHAR (50) NULL,
    [Name]     NCHAR (50) NULL,
    [LastName] NCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
	);
