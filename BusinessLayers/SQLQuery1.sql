select * from Employee

create procedure spGetAllEmployees
as
Begin
	select ID, FirstName, LastName, Gender, Salary, DepartmentId
	from Employee
End