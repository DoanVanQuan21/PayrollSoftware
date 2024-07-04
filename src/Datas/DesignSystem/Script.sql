/*
Created		7/3/2024
Modified		7/4/2024
Project		
Model			
Company		
Author		
Version		
Database		MS SQL 2005 
*/
create database TaskManagement
go
use TaskManagement
go

Create table [Project]
(
	[ProjectID] Integer identity(1,1) NOT NULL,
	[ProjectCode] Nvarchar(100) NULL,
	[ProjectName] Nvarchar(200) NULL,
	[CreatedDate] Datetime NULL,
	[EndDate] Datetime NULL,
	[UpdateDate] Datetime NULL,
	[Descriptions] Ntext NULL,
	[Status] Nvarchar(100) NULL,
	[Disable] Bit not null
Primary Key ([ProjectID])
) 
go

Create table [User]
(
	[UserID] Integer identity(1,1) NOT NULL,
	[UserCode] Nvarchar(100) NULL,
	[FirstName] Nvarchar(100) NULL,
	[LastName] Nvarchar(100) NULL,
	[DateOfBirth] Datetime NULL,
	[Address] Nvarchar(200) NULL,
	[Phone] Nvarchar(200) NULL,
	[Email] Nvarchar(200) NULL,
	[Role] Nvarchar(100) NULL,
	[IdentificationCard] Nvarchar(100) NULL,
	[JobPosition] Nvarchar(100) NULL,
	[CreatedDate] Datetime NULL,
	[Username] NVarchar(100) not null,
	[Password] NVarchar(100) not null,
	[EndDate] Datetime NULL,
	[LockAccount] Bit NULL,
Primary Key ([UserID])
) 
go

-- insert databse
INSERT INTO [User] ([UserCode],[Username],[Password], [FirstName], [LastName], [DateOfBirth], [Address], [Phone], [Email], [Role], [IdentificationCard], [JobPosition], [CreatedDate], [EndDate], [LockAccount])
VALUES 
    ('U001','trang','trang', N'Nguyễn', N'Văn Trang', '2002-05-10', N'123 Đường Lê Lợi, Quận 1, TP HCM', '0909123456', 'vana@example.com', 'User', '012345678', 'Software Developer', '2024-01-01', NULL, 0),
    ('U002','admin','admin', N'Đoàn', N'Văn Quân', '2002-05-21', N'Việt Tiến, Việt Yên, Bắc Giang', '0867687695', 'dvquan210502@gmail.com', 'Admin', '234567891', 'Tech Lead', '2023-12-01', NULL, 0),
    ('U003','dat','dat', N'Lê', N'Văn Đức Đạt', '2002-11-20', N'789 Đường Hai Bà Trưng, Quận 3, TP HCM', '0922123456', 'vanc@example.com', 'User', '345678912', 'Software Developer', '2023-11-15', NULL, 0),
    ('U004','hong','hong', N'Phạm', N'Thị Hồng', '2002-03-05', N'234 Đường Nguyễn Thái Học, Quận 1, TP HCM', '0933123456', 'thid@example.com', 'User', '456789123', 'Software Developer', '2023-10-20', NULL, 0),
    ('U005','trung','trung', N'Hoàng', N'Văn Trung', '2002-07-25', N'567 Đường Nguyễn Chí Thanh, Quận Đống Đa, Hà Nội', '0944123456', 'vane@example.com', 'User', '567891234', 'Software Developer', '2023-09-30', NULL, 0),
    ('U006','tuyet','tuyet', N'Vũ', N'Thị Tuyết', '2002-12-30', N'890 Đường Láng, Quận Đống Đa, Hà Nội', '0955123456', 'thif@example.com', 'Admin', '678912345', 'Software Developer', '2023-08-25', NULL, 0),
    ('U007','giang','giang', N'Ngô', N'Văn Giang', '2002-02-28', N'321 Đường Lý Thái Tổ, Quận 10, TP HCM', '0966123456', 'vang@example.com', 'User', '789123456', 'Software Developer', '2023-07-30', NULL, 0),
    ('U008','huyen','huyen', N'Đặng', N'Thị Huyền', '1986-04-14', N'654 Đường Điện Biên Phủ, Quận Bình Thạnh, TP HCM', '0977123456', 'thih@example.com', 'SuperAdmin', '891234567', 'Manager', '2023-06-10', NULL, 0),
    ('U009','hung','hung', N'Lý', N'Văn Hùng', '1989-06-19', N'987 Đường Phan Đăng Lưu, Quận Phú Nhuận, TP HCM', '0988123456', 'vani@example.com', 'User', '912345678', 'Tester', '2023-05-05', NULL, 0),
    ('U010','ngoc','ngoc', N'Đỗ', N'Thị Ngọc', '1993-09-01', N'654 Đường Nguyễn Văn Linh, Quận Hải Châu, Đà Nẵng', '0999123456', 'thik@example.com', 'User', '123456789', 'Tester', '2023-04-15', NULL, 0);
-- end


Create table [ProjectAssigned]
(
	[ProjectID] Integer NOT NULL,
	[UserID] Char(1) NOT NULL,
	[CreatedDate] Datetime NULL,
	[EndDate] Datetime NULL,
	[Role] Nvarchar(100) NULL,
	[Status] Nvarchar(100) NULL,
Primary Key ([ProjectID],[UserID])
) 
go

Create table [Task]
(
	[TaskID] Bigint identity(1,1) NOT NULL,
	[TaskCode] Nvarchar(100) NULL,
	[TaskName] Nvarchar(100) NULL,
	[Description] Ntext NULL,
	[CreatedDate] Datetime NULL,
	[UpdatedDate] Datetime NULL,
	[DueDate] Datetime NULL,
	[Status] Nvarchar(100) NULL,
	[Type] Nvarchar(100) NULL,
	[Priority] Nvarchar(100) NULL,
	[CompletionDate] Datetime NULL,
	[StartDate] Datetime NULL,
	[ProjectID] Integer NOT NULL foreign key([ProjectID]) References [Project]([ProjectID]) on update no action on delete no action,
	[UserID] Integer NOT NULL foreign key(UserID) References [User](UserID) on update no action on delete no action,
Primary Key ([TaskID])
) 
go

Create table [TaskAssigned]
(
	[UserID] Integer NOT NULL,
	[TaskID] Bigint NOT NULL,
	[CreatedDate] Datetime NULL,
	[StartDate] Datetime NULL,
	[CompletionDate] Datetime NULL,
	[Status] Datetime NULL,
	[Rate] Nvarchar(100) NULL,
	[Comment] Ntext NULL,
	[TaskParent] Bigint NULL,
Primary Key ([UserID],[TaskID])
) 
go

Create table [Comment]
(
	[CommentID] Bigint identity(1,1) NOT NULL,
	[CommentCode] Bigint NULL,
	[CommentContent] Nvarchar(1000) NULL,
	[CreatedDate] Datetime NULL,
	[UserID] Integer NOT NULL  foreign key(UserID) References [User](UserID) on update no action on delete no action,
	[TaskID] Bigint NOT NULL foreign key([TaskID]) References [Task]([TaskID]) on update no action on delete no action,
	[ProjectID] Integer NOT NULL foreign key([ProjectID]) References [Project]([ProjectID]) on update no action on delete no action,
Primary Key ([CommentID])
) 
go

Create table [ActivityLog]
(
	[ActivityLogID] Bigint identity(1,1) NOT NULL,
	[Action] Nvarchar(200) NULL,
	[FromStatus] Nvarchar(100) NULL,
	[ToStatus] Nvarchar(100) NULL,
	[UpdatedDate] Datetime NULL,
	[TaskID] Bigint NOT NULL foreign key([TaskID]) References [Task]([TaskID]) on update no action on delete no action,
	[UserID] Integer NOT NULL  foreign key(UserID) References [User](UserID) on update no action on delete no action,
Primary Key ([ActivityLogID])
) 
go


Set quoted_identifier on
go


Set quoted_identifier off
go


