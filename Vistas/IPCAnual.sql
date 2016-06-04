
CREATE VIEW [dbo].[IPCAnual] as SELECT  top 12
MIN(Fecha) as Fecha,
SUM(IpcMensual.Valor) as Valor,
'%' as Unidad
  FROM [Inflaciondb].[dbo].[IPCMensual]
   GROUP BY CAST(YEAR(Fecha) AS VARCHAR(4))
   order by Fecha
GO