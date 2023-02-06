SELECT 
	[u].[Username],
	AVG([f].[Size]) AS [Size]
FROM [Users] AS [u]
INNER JOIN [Commits] AS [c]
ON [c].[ContributorId] = [u].[Id]
INNER JOIN [Files] AS [f]
ON [f].[CommitId] = [c].[Id]
GROUP BY [u].[Username]
ORDER BY AVG([f].[Size]) DESC, [u].[Username]
