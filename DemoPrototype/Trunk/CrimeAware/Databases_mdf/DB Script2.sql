ALTER TABLE SCHOOLS ADD
  LAT_START NUMERIC(9,6) ,
  LAT_END NUMERIC(9,6) ,
  LONG_START NUMERIC(9,6) ,
  LONG_END NUMERIC(9,6);

GO

UPDATE schools
   SET lat_start = 33.92862
     , lat_end = 33.94265
     , long_start = -84.52847
     , long_end = -84.51057
 WHERE abbreviation = 'SPSU';

UPDATE schools
   SET lat_start = 33.76906
     , lat_end = 33.78651
     , long_start = -84.40759
     , long_end = -84.38732
 WHERE abbreviation = 'GT';

UPDATE schools
   SET lat_start = 33.92265
     , lat_end = 33.95853
     , long_start = -83.38009
     , long_end = -83.36464
 WHERE abbreviation = 'UGA';

INSERT INTO event_data (event_date, location_lat, location_long, school_id, arrest_ind, vicitim_sex, victim_age, victim_student_ind, offender_sex, offender_age, offender_student_ind, created_by, created_date)
   VALUES ('2012-09-01', 33.93911, -84.52011, 1, 'T', 'M', 20, 'T', 'M', 21, 'T', 1, GETDATE());
INSERT INTO event_data_types (event_id, event_type_id, created_by, created_date)
   VALUES (2, 3, 1, GETDATE());

INSERT INTO event_data (event_date, location_lat, location_long, school_id, arrest_ind, vicitim_sex, victim_age, victim_student_ind, offender_sex, offender_age, offender_student_ind, created_by, created_date)
   VALUES ('2012-08-15', 33.93969, -84.51969, 1, 'T', 'M', 20, 'T', 'M', 21, 'T', 1, GETDATE());
INSERT INTO event_data_types (event_id, event_type_id, created_by, created_date)
   VALUES (3, 4, 1, GETDATE());

INSERT INTO event_data (event_date, location_lat, location_long, school_id, arrest_ind, vicitim_sex, victim_age, victim_student_ind, offender_sex, offender_age, offender_student_ind, created_by, created_date)
   VALUES ('2012-09-15', 33.94059, -84.52039, 1, 'T', 'M', 20, 'T', 'M', 21, 'T', 1, GETDATE());
INSERT INTO event_data_types (event_id, event_type_id, created_by, created_date)
   VALUES (4, 7, 1, GETDATE());

INSERT INTO event_data (event_date, location_lat, location_long, school_id, arrest_ind, vicitim_sex, victim_age, victim_student_ind, offender_sex, offender_age, offender_student_ind, created_by, created_date)
   VALUES ('2012-09-30', 33.93991, -84.52074, 1, 'T', 'M', 20, 'T', 'M', 21, 'T', 1, GETDATE());
INSERT INTO event_data_types (event_id, event_type_id, created_by, created_date)
   VALUES (5, 9, 1, GETDATE());

INSERT INTO event_data (event_date, location_lat, location_long, school_id, arrest_ind, vicitim_sex, victim_age, victim_student_ind, offender_sex, offender_age, offender_student_ind, created_by, created_date)
   VALUES ('2012-10-08', 33.93914, -84.52157, 1, 'T', 'M', 20, 'T', 'M', 21, 'T', 1, GETDATE());
INSERT INTO event_data_types (event_id, event_type_id, created_by, created_date)
   VALUES (6, 11, 1, GETDATE());

INSERT INTO event_data (event_date, location_lat, location_long, school_id, arrest_ind, vicitim_sex, victim_age, victim_student_ind, offender_sex, offender_age, offender_student_ind, created_by, created_date)
   VALUES ('2012-06-01', 33.93876, -84.52295, 1, 'T', 'M', 20, 'T', 'M', 21, 'T', 1, GETDATE());
INSERT INTO event_data_types (event_id, event_type_id, created_by, created_date)
   VALUES (7, 12, 1, GETDATE());

INSERT INTO event_data (event_date, location_lat, location_long, school_id, arrest_ind, vicitim_sex, victim_age, victim_student_ind, offender_sex, offender_age, offender_student_ind, created_by, created_date)
   VALUES ('2012-06-15', 33.93876, -84.52295, 1, 'T', 'M', 20, 'T', 'M', 21, 'T', 1, GETDATE());
INSERT INTO event_data_types (event_id, event_type_id, created_by, created_date)
   VALUES (8, 12, 1, GETDATE());

INSERT INTO event_data (event_date, location_lat, location_long, school_id, arrest_ind, vicitim_sex, victim_age, victim_student_ind, offender_sex, offender_age, offender_student_ind, created_by, created_date)
   VALUES ('2012-07-04', 33.93876, -84.52295, 1, 'T', 'M', 20, 'T', 'M', 21, 'T', 1, GETDATE());
INSERT INTO event_data_types (event_id, event_type_id, created_by, created_date)
   VALUES (9, 13, 1, GETDATE());

INSERT INTO event_data (event_date, location_lat, location_long, school_id, arrest_ind, vicitim_sex, victim_age, victim_student_ind, offender_sex, offender_age, offender_student_ind, created_by, created_date)
   VALUES ('2012-08-12', 33.93876, -84.52295, 1, 'T', 'M', 20, 'T', 'M', 21, 'T', 1, GETDATE());
INSERT INTO event_data_types (event_id, event_type_id, created_by, created_date)
   VALUES (10, 13, 1, GETDATE());



INSERT INTO event_data (event_date, location_lat, location_long, school_id, arrest_ind, vicitim_sex, victim_age, victim_student_ind, offender_sex, offender_age, offender_student_ind, created_by, created_date)
   VALUES ('2012-10-01', 33.77000, -84.39000, 1, 'T', 'M', 20, 'T', 'M', 21, 'T', 1, GETDATE());
INSERT INTO event_data_types (event_id, event_type_id, created_by, created_date)
   VALUES (11, 2, 1, GETDATE());

INSERT INTO event_data (event_date, location_lat, location_long, school_id, arrest_ind, vicitim_sex, victim_age, victim_student_ind, offender_sex, offender_age, offender_student_ind, created_by, created_date)
   VALUES ('2012-09-01', 33.77000, -84.39000, 1, 'T', 'M', 20, 'T', 'M', 21, 'T', 1, GETDATE());
INSERT INTO event_data_types (event_id, event_type_id, created_by, created_date)
   VALUES (12, 3, 1, GETDATE());

INSERT INTO event_data (event_date, location_lat, location_long, school_id, arrest_ind, vicitim_sex, victim_age, victim_student_ind, offender_sex, offender_age, offender_student_ind, created_by, created_date)
   VALUES ('2012-08-15', 33.77000, -84.39000, 1, 'T', 'M', 20, 'T', 'M', 21, 'T', 1, GETDATE());
INSERT INTO event_data_types (event_id, event_type_id, created_by, created_date)
   VALUES (13, 4, 1, GETDATE());

INSERT INTO event_data (event_date, location_lat, location_long, school_id, arrest_ind, vicitim_sex, victim_age, victim_student_ind, offender_sex, offender_age, offender_student_ind, created_by, created_date)
   VALUES ('2012-09-15', 33.77000, -84.39000, 1, 'T', 'M', 20, 'T', 'M', 21, 'T', 1, GETDATE());
INSERT INTO event_data_types (event_id, event_type_id, created_by, created_date)
   VALUES (14, 7, 1, GETDATE());

INSERT INTO event_data (event_date, location_lat, location_long, school_id, arrest_ind, vicitim_sex, victim_age, victim_student_ind, offender_sex, offender_age, offender_student_ind, created_by, created_date)
   VALUES ('2012-09-30', 33.77000, -84.39000, 1, 'T', 'M', 20, 'T', 'M', 21, 'T', 1, GETDATE());
INSERT INTO event_data_types (event_id, event_type_id, created_by, created_date)
   VALUES (15, 9, 1, GETDATE());

INSERT INTO event_data (event_date, location_lat, location_long, school_id, arrest_ind, vicitim_sex, victim_age, victim_student_ind, offender_sex, offender_age, offender_student_ind, created_by, created_date)
   VALUES ('2012-10-08', 33.77000, -84.39000, 1, 'T', 'M', 20, 'T', 'M', 21, 'T', 1, GETDATE());
INSERT INTO event_data_types (event_id, event_type_id, created_by, created_date)
   VALUES (16, 11, 1, GETDATE());

INSERT INTO event_data (event_date, location_lat, location_long, school_id, arrest_ind, vicitim_sex, victim_age, victim_student_ind, offender_sex, offender_age, offender_student_ind, created_by, created_date)
   VALUES ('2012-06-01', 33.77000, -84.39000, 1, 'T', 'M', 20, 'T', 'M', 21, 'T', 1, GETDATE());
INSERT INTO event_data_types (event_id, event_type_id, created_by, created_date)
   VALUES (17, 12, 1, GETDATE());

INSERT INTO event_data (event_date, location_lat, location_long, school_id, arrest_ind, vicitim_sex, victim_age, victim_student_ind, offender_sex, offender_age, offender_student_ind, created_by, created_date)
   VALUES ('2012-06-15', 33.77000, -84.39000, 1, 'T', 'M', 20, 'T', 'M', 21, 'T', 1, GETDATE());
INSERT INTO event_data_types (event_id, event_type_id, created_by, created_date)
   VALUES (18, 12, 1, GETDATE());

INSERT INTO event_data (event_date, location_lat, location_long, school_id, arrest_ind, vicitim_sex, victim_age, victim_student_ind, offender_sex, offender_age, offender_student_ind, created_by, created_date)
   VALUES ('2012-07-04', 33.77000, -84.39000, 1, 'T', 'M', 20, 'T', 'M', 21, 'T', 1, GETDATE());
INSERT INTO event_data_types (event_id, event_type_id, created_by, created_date)
   VALUES (19, 13, 1, GETDATE());

INSERT INTO event_data (event_date, location_lat, location_long, school_id, arrest_ind, vicitim_sex, victim_age, victim_student_ind, offender_sex, offender_age, offender_student_ind, created_by, created_date)
   VALUES ('2012-08-12', 33.77000, -84.39000, 1, 'T', 'M', 20, 'T', 'M', 21, 'T', 1, GETDATE());
INSERT INTO event_data_types (event_id, event_type_id, created_by, created_date)
   VALUES (20, 13, 1, GETDATE());


INSERT INTO event_data (event_date, location_lat, location_long, school_id, arrest_ind, vicitim_sex, victim_age, victim_student_ind, offender_sex, offender_age, offender_student_ind, created_by, created_date)
   VALUES ('2012-10-01', 33.94000, -83.37000, 1, 'T', 'M', 20, 'T', 'M', 21, 'T', 1, GETDATE());
INSERT INTO event_data_types (event_id, event_type_id, created_by, created_date)
   VALUES (21, 2, 1, GETDATE());

INSERT INTO event_data (event_date, location_lat, location_long, school_id, arrest_ind, vicitim_sex, victim_age, victim_student_ind, offender_sex, offender_age, offender_student_ind, created_by, created_date)
   VALUES ('2012-09-01', 33.94000, -83.37000, 1, 'T', 'M', 20, 'T', 'M', 21, 'T', 1, GETDATE());
INSERT INTO event_data_types (event_id, event_type_id, created_by, created_date)
   VALUES (22, 3, 1, GETDATE());

INSERT INTO event_data (event_date, location_lat, location_long, school_id, arrest_ind, vicitim_sex, victim_age, victim_student_ind, offender_sex, offender_age, offender_student_ind, created_by, created_date)
   VALUES ('2012-08-15', 33.94000, -83.37000, 1, 'T', 'M', 20, 'T', 'M', 21, 'T', 1, GETDATE());
INSERT INTO event_data_types (event_id, event_type_id, created_by, created_date)
   VALUES (23, 4, 1, GETDATE());

INSERT INTO event_data (event_date, location_lat, location_long, school_id, arrest_ind, vicitim_sex, victim_age, victim_student_ind, offender_sex, offender_age, offender_student_ind, created_by, created_date)
   VALUES ('2012-09-15', 33.94000, -83.37000, 1, 'T', 'M', 20, 'T', 'M', 21, 'T', 1, GETDATE());
INSERT INTO event_data_types (event_id, event_type_id, created_by, created_date)
   VALUES (24, 7, 1, GETDATE());

INSERT INTO event_data (event_date, location_lat, location_long, school_id, arrest_ind, vicitim_sex, victim_age, victim_student_ind, offender_sex, offender_age, offender_student_ind, created_by, created_date)
   VALUES ('2012-09-30', 33.94000, -83.37000, 1, 'T', 'M', 20, 'T', 'M', 21, 'T', 1, GETDATE());
INSERT INTO event_data_types (event_id, event_type_id, created_by, created_date)
   VALUES (25, 9, 1, GETDATE());

INSERT INTO event_data (event_date, location_lat, location_long, school_id, arrest_ind, vicitim_sex, victim_age, victim_student_ind, offender_sex, offender_age, offender_student_ind, created_by, created_date)
   VALUES ('2012-10-08', 33.94000, -83.37000, 1, 'T', 'M', 20, 'T', 'M', 21, 'T', 1, GETDATE());
INSERT INTO event_data_types (event_id, event_type_id, created_by, created_date)
   VALUES (26, 11, 1, GETDATE());

INSERT INTO event_data (event_date, location_lat, location_long, school_id, arrest_ind, vicitim_sex, victim_age, victim_student_ind, offender_sex, offender_age, offender_student_ind, created_by, created_date)
   VALUES ('2012-06-01', 33.94000, -83.37000, 1, 'T', 'M', 20, 'T', 'M', 21, 'T', 1, GETDATE());
INSERT INTO event_data_types (event_id, event_type_id, created_by, created_date)
   VALUES (27, 12, 1, GETDATE());

INSERT INTO event_data (event_date, location_lat, location_long, school_id, arrest_ind, vicitim_sex, victim_age, victim_student_ind, offender_sex, offender_age, offender_student_ind, created_by, created_date)
   VALUES ('2012-06-15', 33.94000, -83.37000, 1, 'T', 'M', 20, 'T', 'M', 21, 'T', 1, GETDATE());
INSERT INTO event_data_types (event_id, event_type_id, created_by, created_date)
   VALUES (28, 12, 1, GETDATE());

INSERT INTO event_data (event_date, location_lat, location_long, school_id, arrest_ind, vicitim_sex, victim_age, victim_student_ind, offender_sex, offender_age, offender_student_ind, created_by, created_date)
   VALUES ('2012-07-04', 33.94000, -83.37000, 1, 'T', 'M', 20, 'T', 'M', 21, 'T', 1, GETDATE());
INSERT INTO event_data_types (event_id, event_type_id, created_by, created_date)
   VALUES (29, 13, 1, GETDATE());

INSERT INTO event_data (event_date, location_lat, location_long, school_id, arrest_ind, vicitim_sex, victim_age, victim_student_ind, offender_sex, offender_age, offender_student_ind, created_by, created_date)
   VALUES ('2012-08-12', 33.94000, -83.37000, 1, 'T', 'M', 20, 'T', 'M', 21, 'T', 1, GETDATE());
INSERT INTO event_data_types (event_id, event_type_id, created_by, created_date)
   VALUES (30, 13, 1, GETDATE());
