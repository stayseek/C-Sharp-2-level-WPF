1. Создать базу данных с именем Lesson7HW1812

2. Создать таблицу пользователей.

CREATE TABLE [dbo].[Employees]
(
	[Id] INT ​IDENTITY​ (​1​,​​1​) NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(MAX) NOT NULL, 
    [LastName] NVARCHAR(MAX) NOT NULL, 
    [Age] INT NOT NULL, 
    [Sallary] INT NULL, 
    [Department] NVARCHAR(MAX) NULL
)

3. Создать таблицу подразделений.

CREATE TABLE [dbo].[Departments]
(
	[Id] INT IDENTITY​ (​1​,​​1​) NOT NULL PRIMARY KEY, 
    [DepartmentName] NVARCHAR(MAX) NOT NULL 
)

4. Если в момент запуска программы какая-либо из таблиц будет пуста - она заполнится стартовыми данными.