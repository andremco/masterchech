USE zuerotopbot;

-- drop table Description;
-- drop table category;

CREATE TABLE Category (
    Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Name varchar(100) NOT NULL,
    RegisterRecord DATETIME NOT NULL,
    RegisterUpdate DATETIME
);

CREATE TABLE Description (
    Id int NOT NULL IDENTITY(1,1),
    CategoryId int NOT NULL,
    Description varchar(250) NOT NULL,
    RegisterRecord DATETIME NOT NULL,
    RegisterUpdate DATETIME
    PRIMARY KEY (Id),
    FOREIGN KEY (CategoryId) REFERENCES Category(Id)
);