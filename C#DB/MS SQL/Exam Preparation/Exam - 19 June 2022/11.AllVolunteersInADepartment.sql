CREATE OR ALTER FUNCTION udf_GetVolunteersCountFromADepartment(@VolunteersDepartment VARCHAR(100)) 
RETURNS INT 
AS 
BEGIN 
	DECLARE @Count INT
	SET @Count = (
		SELECT
		COUNT(*) 
		FROM Volunteers AS v
		JOIN VolunteersDepartments AS vd ON vd.Id = v.DepartmentId
		WHERE vd.DepartmentName = @VolunteersDepartment
	)
	RETURN @Count
END

GO

SELECT dbo.udf_GetVolunteersCountFromADepartment ('Education program assistant')

SELECT dbo.udf_GetVolunteersCountFromADepartment ('Guest engagement')

SELECT dbo.udf_GetVolunteersCountFromADepartment ('Zoo events')