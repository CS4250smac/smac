using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;
/*
* @author team SMAC
*
* Verision 1
*/

namespace InFlightMode
{
    public class InFlight {


        public const string CollisionDistanceLessThanZeroMessage = "Collision Distances less than zero";
        public const string IncorrectWarningLevelMessage = "Warning Level is invalid";


        /*
        *CollisionChecks will take two GPS inputs and checks the
        *current distance between them and checks if both objects vector
        *would collide if they continue on same vector.
        *
        *@param GPS1, GPS2
        *@return distance of the two inputs
        */
        // need to finish with altitude on distance calculation
        public static double collisionCheck(decimal lat1, decimal lon1, decimal lat2, decimal lon2)
        {
            double R = 6372.8; // In kilometers
            double dLat = deg2rad((double)(lat2 - lat1));
            double dLon = deg2rad((double)(lon2 - lon1));
            double lat_1 = (double)(lat1);
            double lat_2 = (double)(lat2);
            lat_1 = deg2rad(lat_1);
            lat_2 = deg2rad(lat_2);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat_1) * Math.Cos(lat_2);
            double c = 2 * Math.Asin(Math.Sqrt(a));

            double dist = R * 2 * Math.Asin(Math.Sqrt(a));
            Console.WriteLine(dist);
            return dist;
        }//calculate

        private static double deg2rad(double deg) {
            return (deg * Math.PI / 180.0);
        }
        private static double rad2deg(double rad) {
            return (rad / Math.PI * 180.0);
        }
        /*
          *WarningMessage will output a warning Message if two objects
          * within a certain distance of each other.
          *
          *@param CollisionDistance
          *@return Warninglevel
          */
        public static int WarningMessage(double CollisionDistance)
        {
            if (CollisionDistance < 0)
            {
                throw new ArgumentOutOfRangeException("Distance", CollisionDistance, CollisionDistanceLessThanZeroMessage);
            }


            int message = 0;
            if (CollisionDistance > 300)
            {
                //no danger
                Console.WriteLine("You are safe");
                message = 0;
            }
            else if (CollisionDistance > 200 && CollisionDistance <= 300)
            {
                //Stage 1 danger
                Console.WriteLine("You are in Stage 1 danger");
                message = 1;
            }
            else if (CollisionDistance > 100 && CollisionDistance <= 200)
            {
                //Stage 2 danger
                Console.WriteLine("You are in Stage 2 danger");
                message = 2;
            }
            else if (CollisionDistance >= 0 && CollisionDistance <= 100)
            {
                //Stage 3 danger
                Console.WriteLine("You are in Stage 3 danger!!! Take immediate action!!");
                message = 3;
            }
            return message;
        }//WarningMessage


        /*
          *ActionRequestMessage will send out an ActionRequestMessage
          * When two object need to avoid a collison
          *
          *@param warningLevel;
          *@return ActionRequestMessage 1 would mean to ascend, 2 descend and 3 to turn
          */
          //feature to add previous warning message to indict all clear. this would require vectors and another class to do.
        public static int ActionRequestMessage(int warningLevel, double alt1, double alt2)
        {
            if (warningLevel < 0 || warningLevel >= 4)
            {
                throw new ArgumentOutOfRangeException("warningLevel", warningLevel, IncorrectWarningLevelMessage);
            }


            if (warningLevel = 3 || WarningMessage = 2)
            {
                if (alt1 > alt2)
                {
                    Console.WriteLine("Ascend");
                    return 1;
                }

                else if (al1 < alt2)
                {
                    Console.WriteLine("Descend");
                    return 2;
                }

                else
                {

                    // Feature to add which direction to turn left or right, slowdown, speed up 
                    Console.turn("Turn");
                    return 3;
                }
                
            }
            

            return 0;
        }

        public static decimal[] getData(string table, string col)
        {

            string connection =
                "Server=localhost;" +
                "Database=gps_data;" +
                "User ID=root;" +
                "Password=0427;" +
                "Pooling=false;";

                IDbConnection dbConn = new MySqlConnection(connection);
                dbConn.Open();
                IDbCommand dbCmd = dbConn.CreateCommand();

                string sqlQuery =
                    "SELECT " + col +
                    " FROM " + table;

                dbCmd.CommandText = sqlQuery;
                IDataReader reader = dbCmd.ExecuteReader();
                decimal[] vals = new decimal[50];
                int i = 0;
                while(reader.Read())
                {
                    Console.WriteLine("Adding value: " + reader [col] + ", from " + table + ".");
                    vals[i] = (decimal) reader[col];
                    i++;
                }
                //Close and cleanup MySql connection
                reader.Close();
                reader = null;
                dbCmd.Dispose();
                dbCmd = null;
                dbConn.Close();
                dbConn = null;

                return vals;
        }

        public static void Main(string[] args) {
            string safeTable = "safe_data", dangerTable = "collision_data", lat1 = "latitude_1", long1 = "longitude_1", lat2 = "latitude_2", long2 = "longitude_2";

            decimal[] safeLat1 = getData(safeTable, lat1);
            decimal[] safeLong1 = getData(safeTable, long1);
            decimal[] safeLat2 = getData(safeTable, lat2);
            decimal[] safeLong2 = getData(safeTable, long2);
            for(int i = 0; i < safeLat1.Length; i++)
            {
                if(safeLat1[i] != 0 && safeLong1[i] != 0 && safeLat2[i] != 0 && safeLong2[i] != 0)
                {
                   int safeMessage = ActionRequestMessage(WarningMessage(collisionCheck(safeLat1[i], safeLong1[i], safeLat2[i], safeLong2[i])));
                }
                //Debug.Assert(safeMessage == 0, "Wrong action request message, expecting 0 but was: " + safeMessage);
            }

            decimal[] dangerLat1 = getData(dangerTable, lat1);
            decimal[] dangerLong1 = getData(dangerTable, long1);
            decimal[] dangerLat2 = getData(dangerTable, lat2);
            decimal[] dangerLong2 = getData(dangerTable, long2);
            for (int i = 0; i < dangerLat1.Length; i++)
            {
                if (dangerLat1[i] != 0 && dangerLong1[i] != 0 && dangerLat2[i] != 0 && dangerLong2[i] != 0)
                {
                    int collisionMessage = ActionRequestMessage(WarningMessage(collisionCheck(dangerLat1[i], dangerLong1[i], dangerLat2[i], dangerLong2[i])));
                }
                //Debug.Assert(collisionMessage == 1, "Wrong action request message, expecting 1 but was: " + collisionMessage);
            }
            Console.WriteLine("Press any key");
            Console.ReadLine();
        }
    }
}