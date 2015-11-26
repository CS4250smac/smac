-- MySQL dump 10.13  Distrib 5.6.27, for debian-linux-gnu (x86_64)
--
-- Host: localhost    Database: gps_data
-- ------------------------------------------------------
-- Server version	5.6.27-0ubuntu0.14.04.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `collision_altitude_data`
--

DROP TABLE IF EXISTS `collision_altitude_data`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `collision_altitude_data` (
  `id` bigint(20) DEFAULT NULL,
  `latitude_1` decimal(8,5) DEFAULT NULL,
  `longitude_1` decimal(8,5) DEFAULT NULL,
  `altitude_1` smallint(6) DEFAULT NULL,
  `latitude_2` decimal(8,5) DEFAULT NULL,
  `longitude_2` decimal(8,5) DEFAULT NULL,
  `altitude_2` smallint(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `collision_altitude_data`
--

LOCK TABLES `collision_altitude_data` WRITE;
/*!40000 ALTER TABLE `collision_altitude_data` DISABLE KEYS */;
INSERT INTO `collision_altitude_data` VALUES (1448571016,-39.85851,-105.30528,10250,40.86151,106.30828,15000),(1448571017,-39.97808,-105.62120,10500,40.98409,106.62721,15000),(1448571017,-40.09802,-105.93806,10750,41.10704,106.94709,15000),(1448571018,-40.21831,-106.25587,11000,41.23037,107.26793,15000),(1448571019,-40.33897,-106.57464,11250,41.35406,107.58973,15000),(1448571020,-40.45998,-106.89437,11500,41.47812,107.91250,15000),(1448571021,-40.58136,-107.21505,11750,41.60255,108.23624,15000),(1448571021,-40.70311,-107.53669,12000,41.72736,108.56095,15000),(1448571022,-40.82522,-107.85930,12250,41.85254,108.88663,15000),(1448571022,-40.94769,-108.18288,12500,41.97810,109.21329,15000),(1448571023,-41.07054,-108.50743,12750,42.10404,109.54093,15000),(1448571023,-41.19375,-108.83295,13000,42.23035,109.86955,15000),(1448571024,-41.31733,-109.15945,13250,42.35704,110.19916,15000),(1448571025,-41.44128,-109.48693,13500,42.48411,110.52976,15000),(1448571025,-41.56560,-109.81539,13750,42.61156,110.86135,15000),(1448571026,-41.69030,-110.14484,14000,42.73940,111.19393,15000),(1448571027,-41.81537,-110.47527,14250,42.86761,111.52751,15000),(1448571028,-41.94082,-110.80670,14500,42.99622,111.86210,15000),(1448571028,-42.06664,-111.13912,14750,43.12521,112.19768,15000),(1448571029,-42.19284,-111.47254,15000,43.25458,112.53428,15000),(1448571030,-42.31942,-111.80695,15250,43.38435,112.87188,15000),(1448571030,-42.44638,-112.14237,15500,43.51450,113.21049,15000),(1448571031,-42.57372,-112.47880,15750,43.64504,113.55013,15000),(1448571032,-42.70144,-112.81624,16000,43.77598,113.89078,15000),(1448571033,-42.82954,-113.15469,16250,43.90731,114.23245,15000),(1448571033,-42.95803,-113.49415,16500,44.03903,114.57515,15000),(1448571034,-43.08690,-113.83463,16750,44.17114,114.91887,15000),(1448571035,-43.21617,-114.17614,17000,44.30366,115.26363,15000),(1448571036,-43.34581,-114.51866,17250,44.43657,115.60942,15000),(1448571037,-43.47585,-114.86222,17500,44.56988,115.95625,15000);
/*!40000 ALTER TABLE `collision_altitude_data` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `collision_vector_data`
--

DROP TABLE IF EXISTS `collision_vector_data`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `collision_vector_data` (
  `id` bigint(20) DEFAULT NULL,
  `latitude_1` decimal(8,5) DEFAULT NULL,
  `longitude_1` decimal(8,5) DEFAULT NULL,
  `altitude_1` smallint(6) DEFAULT NULL,
  `latitude_2` decimal(8,5) DEFAULT NULL,
  `longitude_2` decimal(8,5) DEFAULT NULL,
  `altitude_2` smallint(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `collision_vector_data`
--

LOCK TABLES `collision_vector_data` WRITE;
/*!40000 ALTER TABLE `collision_vector_data` DISABLE KEYS */;
INSERT INTO `collision_vector_data` VALUES (1448570993,39.85851,104.67534,10000,40.86151,105.67234,15000),(1448570994,39.97808,104.36131,10000,40.98409,105.35532,15000),(1448570995,40.09802,104.04823,10000,41.10704,105.03926,15000),(1448570996,40.21831,103.73608,10000,41.23037,104.72414,15000),(1448570997,40.33897,103.42488,10000,41.35406,104.40997,15000),(1448570997,40.45998,103.11460,10000,41.47812,104.09674,15000),(1448570998,40.58136,102.80526,10000,41.60255,103.78445,15000),(1448570999,40.70311,102.49684,10000,41.72736,103.47309,15000),(1448571000,40.82522,102.18935,10000,41.85254,103.16267,15000),(1448571001,40.94769,101.88278,10000,41.97810,102.85319,15000),(1448571001,41.07054,101.57714,10000,42.10404,102.54463,15000),(1448571002,41.19375,101.27240,10000,42.23035,102.23699,15000),(1448571002,41.31733,100.96859,10000,42.35704,101.93028,15000),(1448571003,41.44128,100.66568,10000,42.48411,101.62449,15000),(1448571004,41.56560,100.36368,10000,42.61156,101.31962,15000),(1448571005,41.69030,100.06259,10000,42.73940,101.01566,15000),(1448571006,41.81537,99.76240,10000,42.86761,100.71261,15000),(1448571006,41.94082,99.46312,10000,42.99622,100.41047,15000),(1448571007,42.06664,99.16473,10000,43.12521,100.10924,15000),(1448571008,42.19284,98.86723,10000,43.25458,99.80891,15000),(1448571009,42.31942,98.57063,10000,43.38435,99.50949,15000),(1448571010,42.44638,98.27492,10000,43.51450,99.21096,15000),(1448571010,42.57372,97.98010,10000,43.64504,98.91333,15000),(1448571011,42.70144,97.68616,10000,43.77598,98.61659,15000),(1448571012,42.82954,97.39310,10000,43.90731,98.32074,15000),(1448571013,42.95803,97.10092,10000,44.03903,98.02577,15000),(1448571013,43.08690,96.80961,10000,44.17114,97.73170,15000),(1448571014,43.21617,96.51919,10000,44.30366,97.43850,15000),(1448571015,43.34581,96.22963,10000,44.43657,97.14619,15000),(1448571015,43.47585,95.94094,10000,44.56988,96.85475,15000);
/*!40000 ALTER TABLE `collision_vector_data` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `collision_altitude_vector_data`
--

DROP TABLE IF EXISTS `collision_altitude_vector_data`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `collision_altitude_vector_data` (
  `id` bigint(20) DEFAULT NULL,
  `latitude_1` decimal(8,5) DEFAULT NULL,
  `longitude_1` decimal(8,5) DEFAULT NULL,
  `altitude_1` smallint(6) DEFAULT NULL,
  `latitude_2` decimal(8,5) DEFAULT NULL,
  `longitude_2` decimal(8,5) DEFAULT NULL,
  `altitude_2` smallint(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `collision_altitude_vector_data`
--

LOCK TABLES `collision_altitude_vector_data` WRITE;
/*!40000 ALTER TABLE `collision_altitude_vector_data` DISABLE KEYS */;
INSERT INTO `collision_altitude_vector_data` VALUES (1448571037,39.85851,104.67534,10250,40.86151,105.67234,15000),(1448571038,39.97808,104.36131,10500,40.98409,105.35532,15000),(1448571039,40.09802,104.04823,10750,41.10704,105.03926,15000),(1448571039,40.21831,103.73608,11000,41.23037,104.72414,15000),(1448571040,40.33897,103.42488,11250,41.35406,104.40997,15000),(1448571041,40.45998,103.11460,11500,41.47812,104.09674,15000),(1448571042,40.58136,102.80526,11750,41.60255,103.78445,15000),(1448571043,40.70311,102.49684,12000,41.72736,103.47309,15000),(1448571043,40.82522,102.18935,12250,41.85254,103.16267,15000),(1448571044,40.94769,101.88278,12500,41.97810,102.85319,15000),(1448571045,41.07054,101.57714,12750,42.10404,102.54463,15000),(1448571045,41.19375,101.27240,13000,42.23035,102.23699,15000),(1448571046,41.31733,100.96859,13250,42.35704,101.93028,15000),(1448571047,41.44128,100.66568,13500,42.48411,101.62449,15000),(1448571048,41.56560,100.36368,13750,42.61156,101.31962,15000),(1448571049,41.69030,100.06259,14000,42.73940,101.01566,15000),(1448571050,41.81537,99.76240,14250,42.86761,100.71261,15000),(1448571050,41.94082,99.46312,14500,42.99622,100.41047,15000),(1448571051,42.06664,99.16473,14750,43.12521,100.10924,15000),(1448571052,42.19284,98.86723,15000,43.25458,99.80891,15000),(1448571053,42.31942,98.57063,15250,43.38435,99.50949,15000),(1448571053,42.44638,98.27492,15500,43.51450,99.21096,15000),(1448571054,42.57372,97.98010,15750,43.64504,98.91333,15000),(1448571055,42.70144,97.68616,16000,43.77598,98.61659,15000),(1448571056,42.82954,97.39310,16250,43.90731,98.32074,15000),(1448571056,42.95803,97.10092,16500,44.03903,98.02577,15000),(1448571057,43.08690,96.80961,16750,44.17114,97.73170,15000),(1448571058,43.21617,96.51919,17000,44.30366,97.43850,15000),(1448571059,43.34581,96.22963,17250,44.43657,97.14619,15000),(1448571059,43.47585,95.94094,17500,44.56988,96.85475,15000);
/*!40000 ALTER TABLE `collision_altitude_vector_data` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `safe_data`
--

DROP TABLE IF EXISTS `safe_data`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `safe_data` (
  `id` bigint(20) DEFAULT NULL,
  `latitude_1` decimal(8,5) DEFAULT NULL,
  `longitude_1` decimal(8,5) DEFAULT NULL,
  `altitude_1` smallint(6) DEFAULT NULL,
  `latitude_2` decimal(8,5) DEFAULT NULL,
  `longitude_2` decimal(8,5) DEFAULT NULL,
  `altitude_2` smallint(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `safe_data`
--

LOCK TABLES `safe_data` WRITE;
/*!40000 ALTER TABLE `safe_data` DISABLE KEYS */;
INSERT INTO `safe_data` VALUES (1448571060,-39.85851,-105.30528,10000,40.86151,106.30828,15000),(1448571061,-39.97808,-105.62120,10000,40.98409,106.62721,15000),(1448571061,-40.09802,-105.93806,10000,41.10704,106.94709,15000),(1448571062,-40.21831,-106.25587,10000,41.23037,107.26793,15000),(1448571063,-40.33897,-106.57464,10000,41.35406,107.58973,15000),(1448571063,-40.45998,-106.89437,10000,41.47812,107.91250,15000),(1448571064,-40.58136,-107.21505,10000,41.60255,108.23624,15000),(1448571065,-40.70311,-107.53669,10000,41.72736,108.56095,15000),(1448571066,-40.82522,-107.85930,10000,41.85254,108.88663,15000),(1448571066,-40.94769,-108.18288,10000,41.97810,109.21329,15000),(1448571067,-41.07054,-108.50743,10000,42.10404,109.54093,15000),(1448571068,-41.19375,-108.83295,10000,42.23035,109.86955,15000),(1448571069,-41.31733,-109.15945,10000,42.35704,110.19916,15000),(1448571070,-41.44128,-109.48693,10000,42.48411,110.52976,15000),(1448571070,-41.56560,-109.81539,10000,42.61156,110.86135,15000),(1448571071,-41.69030,-110.14484,10000,42.73940,111.19393,15000),(1448571072,-41.81537,-110.47527,10000,42.86761,111.52751,15000),(1448571072,-41.94082,-110.80670,10000,42.99622,111.86210,15000),(1448571073,-42.06664,-111.13912,10000,43.12521,112.19768,15000),(1448571073,-42.19284,-111.47254,10000,43.25458,112.53428,15000),(1448571074,-42.31942,-111.80695,10000,43.38435,112.87188,15000),(1448571075,-42.44638,-112.14237,10000,43.51450,113.21049,15000),(1448571075,-42.57372,-112.47880,10000,43.64504,113.55013,15000),(1448571076,-42.70144,-112.81624,10000,43.77598,113.89078,15000),(1448571076,-42.82954,-113.15469,10000,43.90731,114.23245,15000),(1448571077,-42.95803,-113.49415,10000,44.03903,114.57515,15000),(1448571078,-43.08690,-113.83463,10000,44.17114,114.91887,15000),(1448571079,-43.21617,-114.17614,10000,44.30366,115.26363,15000),(1448571080,-43.34581,-114.51866,10000,44.43657,115.60942,15000),(1448571080,-43.47585,-114.86222,10000,44.56988,115.95625,15000);
/*!40000 ALTER TABLE `safe_data` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-11-26 14:00:23