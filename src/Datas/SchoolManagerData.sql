/*
Created		3/2/2024
Modified		3/2/2024
Project		
Model			
Company		
Author		
Version		
Database		MS SQL 2005 
*/



CREATE DATABASE SchoolManager
GO
USE SchoolManager
Go

Create table [Student]
(
	[StudentID] Bigint IDENTITY(1,1) NOT NULL,
	[StudentCode] Varchar(10) NULL,
	[StudentFullname] Nvarchar(100) NULL,
	[StudentGender] Bit NULL,
	[StudentBirthday] Date NULL,
	[StudentPhone] Varchar(11) NULL,
	[StudentAddress] Nvarchar(100) NULL,
	[ClassroomID] Bigint NOT NULL,
Primary Key ([StudentID])
) 
go

Create table [Classroom]
(
	[ClassroomID] Bigint IDENTITY(1,1) NOT NULL,
	[ClassroomCode] Varchar(10) NULL,
	[ClassroomName] Nvarchar(100) NULL,
Primary Key ([ClassroomID])
) 
go

Create table [Subject]
(
	[SubjectID] Bigint IDENTITY(1,1) NOT NULL,
	[SubjectCode] nvarchar(10) NULL,
	[SubjectName] Nvarchar(100) NULL,
Primary Key ([SubjectID])
) 
go

Create table [Department]
(
	[DepartmentID] Bigint IDENTITY(1,1) NOT NULL,
	[DepartmentCode] Varchar(10) NULL,
	[DepartmentName] Nvarchar(100) NULL,
	[HeadOfDepartment] Bigint NULL,
Primary Key ([DepartmentID])
) 
go

Create table [AcademicTranscript]
(
	[AcademicTranscriptID] Bigint IDENTITY(1,1) NOT NULL,
	[AcademicTranscriptCode] Varchar(10) NULL,
	[PointOne] Float NULL,
	[PointTwo] Float NULL,
	[PontThree] Float NULL,
	[PointFour] Float NULL,
	[PointFive] Float NULL,
	[TestPointOne] Float NULL,
	[TestPointTwo] Float NULL,
	[TestPointThree] Float NULL,
	[FinalTestPoint] Float NULL,
	[AverageScore] Float NULL,
	[StudentID] Bigint NOT NULL,
	[SubjectID] Bigint NOT NULL,
Primary Key ([AcademicTranscriptID])
) 
go

Create table [Assignment]
(
	[Position] Nvarchar(10) NULL,
	[StartDate] Date NULL,
	[EndDate] Date NULL,
	[Status] Nvarchar(100) NULL,
	[UserID] Bigint NOT NULL,
	[ClassroomID] Bigint NOT NULL,
	[CourseID] Bigint NOT NULL,
Primary Key ([UserID],[ClassroomID])
) 
go

Create table [Course]
(
	[CourseID] Bigint IDENTITY(1,1) NOT NULL,
	[CourseCode] Varchar(10) NULL,
	[CourseContent] Ntext NULL,
	[NumberLesson] Integer NULL,
	[SubjectID] Bigint NOT NULL,
	[DepartmentID] Bigint NOT NULL,
Primary Key ([CourseID])
) 
go

Create table [Shecdule]
(
	[ShecduleID] Bigint IDENTITY(1,1) NOT NULL,
	[ShecduleCode] Varchar(50) NULL,
Primary Key ([ShecduleID])
) 
go

Create table [Users]
(
	[UserID] Bigint IDENTITY(1,1) NOT NULL,
	[DepartmentID] Bigint NOT NULL,
	[UserCode] Varchar(10) NULL,
	[Surname] Nvarchar(100) NULL,
	[Name] Varchar(100) NULL,
	[Gender] Bit NULL,
	[Birthday] Date NULL,
	[PhoneNumber] Varchar(11) NULL,
	[Address] Nvarchar(100) NULL,
	[Email] Varchar(100) NULL,
	[Image] Nvarchar(MAX) Null,
	[Username] Varchar(100) NULL,
	[Password] Varchar(150) NULL,
	[Cartificate] Nvarchar(150) NULL,
	[SpecializedIn] Nvarchar(150) NULL,
	[Role] Varchar(100) NULL,
	[State] Nvarchar(100) NULL,
	[DateStartWork] Date NULL,
	[DateOff] Date NULL,
Primary Key ([UserID])
) 
go


Set quoted_identifier on
go


Set quoted_identifier off
go







-- generate data record

--DEPARTMENT TABLE
DECLARE @counter INT = 1
DECLARE @DepartmentCode VARCHAR(10)
DECLARE @DepartmentName NVARCHAR(100)
DECLARE @HeadOfDepartment BIGINT

WHILE @counter <= 100
BEGIN
    SET @DepartmentCode = 'DEP' + RIGHT('0000' + CAST(@counter AS VARCHAR(3)), 3)
    SET @DepartmentName = N'Tên Khoa ' + CAST(@counter AS NVARCHAR(3))
    SET @HeadOfDepartment = CAST(RAND() * 100 AS BIGINT) + 1
    
    INSERT INTO Department (DepartmentCode, DepartmentName, HeadOfDepartment)
    VALUES (@DepartmentCode, @DepartmentName, @HeadOfDepartment)
    
    SET @counter = @counter + 1
END


-- CLASSROOM TABLE
DECLARE @counter INT = 1
DECLARE @ClassroomCode VARCHAR(10)
DECLARE @ClassroomName NVARCHAR(100)

WHILE @counter <= 100
BEGIN
    SET @ClassroomCode = 'CR' + RIGHT('0000' + CAST(@counter AS VARCHAR(3)), 3)
    SET @ClassroomName = N'Tên Lớp ' + CAST(@counter AS NVARCHAR(3))
    
    INSERT INTO Classroom (ClassroomCode, ClassroomName)
    VALUES (@ClassroomCode, @ClassroomName)
    
    SET @counter = @counter + 1
END





-- STUDENT TABLE
DECLARE @counter INT = 1
DECLARE @StudentCode VARCHAR(10)
DECLARE @StudentFullname NVARCHAR(100)
DECLARE @StudentGender BIT
DECLARE @StudentBirthday DATE
DECLARE @StudentPhone VARCHAR(11)
DECLARE @StudentAddress NVARCHAR(100)
DECLARE @ClassroomID BIGINT

WHILE @counter <= 100
BEGIN
    SET @StudentCode = 'STD' + RIGHT('0000' + CAST(@counter AS VARCHAR(3)), 3)
    SET @StudentFullname = N'Họ Tên Sinh Viên ' + CAST(@counter AS NVARCHAR(3))
    SET @StudentGender = CAST(@counter % 2 AS BIT)
    SET @StudentBirthday = DATEADD(YEAR, -CAST(RAND() * 20 AS INT), GETDATE())
    SET @StudentPhone = '0123456789' + RIGHT('00' + CAST(@counter AS VARCHAR(3)), 3)
    SET @StudentAddress = N'Địa chỉ sinh viên ' + CAST(@counter AS NVARCHAR(3))
    SET @ClassroomID = CAST(RAND() * 10 AS BIGINT) + 1
    
    INSERT INTO Student (StudentCode, StudentFullname, StudentGender, StudentBirthday, StudentPhone, StudentAddress, ClassroomID)
    VALUES (@StudentCode, @StudentFullname, @StudentGender, @StudentBirthday, @StudentPhone, @StudentAddress, @ClassroomID)
    
    SET @counter = @counter + 1
END




-- SUBJECT TABLE

DECLARE @counter INT = 1
DECLARE @SubjectCode NVARCHAR(10)
DECLARE @SubjectName NVARCHAR(100)

WHILE @counter <= 100
BEGIN
    SET @SubjectCode = 'SUB' + RIGHT('0000' + CAST(@counter AS VARCHAR(3)), 3)
    SET @SubjectName = N'Tên Môn Học ' + CAST(@counter AS NVARCHAR(3))
    
    INSERT INTO Subject (SubjectCode, SubjectName)
    VALUES (@SubjectCode, @SubjectName)
    
    SET @counter = @counter + 1
END





-- ACADEMIC TRANSCRIPT TABLE

DECLARE @counter INT = 1
DECLARE @AcademicTranscriptCode VARCHAR(10)
DECLARE @PointOne FLOAT
DECLARE @PointTwo FLOAT
DECLARE @PontThree FLOAT
DECLARE @PointFour FLOAT
DECLARE @PointFive FLOAT
DECLARE @TestPointOne FLOAT
DECLARE @TestPointTwo FLOAT
DECLARE @TestPointThree FLOAT
DECLARE @FinalTestPoint FLOAT
DECLARE @AverageScore FLOAT
DECLARE @StudentID BIGINT
DECLARE @SubjectID BIGINT

WHILE @counter <= 100
BEGIN
    SET @AcademicTranscriptCode = 'AT' + RIGHT('0000' + CAST(@counter AS VARCHAR(3)), 3)
    SET @PointOne = RAND() * 10
    SET @PointTwo = RAND() * 10
    SET @PontThree = RAND() * 10
    SET @PointFour = RAND() * 10
    SET @PointFive = RAND() * 10
    SET @TestPointOne = RAND() * 10
    SET @TestPointTwo = RAND() * 10
    SET @TestPointThree = RAND() * 10
    SET @FinalTestPoint = RAND() * 10
    SET @AverageScore = ( @PointOne + @PointTwo + @PontThree + @PointFour + @PointFive + @TestPointOne + @TestPointTwo + @TestPointThree + @FinalTestPoint ) / 9
    SET @StudentID = CAST(RAND() * 100 AS BIGINT) + 1
    SET @SubjectID = CAST(RAND() * 100 AS BIGINT) + 1
    
    INSERT INTO AcademicTranscript (AcademicTranscriptCode, PointOne, PointTwo, PontThree, PointFour, PointFive, TestPointOne, TestPointTwo, TestPointThree, FinalTestPoint, AverageScore, StudentID, SubjectID)
    VALUES (@AcademicTranscriptCode, @PointOne, @PointTwo, @PontThree, @PointFour, @PointFive, @TestPointOne, @TestPointTwo, @TestPointThree, @FinalTestPoint, @AverageScore, @StudentID, @SubjectID)
    
    SET @counter = @counter + 1
END




--COURSE TABLE

DECLARE @counter INT = 1
DECLARE @CourseCode VARCHAR(10)
DECLARE @CourseContent NVARCHAR(MAX)
DECLARE @NumberLesson INT
DECLARE @SubjectID BIGINT
DECLARE @DepartmentID BIGINT

WHILE @counter <= 100
BEGIN
    SET @CourseCode = 'C' + RIGHT('0000' + CAST(@counter AS VARCHAR(3)), 3)
    SET @CourseContent = N'Nội dung khóa học ' + CAST(@counter AS NVARCHAR(3))
    SET @NumberLesson = CAST(RAND() * 30 AS INT)
    SET @SubjectID = CAST(RAND() * 100 AS BIGINT) + 1
    SET @DepartmentID = CAST(RAND() * 10 AS BIGINT) + 1
    
    INSERT INTO Course (CourseCode, CourseContent, NumberLesson, SubjectID, DepartmentID)
    VALUES (@CourseCode, @CourseContent, @NumberLesson, @SubjectID, @DepartmentID)
    
    SET @counter = @counter + 1
END




-- ASSIGNMENT TABLE
DECLARE @counter INT = 1
DECLARE @Position NVARCHAR(10)
DECLARE @StartDate DATE
DECLARE @EndDate DATE
DECLARE @Status NVARCHAR(100)
DECLARE @UserID BIGINT
DECLARE @ClassroomID BIGINT
DECLARE @CourseID BIGINT

WHILE @counter <= 100
BEGIN
    SET @Position = CASE WHEN @counter % 2 = 0 THEN N'Giáo viên' ELSE N'Trợ giảng' END
    SET @StartDate = DATEADD(DAY, -CAST(RAND() * 365 AS INT), GETDATE())
    SET @EndDate = DATEADD(DAY, CAST(RAND() * 365 AS INT), @StartDate)
    SET @Status = CASE WHEN @counter % 2 = 0 THEN N'Active' ELSE N'Inactive' END
    SET @UserID = CAST(RAND() * 100 AS BIGINT) + 1
    SET @ClassroomID = CAST(RAND() * 100 AS BIGINT) + 1
    SET @CourseID = CAST(RAND() * 100 AS BIGINT) + 1
    
    INSERT INTO Assignment (Position, StartDate, EndDate, Status, UserID, ClassroomID, CourseID)
    VALUES (@Position, @StartDate, @EndDate, @Status, @UserID, @ClassroomID, @CourseID)
    
    SET @counter = @counter + 1
END


-- SHECDULE TABLE
DECLARE @counter INT = 1
DECLARE @ShecduleCode VARCHAR(50)

WHILE @counter <= 100
BEGIN
    SET @ShecduleCode = 'SCH' + RIGHT('0000' + CAST(@counter AS VARCHAR(3)), 3)
    
    INSERT INTO Shecdule (ShecduleCode)
    VALUES (@ShecduleCode)
    
    SET @counter = @counter + 1
END



--USER TABLE


--DECLARE @counter INT = 1
--DECLARE @DepartmentID BIGINT
--DECLARE @UserCode VARCHAR(10)
--DECLARE @Surname NVARCHAR(1)
--DECLARE @Name VARCHAR(100)
--DECLARE @Gender BIT
--DECLARE @Birthday DATE
--DECLARE @PhoneNumber VARCHAR(11)
--DECLARE @Address NVARCHAR(100)
--DECLARE @Email VARCHAR(100)
--DECLARE @Username VARCHAR(100)
--DECLARE @Password VARCHAR(150)
--DECLARE @Cartificate NVARCHAR(150)
--DECLARE @SpecializedIn NVARCHAR(150)
--DECLARE @Role VARCHAR(100)
--DECLARE @State NVARCHAR(100)
--DECLARE @DateStartWork DATE
--DECLARE @DateOff DATE

--WHILE @counter <= 100
--BEGIN
--    SET @DepartmentID = CAST(RAND() * 10 AS BIGINT) + 1
--    SET @UserCode = 'USR' + RIGHT('000' + CAST(@counter AS VARCHAR(3)), 3)
--    SET @Surname = N'Họ ' + CHAR(65 + @counter % 26)
--    SET @Name = N'Tên ' + CHAR(97 + @counter % 26)
--    SET @Gender = CAST(@counter % 2 AS BIT)
--    SET @Birthday = DATEADD(YEAR, -CAST(RAND() * 30 AS INT), GETDATE())
--    SET @PhoneNumber = '0987654321' + RIGHT('00' + CAST(@counter AS VARCHAR(3)), 3)
--    SET @Address = N'Địa chỉ ' + CAST(@counter AS NVARCHAR(3))
--    SET @Email = 'user' + RIGHT('00' + CAST(@counter AS VARCHAR(3)), 3) + '@example.com'
--    SET @Username = 'admin' + RIGHT('00' + CAST(@counter AS VARCHAR(3)), 3)
--    SET @Password = '123456789'
--    SET @Cartificate = N'Chứng chỉ ' + CAST(@counter AS NVARCHAR(3))
--    SET @SpecializedIn = N'Chuyên ngành ' + CAST(@counter AS NVARCHAR(3))
--    SET @Role = 'admin'
--    SET @State = CASE WHEN @counter % 2 = 0 THEN N'Hoạt động' ELSE N'Nghỉ làm' END
--    SET @DateStartWork = DATEADD(MONTH, -CAST(RAND() * 24 AS INT), GETDATE())
--    SET @DateOff = NULL
    
--    INSERT INTO Users (DepartmentID, UserCode, Surname, Name, Gender, Birthday, PhoneNumber, Address, Email, Username, Password, Cartificate, SpecializedIn, Role, State, DateStartWork, DateOff)
--    VALUES (@DepartmentID, @UserCode, @Surname, @Name, @Gender, @Birthday, @PhoneNumber, @Address, @Email, @Username, @Password, @Cartificate, @SpecializedIn, @Role, @State, @DateStartWork, @DateOff)
    
--    SET @counter = @counter + 1
--END


  INSERT INTO Users (DepartmentID, UserCode, Surname, Name, Gender, Birthday, PhoneNumber, Address, Email, Username, Password, Cartificate, SpecializedIn, Role, State, DateStartWork, DateOff)
VALUES
(1, 'GV202001', N'Nguyễn', N'Văn A', 1, '1990-01-15', '0901234567', N'Số 10, Đường ABC, Quận XYZ, Thành phố Hồ Chí Minh', 'nguyenvana@example.com', 'nguyenvana', '123', N'Trình độ chuyên môn', N'Toán', 'teacher', N'Đang làm việc', '2020-01-30', NULL),
(1, 'GV202002', N'Trần', N'Thị B', 0, '1995-05-20', '0987654321', N'Số 20, Đường XYZ, Quận ABC, Thành phố Hà Nội', 'tranthib@example.com', 'tranthib', '123', N'Trình độ chuyên môn', N'Toán', 'teacher', N'Đang làm việc', '2019-07-01', NULL),
(1, 'GV202003', N'Lê', N'Quang C', 1, '1988-09-10', '0912345678', N'Số 30, Đường XYZ, Quận DEF, Thành phố Đà Nẵng', 'lequangc@example.com', 'lequangc', '123', N'Trình độ chuyên môn', N'Tin', 'teacher', N'Đang làm việc', '2018-03-15', NULL),
(2, 'GV202004', N'Phạm', N'Thị D', 0, '1993-12-25', '0978123456', N'Số 40, Đường DEF, Quận MNO, Thành phố Cần Thơ', 'phamthid@example.com', 'phamthid', '123', N'Trình độ chuyên môn', N'Ngữ văn', 'teacher', N'Đang làm việc', '2021-02-10', NULL),
(2, 'GV202005', N'Hoàng', N'Văn E', 1, '1997-08-05', '0923456789', N'Số 50, Đường KLM, Quận PQR, Thành phố Hải Phòng', 'hoangvane@example.com', 'hoangvane', '123', N'Trình độ chuyên môn', N'Ngữ văn', 'teacher', N'Đang làm việc', '2017-11-20', NULL),
(1, 'GV202006', N'Mai', N'Thị F', 0, '1991-04-30', '0965432109', N'Số 60, Đường GHI, Quận JKL, Thành phố Vũng Tàu', 'maithif@example.com', 'maithif', '123', N'Trình độ chuyên môn', N'Lịch sử', 'teacher', N'Đang làm việc', '2016-06-05', NULL),
(1, 'GV202007', N'Đỗ', N'Quang G', 1, '1985-02-20', '0934567890', N'Số 70, Đường NOP, Quận STU, Thành phố Nha Trang', 'doquangg@example.com', 'doquangg', '123', N'Trình độ chuyên môn', N'Toán', 'teacher', N'Đang làm việc', '2015-09-30', NULL),
(2, 'GV202008', N'Lý', N'Thị H', 0, '1990-10-10', '0945678901', N'Số 80, Đường UVW, Quận XYZ, Thành phố Đồng Nai', 'lythih@example.com', 'lythih', '123', N'Trình độ chuyên môn', N'Giáo dục công dân', 'teacher', N'Đang làm việc', '2014-12-15', NULL),
(2, 'GV202009', N'Vũ', N'Quang I', 1, '1987-07-15', '0956789012', N'Số 90, Đường KLM, Quận PQR, Thành phố Hà Tĩnh', 'vuquangi@example.com', 'vuquangi', '123', N'Trình độ chuyên môn', N'Thể dục', 'teacher', N'Đang làm việc', '2013-03-20', NULL),
(3, 'GV202010', N'Ngô', N'Thị K', 0, '1994-06-20', '0987890123', N'Số 100, Đường JKL, Quận NOP, Thành phố Ninh Bình', 'ngthik@example.com', 'ngthik', '123', N'Trình độ chuyên môn', N'Tiếng anh', 'teacher', N'Đang làm việc', '2012-05-25', NULL),
(3, 'GV202011', N'Phan', N'Quang L', 1, '1989-03-25', '0918901234', N'Số 110, Đường QRS, Quận UVW, Thành phố Nam Định', 'phanquangl@example.com', 'phanquangl', '123', N'Trình độ chuyên môn', N'Tiếng anh', 'teacher', N'Đang làm việc', '2011-08-30', NULL),
(4, 'GV202012', N'Dương', N'Thị M', 0, '1992-11-30', '0945678901', N'Số 120, Đường TUV, Quận XYZ, Thành phố Hải Dương', 'duongthim@example.com', 'duongthim', '123', N'Trình độ chuyên môn', N'Tiếng anh', 'teacher', N'Đang làm việc', '2010-11-15', NULL),
(3, 'GV202013', N'Đinh', N'Quang N', 1, '1986-09-05', '0934567890', N'Số 130, Đường WXY, Quận STU, Thành phố Quảng Ngãi', 'dinhquangn@example.com', 'dinhquangn', '123', N'Trình độ chuyên môn', N'Toán', 'teacher', N'Đang làm việc', '2009-07-20', NULL),
(4, 'GV202014', N'Hoàng', N'Thị O', 0, '1993-05-10', '0923456789', N'Số 140, Đường XYZ, Quận DEF, Thành phố Thanh Hóa', 'hoangthio@example.com', 'hoangthio', '123', N'Trình độ chuyên môn', N'Lý', 'teacher', N'Đang làm việc', '2008-06-05', NULL),
(4, 'GV202015', N'Lâm', N'Quang P', 1, '1988-02-15', '0912345678', N'Số 150, Đường QRS, Quận NOP, Thành phố Phú Yên', 'lamquangp@example.com', 'lamquangp', '123', N'Trình độ chuyên môn', N'Lý', 'teacher', N'Đang làm việc', '2007-09-30', NULL),
(4, 'GV202016', N'Võ', N'Quang Q', 1, '1991-10-25', '0901234567', N'Số 160, Đường ABC, Quận XYZ, Thành phố Hồ Chí Minh', 'voquangq@example.com', 'voquangq', '123', N'Trình độ chuyên môn', N'Lập trình viên', 'teacher', N'Đang làm việc', '2018-01-01', NULL),
(3, 'GV202017', N'Đặng', N'Thị R', 0, '1996-08-30', '0987654321', N'Số 170, Đường XYZ, Quận ABC, Thành phố Hà Nội', 'dangthir@example.com', 'dangthir', '123', N'Trình độ chuyên môn', N'Kế toán', 'teacher', N'Đang làm việc', '2019-03-01', NULL),
(3, 'GV202018', N'Mạc', N'Quang S', 1, '1989-04-15', '0912345678', N'Số 180, Đường XYZ, Quận DEF, Thành phố Đà Nẵng', 'macquangs@example.com', 'macquangs', '123', N'Trình độ chuyên môn', N'Quản lý dự án', 'teacher', N'Đang làm việc', '2017-06-15', NULL),
(4, 'GV202019', N'Trần', N'Thị T', 0, '1994-01-20', '0978123456', N'Số 190, Đường DEF, Quận MNO, Thành phố Cần Thơ', 'tranthit@example.com', 'tranthit', '123', N'Trình độ chuyên môn', N'Nhân sự', 'teacher', N'Đang làm việc', '2020-02-10', NULL),
(5, 'GV202020', N'Hoàng', N'Văn U', 1, '1998-06-05', '0923456789', N'Số 200, Đường KLM, Quận PQR, Thành phố Hải Phòng', 'hoangvanu@example.com', 'hoangvanu', '123', N'Trình độ chuyên môn', N'Lập trình viên', 'teacher', N'Đang làm việc', '2016-09-20', NULL),
(5, 'GV202021', N'Mai', N'Thị V', 0, '1992-03-30', '0965432109', N'Số 210, Đường GHI, Quận JKL, Thành phố Vũng Tàu', 'maithiv@example.com', 'maithiv', '123', N'Trình độ chuyên môn', N'Kế toán', 'teacher', N'Đang làm việc', '2015-12-05', NULL),
(5, 'GV202022', N'Đoàn', N'Quang X', 1, '1986-11-20', '0934567890', N'Số 220, Đường NOP, Quận STU, Thành phố Nha Trang', 'doanquangx@example.com', 'doanquangx', '123', N'Trình độ chuyên môn', N'Quản lý dự án', 'teacher', N'Đang làm việc', '2014-10-30', NULL),
(6, 'GV202023', N'Lê', N'Thị Y', 0, '1991-09-10', '0945678901', N'Số 230, Đường UVW, Quận XYZ, Thành phố Đồng Nai', 'lethiy@example.com', 'lethiy', '123', N'Trình độ chuyên môn', N'Nhân sự', 'teacher', N'Đang làm việc', '2013-08-15', NULL),
(6, 'GV202024', N'Vương', N'Quang Z', 1, '1988-07-15', '0956789012', N'Số 240, Đường KLM, Quận PQR, Thành phố Hà Tĩnh', 'vuongquangz@example.com', 'vuongquangz', '123', N'Trình độ chuyên môn', N'Lập trình viên', 'teacher', N'Đang làm việc', '2012-05-20', NULL),
(6, 'GV202025', N'Nguyễn', N'Thị X', 0, '1995-06-20', '0987890123', N'Số 250, Đường JKL, Quận NOP, Thành phố Ninh Bình', 'nguyenthix@example.com', 'nguyenthix', '123', N'Trình độ chuyên môn', N'Kế toán', 'teacher', N'Đang làm việc', '2011-04-25', NULL),
(5, 'GV202026', N'Phạm', N'Quang W', 1, '1990-03-25', '0918901234', N'Số 260, Đường QRS, Quận UVW, Thành phố Nam Định', 'phamquangw@example.com', 'phamquangw', '123', N'Trình độ chuyên môn', N'Quản lý dự án', 'teacher', N'Đang làm việc', '2010-02-20', NULL),
(5, 'GV202027', N'Lý', N'Thị B', 0, '1993-11-30', '0945678901', N'Số 270, Đường TUV, Quận XYZ, Thành phố Hải Dương', 'lythib@example.com', 'lythib', '123', N'Trình độ chuyên môn', N'Nhân sự', 'teacher', N'Đang làm việc', '2009-09-15', NULL),
(6, 'GV202028', N'Vũ', N'Quang C', 1, '1987-09-05', '0934567890', N'Số 280, Đường WXY, Quận STU, Thành phố Quảng Ngãi', 'vuquangc@example.com', 'vuquangc', '123', N'Trình độ chuyên môn', N'Lập trình viên', 'teacher', N'Đang làm việc', '2008-07-20', NULL),
(7, 'GV202029', N'Ngô', N'Thị M', 0, '1994-05-10', '0923456789', N'Số 290, Đường XYZ, Quận DEF, Thành phố Thanh Hóa', 'ngothim@example.com', 'ngothim', '123', N'Trình độ chuyên môn', N'Kế toán', 'teacher', N'Đang làm việc', '2007-06-05', NULL),
(7, 'GV202030', N'Lâm', N'Quang N', 1, '1988-02-15', '0912345678', N'Số 300, Đường QRS, Quận NOP, Thành phố Phú Yên', 'lamquangn@example.com', 'lamquangn', '123', N'Trình độ chuyên môn', N'Quản lý dự án', 'teacher', N'Đang làm việc', '2006-09-30', NULL),
(7, 'GV202031', N'Võ', N'Thị G', 0, '1993-07-20', '0901234567', N'Số 310, Đường ABC, Quận XYZ, Thành phố Hồ Chí Minh', 'vothig@example.com', 'vothig', '123', N'Trình độ chuyên môn', N'Nhân sự', 'teacher', N'Đang làm việc', '2015-01-01', NULL),
(7, 'GV202032', N'Đặng', N'Quang H', 1, '1998-04-30', '0987654321', N'Số 320, Đường XYZ, Quận ABC, Thành phố Hà Nội', 'dangquangh@example.com', 'dangquangh', '123', N'Trình độ chuyên môn', N'Lập trình viên', 'teacher', N'Đang làm việc', '2014-03-01', NULL),
(8, 'GV202033', N'Mạc', N'Thị I', 0, '1992-02-15', '0912345678', N'Số 330, Đường XYZ, Quận DEF, Thành phố Đà Nẵng', 'macthii@example.com', 'macthii', '123', N'Trình độ chuyên môn', N'Kế toán', 'teacher', N'Đang làm việc', '2013-06-15', NULL),
(8, 'GV202034', N'Trần', N'Quang J', 1, '1987-11-10', '0978123456', N'Số 340, Đường DEF, Quận MNO, Thành phố Cần Thơ', 'tranquangj@example.com', 'tranquangj', '123', N'Trình độ chuyên môn', N'Quản lý dự án', 'teacher', N'Đang làm việc', '2012-02-10', NULL),
(8, 'GV202035', N'Hoàng', N'Thị K', 0, '1996-08-05', '0923456789', N'Số 350, Đường KLM, Quận PQR, Thành phố Hải Phòng', 'hoangthik@example.com', 'hoangthik', '123', N'Trình độ chuyên môn', N'Nhân sự', 'teacher', N'Đang làm việc', '2011-09-20', NULL),
(8, 'GV202036', N'Mai', N'Quang L', 1, '1990-06-10', '0965432109', N'Số 360, Đường GHI, Quận JKL, Thành phố Vũng Tàu', 'maiquangl@example.com', 'maiquangl', '123', N'Trình độ chuyên môn', N'Lập trình viên', 'teacher', N'Đang làm việc', '2010-12-05', NULL),
(9, 'GV202037', N'Đoàn', N'Thị M', 0, '1995-03-20', '0934567890', N'Số 370, Đường NOP, Quận STU, Thành phố Nha Trang', 'doanthim@example.com', 'doanthim', '123', N'Trình độ chuyên môn', N'Kế toán', 'teacher', N'Đang làm việc', '2009-11-30', NULL),
(9, 'GV202038', N'Lê', N'Quang N', 1, '1989-09-15', '0945678901', N'Số 380, Đường UVW, Quận XYZ, Thành phố Đồng Nai', 'lequangn@example.com', 'lequangn', '123', N'Trình độ chuyên môn', N'Quản lý dự án', 'teacher', N'Đang làm việc', '2008-08-15', NULL),
(9, 'GV202039', N'Vương', N'Thị O', 0, '1994-07-20', '0956789012', N'Số 390, Đường KLM, Quận PQR, Thành phố Hà Tĩnh', 'vuongthio@example.com', 'vuongthio', '123', N'Trình độ chuyên môn', N'Nhân sự', 'teacher', N'Đang làm việc', '2007-05-20', NULL),
(9, 'GV202040', N'Nguyễn', N'Quang P', 1, '1988-05-25', '0987890123', N'Số 400, Đường JKL, Quận NOP, Thành phố Ninh Bình', 'nguyenquangp@example.com', 'nguyenquangp', '123', N'Trình độ chuyên môn', N'Lập trình viên', 'teacher', N'Đang làm việc', '2006-04-25', NULL),
(10, 'GV202041', N'Phạm', N'Thị Q', 0, '1993-03-30', '0918901234', N'Số 410, Đường QRS, Quận UVW, Thành phố Nam Định', 'phamthiq@example.com', 'phamthiq', '123', N'Trình độ chuyên môn', N'Kế toán', 'teacher', N'Đang làm việc', '2005-02-20', NULL),
(10, 'GV202042', N'Lý', N'Quang R', 1, '1988-12-05', '0945678901', N'Số 420, Đường TUV, Quận XYZ, Thành phố Hải Dương', 'lyquangr@example.com', 'lyquangr', '123', N'Trình độ chuyên môn', N'Quản lý dự án', 'teacher', N'Đang làm việc', '2004-09-15', NULL),
(10, 'GV202043', N'Vũ', N'Thị S', 0, '1995-10-10', '0934567890', N'Số 430, Đường WXY, Quận STU, Thành phố Quảng Ngãi', 'vuthis@example.com', 'vuthis', '123', N'Trình độ chuyên môn', N'Nhân sự', 'teacher', N'Đang làm việc', '2003-07-20', NULL),
(10, 'GV202044', N'Ngô', N'Quang T', 1, '1989-08-15', '0923456789', N'Số 440, Đường XYZ, Quận DEF, Thành phố Thanh Hóa', 'ngoquangt@example.com', 'ngoquangt', '123', N'Trình độ chuyên môn', N'Lập trình viên', 'teacher', N'Đang làm việc', '2002-06-05', NULL),
(10, 'GV202045', N'Lâm', N'Thị U', 0, '1996-06-20', '0912345678', N'Số 450, Đường QRS, Quận NOP, Thành phố Phú Yên', 'lamthiu@example.com', 'lamthiu', '123', N'Trình độ chuyên môn', N'Kế toán', 'teacher', N'Đang làm việc', '2001-03-30', NULL),
(11, 'GV202046', N'Võ', N'Quang V', 1, '1991-04-25', '0901234567', N'Số 460, Đường ABC, Quận XYZ, Thành phố Hồ Chí Minh', 'voquangv@example.com', 'voquangv', '123', N'Trình độ chuyên môn', N'Quản lý dự án', 'teacher', N'Đang làm việc', '2000-01-01', NULL),
(11, 'GV202047', N'Đặng', N'Thị W', 0, '1996-01-30', '0987654321', N'Số 470, Đường XYZ, Quận ABC, Thành phố Hà Nội', 'dangthiw@example.com', 'dangthiw', '123', N'Trình độ chuyên môn', N'Nhân sự', 'teacher', N'Đang làm việc', '1999-03-01', NULL),
(11, 'GV202048', N'Mạc', N'Quang X', 1, '1989-09-15', '0912345678', N'Số 480, Đường XYZ, Quận DEF, Thành phố Đà Nẵng', 'macquangx@example.com', 'macquangx', '123', N'Trình độ chuyên môn', N'Lập trình viên', 'teacher', N'Đang làm việc', '1998-06-15', NULL),
(11, 'GV202049', N'Trần', N'Thị Y', 0, '1994-07-10', '0978123456', N'Số 490, Đường DEF, Quận MNO, Thành phố Cần Thơ', 'tranthiy@example.com', 'tranthiy', '123', N'Trình độ chuyên môn', N'Kế toán', 'teacher', N'Đang làm việc', '1997-12-10', NULL),
(11, 'GV202050', N'Hoàng', N'Quang Z', 1, '1988-05-05', '0923456789', N'Số 500, Đường KLM, Quận PQR, Thành phố Hải Phòng', 'hoangquangz@example.com', 'hoangquangz', '123', N'Trình độ chuyên môn', N'Quản lý dự án', 'teacher', N'Đang làm việc', '1996-09-20', NULL),
(11, 'GV202051', N'Mai', N'Thị A', 0, '1993-03-10', '0965432109', N'Số 510, Đường GHI, Quận JKL, Thành phố Vũng Tàu', 'maithia@example.com', 'maithia', '123', N'Trình độ chuyên môn', N'Nhân sự', 'teacher', N'Đang làm việc', '1995-12-05', NULL),
(11, 'GV202052', N'Đoàn', N'Quang B', 1, '1988-12-15', '0934567890', N'Số 520, Đường NOP, Quận STU, Thành phố Nha Trang', 'doanquangb@example.com', 'doanquangb', '123', N'Trình độ chuyên môn', N'Lập trình viên', 'teacher', N'Đang làm việc', '1994-09-30', NULL),
(12, 'GV202053', N'Lê', N'Thị C', 0, '1993-10-20', '0945678901', N'Số 530, Đường UVW, Quận XYZ, Thành phố Đồng Nai', 'lethic@example.com', 'lethic', '123', N'Trình độ chuyên môn', N'Kế toán', 'teacher', N'Đang làm việc', '1993-08-15', NULL),
(12, 'GV202054', N'Vương', N'Quang D', 1, '1987-08-25', '0956789012', N'Số 540, Đường KLM, Quận PQR, Thành phố Hà Tĩnh', 'vuongquangd@example.com', 'vuongquangd', '123', N'Trình độ chuyên môn', N'Quản lý dự án', 'teacher', N'Đang làm việc', '1992-07-20', NULL),
(12, 'GV202055', N'Nguyễn', N'Thị E', 0, '1992-06-30', '0987890123', N'Số 550, Đường JKL, Quận NOP, Thành phố Ninh Bình', 'nguyenthie@example.com', 'nguyenthie', '123', N'Trình độ chuyên môn', N'Nhân sự', 'teacher', N'Đang làm việc', '1991-05-25', NULL),
(12, 'GV202056', N'Phạm', N'Quang F', 1, '1987-05-05', '0918901234', N'Số 560, Đường QRS, Quận UVW, Thành phố Nam Định', 'phamquangf@example.com', 'phamquangf', '123', N'Trình độ chuyên môn', N'Lập trình viên', 'teacher', N'Đang làm việc', '1990-04-30', NULL),
(12, 'GV202057', N'Lý', N'Thị G', 0, '1992-03-10', '0945678901', N'Số 570, Đường TUV, Quận XYZ, Thành phố Hải Dương', 'lythig@example.com', 'lythig', '123', N'Trình độ chuyên môn', N'Kế toán', 'teacher', N'Đang làm việc', '1989-03-15', NULL),
(1, 'GV202058', N'Võ', N'Quang V', 1, '1991-04-25', '0901234567', N'Số 460, Đường ABC, Quận XYZ, Thành phố Hồ Chí Minh', 'voquangv@example.com', 'admin', '123', N'Trình độ chuyên môn', N'Toán', 'admin', N'Đang làm việc', '2000-01-01', NULL),
(2, 'GV202059', N'Đặng', N'Thị W', 0, '1996-01-30', '0987654321', N'Số 470, Đường XYZ, Quận ABC, Thành phố Hà Nội', 'dangthiw@example.com', 'admin_ly', '123', N'Trình độ chuyên môn', N'Lý', 'admin', N'Đang làm việc', '1999-03-01', NULL),
(3, 'GV202060', N'Mạc', N'Quang X', 1, '1989-09-15', '0912345678', N'Số 480, Đường XYZ, Quận DEF, Thành phố Đà Nẵng', 'macquangx@example.com', 'admin_hoa', '123', N'Trình độ chuyên môn', N'Hóa', 'admin', N'Đang làm việc', '1998-06-15', NULL),
(4, 'GV202061', N'Trần', N'Thị Y', 0, '1994-07-10', '0978123456', N'Số 490, Đường DEF, Quận MNO, Thành phố Cần Thơ', 'tranthiy@example.com', 'admin_ngu_van', '123', N'Trình độ chuyên môn', N'Ngữ Văn', 'admin', N'Đang làm việc', '1997-12-10', NULL),
(5, 'GV202062', N'Hoàng', N'Quang Z', 1, '1988-05-05', '0923456789', N'Số 500, Đường KLM, Quận PQR, Thành phố Hải Phòng', 'hoangquangz@example.com', 'admin_tieng_anh', '123', N'Trình độ chuyên môn', N'Tiếng anh', 'admin', N'Đang làm việc', '1996-09-20', NULL),
(6, 'GV202063', N'Mai', N'Thị A', 0, '1993-03-10', '0965432109', N'Số 510, Đường GHI, Quận JKL, Thành phố Vũng Tàu', 'maithia@example.com', 'admin_gdcd', '123', N'Trình độ chuyên môn', N'Giáo dục công dân', 'admin', N'Đang làm việc', '1995-12-05', NULL),
(7, 'GV202064', N'Đoàn', N'Quang B', 1, '1988-12-15', '0934567890', N'Số 520, Đường NOP, Quận STU, Thành phố Nha Trang', 'doanquangb@example.com', 'admin_lich_su', '123', N'Trình độ chuyên môn', N'Lịch sử', 'admin', N'Đang làm việc', '1994-09-30', NULL),
(8, 'GV202065', N'Lê', N'Thị C', 0, '1993-10-20', '0945678901', N'Số 530, Đường UVW, Quận XYZ, Thành phố Đồng Nai', 'lethic@example.com', 'admin_dia_ly', '123', N'Trình độ chuyên môn', N'Địa lý', 'teacher', N'Đang làm việc', '1993-08-15', NULL),
(9, 'GV202066', N'Vương', N'Quang D', 1, '1987-08-25', '0956789012', N'Số 540, Đường KLM, Quận PQR, Thành phố Hà Tĩnh', 'vuongquangd@example.com', 'admin_the_duc', '123', N'Trình độ chuyên môn', N'Thể dục', 'admin', N'Đang làm việc', '1992-07-20', NULL),
(10, 'GV202067', N'Nguyễn', N'Thị E', 0, '1992-06-30', '0987890123', N'Số 550, Đường JKL, Quận NOP, Thành phố Ninh Bình', 'nguyenthie@example.com', 'admin_quoc_phong', '123', N'Trình độ chuyên môn', N'Quốc phòng', 'admin', N'Đang làm việc', '1991-05-25', NULL),
(11, 'GV202068', N'Phạm', N'Quang F', 1, '1987-05-05', '0918901234', N'Số 560, Đường QRS, Quận UVW, Thành phố Nam Định', 'phamquangf@example.com', 'admin_cong_nghe', '123', N'Trình độ chuyên môn', N'Công nghệ', 'admin', N'Đang làm việc', '1990-04-30', NULL),
(12, 'GV202069', N'Lý', N'Thị G', 0, '1992-03-10', '0945678901', N'Số 570, Đường TUV, Quận XYZ, Thành phố Hải Dương', 'lythig@example.com', 'admin_sinh_hoc', '123', N'Trình độ chuyên môn', N'Sinh học', 'admin', N'Đang làm việc', '1989-03-15', NULL)

UPDATE Users SET Image='D:\documents\management\images\myimage_.jpg'