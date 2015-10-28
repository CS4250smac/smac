using System;
using InFlightMode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
* @author team SMAC
*
* This is static Method test for InFlight mode
* 
* ToDo: Fix input, output to be agreed upon.
*/
namespace InFlightUnitTest
{
    [TestClass]
    public class InFlightUnitTestStatic
    {
        [TestMethod]
        public void CollisionCheckMethodTest()
        {
            byte[] A0 = new byte[1];
            byte[] A1 = new byte [1];
            double expectedDistance = 1;
            InFlight inFlight = new InFlight();
            double actualDistance = inFlight.CollisionCheck(A0,A1);
            Assert.AreEqual(actualDistance, expectedDistance);
        }
        [TestMethod]
        public void NoWarningMessageTest()
        {
            int expectedWarning = 0;
            double collisionDistance = 400;

            InFlight inFlight = new InFlight();
            int actualWarning = inFlight.WarningMessage(collisionDistance);
            Assert.AreEqual(actualWarning, expectedWarning);
        }
        [TestMethod]
        public void FirstWarningMessageTest()
        {
            int expectedWarning = 1;
            double collisionDistance = 200;

            InFlight inFlight = new InFlight();
            int actualWarning = inFlight.WarningMessage(collisionDistance);
            Assert.AreEqual(actualWarning, expectedWarning);

         }
        [TestMethod]
        public void SecondWarningMessageTest()
        {

            int expectedWarning = 2;
            double collisionDistance = 100;
            InFlight inFlight = new InFlight();

            int actualWarning = inFlight.WarningMessage(collisionDistance);
            Assert.AreEqual(actualWarning, expectedWarning);
        }

        [TestMethod]
        public void ThirdWarningMessageTest()
        {
            int expectedWarning = 3;
            double collisionDistance = 25;
            InFlight inFlight = new InFlight();

            int actualWarning = inFlight.WarningMessage(collisionDistance);
            Assert.AreEqual(actualWarning, expectedWarning);
        }


        [TestMethod]
        public void BadDataWarningMessageTest()
        {
            double collisionDistance = -25;
            InFlight inFlight = new InFlight();
            try {
                int actualWarning = inFlight.WarningMessage(collisionDistance);
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "Bad data");
            }
            Assert.Fail("No exception was thrown.");
        }

        [TestMethod]
        public void NoActionRequestMessageTest()
        {
            int expectedWarning= 0;
            int warningLevel = 2;
            byte[] A0 = new byte[1];
            byte[] A1 = new byte[1];

            InFlight inFlight = new InFlight();

            int actualWarning = inFlight.ActionRequestMessage(warningLevel, A0,A1);
            Assert.AreEqual(actualWarning, expectedWarning);

            inFlight = new InFlight();
            warningLevel = 3;
            actualWarning = inFlight.ActionRequestMessage(warningLevel, A0,A1);
            Assert.AreEqual(actualWarning, expectedWarning);
        }
        [TestMethod]
        public void UpActionRequestMessageTest()
        {
            int expectedWarning = 1;
            int warningLevel = 2;
            byte[] A0 = new byte[1];
            byte[] A1 = new byte[1];

            InFlight inFlight = new InFlight();

            int actualWarning = inFlight.ActionRequestMessage(warningLevel, A0, A1);
            Assert.AreEqual(actualWarning, expectedWarning);

            inFlight = new InFlight();
            warningLevel = 3;
            actualWarning = inFlight.ActionRequestMessage(warningLevel, A0, A1);
            Assert.AreEqual(actualWarning, expectedWarning);
        }
        [TestMethod]
        public void DownActionRequestMessageTest()
        {

            int expectedWarning = 2;
            int warningLevel = 2;
            byte[] A0 = new byte[1];
            byte[] A1 = new byte[1];

            InFlight inFlight = new InFlight();

            int actualWarning = inFlight.ActionRequestMessage(warningLevel, A0, A1);
            Assert.AreEqual(actualWarning, expectedWarning);

            inFlight = new InFlight();
            warningLevel = 3;
            actualWarning = inFlight.ActionRequestMessage(warningLevel, A0, A1);
            Assert.AreEqual(actualWarning, expectedWarning);

        }

        [TestMethod]
        public void LeftActionRequestMessageTest()
        {
            int expectedWarning = 3;
            int warningLevel = 2;
            byte[] A0 = new byte[1];
            byte[] A1 = new byte[1];

            InFlight inFlight = new InFlight();

            int actualWarning = inFlight.ActionRequestMessage(warningLevel, A0, A1);
            Assert.AreEqual(actualWarning, expectedWarning);

            inFlight = new InFlight();
            warningLevel = 3;
            actualWarning = inFlight.ActionRequestMessage(warningLevel, A0, A1);
            Assert.AreEqual(actualWarning, expectedWarning);
        }
        [TestMethod]
        public void RightActionRequestMessageTest()
        {
            int expectedWarning = 4;
            int warningLevel = 2;
            byte[] A0 = new byte[1];
            byte[] A1 = new byte[1];

            InFlight inFlight = new InFlight();

            int actualWarning = inFlight.ActionRequestMessage(warningLevel, A0, A1);
            Assert.AreEqual(actualWarning, expectedWarning);

            inFlight = new InFlight();
            warningLevel = 3;
            actualWarning = inFlight.ActionRequestMessage(warningLevel, A0, A1);
            Assert.AreEqual(actualWarning, expectedWarning);
        }

        [TestMethod]
        public void BadInputActionRequestMessageTest()
        {
            int badWarning = -25;
            byte[] A0 = new byte[1];
            byte[] A1 = new byte[1];
            InFlight inFlight = new InFlight();
            try
            {
                int actualWarning = inFlight.ActionRequestMessage(badWarning,A0,A1);
                   }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "Bad data");
                Console.Write(e);
            }
            Assert.Fail("No exception was thrown.");
        }







    }
}
