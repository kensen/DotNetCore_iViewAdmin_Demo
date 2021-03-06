USE [LBDBTest]
GO
/****** Object:  Table [dbo].[BaseRole]    Script Date: 2018/12/19 20:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BaseRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](20) NULL,
	[Description] [varchar](500) NULL,
	[Authority] [varchar](3000) NULL,
	[CreateUser] [varchar](20) NULL,
	[CreateUserId] [int] NULL,
	[UpdateTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedTime] [datetime] NULL,
 CONSTRAINT [PK_BASE_ROLE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BaseTokens]    Script Date: 2018/12/19 20:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaseTokens](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LoginId] [nvarchar](100) NULL,
	[AccessToken] [nvarchar](1000) NULL,
	[RefreshToken] [nvarchar](300) NULL,
	[IssuedUtc] [datetime] NULL,
	[CreatedTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[ExpiresUtc] [datetime] NULL,
 CONSTRAINT [PK_BASETOKENS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BaseUserRoleMap]    Script Date: 2018/12/19 20:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaseUserRoleMap](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[RoleId] [int] NULL,
	[CreatedTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_BASE_USERROLEMAP] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BaseUsers]    Script Date: 2018/12/19 20:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BaseUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](20) NULL,
	[LoginId] [varchar](100) NULL,
	[PassWord] [varchar](100) NULL,
	[UserAuthority] [varchar](3000) NULL,
	[UserType] [tinyint] NULL,
	[CreateUser] [nvarchar](50) NULL,
	[CreateUserId] [int] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedTime] [datetime] NULL,
	[OpenId] [nvarchar](100) NULL,
 CONSTRAINT [PK_BASE_USERS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[v_UserInfo]    Script Date: 2018/12/19 20:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_UserInfo]
AS
SELECT   dbo.BaseUsers.Id, dbo.BaseUsers.UserName, dbo.BaseUsers.LoginId, dbo.BaseUsers.UserType, 
                dbo.BaseRole.RoleName, dbo.BaseRole.Description, dbo.BaseRole.Authority, dbo.BaseUsers.CreatedTime, 
                dbo.BaseUsers.PassWord
FROM      dbo.BaseUsers LEFT OUTER JOIN
                dbo.BaseUserRoleMap ON dbo.BaseUsers.Id = dbo.BaseUserRoleMap.UserId LEFT OUTER JOIN
                dbo.BaseRole ON dbo.BaseUserRoleMap.RoleId = dbo.BaseRole.Id

GO
SET IDENTITY_INSERT [dbo].[BaseRole] ON 

INSERT [dbo].[BaseRole] ([Id], [RoleName], [Description], [Authority], [CreateUser], [CreateUserId], [UpdateTime], [IsDeleted], [CreatedTime]) VALUES (39, N'234', N'234', N'[{"name":"sysmanager","icon":"md-menu","href":"","meta":{"title":"系统管理","icon":"md-menu","href":null,"access":null,"showAlways":false},"show":false,"children":[{"name":"usermanager","icon":"md-funnel","href":"","meta":{"title":"用户管理","icon":"md-funnel","href":null,"access":null,"showAlways":false},"show":true,"children":null},{"name":"rolemanager","icon":"md-funnel","href":"","meta":{"title":"角色管理","icon":"md-funnel","href":null,"access":null,"showAlways":false},"show":true,"children":null}]},{"name":"multilevel","icon":"md-menu","href":"","meta":{"title":"多级菜单","icon":"md-menu","href":null,"access":null,"showAlways":false},"show":false,"children":[{"name":"level_2_1","icon":"md-funnel","href":"","meta":{"title":"二级-1","icon":"md-funnel","href":null,"access":null,"showAlways":false},"show":false,"children":null},{"name":"level_2_2","icon":"md-funnel","href":"","meta":{"title":"二级-2","icon":"md-funnel","href":null,"access":["super_admin"],"showAlways":true},"show":false,"children":[{"name":"level_2_2_1","icon":"md-funnel","href":"","meta":{"title":"三级","icon":"md-funnel","href":null,"access":null,"showAlways":false},"show":false,"children":null}]},{"name":"level_2_3","icon":"md-funnel","href":"","meta":{"title":"二级-3","icon":"md-funnel","href":null,"access":null,"showAlways":false},"show":false,"children":null}]}]', N'admin', 1, CAST(0x0000A9BA01146A94 AS DateTime), 0, CAST(0x0000A9BA01146A94 AS DateTime))
INSERT [dbo].[BaseRole] ([Id], [RoleName], [Description], [Authority], [CreateUser], [CreateUserId], [UpdateTime], [IsDeleted], [CreatedTime]) VALUES (40, N'系统管理员', N'系统管理员', N'[{"name":"sysmanager","icon":"md-menu","href":"","meta":{"title":"系统管理","icon":"md-menu","href":null,"access":null,"showAlways":false},"show":true,"children":[{"name":"usermanager","icon":"md-funnel","href":"","meta":{"title":"用户管理","icon":"md-funnel","href":null,"access":null,"showAlways":false},"show":true,"children":null},{"name":"rolemanager","icon":"md-funnel","href":"","meta":{"title":"角色管理","icon":"md-funnel","href":null,"access":null,"showAlways":false},"show":false,"children":null}]},{"name":"multilevel","icon":"md-menu","href":"","meta":{"title":"多级菜单","icon":"md-menu","href":null,"access":null,"showAlways":false},"show":true,"children":[{"name":"level_2_1","icon":"md-funnel","href":"","meta":{"title":"二级-1","icon":"md-funnel","href":null,"access":null,"showAlways":false},"show":false,"children":null},{"name":"level_2_2","icon":"md-funnel","href":"","meta":{"title":"二级-2","icon":"md-funnel","href":null,"access":["super_admin"],"showAlways":true},"show":true,"children":[{"name":"level_2_2_1","icon":"md-funnel","href":"","meta":{"title":"三级","icon":"md-funnel","href":null,"access":null,"showAlways":false},"show":false,"children":null}]},{"name":"level_2_3","icon":"md-funnel","href":"","meta":{"title":"二级-3","icon":"md-funnel","href":null,"access":null,"showAlways":false},"show":true,"children":null}]}]', N'admin', 1, CAST(0x0000A9BB01460981 AS DateTime), 0, CAST(0x0000A9BA0114D454 AS DateTime))
SET IDENTITY_INSERT [dbo].[BaseRole] OFF
SET IDENTITY_INSERT [dbo].[BaseUserRoleMap] ON 

INSERT [dbo].[BaseUserRoleMap] ([Id], [UserId], [RoleId], [CreatedTime], [IsDeleted]) VALUES (3, 4, 39, CAST(0x0000A9BB0106DB63 AS DateTime), 0)
INSERT [dbo].[BaseUserRoleMap] ([Id], [UserId], [RoleId], [CreatedTime], [IsDeleted]) VALUES (4, 5, 39, CAST(0x0000A9BB0107F156 AS DateTime), 0)
INSERT [dbo].[BaseUserRoleMap] ([Id], [UserId], [RoleId], [CreatedTime], [IsDeleted]) VALUES (5, 6, 40, CAST(0x0000A9BB010B30B5 AS DateTime), 0)
INSERT [dbo].[BaseUserRoleMap] ([Id], [UserId], [RoleId], [CreatedTime], [IsDeleted]) VALUES (6, 7, 39, CAST(0x0000A9BB014638FF AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[BaseUserRoleMap] OFF
SET IDENTITY_INSERT [dbo].[BaseUsers] ON 

INSERT [dbo].[BaseUsers] ([Id], [UserName], [LoginId], [PassWord], [UserAuthority], [UserType], [CreateUser], [CreateUserId], [IsDeleted], [CreatedTime], [OpenId]) VALUES (1, N'管理员', N'admin', N'e10adc3949ba59abbe56e057f20f883e', NULL, 0, N'admin', 0, 0, CAST(0x0000A9B400000000 AS DateTime), NULL)
INSERT [dbo].[BaseUsers] ([Id], [UserName], [LoginId], [PassWord], [UserAuthority], [UserType], [CreateUser], [CreateUserId], [IsDeleted], [CreatedTime], [OpenId]) VALUES (4, N'12333', N'123', N'e10adc3949ba59abbe56e057f20f883e', NULL, 1, N'admin', 1, 0, CAST(0x0000A9BB0106DB55 AS DateTime), NULL)
INSERT [dbo].[BaseUsers] ([Id], [UserName], [LoginId], [PassWord], [UserAuthority], [UserType], [CreateUser], [CreateUserId], [IsDeleted], [CreatedTime], [OpenId]) VALUES (5, N'4r原因', N'4r', N'e10adc3949ba59abbe56e057f20f883e', NULL, 1, N'admin', 1, 0, CAST(0x0000A9BB0107F153 AS DateTime), NULL)
INSERT [dbo].[BaseUsers] ([Id], [UserName], [LoginId], [PassWord], [UserAuthority], [UserType], [CreateUser], [CreateUserId], [IsDeleted], [CreatedTime], [OpenId]) VALUES (6, N'测试2', N'test', N'e10adc3949ba59abbe56e057f20f883e', NULL, 1, N'admin', 1, 0, CAST(0x0000A9BB010B30B3 AS DateTime), NULL)
INSERT [dbo].[BaseUsers] ([Id], [UserName], [LoginId], [PassWord], [UserAuthority], [UserType], [CreateUser], [CreateUserId], [IsDeleted], [CreatedTime], [OpenId]) VALUES (7, N'test2', N'test2', N'e10adc3949ba59abbe56e057f20f883e', NULL, 1, N'test', 6, 0, CAST(0x0000A9BB014638F6 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[BaseUsers] OFF
ALTER TABLE [dbo].[BaseUserRoleMap]  WITH NOCHECK ADD  CONSTRAINT [FK_BASEUSER_REFERENCE_BASEROLE] FOREIGN KEY([RoleId])
REFERENCES [dbo].[BaseRole] ([Id])
ON DELETE CASCADE
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[BaseUserRoleMap] NOCHECK CONSTRAINT [FK_BASEUSER_REFERENCE_BASEROLE]
GO
ALTER TABLE [dbo].[BaseUserRoleMap]  WITH CHECK ADD  CONSTRAINT [FK_BASEUSER_REFERENCE_BASEUSER] FOREIGN KEY([UserId])
REFERENCES [dbo].[BaseUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BaseUserRoleMap] CHECK CONSTRAINT [FK_BASEUSER_REFERENCE_BASEUSER]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseRole', @level2type=N'COLUMN',@level2name=N'RoleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseRole', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限配置信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseRole', @level2type=N'COLUMN',@level2name=N'Authority'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户角色权限表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseRole'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户登录ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseTokens', @level2type=N'COLUMN',@level2name=N'LoginId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'授权Token' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseTokens', @level2type=N'COLUMN',@level2name=N'AccessToken'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'刷新Token' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseTokens', @level2type=N'COLUMN',@level2name=N'RefreshToken'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseTokens', @level2type=N'COLUMN',@level2name=N'IssuedUtc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseTokens', @level2type=N'COLUMN',@level2name=N'CreatedTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'到期时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseTokens', @level2type=N'COLUMN',@level2name=N'ExpiresUtc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'授权票据表 ，OAuth授权令牌信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseTokens'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户角色对应表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseUserRoleMap'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseUsers', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录账号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseUsers', @level2type=N'COLUMN',@level2name=N'LoginId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseUsers', @level2type=N'COLUMN',@level2name=N'PassWord'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseUsers', @level2type=N'COLUMN',@level2name=N'UserAuthority'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0内置管理员，1普通用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseUsers', @level2type=N'COLUMN',@level2name=N'UserType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预留OpenID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseUsers', @level2type=N'COLUMN',@level2name=N'OpenId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户账号表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseUsers'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[37] 4[24] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "BaseRole"
            Begin Extent = 
               Top = 8
               Left = 877
               Bottom = 285
               Right = 1058
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BaseUserRoleMap"
            Begin Extent = 
               Top = 50
               Left = 478
               Bottom = 294
               Right = 641
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BaseUsers"
            Begin Extent = 
               Top = 14
               Left = 0
               Bottom = 295
               Right = 335
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 15
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_UserInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_UserInfo'
GO
