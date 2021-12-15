USE [U13SHOUHOU]
GO

/****** Object:  Table [dbo].[RL_DBInfo]    Script Date: 2020-07-03 11:30:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RL_DBInfo](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[AccountName] [nvarchar](50) NULL,
	[Server] [nvarchar](100) NULL,
	[DataBase] [nvarchar](100) NULL,
	[User] [nvarchar](100) NULL,
	[PassWord] [nvarchar](100) NULL,
	[U8Server] [nvarchar](100) NULL,
	[U8DataBase] [nvarchar](100) NULL
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RL_DBInfo', @level2type=N'COLUMN',@level2name=N'AutoID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'售后账套名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RL_DBInfo', @level2type=N'COLUMN',@level2name=N'AccountName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'售后数据库IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RL_DBInfo', @level2type=N'COLUMN',@level2name=N'Server'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'售后数据库' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RL_DBInfo', @level2type=N'COLUMN',@level2name=N'DataBase'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'售后数据库登陆账号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RL_DBInfo', @level2type=N'COLUMN',@level2name=N'User'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'售后数据库登陆密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RL_DBInfo', @level2type=N'COLUMN',@level2name=N'PassWord'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'U8数据库IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RL_DBInfo', @level2type=N'COLUMN',@level2name=N'U8Server'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'U8数据库名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RL_DBInfo', @level2type=N'COLUMN',@level2name=N'U8DataBase'
GO






select * from RL_DBInfo

insert into RL_DBInfo(AccountName,[Server],[DataBase],[User],[PassWord],U8Server,U8DataBase)
values('001日立医疗售后账套','14.23.163.226,1491','U13SHOUHOU','sa','H&A87550788','192.168.0.220','UFDATA_001_2020')

insert into RL_DBInfo(AccountName,[Server],[DataBase],[User],[PassWord],U8Server,U8DataBase)
values('003日立医疗售后账套','14.23.163.226,1491','U13SHOUHOU003','sa','H&A87550788','192.168.0.220','UFDATA_003_2020')

insert into RL_DBInfo(AccountName,[Server],[DataBase],[User],[PassWord],U8Server,U8DataBase)
values('005日立医疗售后账套','14.23.163.226,1491','U13SHOUHOU005','sa','H&A87550788','192.168.0.220','UFDATA_005_2020')