DECLARE @dt DATETIME
DECLARE cursor3 CURSOR FOR
SELECT event_date FROM event_data
FOR UPDATE OF event_date
OPEN cursor3

FETCH NEXT FROM cursor3 INTO @dt
WHILE (@@FETCH_STATUS > -1)
BEGIN
 UPDATE EVENT_DATA
 SET EVENT_DATE = dateadd(second, cast(86400 * RAND() as int), cast(EVENT_DATE As CHAR))
 WHERE CURRENT OF cursor3
 FETCH NEXT FROM cursor3 INTO @dt
END
CLOSE cursor3
