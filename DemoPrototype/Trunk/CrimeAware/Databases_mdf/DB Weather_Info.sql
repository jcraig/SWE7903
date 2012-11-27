TRUNCATE TABLE weather_info
GO

DECLARE @i int
DECLARE @j int
DECLARE @begdt  datetime
SET @begdt = '01-JAN-2012'
SET @i = 0
SET @j = 1
WHILE @j <= 3
BEGIN
   WHILE (@begdt + @i) < getdate()
   BEGIN
      INSERT INTO weather_info
         (school_id, weather_start_date, weather_end_date, temperature, sunny_ind, rainy_ind)
      SELECT @j, (@begdt + @i), (@begdt + @i), (20 + (SELECT RAND()) * (100-20))
           , (CASE WHEN RAND() < 0.5 THEN 'T' ELSE 'F' END)
           , (CASE WHEN RAND() < 0.5 THEN 'T' ELSE 'F' END)

      SET @i = @i + 1
   END

   SET @i = 0
   SET @j = @j + 1
END
