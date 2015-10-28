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
        public Double CollisionCheck(Array gps1, Array gps2) {
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
          *@param warningLevel, GPS1, GPS2;
          *@return ActionRequestMessage
          */
        public int ActionRequestMessage(int warningLevel, Array gps1, Array gps2)
        {
            return 0;
        }
    }
}
