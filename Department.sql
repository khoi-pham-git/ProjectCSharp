USE [DepartmentManagement]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 7/11/2021 2:51:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [char](10) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Foundedyear] [int] NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Department] ([Id], [Name], [Foundedyear]) VALUES (N'AB        ', N'eddd', 2011)
INSERT [dbo].[Department] ([Id], [Name], [Foundedyear]) VALUES (N'AI        ', N'Artificial Intellingence', 2001)
INSERT [dbo].[Department] ([Id], [Name], [Foundedyear]) VALUES (N'DM        ', N'Digital Marketing', 2019)
INSERT [dbo].[Department] ([Id], [Name], [Foundedyear]) VALUES (N'FA        ', N'dddd', 2012)
INSERT [dbo].[Department] ([Id], [Name], [Foundedyear]) VALUES (N'GD        ', N'Graphic Design', 2000)
INSERT [dbo].[Department] ([Id], [Name], [Foundedyear]) VALUES (N'IA        ', N'Information Assurance', 1999)
INSERT [dbo].[Department] ([Id], [Name], [Foundedyear]) VALUES (N'IB        ', N'International Business', 1999)
INSERT [dbo].[Department] ([Id], [Name], [Foundedyear]) VALUES (N'IU        ', N'Iuxinhdep', 2011)
INSERT [dbo].[Department] ([Id], [Name], [Foundedyear]) VALUES (N'MC        ', N'Multimedia Communications', 2020)
INSERT [dbo].[Department] ([Id], [Name], [Foundedyear]) VALUES (N'SE        ', N'Software Engineering', 1999)
GO
