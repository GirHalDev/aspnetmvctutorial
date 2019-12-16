select * from Employee

Create procedure spSaveEmployee
@ID int,
@FirstName nvarchar (50),
@LastName nvarchar(50),
@Gender nvarchar (50),
@Salary int,
@DepartmentId int,
@DateOfBirth DateTime
as
Begin
 Update Employee Set FirstName = @FirstName,LastName = @LastName,Gender = @Gender,Salary = @salary,DepartmentId = @DepartmentId,DateOfBirth = @DateOfBirth
 where ID = @ID
End
