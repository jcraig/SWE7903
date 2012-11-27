TRUNCATE TABLE schedule
GO

DECLARE @i int
DECLARE @j int
DECLARE @begdt  datetime
SET @begdt = '01-JAN-2012'
SET @i = 0
SET @j = 1
WHILE @j <= 3
BEGIN
   WHILE (@begdt + @i) < '31-DEC-2012'
   BEGIN
      INSERT INTO schedule
         (school_id, schedule_date, holiday_ind, school_insession_ind, exam_ind, created_by, created_date)
      SELECT @j, (@begdt + @i), 'F', 'F', 'F', 1, GETDATE()

      SET @i = @i + 1
   END

   SET @i = 0
   SET @j = @j + 1
END

UPDATE schedule
   SET holiday_ind = 'T'
     , name = 'New Years'
 WHERE schedule_date = '01-JAN-2012'

UPDATE schedule
   SET holiday_ind = 'T'
     , name = 'Martin Luther King Jr.'
 WHERE schedule_date = '16-JAN-2012'

UPDATE schedule
   SET holiday_ind = 'T'
     , name = 'Memorial Day'
 WHERE schedule_date = '26-MAY-2012'

UPDATE schedule
   SET holiday_ind = 'T'
     , name = 'Independence Day'
 WHERE schedule_date = '04-JUL-2012'

UPDATE schedule
   SET holiday_ind = 'T'
     , name = 'Labor Day'
 WHERE schedule_date = '03-SEP-2012'

UPDATE schedule
   SET holiday_ind = 'T'
     , name = 'Thanksgiving'
 WHERE schedule_date = '22-NOV-2012'

UPDATE schedule
   SET holiday_ind = 'T'
     , name = 'Thanksgiving'
 WHERE schedule_date = '23-NOV-2012'

UPDATE schedule
   SET holiday_ind = 'T'
     , name = 'Christmas'
 WHERE schedule_date = '25-DEC-2012'

UPDATE schedule
   SET school_insession_ind = 'F'
 WHERE schedule_date BETWEEN '09-JAN-2012' AND '03-MAR-2012'
    OR schedule_date BETWEEN '11-MAR-2012' AND '08-MAY-2012'
    OR schedule_date BETWEEN '21-MAY-2012' AND '01-AUG-2012'
    OR schedule_date BETWEEN '15-AUG-2012' AND '11-DEC-2012'

UPDATE schedule
   SET exam_ind = 'F'
 WHERE schedule_date BETWEEN '02-MAY-2012' AND '08-MAY-2012'
    OR schedule_date BETWEEN '28-JUL-2012' AND '01-AUG-2012'
    OR schedule_date BETWEEN '05-DEC-2012' AND '11-DEC-2012'
TRUNCATE TABLE schedule
GO

DECLARE @i int
DECLARE @j int
DECLARE @begdt  datetime
SET @begdt = '01-JAN-2012'
SET @i = 0
SET @j = 1
WHILE @j <= 3
BEGIN
   WHILE (@begdt + @i) < '31-DEC-2012'
   BEGIN
      INSERT INTO schedule
         (school_id, schedule_date, holiday_ind, school_insession_ind, exam_ind, created_by, created_date)
      SELECT @j, (@begdt + @i), 'F', 'F', 'F', 1, GETDATE()

      SET @i = @i + 1
   END

   SET @i = 0
   SET @j = @j + 1
END

UPDATE schedule
   SET holiday_ind = 'T'
     , name = 'New Years'
 WHERE schedule_date = '01-JAN-2012'

UPDATE schedule
   SET holiday_ind = 'T'
     , name = 'Martin Luther King Jr.'
 WHERE schedule_date = '16-JAN-2012'

UPDATE schedule
   SET holiday_ind = 'T'
     , name = 'Memorial Day'
 WHERE schedule_date = '26-MAY-2012'

UPDATE schedule
   SET holiday_ind = 'T'
     , name = 'Independence Day'
 WHERE schedule_date = '04-JUL-2012'

UPDATE schedule
   SET holiday_ind = 'T'
     , name = 'Labor Day'
 WHERE schedule_date = '03-SEP-2012'

UPDATE schedule
   SET holiday_ind = 'T'
     , name = 'Thanksgiving'
 WHERE schedule_date = '22-NOV-2012'

UPDATE schedule
   SET holiday_ind = 'T'
     , name = 'Thanksgiving'
 WHERE schedule_date = '23-NOV-2012'

UPDATE schedule
   SET holiday_ind = 'T'
     , name = 'Christmas'
 WHERE schedule_date = '25-DEC-2012'

UPDATE schedule
   SET school_insession_ind = 'F'
 WHERE schedule_date BETWEEN '09-JAN-2012' AND '03-MAR-2012'
    OR schedule_date BETWEEN '11-MAR-2012' AND '08-MAY-2012'
    OR schedule_date BETWEEN '21-MAY-2012' AND '01-AUG-2012'
    OR schedule_date BETWEEN '15-AUG-2012' AND '11-DEC-2012'

UPDATE schedule
   SET exam_ind = 'F'
 WHERE schedule_date BETWEEN '02-MAY-2012' AND '08-MAY-2012'
    OR schedule_date BETWEEN '28-JUL-2012' AND '01-AUG-2012'
    OR schedule_date BETWEEN '05-DEC-2012' AND '11-DEC-2012'
