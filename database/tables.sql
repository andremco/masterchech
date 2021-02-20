create table Category(
	Id Int IDENTITY (1,1) Not Null,
	Name Varchar(100) Not Null,
	RegisterRecord DateTime Not Null,
	RegisterUpdate DateTime,
	CONSTRAINT PK_Category PRIMARY KEY CLUSTERED (Id) 
)

create table Recipe(
	Id Int IDENTITY (1,1) Not Null,
	CategoryId Int Not Null,
	Description Varchar(250) Not Null,
	RegisterRecord DateTime Not Null,
	RegisterUpdate DateTime,
	CONSTRAINT PK_Recipe PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT FK_Recipe_Category FOREIGN KEY (CategoryId) REFERENCES Category(Id) 
)