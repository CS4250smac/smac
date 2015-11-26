# smac
Repository for SMAC project including tests, code, &amp;c

Query to create the tables needed for the data generator:

[source,sql]
--
CREATE TABLE `collision_data` (
  `id` bigint(20) DEFAULT NULL,
  `latitude_1` decimal(8,5) DEFAULT NULL,
  `longitude_1` decimal(8,5) DEFAULT NULL,
  `altitude_1` smallint(6) DEFAULT NULL,
  `latitude_2` decimal(8,5) DEFAULT NULL,
  `longitude_2` decimal(8,5) DEFAULT NULL,
  `altitude_2` smallint(6) DEFAULT NULL
);
--

[source,sql]
--
 CREATE TABLE `safe_data` (
  `id` bigint(20) DEFAULT NULL,
  `latitude_1` decimal(8,5) DEFAULT NULL,
  `longitude_1` decimal(8,5) DEFAULT NULL,
  `altitude_1` smallint(6) DEFAULT NULL,
  `latitude_2` decimal(8,5) DEFAULT NULL,
  `longitude_2` decimal(8,5) DEFAULT NULL,
  `altitude_2` smallint(6) DEFAULT NULL
);
--

Once run in a mysql db you should be able to run the following commands and see:

[source,sql]
--
mysql> show tables;
+--------------------+
| Tables_in_gps_data |
+--------------------+
| collision_data     |
| safe_data          |
+--------------------+
2 rows in set (0.00 sec)

mysql> show columns from safe_data;
+-------------+--------------+------+-----+---------+-------+
| Field       | Type         | Null | Key | Default | Extra |
+-------------+--------------+------+-----+---------+-------+
| id          | bigint(20)   | YES  |     | NULL    |       |
| latitude_1  | decimal(8,5) | YES  |     | NULL    |       |
| longitude_1 | decimal(8,5) | YES  |     | NULL    |       |
| altitude_1  | smallint(6)  | YES  |     | NULL    |       |
| latitude_2  | decimal(8,5) | YES  |     | NULL    |       |
| longitude_2 | decimal(8,5) | YES  |     | NULL    |       |
| altitude_2  | smallint(6)  | YES  |     | NULL    |       |
+-------------+--------------+------+-----+---------+-------+
7 rows in set (0.00 sec)

mysql> show columns from collision_data;
+-------------+--------------+------+-----+---------+-------+
| Field       | Type         | Null | Key | Default | Extra |
+-------------+--------------+------+-----+---------+-------+
| id          | bigint(20)   | YES  |     | NULL    |       |
| latitude_1  | decimal(8,5) | YES  |     | NULL    |       |
| longitude_1 | decimal(8,5) | YES  |     | NULL    |       |
| altitude_1  | smallint(6)  | YES  |     | NULL    |       |
| latitude_2  | decimal(8,5) | YES  |     | NULL    |       |
| longitude_2 | decimal(8,5) | YES  |     | NULL    |       |
| altitude_2  | smallint(6)  | YES  |     | NULL    |       |
+-------------+--------------+------+-----+---------+-------+
7 rows in set (0.00 sec)
--
