1. Создать базу данных с именем Lesson8

2. Создать таблицу пользователей.

CREATE TABLE [dbo].[Employees]
(
	[Id] INT ​IDENTITY​ (​1​,​​1​) NOT NULL, 
    [FirstName] NVARCHAR(MAX) NOT NULL, 
    [LastName] NVARCHAR(MAX) NOT NULL, 
    [Age] INT NOT NULL, 
    [Sallary] INT NULL, 
    [Department] NVARCHAR(MAX) NULL,
	CONSTRAINT[PK_dbo.Employees] PRIMARY KEY CLUSTERED([Id] ASC)
)

3. Создать таблицу подразделений.

CREATE TABLE [dbo].[Departments]
(
	[Id] INT IDENTITY​ (​1​,​​1​) NOT NULL, 
    [DepartmentName] NVARCHAR(MAX) NOT NULL,
	CONSTRAINT[PK_dbo.Departments] PRIMARY KEY CLUSTERED([Id] ASC)
)

4. Если в момент запуска программы какая-либо из таблиц будет пуста - она заполнится стартовыми данными.