SELECT * FROM [MyOnlineShopping].[dbo].[Members]

SET IDENTITY_INSERT [MyOnlineShopping].[dbo].[Members] ON;  
GO

INSERT INTO Members(MemberId, FristName, LastName, EmailId, Password, IsActive, IsDelete, CreatedOn, ModifiedOn) 
VALUES(1, 'Lakshman', 'Kolluru', 'b1@gmail.com', 'Lakshman', 1, 0, GETDATE(), GETDATE())
INSERT INTO Members(MemberId, FristName, LastName, EmailId, Password, IsActive, IsDelete, CreatedOn, ModifiedOn)
VALUES(2, 'Subhakar', 'Kalva', 'b2@gmail.com', 'Subhakar', 1, 0, GETDATE(), GETDATE())
INSERT INTO Members(MemberId, FristName, LastName, EmailId, Password, IsActive, IsDelete, CreatedOn, ModifiedOn) 
VALUES(3, 'Keerthana', 'Konduru', 'b3@gmail.com', 'Keerthana', 1, 0, GETDATE(), GETDATE())
INSERT INTO Members(MemberId, FristName, LastName, EmailId, Password, IsActive, IsDelete, CreatedOn, ModifiedOn) 
VALUES(4, 'Mohana', 'Mandava', 'b4@gmail.com', 'Mohana', 1, 0, GETDATE(), GETDATE())
INSERT INTO Members(MemberId, FristName, LastName, EmailId, Password, IsActive, IsDelete, CreatedOn, ModifiedOn) 
VALUES(5, 'Bala', 'Barre', 'b5@gmail.com', 'Bala', 1, 0, GETDATE(), GETDATE())

SET IDENTITY_INSERT [MyOnlineShopping].[dbo].[Members] OFF;  
GO

SELECT * FROM [MyOnlineShopping].[dbo].[Roles]

SET IDENTITY_INSERT [MyOnlineShopping].[dbo].[Roles] ON;  
GO

INSERT INTO Roles(RoleId, RoleName) VALUES(1, 'Security Admin')
INSERT INTO Roles(RoleId, RoleName) VALUES(2, 'Reviewer')
INSERT INTO Roles(RoleId, RoleName) VALUES(3, 'ReadOnly')
INSERT INTO Roles(RoleId, RoleName) VALUES(4, 'LOBManager')
INSERT INTO Roles(RoleId, RoleName) VALUES(5, 'Admin')

SET IDENTITY_INSERT [MyOnlineShopping].[dbo].[Roles] OFF;  
GO

SELECT * FROM [MyOnlineShopping].[dbo].[MemberRole]

SET IDENTITY_INSERT [MyOnlineShopping].[dbo].[MemberRole] ON;  
GO

INSERT INTO MemberRole(MemberRoleID, memberId, RoleId) VALUES(1, 1, 2)
INSERT INTO MemberRole(MemberRoleID, memberId, RoleId) VALUES(2, 1, 4)
INSERT INTO MemberRole(MemberRoleID, memberId, RoleId) VALUES(3, 1, 5)
INSERT INTO MemberRole(MemberRoleID, memberId, RoleId) VALUES(4, 2, 2)
INSERT INTO MemberRole(MemberRoleID, memberId, RoleId) VALUES(5, 2, 4)
INSERT INTO MemberRole(MemberRoleID, memberId, RoleId) VALUES(6, 2, 5)
INSERT INTO MemberRole(MemberRoleID, memberId, RoleId) VALUES(7, 3, 2)
INSERT INTO MemberRole(MemberRoleID, memberId, RoleId) VALUES(8, 3, 4)
INSERT INTO MemberRole(MemberRoleID, memberId, RoleId) VALUES(9, 3, 5)
INSERT INTO MemberRole(MemberRoleID, memberId, RoleId) VALUES(10, 1, 4)
INSERT INTO MemberRole(MemberRoleID, memberId, RoleId) VALUES(11, 3, 5)

SET IDENTITY_INSERT [MyOnlineShopping].[dbo].[MemberRole] OFF;  
GO