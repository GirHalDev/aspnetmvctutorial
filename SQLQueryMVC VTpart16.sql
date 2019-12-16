sp_helptext spAddEmployee

sp_helptext spGetAllEmployees

ALTER TABLE Employee ADD DateOfBirth datetime NULL

Alter Procedure spAddEmployee    
@FirstName nvarchar(50) = null,    
@LastName nvarchar(50) = null,    
@Gender nvarchar(10) = null,    
@Salary int = null,    
@DepartmentId int = null,  
@DateOfBirth datetime = null  
as    
Begin    
 Insert into Employee (FirstName, LastName, Gender, Salary, DepartmentId, DateOfBirth)    
 Values (@FirstName, @LastName, @Gender, @Salary, @DepartmentId, @DateOfBirth)    
End

select * from Employee

Alter procedure spGetAllEmployees  
as  
Begin  
 select ID, FirstName, LastName, Gender, Salary, DepartmentId, DateOfBirth  
 from Employee  
End