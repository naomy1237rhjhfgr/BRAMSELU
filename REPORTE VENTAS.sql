DECLARE @FechaInicio DATETIME = '2026-07-01';
DECLARE @FechaFin DATETIME = '2026-07-31 23:59:59';

SELECT 
    v.IdVenta,
    v.FechaVenta,
    v.Total,
    v.EfectivoRecibido,
    v.Cambio,
    c.IdCaja
FROM Ventas v
INNER JOIN Cajas c ON v.IdCaja = c.IdCaja
WHERE v.FechaVenta BETWEEN @FechaInicio AND @FechaFin;