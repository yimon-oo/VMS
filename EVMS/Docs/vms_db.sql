USE [vms]
GO
/****** Object:  Table [dbo].[goods]    Script Date: 2023/04/28 10:58:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[goods](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[price] [int] NULL,
 CONSTRAINT [PK_goods] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[user]    Script Date: 2023/04/28 10:58:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[phone_number] [int] NULL,
	[username] [nvarchar](max) NULL,
	[password] [nvarchar](max) NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[user_goods]    Script Date: 2023/04/28 10:58:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_goods](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_voucher_id] [int] NULL,
	[goods_id] [int] NULL,
	[payment_method] [int] NULL,
	[promo_price] [int] NULL,
 CONSTRAINT [PK_user_goods] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[user_voucher]    Script Date: 2023/04/28 10:58:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_voucher](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[voucher_id] [int] NULL,
	[buy_type] [int] NULL,
	[gifttouser_id] [int] NULL,
	[qty] [int] NULL,
 CONSTRAINT [PK_user_voucher] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[voucher]    Script Date: 2023/04/28 10:58:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[voucher](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](max) NULL,
	[description] [nvarchar](max) NULL,
	[expiry_date] [datetime] NULL,
	[code] [nvarchar](100) NULL,
	[qr_image] [nvarchar](max) NULL,
	[amount] [int] NULL,
	[quantity] [int] NULL,
	[maximum] [int] NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_voucher] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  View [dbo].[View_PurchaseHistory]    Script Date: 2023/04/28 10:58:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[View_PurchaseHistory] as

select 
u.id,u.name, u.phone_number, v.title, v.code, v.expiry_date, IIF(v.status =1 ,'Active','InActive')
AS status,
g.name as goodsname,g.price as originalprice, ug.promo_price
from [user] u
inner join user_voucher uv on uv.user_id=u.id 
right join voucher v on v.id=uv.voucher_id
inner join user_goods ug on ug.user_voucher_id=uv.id
inner join goods g on g.id=ug.goods_id


GO
SET IDENTITY_INSERT [dbo].[goods] ON 

INSERT [dbo].[goods] ([id], [name], [price]) VALUES (1, N'Watch', 100)
SET IDENTITY_INSERT [dbo].[goods] OFF
SET IDENTITY_INSERT [dbo].[user] ON 

INSERT [dbo].[user] ([id], [name], [phone_number], [username], [password]) VALUES (1, N'ymo', 999999999, N'yimon', N'yimon')
SET IDENTITY_INSERT [dbo].[user] OFF
SET IDENTITY_INSERT [dbo].[user_goods] ON 

INSERT [dbo].[user_goods] ([id], [user_voucher_id], [goods_id], [payment_method], [promo_price]) VALUES (1, 1, 1, 1, 80)
SET IDENTITY_INSERT [dbo].[user_goods] OFF
SET IDENTITY_INSERT [dbo].[user_voucher] ON 

INSERT [dbo].[user_voucher] ([id], [user_id], [voucher_id], [buy_type], [gifttouser_id], [qty]) VALUES (1, 1, 2, 1, 0, 2)
SET IDENTITY_INSERT [dbo].[user_voucher] OFF
SET IDENTITY_INSERT [dbo].[voucher] ON 

INSERT [dbo].[voucher] ([id], [title], [description], [expiry_date], [code], [qr_image], [amount], [quantity], [maximum], [status]) VALUES (2, N'HappyThinGyan', N'HappyThinGyan', CAST(N'2022-01-02 00:00:00.000' AS DateTime), N'ThinGyan423', N'', 20, 100, 3, 1)
INSERT [dbo].[voucher] ([id], [title], [description], [expiry_date], [code], [qr_image], [amount], [quantity], [maximum], [status]) VALUES (3, N'HappyThinGyan', N'HappyThinGyan', CAST(N'2022-01-02 00:00:00.000' AS DateTime), N'ThinGyan423', N'', 20, 100, 3, 1)
SET IDENTITY_INSERT [dbo].[voucher] OFF
