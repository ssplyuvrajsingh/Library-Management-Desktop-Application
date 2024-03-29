USE [master]
GO
/****** Object:  Database [Library]    Script Date: 06/09/2019 20:28:11 ******/
CREATE DATABASE [Library] ON  PRIMARY 
( NAME = N'Library', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Library.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Library_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Library_log.LDF' , SIZE = 768KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Library] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Library].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Library] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Library] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Library] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Library] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Library] SET ARITHABORT OFF
GO
ALTER DATABASE [Library] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Library] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Library] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Library] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Library] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Library] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Library] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Library] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Library] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Library] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Library] SET  ENABLE_BROKER
GO
ALTER DATABASE [Library] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Library] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Library] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Library] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Library] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Library] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Library] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Library] SET  READ_WRITE
GO
ALTER DATABASE [Library] SET RECOVERY FULL
GO
ALTER DATABASE [Library] SET  MULTI_USER
GO
ALTER DATABASE [Library] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Library] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'Library', N'ON'
GO
USE [Library]
GO
/****** Object:  Table [dbo].[Lib]    Script Date: 06/09/2019 20:28:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Lib](
	[Lib_Id] [int] IDENTITY(1,1) NOT NULL,
	[Lib_Name] [char](50) NULL,
	[Lib_Mob] [varchar](10) NULL,
	[Lib_E_mail] [varchar](50) NULL,
	[Pass] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Lib_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User_SignUp]    Script Date: 06/09/2019 20:28:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User_SignUp](
	[Name] [char](50) NULL,
	[E_mail] [varchar](50) NULL,
	[Pass] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[ST_Lib_Id_REG]    Script Date: 06/09/2019 20:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ST_Lib_Id_REG](
@ST_Id int=null,
@Create_ST_Lib_Id varchar(20)=null,
@Lib_Expiry_Date Date=null,
@Lib_Id int=null,
@Action char(10)
)
as 
begin
if(not exists(Select * from ST_Lib_Id where Create_ST_Lib_Id=@Create_ST_Lib_Id))
	begin
	if(@Action='Insert')
		insert into ST_Lib_Id(ST_Id,Create_ST_Lib_Id,Lib_Expiry_Date,Lib_Id) values (@ST_Id,@Create_ST_Lib_Id,@Lib_Expiry_Date,@Lib_Id)
	end
end
GO
/****** Object:  Table [dbo].[Issue_Books]    Script Date: 06/09/2019 20:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Issue_Books](
	[Issue_Id] [int] IDENTITY(1,1) NOT NULL,
	[U_Book_Id] [varchar](20) NULL,
	[St_Lib_Id] [varchar](10) NULL,
	[Issue_Books_Total] [int] NULL,
	[Lib_Id] [int] NULL,
	[Issue_Date] [date] NULL,
	[Return_Date] [date] NULL,
	[Issue_Yes] [char](3) NULL,
PRIMARY KEY CLUSTERED 
(
	[Issue_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Add_Dept]    Script Date: 06/09/2019 20:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Add_Dept](
	[Dept_Id] [int] IDENTITY(1,1) NOT NULL,
	[Lib_Id] [int] NULL,
	[Dept_Name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Dept_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Add_Books]    Script Date: 06/09/2019 20:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Add_Books](
	[Book_Id] [int] IDENTITY(1,1) NOT NULL,
	[Book_Name] [varchar](100) NULL,
	[Book_Auther_Name] [varchar](100) NULL,
	[Book_Publication_Name] [varchar](100) NULL,
	[Book_Purchase_Date] [date] NULL,
	[Book_Price] [int] NULL,
	[Book_Quantity] [int] NULL,
	[Lib_Id] [int] NULL,
	[U_Book_Id] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Book_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[tbl_Lib_Reg]    Script Date: 06/09/2019 20:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[tbl_Lib_Reg](
@U_Id varchar(50),
@Pass varchar(50)
)
as
begin
	select Lib_Id from Lib where Lib_E_mail=@U_Id and Pass=@Pass
end
GO
/****** Object:  StoredProcedure [dbo].[Issue_Books_Reg]    Script Date: 06/09/2019 20:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Issue_Books_Reg](
@U_Book_Id varchar(20)=null,
@St_Lib_Id varchar(10)=null,
@Issue_Books_Total int=null,
@Lib_Id int=null,
@Return_Date date=null,
@Yes char(3)=null,
@Action char(15)=null,
@Search char(20)=null
)
as
begin
if(@Action = 'Insert')
	begin
		if(not exists(Select U_BOOk_Id from Issue_Books where U_Book_Id=@U_Book_Id and St_Lib_Id=@St_Lib_Id))
		insert into Issue_Books(U_Book_Id,St_Lib_Id,Issue_Books_Total,Lib_Id,Return_Date,Issue_Yes) values(@U_Book_Id,@St_Lib_Id,@Issue_Books_Total,@Lib_Id,@Return_Date,@Yes)
	end
if(@Action = 'ST')
	begin
		select COUNT(St_Lib_Id) from Issue_Books where St_Lib_Id=@St_Lib_Id and Issue_Yes = 'Yes'	
	end
if(@Action='Issue')
	begin
	    Select count(U_Book_Id) from Issue_Books where U_Book_Id = @U_Book_Id and Issue_Yes = 'Yes'
	end
if(@Action='Re')
	begin
		if(exists(Select Issue_Id from Issue_Books where U_Book_Id=@U_Book_Id and St_Lib_Id=@St_Lib_Id))
		update Issue_Books set Return_Date=@Return_Date,Lib_Id=@Lib_Id
	end
if(@Action = 'View')
	begin
		Select Issue_Id,U_Book_Id,St_Lib_Id,Issue_Date,Return_Date from Issue_Books where Issue_Yes='Yes'
	end
if(@Action = 'View1')
	begin
		Select * from Issue_Books Where U_Book_Id = @Search OR St_Lib_Id = @Search and Issue_Yes='Yes'
	end
if(@Action = 'View2')
	begin
		select Issue_Id from Issue_Books where U_Book_Id=@U_Book_Id and St_Lib_Id=@St_Lib_Id and Issue_Yes='Yes'
	end
 if(@Action = 'View3')
	begin
		select Return_Date from Issue_Books where U_Book_Id=@U_Book_Id and St_Lib_Id=@St_Lib_Id and Issue_Yes='Yes'
    end   
end
GO
/****** Object:  StoredProcedure [dbo].[Add_Dept_Reg]    Script Date: 06/09/2019 20:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Add_Dept_Reg](
@Dept_Id int=null,
@Lib_Id int=null,
@Dept_Name varchar(100)=null,
@Action char(10)
)
as
begin
	if(@Action='Insert')
	begin
	if(not exists(select * from Add_Dept where Dept_Name=@Dept_Name))
		begin
			insert into Add_Dept Values(@Lib_Id,@Dept_Name)
		end
	end
	if(@Action='View')
	begin
		Select * from Add_Dept
	end
	
	if(@Action='dd_Dept')
	begin
		Select Dept_Id,Dept_Name from Add_Dept
	end
	if(@Action='Update')
	begin
		Update Add_Dept set Dept_Name=@Dept_Name where Dept_Id=@Dept_Id
	end
	if(@Action='Delete')
	begin
		Delete Add_Dept where Dept_Id=@Dept_Id
	end
end
GO
/****** Object:  Table [dbo].[Add_Course]    Script Date: 06/09/2019 20:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Add_Course](
	[Course_Id] [int] IDENTITY(1,1) NOT NULL,
	[Lib_Id] [int] NULL,
	[Dept_Id] [int] NULL,
	[Course_Name] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Course_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[Add_Books_Reg]    Script Date: 06/09/2019 20:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Add_Books_Reg](
@Book_Id int=null,
@Book_Name varchar(50)=null,
@Book_Auther_Name varchar(100)=null,
@Book_Publication_Name varchar(100)=null,
@Book_Price int=null,
@Book_Quantity int=null,
@Lib_Id int=null,
@U_Book_Id varchar(20)=null,
@Action char(10),
@Search varchar(100)=null
)
as
begin
if(@Action='Insert')
	begin
		insert into Add_Books(Book_Name,Book_Auther_Name,Book_Publication_Name,Book_Price,Book_Quantity,Lib_Id,U_Book_Id) values(@Book_Name,@Book_Auther_Name,@Book_Publication_Name,@Book_Price,@Book_Quantity,@Lib_Id,@U_Book_Id)
	end
if(@Action='View')
	begin
		Select * from Add_Books
	end
if(@Action='Book_View')
	begin
		Select * from Add_Books Where Book_Name Like @Search OR Book_Auther_Name Like @Search OR Book_Publication_Name Like @Search OR  U_Book_Id Like @Search
	end
if(@Action='Update')
	begin
		Update Add_Books Set Book_Name=@Book_Name,Book_Auther_Name=@Book_Auther_Name,Book_Publication_Name=@Book_Publication_Name,Book_Price=@Book_Price,Book_Quantity=@Book_Quantity where Book_Id=@Book_Id
	end
if(@Action='Delete')
	begin
	    Delete Add_Books where Book_Id=@Book_Id
	end
if(@Action='Issue')
	begin
	    Select sum(Book_Quantity) from Add_Books where  U_Book_Id = @U_Book_Id
	end
if(@Action='Book_View1')
	begin
	    select distinct(U_Book_Id) from Add_Books where U_Book_Id=@U_Book_Id
	end

end
GO
/****** Object:  Table [dbo].[Book_Fine]    Script Date: 06/09/2019 20:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Book_Fine](
	[Book_Fine_Id] [int] IDENTITY(1,1) NOT NULL,
	[Issue_Id] [int] NULL,
	[Fine] [int] NULL,
	[Pay] [char](3) NULL,
	[Lib_Id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Book_Fine_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[Book_Fine_Reg]    Script Date: 06/09/2019 20:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Book_Fine_Reg](
@Issue_Id int=null,
@Fine int=null,
@Pay char(3)=null,
@Lib_Id int=null,
@Action char(15	)=null,
@U_Book_Id varchar(20)=null,
@St_Lib_Id varchar(10)=null
)
as
begin
if(@Action = 'Insert')
	begin
		insert into Book_Fine values(@Issue_Id,@Fine,@Pay,@Lib_Id)
	end
if(@Action = 'View1')
	begin
		Select Book_Fine.Book_Fine_Id,Issue_Books.U_Book_Id,Issue_Books.St_Lib_Id,Book_Fine.Fine,Book_Fine.Pay from Book_Fine join Issue_Books
		on Issue_Books.Issue_Id = Book_Fine.Issue_Id Where Book_Fine.Pay='Due' and Issue_Books.St_Lib_Id=@St_Lib_Id
	end
if(@Action = 'View')
	begin
		Select Book_Fine.Book_Fine_Id,Issue_Books.U_Book_Id,Issue_Books.St_Lib_Id,Book_Fine.Fine,Book_Fine.Pay from Book_Fine join Issue_Books
		on Issue_Books.Issue_Id = Book_Fine.Issue_Id
	end
if(@Action = 'View2')
	begin
		select Sum(Book_Fine.Fine) from Book_Fine join Issue_Books on Issue_Books.Issue_Id = Book_Fine.Issue_Id where Pay='Due' and Issue_Books.St_Lib_Id=@St_Lib_Id
	end
end
GO
/****** Object:  Table [dbo].[Add_Student]    Script Date: 06/09/2019 20:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Add_Student](
	[St_Id] [int] IDENTITY(1,1) NOT NULL,
	[Lib_Id] [int] NULL,
	[Course_Id] [int] NULL,
	[St_Name] [char](50) NULL,
	[St_Session] [varchar](15) NULL,
	[St_Mob] [varchar](10) NULL,
	[St_E_mail] [varchar](50) NULL,
	[St_Lib_Id] [varchar](10) NULL,
	[Gender] [char](6) NULL,
	[Father_Name] [char](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[St_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[Add_Course_Reg]    Script Date: 06/09/2019 20:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Add_Course_Reg](
@Lib_Id int=null,
@Dept_Id int=null,
@Course_Name char(100)=null,
@Action char(10),
@Course_Id int=null
)
as 
begin
if(@Action='Insert')
begin
	if(not exists(Select * from Add_Course where Course_Name=@Course_Name))
		begin
			Insert into Add_Course values(@Lib_Id,@Dept_Id,@Course_Name)
		end
	end
	if(@Action='View')
	begin
		Select Add_Course.Course_Id,Dept_Name,Add_Course.Course_Name from Add_Course join Add_Dept
		on Add_Course.Dept_Id=Add_Dept.Dept_Id
	end
	if(@Action='cb_View')
	begin
		Select Course_Id,Course_Name from Add_Course
	end
	if(@Action='Update')
	begin
		Update Add_Course set Dept_Id=@Dept_Id,Course_Name=@Course_Name where Course_Id=@Course_Id
	end
	if(@Action='Delete')
	begin
		Delete Add_Course where Course_Id=@Course_Id
	end
end
GO
/****** Object:  StoredProcedure [dbo].[ST_Info_Reg]    Script Date: 06/09/2019 20:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ST_Info_Reg](
@Lib_Id int=null,
@Course_Id int=null,
@ST_Name char(50)=null,
@Session varchar(15)=null,
@Mobile varchar(10)=null,
@E_mail varchar(50)=null,
@St_Lib_Id varchar(10)=null,
@Gender char(6)=null,
@Father_Name char(50)=null,
@Action char(10)
)
as
begin
if(@Action='Insert')
	begin
		insert into Add_Student values(@Lib_Id,@Course_Id,@ST_Name,@Session,@Mobile,@E_mail,@St_Lib_Id,@Gender,@Father_Name)
	end
if(@Action='View_ST')
	begin
		Select St_Lib_Id from Add_Student where St_Lib_Id=@St_Lib_Id
	end
if(@Action='View')
	begin
		Select * from Add_Student
	end
end
GO
/****** Object:  Default [DF_Issue_Books_Issue_Date]    Script Date: 06/09/2019 20:28:14 ******/
ALTER TABLE [dbo].[Issue_Books] ADD  CONSTRAINT [DF_Issue_Books_Issue_Date]  DEFAULT (getdate()) FOR [Issue_Date]
GO
/****** Object:  Default [DF_Add_Books_Book_Purchase_Date]    Script Date: 06/09/2019 20:28:14 ******/
ALTER TABLE [dbo].[Add_Books] ADD  CONSTRAINT [DF_Add_Books_Book_Purchase_Date]  DEFAULT (getdate()) FOR [Book_Purchase_Date]
GO
/****** Object:  ForeignKey [FK__Issue_Boo__Lib_I__52593CB8]    Script Date: 06/09/2019 20:28:14 ******/
ALTER TABLE [dbo].[Issue_Books]  WITH CHECK ADD FOREIGN KEY([Lib_Id])
REFERENCES [dbo].[Lib] ([Lib_Id])
GO
/****** Object:  ForeignKey [FK__Add_Dept__Lib_Id__38996AB5]    Script Date: 06/09/2019 20:28:14 ******/
ALTER TABLE [dbo].[Add_Dept]  WITH CHECK ADD FOREIGN KEY([Lib_Id])
REFERENCES [dbo].[Lib] ([Lib_Id])
GO
/****** Object:  ForeignKey [FK__Add_Books__Lib_I__48CFD27E]    Script Date: 06/09/2019 20:28:14 ******/
ALTER TABLE [dbo].[Add_Books]  WITH CHECK ADD FOREIGN KEY([Lib_Id])
REFERENCES [dbo].[Lib] ([Lib_Id])
GO
/****** Object:  ForeignKey [FK__Add_Cours__Dept___3E52440B]    Script Date: 06/09/2019 20:28:14 ******/
ALTER TABLE [dbo].[Add_Course]  WITH CHECK ADD FOREIGN KEY([Dept_Id])
REFERENCES [dbo].[Add_Dept] ([Dept_Id])
GO
/****** Object:  ForeignKey [FK__Add_Cours__Lib_I__3D5E1FD2]    Script Date: 06/09/2019 20:28:14 ******/
ALTER TABLE [dbo].[Add_Course]  WITH CHECK ADD FOREIGN KEY([Lib_Id])
REFERENCES [dbo].[Lib] ([Lib_Id])
GO
/****** Object:  ForeignKey [FK__Book_Fine__Issue__619B8048]    Script Date: 06/09/2019 20:28:14 ******/
ALTER TABLE [dbo].[Book_Fine]  WITH CHECK ADD FOREIGN KEY([Issue_Id])
REFERENCES [dbo].[Issue_Books] ([Issue_Id])
GO
/****** Object:  ForeignKey [FK__Book_Fine__Lib_I__66603565]    Script Date: 06/09/2019 20:28:14 ******/
ALTER TABLE [dbo].[Book_Fine]  WITH CHECK ADD FOREIGN KEY([Lib_Id])
REFERENCES [dbo].[Lib] ([Lib_Id])
GO
/****** Object:  ForeignKey [FK__Add_Stude__Cours__440B1D61]    Script Date: 06/09/2019 20:28:14 ******/
ALTER TABLE [dbo].[Add_Student]  WITH CHECK ADD FOREIGN KEY([Course_Id])
REFERENCES [dbo].[Add_Course] ([Course_Id])
GO
/****** Object:  ForeignKey [FK__Add_Stude__Lib_I__4316F928]    Script Date: 06/09/2019 20:28:14 ******/
ALTER TABLE [dbo].[Add_Student]  WITH CHECK ADD FOREIGN KEY([Lib_Id])
REFERENCES [dbo].[Lib] ([Lib_Id])
GO
