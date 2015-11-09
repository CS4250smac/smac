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
        *current distance between then and checks if both objects vector
        *would collide if they continue on same vector.
        *
        *@param GPS1, GPS2
        *@return distance of the two inputs
        */
        public static Double CollisionCheck(decimal[] lat1, decimal[] long1, decimal[] lat2, decimal[] long2) {
        	//Read data in order, if distance is too close pass distance to WarningMessage
            return 0;
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
        		message = 0;
        	}
        	else
        	{
        		message = 1;
        	}
            return 0;
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
        		"User ID=smackers;" +
        		"Password=1234;" +
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
        	int safeMessage = ActionRequestMessage(WarningMessage(CollisionCheck(safeLat1, safeLong1, safeLat2, safeLong2)));
        	Debug.Assert(safeMessage == 0, "Wrong action request message, expecting 0 but was: " + safeMessage);

        	decimal[] dangerLat1 = getData(dangerTable, lat1);
        	decimal[] dangerLong1 = getData(dangerTable, long1);
        	decimal[] dangerLat2 = getData(dangerTable, lat2);
        	decimal[] dangerLong2 = getData(dangerTable, long2);
        	int collisionMessage = ActionRequestMessage(WarningMessage(CollisionCheck(dangerLat1, dangerLong1, dangerLat2, dangerLong2)));
        	Debug.Assert(collisionMessage == 1, "Wrong action request message, expecting 1 but was: " + collisionMessage);
        }
    }
}
