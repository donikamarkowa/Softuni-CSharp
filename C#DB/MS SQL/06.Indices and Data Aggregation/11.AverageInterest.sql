SELECT [DepositGroup],
	   [IsDepositExpired],
	   AVG([DepositInterest]) AS [AverageInterest]
FROM [WizzardDeposits]
WHERE [DepositStartDate] > '01/01/1985'
GROUP BY [DepositGroup], [IsDepositExpired]
ORDER By [DepositGroup] DESC, [IsDepositExpired]

