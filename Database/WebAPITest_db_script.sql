USE [WebAPITest]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 14/9/2018 1:35:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EventId] [varchar](50) NOT NULL,
	[EventTimestamp] [datetime] NOT NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 14/9/2018 1:35:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EventId] [varchar](50) NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[ProductName] [varchar](255) NOT NULL,
	[Quantity] [int] NOT NULL,
	[SaleAmount] [money] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([Id], [EventId], [EventTimestamp]) VALUES (1, N'E001', CAST(N'2018-09-14T10:00:00.000' AS DateTime))
INSERT [dbo].[Events] ([Id], [EventId], [EventTimestamp]) VALUES (2, N'E002', CAST(N'2018-09-14T10:00:00.000' AS DateTime))
INSERT [dbo].[Events] ([Id], [EventId], [EventTimestamp]) VALUES (3, N'E003', CAST(N'2018-09-14T10:00:00.000' AS DateTime))
INSERT [dbo].[Events] ([Id], [EventId], [EventTimestamp]) VALUES (4, N'E004', CAST(N'2018-09-14T10:00:00.000' AS DateTime))
INSERT [dbo].[Events] ([Id], [EventId], [EventTimestamp]) VALUES (6, N'E005', CAST(N'2018-09-14T10:00:00.000' AS DateTime))
INSERT [dbo].[Events] ([Id], [EventId], [EventTimestamp]) VALUES (7, N'E006', CAST(N'2018-09-14T10:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Events] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [EventId], [ProductId], [ProductName], [Quantity], [SaleAmount]) VALUES (1, N'E001', 1, N'Product 1', 10, 1000.0000)
INSERT [dbo].[Products] ([Id], [EventId], [ProductId], [ProductName], [Quantity], [SaleAmount]) VALUES (2, N'E002', 2, N'Product 2', 20, 2000.0000)
INSERT [dbo].[Products] ([Id], [EventId], [ProductId], [ProductName], [Quantity], [SaleAmount]) VALUES (3, N'E002', 3, N'Product 3', 30, 3000.0000)
INSERT [dbo].[Products] ([Id], [EventId], [ProductId], [ProductName], [Quantity], [SaleAmount]) VALUES (4, N'E003', 4, N'Product 4', 40, 4000.0000)
INSERT [dbo].[Products] ([Id], [EventId], [ProductId], [ProductName], [Quantity], [SaleAmount]) VALUES (5, N'E003', 5, N'Product 5', 50, 5000.0000)
INSERT [dbo].[Products] ([Id], [EventId], [ProductId], [ProductName], [Quantity], [SaleAmount]) VALUES (6, N'E004', 6, N'Product 6', 60, 6000.0000)
INSERT [dbo].[Products] ([Id], [EventId], [ProductId], [ProductName], [Quantity], [SaleAmount]) VALUES (7, N'E004', 7, N'Product 7', 70, 7000.0000)
INSERT [dbo].[Products] ([Id], [EventId], [ProductId], [ProductName], [Quantity], [SaleAmount]) VALUES (8, N'E005', 8, N'Product 8', 80, 8000.0000)
INSERT [dbo].[Products] ([Id], [EventId], [ProductId], [ProductName], [Quantity], [SaleAmount]) VALUES (9, N'E005', 9, N'Product 9', 90, 9000.0000)
INSERT [dbo].[Products] ([Id], [EventId], [ProductId], [ProductName], [Quantity], [SaleAmount]) VALUES (10, N'E006', 10, N'Product 10', 100, 10000.0000)
SET IDENTITY_INSERT [dbo].[Products] OFF
