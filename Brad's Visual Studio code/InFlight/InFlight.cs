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
    public class InFlight
    {
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
        public  double CollisionCheck(decimal lat1, decimal long1, decimal lat2, decimal long2)
        {
            //Read data in order, if distance is too close pass distance to WarningMessage
            double dist;

            double theta = (double)(long1 - long2);
            dist = Math.Sin(deg2rad((double)lat1)) * Math.Sin(deg2rad((double)lat2)) + Math.Cos(deg2rad((double)lat1)) * Math.Cos(deg2rad((double)lat2)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515;
            return dist;
        }

        private  double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        private  double rad2deg(double rad)
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
        public  int WarningMessage(double CollisionDistance)
        {
               
            if ( CollisionDistance < 0)
            {
                throw new ArgumentOutOfRangeException("Distance", CollisionDistance, CollisionDistanceLessThanZeroMessage);
            }

             
            int message = 0;
    



            if (CollisionDistance < 10)
            {
                //Action needs to occur- follow by action
                Console.WriteLine("Immediate Action Required");
                message = 3;
            }
            else if (CollisionDistance < 20)
            {
                //Warning action needs to occur- follow by action
                Console.WriteLine("Traffic Alert");
                message = 2;
            }
            else if (CollisionDistance < 30)
            {
                //Warning message no action request
                Console.WriteLine("Traffic Warning");
                message = 1;
            }
            else
            {
                Console.WriteLine("No conflict.");
                message = 0;
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
        public  int ActionRequestMessage(int warningLevel)
        {
            if (warningLevel < 0)
            {
                throw new ArgumentOutOfRangeException("warningLevel", warningLevel, IncorrectWarningLevelMessage);
            }
            //Climb
            //Descend

            //Reduce climb.
            //Reduce descent.
            //increase Climb
            //Increase descent

            //maintain vertical speed
            //Level off
            //Monitor vertical speed.

            //Clear of Conflict

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
            while (reader.Read())
            {
                Console.WriteLine("Adding value: " + reader[col] + ", from " + table + ".");
                vals[i] = (decimal)reader[col];
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

        //public static void main(string[] args)
        //{
        //    string safetable = "safe_data", dangertable = "collision_data", lat1 = "latitude_1", long1 = "longitude_1", lat2 = "latitude_2", long2 = "longitude_2";

        //    decimal[] safelat1 = getdata(safetable, lat1);
        //    decimal[] safelong1 = getdata(safetable, long1);
        //    decimal[] safelat2 = getdata(safetable, lat2);
        //    decimal[] safelong2 = getdata(safetable, long2);
        //    for (int i = 0; i < safelat1.length; i++)
        //    {
        //        int safemessage = actionrequestmessage(warningmessage(collisioncheck(safelat1[i], safelong1[i], safelat2[i], safelong2[i])));
        //        debug.assert(safemessage == 0, "wrong action request message, expecting 0 but was: " + safemessage);
        //    }

        //    decimal[] dangerlat1 = getdata(dangertable, lat1);
        //    decimal[] dangerlong1 = getdata(dangertable, long1);
        //    decimal[] dangerlat2 = getdata(dangertable, lat2);
        //    decimal[] dangerlong2 = getdata(dangertable, long2);
        //    for (int i = 0; i < dangerlat1.length; i++)
        //    {
        //        int collisionmessage = actionrequestmessage(warningmessage(collisioncheck(dangerlat1[i], dangerlong1[i], dangerlat2[i], dangerlong2[i])));
        //        debug.assert(collisionmessage == 1, "wrong action request message, expecting 1 but was: " + collisionmessage);
        //    }
        //}
    }
}