Create database PRG281Databse;

Use PRG281Databse;
Go

Create table Student(
	StudentNumber int not null Identity (1,1) primary key,
	Name varchar(30) not null,
	Surname varchar(30) not null,
	StudentImage varchar(100) not null,
	DOB Date,
	Gender varchar(10) not null,
	Phone varchar(15) not null,
	Address varchar(50) not null,
	ModuleCode varchar(30) not null foreign key references Modules(ModuleCode)
);

insert into Student values
('Emma', 'Johnson', ' ','2000-05-15',  'Female' ,'(555) 123-4567', '123 Main St', 'PRG281'),
('Liam', 'Smith', ' ' , ' 1999-08-21', 'Male', '(555) 987-6543', '456 Elm St', 'MAT281'),
('Olivia', 'Davis', ' ' ,'2001-03-10',  'Female', '(555) 555-1212', '789 Oak Ave', 'LPR281'),
('Noah', 'Miller',' ' , '1998-11-30',  'Male', '(555) 369-8521', '101 Pine Rd', 'SWT281'),
('Sophia', 'Wilson', ' ' ,'2002-07-08',  'Female', '(555) 246-8130', '222 Cedar Ln', 'MAT282'),
('Ethan', 'Brown', ' ' ,'1997-04-25',  'Male', '(555) 777-8888', '333 Birch Pl', 'IOT281'),
('Mia', 'Anderson',' ' , '2003-01-19',  'Female', '(555) 444-3322', '444 Maple Dr', 'DBD281'),
('Aiden', 'Taylor', ' ' , '1996-09-05', 'Male', '(555) 999-5555', '555 Spruce Ave', 'INL281'),
('Isabella', 'White', ' ' ,'2004-06-12',  'Female', '(555) 123-9876', '66 Willow Rd', 'INF281'),
('Jackson', 'Martinez', ' ' ,'1995-02-28',  'Male', '(555) 987-1234', '777 Redwood St', 'PRG282'),
('Isabella', 'White',' ' , '2004-06-12','Female', '(555) 123-9876', '66 Willow Rd', 'AUX381'),
('Jackson', 'Martinez',' ' , '1995-02-28',  'Male', '(555) 987-1234', '777 Redwood St', 'DBD282');

use PRG281Databse;
go

Create table Modules(
	ModuleCode varchar(30) not null primary key,
	ModuleName varchar(60) not null,
	ModuleDescription varchar(255) not null,
	Links varchar(200),
);

Insert into Modules values
('PRG281', 'Programming', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua', ''),
('MAT281', 'Mathematics', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua', ''),
('LPR281', 'Linear Programming', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua', ''),
('SWT281', 'Software Testing', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua', ''),
('MAT282', 'Programming', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua', ''),
('IOT281', 'Internet of Things', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua', ''),
('DBD281', 'Database Management', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua', ''),
('INL281', 'Innovation Leadership', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua', ''),
('INF281', 'Information Systems', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua', ''),
('PRG282', 'Programming', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua', ''),
('AUX381', 'Programming', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua', ''),
('DBD282', 'Database Management', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua', '');
