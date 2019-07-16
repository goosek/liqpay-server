IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rl_feedback_data]') AND type in (N'U'))
CREATE TABLE [dbo].[rl_feedback_data](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Message] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rl_liqpay_donate_info]') AND type in (N'U'))
CREATE TABLE [dbo].[rl_liqpay_donate_info](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Order_id] [nvarchar](max) NULL,
	[Action] [nvarchar](max) NULL,
	[Amount] [decimal](18, 0) NULL,
	[Currency] [nvarchar](max) NULL,
	[Subscribe_amount] [decimal](18, 0) NULL,
	[Subscribe_date_start] [nvarchar](max) NULL,
	[Subscribe_periodicity] [nvarchar](max) NULL,
	[Signature] [nvarchar](max) NULL,
	[Status] [nvarchar](50) NULL,
	[JsonData] [nvarchar](max) NULL,
	[Sender_commission] [decimal](18, 0) NULL,
	[Receiver_commission] [decimal](18, 0) NULL,
	[Agent_commission] [decimal](18, 0) NULL,
	[Sender_card_country] [nvarchar](max) NULL,
	[Ip] [nvarchar](max) NULL,
	[Description] [nvarchar](50) NULL,
	[PaimentDate] [datetime] NULL,
	[TypeOfPayer] [nvarchar](50) NULL,
 CONSTRAINT [PK_rl_liqpay_donate_info] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rl_subscribers]') AND type in (N'U'))
CREATE TABLE [dbo].[rl_subscribers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

