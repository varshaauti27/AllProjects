select * from AspNetUsers
Join AspNetUserRoles on AspNetUserRoles.UserId = AspNetUsers.Id
Join AspNetRoles on AspNetRoles.Id = AspNetUserRoles.RoleId
where AspNetRoles.Name like 'Admin'



SELECT * from AspNetRoles


SELECT * FROM Style

SELECT * FROM Transmission

SELECT * FROM Color

SELECT * FROM Make

SELECT * FROM Model

SELECT * FROM Vehicle

SELECT * FROM Special

SELECT * FROM State

SELECT * FROM Customer

SELECT * FROM PurchaseType

SELECT * FROM Sales

SELECT * FROM Contact

SELECT * FROM Inquiry
