use Crj2OTSNvh;

CREATE TABLE IF NOT EXISTS Department(
    ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Name text NOT NULL
);

CREATE TABLE IF NOT EXISTS User(
    ID int auto_increment PRIMARY KEY,
    FullName varchar(255),
    Email varchar(255) not null UNIQUE,
    Password varchar(255) not null,
    PhoneNumber varchar(255),
    Role ENUM('Administrator', 'Manager', 'Employee') NOT NULL,
    Wage double
);

CREATE TABLE IF NOT EXISTS UserDepartment (
	ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    DepartmentID INT NOT NULL,
    UserID INT NOT NULL,
    FOREIGN KEY (DepartmentID) REFERENCES Department(ID),
	FOREIGN KEY (UserID) REFERENCES User(ID)
);

CREATE TABLE IF NOT EXISTS Cancellation(
	ID INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
	Date date,
    State ENUM('Pending', 'Approved', 'Declined'),
    Subject text,
    Message text,
    
    UserID int not null,
    FOREIGN KEY (UserID) REFERENCES User(ID)
);

CREATE TABLE IF NOT EXISTS Shift(
	ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	Availability boolean,
    ShiftDate Date not null,
    StartTime varchar(100) not null,
    EndTime varchar(100) not null,
	ShiftType ENUM('Morning', 'Afternoon', 'Evening'),
    Attended tinyint(1) default FALSE,
    Cancelled tinyint(1) default FALSE,
    
    AssignedUserID int NOT NULL,
    DepartmentID int NOT NULL,
    FOREIGN KEY (AssignedUserID) references User(ID),
    FOREIGN KEY (DepartmentID) references Department(ID)
);

CREATE TABLE IF NOT EXISTS Availability(
	ID INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    UserID int NOT NULL,    
    State ENUM('Pending', 'Approved', 'Declined') DEFAULT 'Pending',
    Days text,
    IsWeekly int NOT NULL,
    IsMonthly int NOT NULL,
    
    FOREIGN KEY (UserID) REFERENCES User(ID)
);

CREATE TABLE IF NOT EXISTS Image(
    ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	UserID INT NOT NULL,
    UrlPath text NOT NULL,

    FOREIGN KEY (UserID) REFERENCES User(ID)
);

CREATE TABLE IF NOT EXISTS Stock(
	ID INT AUTO_INCREMENT not null PRIMARY KEY,
	Name text,
    Amount int not null,
    Price double not null,
    Availability bool DEFAULT FALSE,
    DepartmentID INT NOT NULL,
    
    FOREIGN KEY (DepartmentID) REFERENCES Department(ID)
);

