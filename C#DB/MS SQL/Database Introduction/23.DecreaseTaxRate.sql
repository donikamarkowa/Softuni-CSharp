UPDATE [Payments]
SET [TaxRate] -= [TaxRate] * 3/100

SELECT [TaxRate]
FROM [Payments]