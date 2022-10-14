Create Table Pilot(
	IdPilot int identity(1000,1),
	NamePilot varchar(50) NOT NULL,
	CONSTRAINT PK_Pilot_IdPilot PRIMARY KEY (IdPilot),
	CONSTRAINT UN_Pilot_NamePilot Unique(NamePilot)
);
Create Table Team(
	IdTeam int identity(100,1) Not Null,
	NameTeam varchar(50) NOT NULL,
	CONSTRAINT PK_Team_IdTeam PRIMARY KEY (IdTeam),
	CONSTRAINT UN_Team_NameTeam Unique (NameTeam)
);
Create Table Car(
	IdCar int identity(2000,10),
	Year int Not Null,
	Model varchar(10)Not Null,
	Unit int Not Null,
	IdTeam int  Not Null,
	CONSTRAINT PK_IdCar_Car PRIMARY KEY (IdCar),
	FOREIGN KEY (IdTeam) references Team(IdTeam),
	Unique (Year,Model,Unit)
);
Create Table CarPilot(
	IdCar int Not Null,
	IdPilot int Not Null,
	EventDate date Not Null,
	CONSTRAINT PK_DateRun_CarPilot PRIMARY KEY (EventDate,IdCar,IdPilot),
	FOREIGN KEY (IdPilot) references Pilot(IdPilot),
	FOREIGN KEY (IdCar) references Car(IdCar),
);

select * from pilot
select * from Carpilot
select * from car
select * from team