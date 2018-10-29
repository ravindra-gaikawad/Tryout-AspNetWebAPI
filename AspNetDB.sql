Create Database AspNetDB;
Go

CREATE TABLE [dbo].[Employee](  
[ID] [bigint] IDENTITY(1,1) NOT NULL,  
[Name] [nvarchar](max) NULL,  
[Designation] [nvarchar](200) NULL,  
[Location] [nvarchar](200) NULL,  
CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED  
(  
    [ID] ASC  
))  
GO  

GO  
SET IDENTITY_INSERT [dbo].[Employee] ON  
GO  
INSERT [dbo].[Employee] ([ID], [Name], [Designation], [Location]) VALUES (1, N'Gnanavel Sekar', N'Software Engineer', N'Chennai')  
GO  
INSERT [dbo].[Employee] ([ID], [Name], [Designation], [Location]) VALUES (3, N'Robert', N'Application Developer', N'Chennai')  
GO  
INSERT [dbo].[Employee] ([ID], [Name], [Designation], [Location]) VALUES (4, N'Ramar', N'TechLead', N'Chennai')  
GO  
INSERT [dbo].[Employee] ([ID], [Name], [Designation], [Location]) VALUES (10002, N'Subash', N'Software Engineer', N'Coimbatore')  
GO  
INSERT [dbo].[Employee] ([ID], [Name], [Designation], [Location]) VALUES (10003, N'Gokul', N'Team Lead', N'USA')  
GO  
INSERT [dbo].[Employee] ([ID], [Name], [Designation], [Location]) VALUES (10004, N'Karthi', N'Sr. Software Engineer', N'Coimbatore')  
GO  
INSERT [dbo].[Employee] ([ID], [Name], [Designation], [Location]) VALUES (10005, N'Sharma', N'Software Engineer', N'Banglore')  
GO  
INSERT [dbo].[Employee] ([ID], [Name], [Designation], [Location]) VALUES (10006, N'Ammaiyappan', N'Software Developer', N'Chennai')  
GO  
INSERT [dbo].[Employee] ([ID], [Name], [Designation], [Location]) VALUES (10007, N'Manoj', N'Sr.Software Engineer', N'Chennai')  
GO  
INSERT [dbo].[Employee] ([ID], [Name], [Designation], [Location]) VALUES (10008, N'Mr.Blue', N'Sr.Software Engineer', N'Coimbatore')  
GO  
SET IDENTITY_INSERT [dbo].[Employee] OFF  
GO  
