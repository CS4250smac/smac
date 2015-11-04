# smac
Repository for SMAC project including tests, code, &amp;c

Query to create the table needed for the data generator:
CREATE TABLE `data` (
  `id` bigint(20) DEFAULT NULL,
  `latitude` decimal(8,5) DEFAULT NULL,
  `longitude` decimal(8,5) DEFAULT NULL,
  `x` int(11) DEFAULT NULL,
  `y` int(11) DEFAULT NULL,
  `z` int(11) DEFAULT NULL
)
