use Crj2OTSNvh;

CREATE TABLE IF NOT EXISTS Department(
    ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Name text NOT NULL
);

CREATE TABLE User(
    ID int auto_increment PRIMARY KEY,
    FullName varchar(255),
    Email varchar(255) not null,
    Password varchar(255) not null,
    PhoneNumber varchar(255),
    Role ENUM('Administrator', 'Manager', 'Employee') NOT NULL,
    Wage float
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
    Email text,
    Subject text,
    Message text,
    
    UserID int not null,
    FOREIGN KEY (UserID) REFERENCES User(ID)
);

CREATE TABLE IF NOT EXISTS Shift(
	ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	Availability boolean,
    ShiftDate Date not null,
    StartTime Time not null,
    EndTime Time not null,
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
    Date date,
    Available bool NOT NULL DEFAULT FALSE,
    UserID int NOT NULL,
    
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
    Price DECIMAL not null,
    Amount int not null,
    Availability bool DEFAULT FALSE,
    DepartmentID INT NOT NULL,
    
    FOREIGN KEY (DepartmentID) REFERENCES Department(ID)
);

