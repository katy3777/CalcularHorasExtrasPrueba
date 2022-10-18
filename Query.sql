
WITH cte
     AS (SELECT 
        ROW_NUMBER() OVER(PARTITION BY a.rut ORDER BY a.rut) AS fila,
            a.rut, 
            a.fecha, 
            LEAD(a.fecha) OVER(PARTITION BY a.rut ORDER BY a.fecha) AS siguiente
            FROM dbo.registro AS a
        )
SELECT c.rut, 
       
       CASE
           WHEN c.fecha > c.siguiente
           THEN c.fecha
           ELSE c.siguiente
       END AS [IN],
       CASE
           WHEN c.siguiente IS NULL
           THEN '19000101'
           WHEN c.fecha < c.siguiente
           THEN c.fecha
           ELSE c.siguiente
       END AS [OUT]
FROM cte AS c
WHERE c.fila % 2 != 0;