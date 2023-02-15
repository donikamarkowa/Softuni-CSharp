SELECT 
	CONCAT([m].[FirstName], ' ', [m].[LastName]) AS [Available]
FROM [Mechanics] AS [m]
LEFT JOIN [Jobs] AS [j] 
ON [m].[MechanicId] = [j].[MechanicId]
WHERE [m].[MechanicId] NOT IN (SELECT 
									DISTINCT [m].[MechanicId] 
                               FROM [Mechanics] AS [m]
							   LEFT JOIN [Jobs] AS [j] ON [j].[MechanicId] = [m].[MechanicId]
    						   WHERE [j].[Status] <> 'Finished'
							  )
GROUP BY CONCAT(m.FirstName, ' ', m.LastName), m.MechanicId
ORDER BY m.MechanicId ASC