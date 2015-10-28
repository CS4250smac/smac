using System;
using InFlightMode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InFlightUnitTest
{
    [TestClass]
    public class InFlightUnitTestStatic
    {
        [TestMethod]
        public void CollisionCheckMethodTest()
        {
            Array A0;
            Array A1;
            double expectedDistance = 1;
            InFlight inFlight = new InFlight();
            double actualDistance = inFlight.CollisionCheck();
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
                Console.Write(e);
            }
            Assert.Fail("No exception was thrown.");
        }

        [TestMethod]
        public void NoActionRequestMessageTest()
        {
            int expectedWarning= 0;
            InFlight inFlight = new InFlight();

            int actualWarning = inFlight.ActionRequestMessage(2);
            Assert.AreEqual(actualWarning, expectedWarning);

            inFlight = new InFlight();

            actualWarning = inFlight.ActionRequestMessage(3);
            Assert.AreEqual(actualWarning, expectedWarning);
        }
        [TestMethod]
        public void UpActionRequestMessageTest()
        {
            int expectedWarning = 1;
            InFlight inFlight = new InFlight();

            int actualWarning = inFlight.ActionRequestMessage(2);
            Assert.AreEqual(actualWarning, expectedWarning);

            inFlight = new InFlight();

            actualWarning = inFlight.ActionRequestMessage(3);
            Assert.AreEqual(actualWarning, expectedWarning);

        }
        [TestMethod]
        public void DownActionRequestMessageTest()
        {

            int expectedWarning = 2;
            InFlight inFlight = new InFlight();

            int actualWarning = inFlight.ActionRequestMessage(2);
            Assert.AreEqual(actualWarning, expectedWarning);

            inFlight = new InFlight();
        
            actualWarning = inFlight.ActionRequestMessage(3);
            Assert.AreEqual(actualWarning, expectedWarning);

        }

        [TestMethod]
        public void LeftActionRequestMessageTest()
        {
            int expectedWarning = 3;
            InFlight inFlight = new InFlight();

            int actualWarning = inFlight.ActionRequestMessage(2);
            Assert.AreEqual(actualWarning, expectedWarning);

            inFlight = new InFlight();

            actualWarning = inFlight.ActionRequestMessage(3);
            Assert.AreEqual(actualWarning, expectedWarning);
        }
        [TestMethod]
        public void RightActionRequestMessageTest()
        {
            int expectedWarning = 4;
            InFlight inFlight = new InFlight();

            int actualWarning = inFlight.ActionRequestMessage(2);
            Assert.AreEqual(actualWarning, expectedWarning);

            inFlight = new InFlight();

            actualWarning = inFlight.ActionRequestMessage(3);
            Assert.AreEqual(actualWarning, expectedWarning);
        }

        [TestMethod]
        public void BadInputActionRequestMessageTest()
        {
            int badWarning = -25;
            InFlight inFlight = new InFlight();
            try
            {
                int actualWarning = inFlight.ActionRequestMessage(badWarning);
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
