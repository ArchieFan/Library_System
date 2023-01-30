USE [eBookDB]
GO

/****** Object:  StoredProcedure [dbo].[sp_builddropdownauthor]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_builddropdownauthor]   
     
AS   

    SET NOCOUNT ON;  
	SELECT author_name from tbl_author_master order by author_id;
GO

/****** Object:  StoredProcedure [dbo].[sp_builddropdownpublisher]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_builddropdownpublisher]   
     
AS   

    SET NOCOUNT ON;  
	SELECT publisher_name from tbl_publisher_master order by publisher_id;
GO

/****** Object:  StoredProcedure [dbo].[sp_checkadminauth]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[sp_checkadminauth]   
    @userid nvarchar(50),
	@password nvarchar(50)
AS   

    SET NOCOUNT ON;  
	SELECT * from tbl_admin_login where username=@userid and password=@password; 
GO

/****** Object:  StoredProcedure [dbo].[sp_checkbook]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[sp_checkbook]   
    @book_id nchar(10),
	@book_name nvarchar(50)
AS   

    SET NOCOUNT ON;  
	SELECT * from tbl_book_master where book_id=@book_id OR book_name=@book_name;
GO

/****** Object:  StoredProcedure [dbo].[sp_checkmemberauth]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[sp_checkmemberauth]   
    @member_id nchar(10),
	@password nvarchar(50)
AS   

    SET NOCOUNT ON;  
	SELECT * from tbl_member_master where member_id=@member_id and password=@password;
GO

/****** Object:  StoredProcedure [dbo].[sp_deleteauthor]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_deleteauthor]   
    @author_id nchar(10)   
AS   

    SET NOCOUNT ON;  
	DELETE from tbl_author_master WHERE author_id=@author_id;  
GO

/****** Object:  StoredProcedure [dbo].[sp_deletebook]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[sp_deletebook]   
    @book_id nchar(10)   
AS   

    SET NOCOUNT ON;  
	DELETE from tbl_book_master WHERE book_id=@book_id; 
GO

/****** Object:  StoredProcedure [dbo].[sp_deletemember]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[sp_deletemember]   
    @member_id nchar(10)   
AS   

    SET NOCOUNT ON;  
	DELETE from tbl_member_master WHERE member_id=@member_id;  
GO

/****** Object:  StoredProcedure [dbo].[sp_deletepublisher]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_deletepublisher]   
    @publisher_id nchar(10)   
AS   

    --SET NOCOUNT ON;  
	Delete from tbl_publisher_master WHERE publisher_id=@publisher_id;
GO

/****** Object:  StoredProcedure [dbo].[sp_getauthor]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_getauthor]   
    @author_id nchar(10)   
AS   

    SET NOCOUNT ON;  
	SELECT * from tbl_author_master where author_id=@author_id;  
GO

/****** Object:  StoredProcedure [dbo].[sp_getauthorlist]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[sp_getauthorlist] 
AS   

    SET NOCOUNT ON;  
	SELECT * FROM [tbl_author_master] ORDER BY [author_id]
GO

/****** Object:  StoredProcedure [dbo].[sp_getbook]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_getbook]   
    @book_id nchar(10)   
AS   

    SET NOCOUNT ON;  
	SELECT * from tbl_book_master WHERE book_id=@book_id;
GO

/****** Object:  StoredProcedure [dbo].[sp_getbookissuefrommember]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[sp_getbookissuefrommember]   
    @member_id nchar(10)   
AS   

    SET NOCOUNT ON;  
	SELECT * from tbl_book_issue where member_id=@member_id;
GO

/****** Object:  StoredProcedure [dbo].[sp_getbooklist]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[sp_getbooklist]   
AS   

    SET NOCOUNT ON;  
	SELECT * FROM [tbl_book_master] ORDER BY book_id;
GO

/****** Object:  StoredProcedure [dbo].[sp_getmember]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[sp_getmember]   
    @member_id nchar(10)   
AS   

    SET NOCOUNT ON;  
	select * from tbl_member_master where member_id=@member_id;
GO

/****** Object:  StoredProcedure [dbo].[sp_getmemberlist]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[sp_getmemberlist]   
AS   

    SET NOCOUNT ON;  
	SELECT * FROM [tbl_member_master] ORDER BY [member_id];
GO

/****** Object:  StoredProcedure [dbo].[sp_getpublisher]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_getpublisher]   
    @publisher_id nchar(10)   
AS   

    SET NOCOUNT ON;  
	SELECT * from tbl_publisher_master where publisher_id=@publisher_id;
GO

/****** Object:  StoredProcedure [dbo].[sp_getpublisherlist]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[sp_getpublisherlist]   
AS   

    SET NOCOUNT ON;  
	SELECT * FROM [tbl_publisher_master] ORDER BY [publisher_id];
GO

/****** Object:  StoredProcedure [dbo].[sp_insertauthor]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_insertauthor]   
    @author_id nchar(10),
	@author_name nvarchar(50)
AS   

    SET NOCOUNT ON;  
	INSERT INTO tbl_author_master(author_id,author_name) values(@author_id,@author_name)
GO

/****** Object:  StoredProcedure [dbo].[sp_insertbook]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[sp_insertbook]   
    @book_id nchar(10),
	@book_name nvarchar(100),
	@genre nvarchar(500),
	@author_name nvarchar(50),
	@publisher_name nvarchar(50),
	@publish_date datetime,
	@language nvarchar(50),
	@edition nvarchar(max),
	@book_cost nchar(10),
	@no_of_pages nchar(10),
	@book_description nvarchar(max),
	@actual_stock nchar(10),
	@current_stock nchar(10),
	@book_img_link nvarchar(max)
AS   

    SET NOCOUNT ON;  
	INSERT INTO tbl_book_master(book_id,book_name,genre,author_name,publisher_name,publish_date,language,edition,book_cost,no_of_pages,book_description,actual_stock,current_stock,book_img_link) 
	values(@book_id,@book_name,@genre,@author_name,@publisher_name,@publish_date,@language,@edition,@book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock,@book_img_link)
GO

/****** Object:  StoredProcedure [dbo].[sp_insertmember]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO








CREATE PROCEDURE [dbo].[sp_insertmember]   
    @member_id nchar(10),
	@full_name nvarchar(50),
	@dob datetime,
	@contact_no nvarchar(50),
	@email nvarchar(50),
	@state nvarchar(50),
	@city nvarchar(50),
	@pincode nvarchar(50),
	@full_address nvarchar(max),
	@password nvarchar(50),
	@account_status nvarchar(50)
AS   

    --SET NOCOUNT ON;  
	INSERT INTO tbl_member_master
	(full_name,dob,contact_no,email,state,city,pincode,full_address,member_id,password,account_status) 
	values
	(@full_name,@dob,@contact_no,@email,@state,@city,@pincode,@full_address,@member_id,@password,@account_status)
GO

/****** Object:  StoredProcedure [dbo].[sp_insertpublisher]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_insertpublisher]   
    @publisher_id nchar(10),
	@publisher_name nvarchar(50)
AS   

    SET NOCOUNT ON;  
	INSERT INTO tbl_publisher_master(publisher_id,publisher_name) values(@publisher_id,@publisher_name)
GO

/****** Object:  StoredProcedure [dbo].[sp_updateauthor]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_updateauthor]   
    @author_id nchar(10),
	@author_name nvarchar(50)
AS   

    SET NOCOUNT ON;  
	UPDATE tbl_author_master SET author_name=@author_name WHERE author_id=@author_id
GO

/****** Object:  StoredProcedure [dbo].[sp_updatebook]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[sp_updatebook]   
    @book_id nchar(10),
	@book_name nvarchar(100),
	@genre nvarchar(500),
	@author_name nvarchar(50),
	@publisher_name nvarchar(50),
	@publish_date datetime,
	@language nvarchar(50),
	@edition nvarchar(max),
	@book_cost nchar(10),
	@no_of_pages nchar(10),
	@book_description nvarchar(max),
	@actual_stock nchar(10),
	@current_stock nchar(10),
	@book_img_link nvarchar(max)
AS   

    SET NOCOUNT ON;  
	UPDATE tbl_book_master set 
	book_name=@book_name, 
	genre=@genre, 
	author_name=@author_name, 
	publisher_name=@publisher_name, 
	publish_date=@publish_date, 
	language=@language, 
	edition=@edition, 
	book_cost=@book_cost, 
	no_of_pages=@no_of_pages, 
	book_description=@book_description, 
	actual_stock=@actual_stock, 
	current_stock=@current_stock, 
	book_img_link=@book_img_link 
	where book_id=@book_id;
GO

/****** Object:  StoredProcedure [dbo].[sp_updatemember]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE [dbo].[sp_updatemember]   
    @member_id nchar(10),
	@full_name nvarchar(50),
	@dob datetime,
	@contact_no nvarchar(50),
	@email nvarchar(50),
	@state nvarchar(50),
	@city nvarchar(50),
	@pincode nvarchar(50),
	@full_address nvarchar(max),
	@password nvarchar(50),
	@account_status nvarchar(50)
AS   

    --SET NOCOUNT ON;  
	update tbl_member_master set 
	full_name=@full_name, 
	dob=@dob, 
	contact_no=@contact_no, 
	email=@email, 
	state=@state, 
	city=@city, 
	pincode=@pincode, 
	full_address=@full_address, 
	password=@password, 
	account_status=@account_status 
	WHERE member_id=@member_id;
GO

/****** Object:  StoredProcedure [dbo].[sp_updatememberstatus]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[sp_updatememberstatus]   
    @member_id nchar(10),
	@status nvarchar(50)
AS   

    SET NOCOUNT ON;  
	UPDATE tbl_member_master SET account_status=@status WHERE member_id=@member_id;
GO

/****** Object:  StoredProcedure [dbo].[sp_updatepublisher]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_updatepublisher]   
    @publisher_id nchar(10),
	@publisher_name nvarchar(50)
AS   

    --SET NOCOUNT ON;  
	update tbl_publisher_master set publisher_name=@publisher_name WHERE publisher_id=@publisher_id
GO

/****** Object:  StoredProcedure [dbo].[spAddCustomer]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[spAddCustomer]
@Name nvarchar(50) = null,  
@Gender nvarchar (10) = null,  
@City nvarchar (50) = null,  
@DateOfBirth DateTime = null  
as  
Begin  
 Insert into tblCustomer (Name, Gender, City, DateOfBirth)  
 Values (@Name, @Gender, @City, @DateOfBirth)  
End
GO

/****** Object:  StoredProcedure [dbo].[spDeleteCustomer]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[spDeleteCustomer]
@Id int
as
Begin
 Delete from tblCustomer
 where Id = @Id
End
GO

/****** Object:  StoredProcedure [dbo].[spGetAllCustomers]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[spGetAllCustomers]
as
Begin
 Select Id, Name, Gender, City, DateOfBirth
 from tblCustomer
End
GO

/****** Object:  StoredProcedure [dbo].[spSaveCustomer]    Script Date: 30/01/2023 15:44:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[spSaveCustomer]      
@Id int,
@Name nvarchar(50),      
@Gender nvarchar (10),      
@City nvarchar (50),      
@DateOfBirth DateTime 
as      
Begin      
 Update tblCustomer Set
 Name = @Name,
 Gender = @Gender,
 City = @City,
 DateOfBirth = @DateOfBirth
 Where Id = @Id 
End
GO


