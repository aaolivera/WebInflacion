CREATE VIEW [dbo].[IPCMensual] as SELECT  top 12
	  MIN(p.Fecha) as Fecha,
      ((SELECT Valor FROM [Inflaciondb].[dbo].[IPCDiario] WHERE Fecha = MAX(p.Fecha)) - (SELECT Valor FROM [Inflaciondb].[dbo].[IPCDiario] WHERE Fecha = MIN(p.Fecha)))
	  /(SELECT Valor FROM [Inflaciondb].[dbo].[IPCDiario] WHERE Fecha = MIN(p.Fecha))*100 as Valor,
      '%' as Unidad
  FROM [Inflaciondb].[dbo].[IPCDiario] as p
  
  GROUP BY CAST(YEAR(Fecha) AS VARCHAR(4)) , CAST(MONTH(Fecha) AS VARCHAR(2))
  order by Fecha
GO