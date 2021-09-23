create table Candidates
(
	CandidateID int not null
		constraint PK_Candidates
			primary key,
	Name nvarchar(50) not null,
	[Phone number] varchar(50),
	Email nvarchar(50),
	PositionID int not null,
	Position nvarchar(50) not null,
	[Years of experience] float,
	City nvarchar(50),
	Remote bit,
	[Full time] bit,
	University nvarchar(50),
	Relocate bit,
	Skills nvarchar(max),
	[Other info] nvarchar(max)
)
go

create table Companies
(
	CompanyID int not null
		constraint PK_Companies
			primary key,
	[Company name] nvarchar(50) not null,
	Industry nvarchar(50),
	Activity nvarchar(50),
	[Amount of workers] int,
	Founded int,
	Requirements nvarchar(max),
	[Other info] nvarchar(max)
)
go

create table Positions
(
	PositionID int not null,
	Position nvarchar(50) not null,
	[Years of experience] float,
	CompanyID int not null,
	Company nvarchar(50) not null,
	City nvarchar(50),
	Salary nvarchar(50),
	[Starting date] date,
	[Master's degree] bit,
	PhD bit,
	[Partial remote authorized] bit,
	[Full remote] bit,
	[Link to position] nvarchar(max),
	[Other info needed] nvarchar(max)
)
go
