USE [eBookDB]
GO

/****** Object:  Table [dbo].[tbl_admin_login]    Script Date: 30/01/2023 15:19:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_admin_login](
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NULL,
	[full_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_admin_login] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tbl_author_master]    Script Date: 30/01/2023 15:19:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_author_master](
	[author_id] [nchar](10) NOT NULL,
	[author_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_author_master] PRIMARY KEY CLUSTERED 
(
	[author_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tbl_book_issue]    Script Date: 30/01/2023 15:19:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_book_issue](
	[member_id] [nchar](10) NULL,
	[member_name] [nvarchar](50) NULL,
	[book_id] [nchar](10) NULL,
	[book_name] [nvarchar](max) NULL,
	[issue_date] [datetime] NULL,
	[due_date] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tbl_book_master]    Script Date: 30/01/2023 15:19:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_book_master](
	[book_id] [nchar](10) NOT NULL,
	[book_name] [nvarchar](100) NULL,
	[genre] [nvarchar](500) NULL,
	[author_name] [nvarchar](50) NULL,
	[publisher_name] [nvarchar](50) NULL,
	[publish_date] [datetime] NULL,
	[language] [nvarchar](50) NULL,
	[edition] [nvarchar](max) NULL,
	[book_cost] [nchar](10) NULL,
	[no_of_pages] [nchar](10) NULL,
	[book_description] [nvarchar](max) NULL,
	[actual_stock] [nchar](10) NULL,
	[current_stock] [nchar](10) NULL,
	[book_img_link] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_book_master] PRIMARY KEY CLUSTERED 
(
	[book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tbl_member_master]    Script Date: 30/01/2023 15:19:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_member_master](
	[member_id] [nchar](10) NOT NULL,
	[password] [nvarchar](50) NULL,
	[account_status] [nvarchar](50) NULL,
	[full_name] [nvarchar](50) NULL,
	[dob] [datetime] NULL,
	[contact_no] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[state] [nvarchar](50) NULL,
	[city] [nvarchar](50) NULL,
	[pincode] [nvarchar](50) NULL,
	[full_address] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_member_master] PRIMARY KEY CLUSTERED 
(
	[member_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tbl_publisher_master]    Script Date: 30/01/2023 15:19:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_publisher_master](
	[publisher_id] [nchar](10) NOT NULL,
	[publisher_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_publisher_master] PRIMARY KEY CLUSTERED 
(
	[publisher_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblCustomer]    Script Date: 30/01/2023 15:19:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblCustomer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Gender] [nvarchar](10) NULL,
	[City] [nvarchar](50) NULL,
	[DateOfBirth] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblDepartment]    Script Date: 30/01/2023 15:19:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblDepartment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IsSelected] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblEmployee]    Script Date: 30/01/2023 15:19:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblEmployee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Gender] [nvarchar](10) NULL,
	[City] [nvarchar](50) NULL,
	[DepartmentId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblEmployee]  WITH CHECK ADD FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[tblDepartment] ([Id])
GO


