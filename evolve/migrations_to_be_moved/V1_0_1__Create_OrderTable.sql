CREATE TABLE [dbo].[${orderTable}](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime] NULL,
	[Total] [decimal](18, 2) NULL,
	[CustomerId] [int] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[${orderTable}]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO

ALTER TABLE [dbo].[${orderTable}] CHECK CONSTRAINT [FK_Order_Customer]
GO