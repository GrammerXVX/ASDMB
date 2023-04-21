--ИРЦ, МЦК, МГТС, МС, МТТС
CREATE TABLE Departments (
  Department_ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
  Department_Name VARCHAR(50) NOT NULL,
  Department_Street VARCHAR(100) NOT NULL,
  Department_City VARCHAR(100) NOT NULL,
  Department_Specification VARCHAR(500) NOT NULL,
  Department_PhoneNumber VARCHAR(20) NOT NULL,
  Employee_Count INT NOT NULL,
  CONSTRAINT CHK_Department_City CHECK (Department_City IN ('Минск', 'Брест', 'Витебск', 'Гомель','Гродно','Могилев'))
);
 
--ЦРУЭ (Цех расчёта за услуги электросвязи)
--ЦСЭ (Цех сопровождения и эксплуатации)
--ОРЗП (Отдел расчетов по заработной плате)
--ЦАП (Цех алгоритмов и программ)
CREATE TABLE Units (
    Unit_ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Unit_Name VARCHAR(50) NOT NULL,
    Unit_Description VARCHAR(500) NOT NULL, 
	Department_ID INT NOT NULL,
	CONSTRAINT FK_Unit_Department FOREIGN KEY (Department_ID) REFERENCES Departments (Department_ID)
);

CREATE TABLE Positions (
    Position_ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Position_Name VARCHAR(50) NOT NULL,
    Position_Description VARCHAR(500) NOT NULL, 
	Unit_ID INT NOT NULL,
	CONSTRAINT FK_Position_Unit FOREIGN KEY (Unit_ID) REFERENCES Units (Unit_ID)
);

CREATE TABLE Employees (
    Employee_ID INT PRIMARY KEY IDENTITY(1,1),
    First_Name VARCHAR(50) NOT NULL,
    Last_Name VARCHAR(50) NOT NULL,
    Unique_Number VARCHAR(50) NOT NULL,
    Position_ID INT NOT NULL,
    Department_ID INT NOT NULL,
    Birth_Date DATE,
    Email VARCHAR(50),
    PhoneNumber VARCHAR(20),
    CONSTRAINT FK_Employee_Position FOREIGN KEY (Position_ID) REFERENCES Positions (Position_ID),
    CONSTRAINT FK_Employee_Department FOREIGN KEY (Department_ID) REFERENCES Departments (Department_ID)
);

CREATE TABLE Categories (
	Category_ID INT PRIMARY KEY IDENTITY(1,1),
    Category_Type VARCHAR(50) NOT NULL,
);
CREATE TABLE Services (
    Service_ID INT PRIMARY KEY IDENTITY(1,1),
    Service_Name VARCHAR(50) NOT NULL,
    Service_Description TEXT,
    Price DECIMAL(8,2) NOT NULL,
	Service_Category_Type Bit,--1-ЮрЛицо 0-ФизЛицо Null-Для всех
    Category_ID INT NOT NULL,
    CONSTRAINT FK_Service_Category FOREIGN KEY (Category_ID) REFERENCES Categories (Category_ID)
);

CREATE TABLE Users (
    User_ID INT PRIMARY KEY IDENTITY(1,1),
    Login VARCHAR(50) NOT NULL,
    Password VARCHAR(50) NOT NULL,
	Employee_ID INT NOT NULL,
    Role VARCHAR(50) NOT NULL CHECK (Role IN ('admin', 'user','developer')),
	CONSTRAINT FK_User_Employee FOREIGN KEY (Employee_ID) REFERENCES Employees (Employee_ID)
);