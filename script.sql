USE [master]
GO
/****** Object:  Database [bug_tracker]    Script Date: 5/18/2018 5:58:37 PM ******/
CREATE DATABASE [bug_tracker]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'bug_tracker', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\bug_tracker.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'bug_tracker_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\bug_tracker_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [bug_tracker] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bug_tracker].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bug_tracker] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [bug_tracker] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [bug_tracker] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [bug_tracker] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [bug_tracker] SET ARITHABORT OFF 
GO
ALTER DATABASE [bug_tracker] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [bug_tracker] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [bug_tracker] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [bug_tracker] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [bug_tracker] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [bug_tracker] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [bug_tracker] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [bug_tracker] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [bug_tracker] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [bug_tracker] SET  ENABLE_BROKER 
GO
ALTER DATABASE [bug_tracker] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [bug_tracker] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [bug_tracker] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [bug_tracker] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [bug_tracker] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [bug_tracker] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [bug_tracker] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [bug_tracker] SET RECOVERY FULL 
GO
ALTER DATABASE [bug_tracker] SET  MULTI_USER 
GO
ALTER DATABASE [bug_tracker] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [bug_tracker] SET DB_CHAINING OFF 
GO
ALTER DATABASE [bug_tracker] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [bug_tracker] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [bug_tracker] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'bug_tracker', N'ON'
GO
ALTER DATABASE [bug_tracker] SET QUERY_STORE = OFF
GO
USE [bug_tracker]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [bug_tracker]
GO
/****** Object:  Table [dbo].[table_admin]    Script Date: 5/18/2018 5:58:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[table_admin](
	[admin_id] [int] IDENTITY(1,1) NOT NULL,
	[company_name] [varchar](999) NOT NULL,
	[username] [varchar](999) NOT NULL,
	[password] [varchar](999) NOT NULL,
 CONSTRAINT [pk_admin_id] PRIMARY KEY CLUSTERED 
(
	[admin_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[table_assign]    Script Date: 5/18/2018 5:58:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[table_assign](
	[assign_id] [int] IDENTITY(1,1) NOT NULL,
	[assign_date] [datetime] NOT NULL,
	[descriptions] [varchar](999) NULL,
	[assign_by] [int] NULL,
	[assign_to] [int] NULL,
	[bug_id] [int] NULL,
 CONSTRAINT [pk_assign_id] PRIMARY KEY CLUSTERED 
(
	[assign_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[table_bug]    Script Date: 5/18/2018 5:58:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[table_bug](
	[bug_id] [int] IDENTITY(1,1) NOT NULL,
	[project_name] [varchar](256) NOT NULL,
	[class_name] [varchar](256) NULL,
	[method_name] [varchar](256) NULL,
	[start_line] [int] NOT NULL,
	[end_line] [int] NULL,
	[code_author] [int] NULL,
	[bug_status] [char](1) NOT NULL,
 CONSTRAINT [pk_bug_id] PRIMARY KEY CLUSTERED 
(
	[bug_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[table_bug_history]    Script Date: 5/18/2018 5:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[table_bug_history](
	[bug_history_id] [int] IDENTITY(1,1) NOT NULL,
	[descriptions] [varchar](999) NULL,
	[source_control_id] [int] NULL,
 CONSTRAINT [pk_bug_history_id] PRIMARY KEY CLUSTERED 
(
	[bug_history_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[table_bug_information]    Script Date: 5/18/2018 5:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[table_bug_information](
	[bug_information_id] [int] IDENTITY(1,1) NOT NULL,
	[symptons] [varchar](999) NULL,
	[cause] [varchar](999) NULL,
	[bug_id] [int] NULL,
 CONSTRAINT [pk_bug_information_id] PRIMARY KEY CLUSTERED 
(
	[bug_information_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[table_code]    Script Date: 5/18/2018 5:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[table_code](
	[code_id] [int] IDENTITY(1,1) NOT NULL,
	[code_file_path] [varchar](256) NOT NULL,
	[code_file_name] [varchar](256) NOT NULL,
	[programming_language] [varchar](256) NOT NULL,
	[bug_id] [int] NULL,
 CONSTRAINT [pk_code_id] PRIMARY KEY CLUSTERED 
(
	[code_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[table_fixer]    Script Date: 5/18/2018 5:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[table_fixer](
	[fixer_id] [int] IDENTITY(1,1) NOT NULL,
	[fixed_by] [int] NULL,
	[bug_id] [int] NULL,
	[fixed_date] [datetime] NOT NULL,
 CONSTRAINT [pk_fixer_id] PRIMARY KEY CLUSTERED 
(
	[fixer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[table_image]    Script Date: 5/18/2018 5:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[table_image](
	[image_id] [int] IDENTITY(1,1) NOT NULL,
	[image_path] [varchar](999) NOT NULL,
	[image_name] [varchar](256) NOT NULL,
	[bug_id] [int] NULL,
 CONSTRAINT [pk_image_id] PRIMARY KEY CLUSTERED 
(
	[image_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[table_programmer]    Script Date: 5/18/2018 5:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[table_programmer](
	[programmer_id] [int] IDENTITY(1,1) NOT NULL,
	[full_name] [varchar](256) NOT NULL,
	[username] [varchar](256) NOT NULL,
	[password] [varchar](256) NOT NULL,
 CONSTRAINT [pk_programmer_id] PRIMARY KEY CLUSTERED 
(
	[programmer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[table_project]    Script Date: 5/18/2018 5:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[table_project](
	[project_id] [int] IDENTITY(1,1) NOT NULL,
	[project_name] [varchar](999) NOT NULL,
	[admin_id] [int] NOT NULL,
 CONSTRAINT [pk_project_id] PRIMARY KEY CLUSTERED 
(
	[project_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[table_project_programmer]    Script Date: 5/18/2018 5:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[table_project_programmer](
	[project_programmer_id] [int] IDENTITY(1,1) NOT NULL,
	[project_id] [int] NULL,
	[programmer_id] [int] NULL,
	[admin_id] [int] NULL,
 CONSTRAINT [pk_project_programmer_id] PRIMARY KEY CLUSTERED 
(
	[project_programmer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[table_source_control]    Script Date: 5/18/2018 5:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[table_source_control](
	[source_control_id] [int] IDENTITY(1,1) NOT NULL,
	[link] [varchar](999) NOT NULL,
	[start_line] [int] NOT NULL,
	[end_line] [int] NULL,
	[bug_id] [int] NULL,
 CONSTRAINT [pk_source_control_id] PRIMARY KEY CLUSTERED 
(
	[source_control_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[table_tester]    Script Date: 5/18/2018 5:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[table_tester](
	[tester_id] [int] IDENTITY(1,1) NOT NULL,
	[full_name] [varchar](256) NOT NULL,
	[username] [varchar](256) NOT NULL,
	[password] [varchar](256) NOT NULL,
 CONSTRAINT [pk_tester_id] PRIMARY KEY CLUSTERED 
(
	[tester_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[table_admin] ON 

INSERT [dbo].[table_admin] ([admin_id], [company_name], [username], [password]) VALUES (1, N'nishan', N'nishan', N'nishan')
SET IDENTITY_INSERT [dbo].[table_admin] OFF
SET IDENTITY_INSERT [dbo].[table_assign] ON 

INSERT [dbo].[table_assign] ([assign_id], [assign_date], [descriptions], [assign_by], [assign_to], [bug_id]) VALUES (1, CAST(N'2018-05-18T02:02:19.327' AS DateTime), N'asdlfkaj', 1, 1, 98)
INSERT [dbo].[table_assign] ([assign_id], [assign_date], [descriptions], [assign_by], [assign_to], [bug_id]) VALUES (2, CAST(N'2018-05-18T02:13:11.260' AS DateTime), N'taile yo kam xito gar natra ta office bata fire holas', 1, 1, 102)
INSERT [dbo].[table_assign] ([assign_id], [assign_date], [descriptions], [assign_by], [assign_to], [bug_id]) VALUES (3, CAST(N'2018-05-18T13:38:39.933' AS DateTime), N'', 1, 2, 102)
INSERT [dbo].[table_assign] ([assign_id], [assign_date], [descriptions], [assign_by], [assign_to], [bug_id]) VALUES (4, CAST(N'2018-05-18T13:38:47.720' AS DateTime), N'', 1, 1003, 102)
INSERT [dbo].[table_assign] ([assign_id], [assign_date], [descriptions], [assign_by], [assign_to], [bug_id]) VALUES (5, CAST(N'2018-05-18T13:40:01.263' AS DateTime), N'', 1, 1008, 98)
INSERT [dbo].[table_assign] ([assign_id], [assign_date], [descriptions], [assign_by], [assign_to], [bug_id]) VALUES (6, CAST(N'2018-05-18T13:40:07.247' AS DateTime), N'', 1, 1, 98)
SET IDENTITY_INSERT [dbo].[table_assign] OFF
SET IDENTITY_INSERT [dbo].[table_bug] ON 

INSERT [dbo].[table_bug] ([bug_id], [project_name], [class_name], [method_name], [start_line], [end_line], [code_author], [bug_status]) VALUES (78, N'Auction', N'Troper', N'troper', 1, 4, 1, N'0')
INSERT [dbo].[table_bug] ([bug_id], [project_name], [class_name], [method_name], [start_line], [end_line], [code_author], [bug_status]) VALUES (79, N'Auction', N'asfas', N'asfasdf', 1, 3, 1, N'0')
INSERT [dbo].[table_bug] ([bug_id], [project_name], [class_name], [method_name], [start_line], [end_line], [code_author], [bug_status]) VALUES (80, N'Auction', N'asfas', N'asfasdf', 1, 3, 1, N'0')
INSERT [dbo].[table_bug] ([bug_id], [project_name], [class_name], [method_name], [start_line], [end_line], [code_author], [bug_status]) VALUES (81, N'Troper', N'nishan', N'nishan', 1, 8, 1, N'0')
INSERT [dbo].[table_bug] ([bug_id], [project_name], [class_name], [method_name], [start_line], [end_line], [code_author], [bug_status]) VALUES (83, N'Auction', N'Common', N'loopPanel', 1, 91, 1, N'0')
INSERT [dbo].[table_bug] ([bug_id], [project_name], [class_name], [method_name], [start_line], [end_line], [code_author], [bug_status]) VALUES (84, N'Auction', N'Common', N'loopPanel', 1, 91, 1, N'0')
INSERT [dbo].[table_bug] ([bug_id], [project_name], [class_name], [method_name], [start_line], [end_line], [code_author], [bug_status]) VALUES (85, N'Auction', N'Bug', N'insertBug', 1, 8, 1, N'0')
INSERT [dbo].[table_bug] ([bug_id], [project_name], [class_name], [method_name], [start_line], [end_line], [code_author], [bug_status]) VALUES (86, N'Auction', N'Bug', N'insertBug', 1, 8, 1, N'0')
INSERT [dbo].[table_bug] ([bug_id], [project_name], [class_name], [method_name], [start_line], [end_line], [code_author], [bug_status]) VALUES (87, N'Troper', N'Bug', N'updateBug', 1, 8, 1, N'0')
INSERT [dbo].[table_bug] ([bug_id], [project_name], [class_name], [method_name], [start_line], [end_line], [code_author], [bug_status]) VALUES (89, N'Troper', N'Location', N'loopPanel', 1, 13, 1, N'0')
INSERT [dbo].[table_bug] ([bug_id], [project_name], [class_name], [method_name], [start_line], [end_line], [code_author], [bug_status]) VALUES (90, N'Troper', N'Location', N'loopPanel', 1, 13, 1, N'0')
INSERT [dbo].[table_bug] ([bug_id], [project_name], [class_name], [method_name], [start_line], [end_line], [code_author], [bug_status]) VALUES (91, N'Troper', N'Location', N'loopPanel', 1, 13, 1, N'0')
INSERT [dbo].[table_bug] ([bug_id], [project_name], [class_name], [method_name], [start_line], [end_line], [code_author], [bug_status]) VALUES (92, N'Troper', N'Location', N'loopPanel', 1, 13, 1, N'0')
INSERT [dbo].[table_bug] ([bug_id], [project_name], [class_name], [method_name], [start_line], [end_line], [code_author], [bug_status]) VALUES (93, N'Auction', N'hello', N'hello', 1, 1, 1, N'0')
INSERT [dbo].[table_bug] ([bug_id], [project_name], [class_name], [method_name], [start_line], [end_line], [code_author], [bug_status]) VALUES (94, N'Auction', N'hello', N'hello', 1, 1, 1, N'0')
INSERT [dbo].[table_bug] ([bug_id], [project_name], [class_name], [method_name], [start_line], [end_line], [code_author], [bug_status]) VALUES (95, N'Auction', N'SourceControlDAO', N'Insert', 1, 10, 1, N'0')
INSERT [dbo].[table_bug] ([bug_id], [project_name], [class_name], [method_name], [start_line], [end_line], [code_author], [bug_status]) VALUES (96, N'Auction', N'SourceControlDAO', N'Insert', 1, 10, 1, N'0')
INSERT [dbo].[table_bug] ([bug_id], [project_name], [class_name], [method_name], [start_line], [end_line], [code_author], [bug_status]) VALUES (97, N'Troper', N'ViewModel', N'Link', 1, 7, 1, N'0')
INSERT [dbo].[table_bug] ([bug_id], [project_name], [class_name], [method_name], [start_line], [end_line], [code_author], [bug_status]) VALUES (98, N'Troper', N'ViewModel', N'Link', 1, 7, 1, N'0')
INSERT [dbo].[table_bug] ([bug_id], [project_name], [class_name], [method_name], [start_line], [end_line], [code_author], [bug_status]) VALUES (99, N'Bug Tracker', N'BugDAO', N'Insert', 20, 35, 2008, N'0')
INSERT [dbo].[table_bug] ([bug_id], [project_name], [class_name], [method_name], [start_line], [end_line], [code_author], [bug_status]) VALUES (100, N'Bug Tracker', N'BugDAO', N'Insert', 20, 35, 2008, N'0')
INSERT [dbo].[table_bug] ([bug_id], [project_name], [class_name], [method_name], [start_line], [end_line], [code_author], [bug_status]) VALUES (101, N'Troper', N'Troper', N'listView1_Click', 5, 11, 1, N'0')
INSERT [dbo].[table_bug] ([bug_id], [project_name], [class_name], [method_name], [start_line], [end_line], [code_author], [bug_status]) VALUES (102, N'Troper', N'Troper', N'listView1_Click', 5, 11, 1, N'0')
SET IDENTITY_INSERT [dbo].[table_bug] OFF
SET IDENTITY_INSERT [dbo].[table_bug_information] ON 

INSERT [dbo].[table_bug_information] ([bug_information_id], [symptons], [cause], [bug_id]) VALUES (3, N'According to Lonely Planet''s Annual “Best in Travel List”, Nepal is the Best Value Destination to travel in the year 2017. As per the publication, Nepal is speedily bouncing back from the twin earthquake and the fuel embargo imposed in the year 2015. “It remains a fabulous choice for budget-conscious travelers, who can 
what the hell




what is yo name', N'Nepal officially the Federal Democratic Republic of Nepal is a landlocked country in South Asia located mainly in the Himalayas but also includes parts of the Indo-Gangetic Plain. With an estimated population of 26.4 million, it is 48th largest country by population and 93rd largest country by area. It borders China in the ...', 98)
INSERT [dbo].[table_bug_information] ([bug_information_id], [symptons], [cause], [bug_id]) VALUES (5, N'k le garda aako ', N'karan k ho', 102)
SET IDENTITY_INSERT [dbo].[table_bug_information] OFF
SET IDENTITY_INSERT [dbo].[table_code] ON 

INSERT [dbo].[table_code] ([code_id], [code_file_path], [code_file_name], [programming_language], [bug_id]) VALUES (1, N'code', N'55', N'CSharp', 78)
INSERT [dbo].[table_code] ([code_id], [code_file_path], [code_file_name], [programming_language], [bug_id]) VALUES (3, N'code', N'40', N'CSharp', 84)
INSERT [dbo].[table_code] ([code_id], [code_file_path], [code_file_name], [programming_language], [bug_id]) VALUES (4, N'code', N'31', N'CSharp', 86)
INSERT [dbo].[table_code] ([code_id], [code_file_path], [code_file_name], [programming_language], [bug_id]) VALUES (6, N'code', N'30', N'CSharp', 90)
INSERT [dbo].[table_code] ([code_id], [code_file_path], [code_file_name], [programming_language], [bug_id]) VALUES (7, N'code', N'9', N'CSharp', 92)
INSERT [dbo].[table_code] ([code_id], [code_file_path], [code_file_name], [programming_language], [bug_id]) VALUES (8, N'code', N'57', N'CSharp', 94)
INSERT [dbo].[table_code] ([code_id], [code_file_path], [code_file_name], [programming_language], [bug_id]) VALUES (9, N'code', N'10', N'CSharp', 96)
INSERT [dbo].[table_code] ([code_id], [code_file_path], [code_file_name], [programming_language], [bug_id]) VALUES (10, N'code', N'43', N'CSharp', 98)
INSERT [dbo].[table_code] ([code_id], [code_file_path], [code_file_name], [programming_language], [bug_id]) VALUES (12, N'code', N'43', N'CSharp', 102)
SET IDENTITY_INSERT [dbo].[table_code] OFF
SET IDENTITY_INSERT [dbo].[table_image] ON 

INSERT [dbo].[table_image] ([image_id], [image_path], [image_name], [bug_id]) VALUES (2, N'code_image', N'bad data 2.PNG', 84)
INSERT [dbo].[table_image] ([image_id], [image_path], [image_name], [bug_id]) VALUES (3, N'code_image', N'database creating.PNG', 86)
INSERT [dbo].[table_image] ([image_id], [image_path], [image_name], [bug_id]) VALUES (5, N'code_image', N'SELECT 1.PNG', 90)
INSERT [dbo].[table_image] ([image_id], [image_path], [image_name], [bug_id]) VALUES (6, N'code_image', N'insert.PNG', 92)
INSERT [dbo].[table_image] ([image_id], [image_path], [image_name], [bug_id]) VALUES (7, N'code_image', N'star schema.PNG', 94)
INSERT [dbo].[table_image] ([image_id], [image_path], [image_name], [bug_id]) VALUES (8, N'code_image', N'1.su company desc.PNG', 96)
INSERT [dbo].[table_image] ([image_id], [image_path], [image_name], [bug_id]) VALUES (9, N'code_image', N'report.PNG', 98)
INSERT [dbo].[table_image] ([image_id], [image_path], [image_name], [bug_id]) VALUES (11, N'code_image', N'CREATE DESC.PNG', 102)
SET IDENTITY_INSERT [dbo].[table_image] OFF
SET IDENTITY_INSERT [dbo].[table_programmer] ON 

INSERT [dbo].[table_programmer] ([programmer_id], [full_name], [username], [password]) VALUES (1, N'Nishan Dhungana', N'nishandhungana41', N'nishan')
INSERT [dbo].[table_programmer] ([programmer_id], [full_name], [username], [password]) VALUES (2, N'asdf', N'asdf', N'asdf')
INSERT [dbo].[table_programmer] ([programmer_id], [full_name], [username], [password]) VALUES (3, N'asdf', N'aslfdkj', N'asdf')
INSERT [dbo].[table_programmer] ([programmer_id], [full_name], [username], [password]) VALUES (1002, N'admin', N'admin', N'admin')
INSERT [dbo].[table_programmer] ([programmer_id], [full_name], [username], [password]) VALUES (1003, N'image_code', N'code', N'CSharp')
INSERT [dbo].[table_programmer] ([programmer_id], [full_name], [username], [password]) VALUES (1007, N'Hello ', N'nishan', N'nishan')
INSERT [dbo].[table_programmer] ([programmer_id], [full_name], [username], [password]) VALUES (1008, N'asdfasd', N'sdfasdf', N'asdfasd')
INSERT [dbo].[table_programmer] ([programmer_id], [full_name], [username], [password]) VALUES (2008, N'Milan Adhikari', N'milan', N'milan')
INSERT [dbo].[table_programmer] ([programmer_id], [full_name], [username], [password]) VALUES (2009, N'Ashim Karki', N'ashim', N'ashim')
SET IDENTITY_INSERT [dbo].[table_programmer] OFF
SET IDENTITY_INSERT [dbo].[table_project] ON 

INSERT [dbo].[table_project] ([project_id], [project_name], [admin_id]) VALUES (1020, N'Troper', 1)
INSERT [dbo].[table_project] ([project_id], [project_name], [admin_id]) VALUES (1021, N'Auction', 1)
INSERT [dbo].[table_project] ([project_id], [project_name], [admin_id]) VALUES (1022, N'Mendolbrot', 1)
INSERT [dbo].[table_project] ([project_id], [project_name], [admin_id]) VALUES (1023, N'Bug Tracker', 1)
INSERT [dbo].[table_project] ([project_id], [project_name], [admin_id]) VALUES (1024, N'Game', 1)
SET IDENTITY_INSERT [dbo].[table_project] OFF
SET IDENTITY_INSERT [dbo].[table_project_programmer] ON 

INSERT [dbo].[table_project_programmer] ([project_programmer_id], [project_id], [programmer_id], [admin_id]) VALUES (1010, 1020, 1, 1)
INSERT [dbo].[table_project_programmer] ([project_programmer_id], [project_id], [programmer_id], [admin_id]) VALUES (1011, 1020, 2, 1)
INSERT [dbo].[table_project_programmer] ([project_programmer_id], [project_id], [programmer_id], [admin_id]) VALUES (1012, 1020, 1003, 1)
INSERT [dbo].[table_project_programmer] ([project_programmer_id], [project_id], [programmer_id], [admin_id]) VALUES (1013, 1020, 1007, 1)
INSERT [dbo].[table_project_programmer] ([project_programmer_id], [project_id], [programmer_id], [admin_id]) VALUES (1014, 1021, 1007, 1)
INSERT [dbo].[table_project_programmer] ([project_programmer_id], [project_id], [programmer_id], [admin_id]) VALUES (1015, 1021, 2, 1)
INSERT [dbo].[table_project_programmer] ([project_programmer_id], [project_id], [programmer_id], [admin_id]) VALUES (1016, 1021, 1, 1)
INSERT [dbo].[table_project_programmer] ([project_programmer_id], [project_id], [programmer_id], [admin_id]) VALUES (1017, 1022, 1, 1)
INSERT [dbo].[table_project_programmer] ([project_programmer_id], [project_id], [programmer_id], [admin_id]) VALUES (1018, 1022, 1002, 1)
INSERT [dbo].[table_project_programmer] ([project_programmer_id], [project_id], [programmer_id], [admin_id]) VALUES (1019, 1022, 1007, 1)
INSERT [dbo].[table_project_programmer] ([project_programmer_id], [project_id], [programmer_id], [admin_id]) VALUES (1020, 1023, 1007, 1)
INSERT [dbo].[table_project_programmer] ([project_programmer_id], [project_id], [programmer_id], [admin_id]) VALUES (1021, 1023, 2, 1)
INSERT [dbo].[table_project_programmer] ([project_programmer_id], [project_id], [programmer_id], [admin_id]) VALUES (1022, 1023, 1, 1)
INSERT [dbo].[table_project_programmer] ([project_programmer_id], [project_id], [programmer_id], [admin_id]) VALUES (1023, 1023, 1002, 1)
INSERT [dbo].[table_project_programmer] ([project_programmer_id], [project_id], [programmer_id], [admin_id]) VALUES (1031, 1024, 2009, 1)
SET IDENTITY_INSERT [dbo].[table_project_programmer] OFF
SET IDENTITY_INSERT [dbo].[table_source_control] ON 

INSERT [dbo].[table_source_control] ([source_control_id], [link], [start_line], [end_line], [bug_id]) VALUES (1, N'https://github.com/Nishan211775/Bug-Tracking-System/blob/master/Bug%20Tracker/DAOImp/GenericDaoImp.cs', 1, 7, 98)
INSERT [dbo].[table_source_control] ([source_control_id], [link], [start_line], [end_line], [bug_id]) VALUES (2, N'https://github.com/Nishan211775/Bug-Tracking-System/blob/master/Bug%20Tracker/DAO/BugDAO.cs', 132, 147, 100)
INSERT [dbo].[table_source_control] ([source_control_id], [link], [start_line], [end_line], [bug_id]) VALUES (3, N'https://github.com/Nishan211775/Bug-Tracking-System/commits/master', 1, 5, 102)
SET IDENTITY_INSERT [dbo].[table_source_control] OFF
SET IDENTITY_INSERT [dbo].[table_tester] ON 

INSERT [dbo].[table_tester] ([tester_id], [full_name], [username], [password]) VALUES (1, N'Nishan Dhungana', N'nishandhungana41', N'nishan')
INSERT [dbo].[table_tester] ([tester_id], [full_name], [username], [password]) VALUES (2, N'uttam Bhandari', N'uttam', N'uttam')
SET IDENTITY_INSERT [dbo].[table_tester] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__table_admi__F3DBC572D2532E70]    Script Date: 5/18/2018 5:58:40 PM ******/
ALTER TABLE [dbo].[table_admin] ADD UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__table_prog__F3DBC572507AF3C7]    Script Date: 5/18/2018 5:58:40 PM ******/
ALTER TABLE [dbo].[table_programmer] ADD UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__table_test__F3DBC5726E85CA3F]    Script Date: 5/18/2018 5:58:40 PM ******/
ALTER TABLE [dbo].[table_tester] ADD UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[table_assign] ADD  DEFAULT (getdate()) FOR [assign_date]
GO
ALTER TABLE [dbo].[table_bug] ADD  DEFAULT ('0') FOR [bug_status]
GO
ALTER TABLE [dbo].[table_fixer] ADD  DEFAULT (getdate()) FOR [fixed_date]
GO
ALTER TABLE [dbo].[table_assign]  WITH CHECK ADD  CONSTRAINT [fk_assign_by] FOREIGN KEY([assign_by])
REFERENCES [dbo].[table_tester] ([tester_id])
GO
ALTER TABLE [dbo].[table_assign] CHECK CONSTRAINT [fk_assign_by]
GO
ALTER TABLE [dbo].[table_assign]  WITH CHECK ADD  CONSTRAINT [fk_assign_to] FOREIGN KEY([assign_to])
REFERENCES [dbo].[table_programmer] ([programmer_id])
GO
ALTER TABLE [dbo].[table_assign] CHECK CONSTRAINT [fk_assign_to]
GO
ALTER TABLE [dbo].[table_bug]  WITH CHECK ADD  CONSTRAINT [fk_code_author] FOREIGN KEY([code_author])
REFERENCES [dbo].[table_programmer] ([programmer_id])
GO
ALTER TABLE [dbo].[table_bug] CHECK CONSTRAINT [fk_code_author]
GO
ALTER TABLE [dbo].[table_bug_history]  WITH CHECK ADD  CONSTRAINT [fk_source_control_id] FOREIGN KEY([source_control_id])
REFERENCES [dbo].[table_source_control] ([source_control_id])
GO
ALTER TABLE [dbo].[table_bug_history] CHECK CONSTRAINT [fk_source_control_id]
GO
ALTER TABLE [dbo].[table_bug_information]  WITH CHECK ADD  CONSTRAINT [fk_bug_information_bug_id] FOREIGN KEY([bug_id])
REFERENCES [dbo].[table_bug] ([bug_id])
GO
ALTER TABLE [dbo].[table_bug_information] CHECK CONSTRAINT [fk_bug_information_bug_id]
GO
ALTER TABLE [dbo].[table_code]  WITH CHECK ADD  CONSTRAINT [fk_code_bug_id] FOREIGN KEY([bug_id])
REFERENCES [dbo].[table_bug] ([bug_id])
GO
ALTER TABLE [dbo].[table_code] CHECK CONSTRAINT [fk_code_bug_id]
GO
ALTER TABLE [dbo].[table_fixer]  WITH CHECK ADD  CONSTRAINT [fk_fixed_by] FOREIGN KEY([fixed_by])
REFERENCES [dbo].[table_programmer] ([programmer_id])
GO
ALTER TABLE [dbo].[table_fixer] CHECK CONSTRAINT [fk_fixed_by]
GO
ALTER TABLE [dbo].[table_fixer]  WITH CHECK ADD  CONSTRAINT [fk_fixer_bug_id] FOREIGN KEY([bug_id])
REFERENCES [dbo].[table_bug] ([bug_id])
GO
ALTER TABLE [dbo].[table_fixer] CHECK CONSTRAINT [fk_fixer_bug_id]
GO
ALTER TABLE [dbo].[table_image]  WITH CHECK ADD  CONSTRAINT [fk_image_bug_id] FOREIGN KEY([bug_id])
REFERENCES [dbo].[table_bug] ([bug_id])
GO
ALTER TABLE [dbo].[table_image] CHECK CONSTRAINT [fk_image_bug_id]
GO
ALTER TABLE [dbo].[table_project]  WITH CHECK ADD  CONSTRAINT [fk_admin_id] FOREIGN KEY([admin_id])
REFERENCES [dbo].[table_admin] ([admin_id])
GO
ALTER TABLE [dbo].[table_project] CHECK CONSTRAINT [fk_admin_id]
GO
ALTER TABLE [dbo].[table_project_programmer]  WITH CHECK ADD  CONSTRAINT [fk_admins_id] FOREIGN KEY([admin_id])
REFERENCES [dbo].[table_admin] ([admin_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[table_project_programmer] CHECK CONSTRAINT [fk_admins_id]
GO
ALTER TABLE [dbo].[table_project_programmer]  WITH CHECK ADD  CONSTRAINT [fk_programmer_id] FOREIGN KEY([programmer_id])
REFERENCES [dbo].[table_programmer] ([programmer_id])
GO
ALTER TABLE [dbo].[table_project_programmer] CHECK CONSTRAINT [fk_programmer_id]
GO
ALTER TABLE [dbo].[table_project_programmer]  WITH CHECK ADD  CONSTRAINT [fk_project_id] FOREIGN KEY([project_id])
REFERENCES [dbo].[table_project] ([project_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[table_project_programmer] CHECK CONSTRAINT [fk_project_id]
GO
ALTER TABLE [dbo].[table_source_control]  WITH CHECK ADD  CONSTRAINT [fk_bug_id] FOREIGN KEY([bug_id])
REFERENCES [dbo].[table_bug] ([bug_id])
GO
ALTER TABLE [dbo].[table_source_control] CHECK CONSTRAINT [fk_bug_id]
GO
USE [master]
GO
ALTER DATABASE [bug_tracker] SET  READ_WRITE 
GO
