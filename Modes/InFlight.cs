using System;
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
        public Double CollisionCheck(decimal[] lat1, decimal[] long1, decimal[] lat2, decimal[] long2) {
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
        public int WarningMessage(double CollisionDistance)
        {
            return 0;
        }
        /*
          *ActionRequestMessage will send out an ActionRequestMessage
          * When two object need to avoid a collison
          *
          *@param warningLevel;
          *@return ActionRequestMessage
          */
        public int ActionRequestMessage(int warningLevel)
        {
            return warningLevel;
        }

        public decimal[] getData(string table, string col)
        {

        }

        public static void main(string[] args) {
        	string safeTable = "safe_data", dangerTable = "collision_data", lat1 = "latitude_1", long1 = "longitude_1", lat2 = "latitude_2", long2 = "longitude_2";

        	decimal[] safeLat1 = getData(safeTable, lat1);
        	decimal[] safeLong1 = getData(safeTable, long1);
        	decimal[] safeLat2 = getData(safeTable, lat2);
        	decimal[] safeLong2 = getData(safeTable, long2);
        	int safeMessage = ActionRequestMessage(WarningMessage(CollisionDistance(safeLat1, safeLong1, safeLat2, safeLong2)));
        	Debug.Assert(safeMessage == 0, "Wrong action request message, expecting 0 but was: " + safeMessage);

        	decimal[] dangerLat1 = getData(dangerTable, lat1);
        	decimal[] dangerLong1 = getData(dangerTable, long1);
        	decimal[] dangerLat2 = getData(safedangerTableTable, lat2);
        	decimal[] dangerLong2 = getData(safedangerTableTable, long2);
        	int collisionMessage = ActionRequestMessage(WarningMessage(CollisionDistance(dangerLat1, dangerLong1, dangerLat2, dangerLong2)));
        	Debug.Assert(collisionMessage == 1, "Wrong action request message, expecting 1 but was: " + collisionMessage);
        }
    }
}
