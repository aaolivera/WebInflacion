CREATE VIEW [dbo].[IPCDiario] as
SELECT     top 30
SUM(PrecioMaximo)/COUNT(*) AS Valor, CONVERT(DATE, Fecha) AS Fecha, 'IPC' as Unidad
FROM         dbo.Precio
GROUP BY CONVERT(DATE, Fecha)
order by Fecha
GO