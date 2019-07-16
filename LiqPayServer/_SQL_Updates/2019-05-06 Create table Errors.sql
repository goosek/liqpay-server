IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Errors]') AND type in (N'U'))
CREATE TABLE [dbo].[Errors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ErrorDate] [datetime] NULL,
	[ErrorMessage] [nvarchar](max) NULL,
	[ErrorInfo] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


