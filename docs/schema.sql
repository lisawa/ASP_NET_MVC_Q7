USE [Q7DB]
GO

/****** Object:  Table [dbo].[TodoList]    Script Date: 2019/6/21 ¤U¤È 03:19:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TodoList](
	[ID] [int] NOT NULL identity,
	[UserName] [nvarchar](50) NULL,
	[TodoTopic] [nvarchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[FinishTime] [datetime] NULL,
	[ShowStatus] [bit] NOT NULL,
UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


