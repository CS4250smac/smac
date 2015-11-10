using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;
/*
* @author team SMAC
*
* Barebones method and inputs.
*/

namespace InFlightMode
{
    public class InFlight {

        /*
        *CollisionChecks will take two GPS inputs and checks the
        *current distance between them and checks if both objects vector
        *would collide if they continue on same vector.
        *
        *@param GPS1, GPS2
        *@return distance of the two inputs
        */
        public static double CollisionCheck(decimal lat1, decimal long1, decimal lat2, decimal long2) {
            //Read data in order, if distance is too close pass distance to WarningMessage
            double dist;

            double theta = (double)(long1 - long2);
            dist = Math.Sin(deg2rad((double) lat1)) * Math.Sin(deg2rad((double) lat2)) + Math.Cos(deg2rad((double) lat1)) * Math.Cos(deg2rad((double) lat2)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515;
            return dist;
        }

        private static double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        private static double rad2deg(double rad)
        {
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
        	int message = 0;
        	if (CollisionDistance > 20)
        	{
                //no danger
                Console.WriteLine("You are safe");
        		message = 0;
        	}
        	else
        	{
                //danger
                Console.WriteLine("You are in danger");
                message = 1;
        	}
            return message;
        }
        /*
          *ActionRequestMessage will send out an ActionRequestMessage
          * When two object need to avoid a collison
          *
          *@param warningLevel;
          *@return ActionRequestMessage
          */
        public static int ActionRequestMessage(int warningLevel)
        {
            return warningLevel;
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
                int safeMessage = ActionRequestMessage(WarningMessage(CollisionCheck(safeLat1[i], safeLong1[i], safeLat2[i], safeLong2[i])));
                Debug.Assert(safeMessage == 0, "Wrong action request message, expecting 0 but was: " + safeMessage);
            }

        	decimal[] dangerLat1 = getData(dangerTable, lat1);
        	decimal[] dangerLong1 = getData(dangerTable, long1);
        	decimal[] dangerLat2 = getData(dangerTable, lat2);
        	decimal[] dangerLong2 = getData(dangerTable, long2);
            for (int i = 0; i < dangerLat1.Length; i++)
            {
                int collisionMessage = ActionRequestMessage(WarningMessage(CollisionCheck(dangerLat1[i], dangerLong1[i], dangerLat2[i], dangerLong2[i])));
                Debug.Assert(collisionMessage == 1, "Wrong action request message, expecting 1 but was: " + collisionMessage);
            }
        }
    }
}