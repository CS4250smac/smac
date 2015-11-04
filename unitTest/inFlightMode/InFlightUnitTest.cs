using System;
using InFlightMode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InFlightUnitTest
{
    [TestClass]
    public class InFlightUnitTest
    {
        private byte[] AdvanceTime(byte[] oldPOS)
        {
            byte[] newPOS;
            // move the postion based on vector;
            newPOS = oldPOS;
            return newPOS;
        }
        // Test 1: A1 is on opposite course of A0.
        // Validation: no warning message, plan should be tracked till out of range.
        [TestMethod]
        public void TestMethod1(byte[] A0, byte[] A1)
        {
            double expected = 0;
            double actual;


            InFlight inFlight = new InFlight();
            //int t, is time in this case. 
            for (int t = 0; t >= 30; t++)
            {
                actual = inFlight.WarningMessage(inFlight.CollisionCheck(A0, A1));
                Assert.AreEqual(expected, actual);
                AdvanceTime(A0);
                AdvanceTime(A1);
            }

        }

        // Test 2: A1 is on course that will pass by A0 within X (1st warning area) distance of each other.
        // Validation: no warning message, First warning message, no warning message.
        [TestMethod]
        public void TestMethod2(byte[] A0, byte[] A1)
        {
            double expected = 0;
            double actual;


            InFlight inFlight = new InFlight();
            //int t, is time in this case. 
            for (int t = 0; t >= 30; t++)
            {
                actual = inFlight.WarningMessage(inFlight.CollisionCheck(A0, A1));
                if (t == 5)
                {
                    expected++;
                }
                Assert.AreEqual(expected, actual);

                AdvanceTime(A0);
                AdvanceTime(A1);
            }
        }

        // Test 3: A1 is on course that will pass by A0 within X (2nd warning area) distance of each other.
        // Validation: no warning message, First warning message, second warning message no warning message.
        [TestMethod]
        public void TestMethod3(byte[] A0, byte[] A1)
        {
            double expected = 0;
            double actual;


            InFlight inFlight = new InFlight();
            //int t, is time in this case. 
            for (int t = 0; t >= 30; t++)
            {
                actual = inFlight.WarningMessage(inFlight.CollisionCheck(A0, A1));
                if (t == 5 || t == 10)
                {
                    expected++;
                }

                Assert.AreEqual(expected, actual);

                AdvanceTime(A0);
                AdvanceTime(A1);
            }
        }

        // Test 4: A1 is on course that will pass by A0 within X (3rd warning area) distance of each other.
        // Validation: no warning message, First warning message, Second warning message, Third warning message, no warning message.
        [TestMethod]
        public void TestMethod4(byte[] A0, byte[] A1)
        {
            double expected = 0;
            double actual;


            InFlight inFlight = new InFlight();
            //int t, is time in this case. 
            for (int t = 0; t >= 30; t++)
            {
                actual = inFlight.WarningMessage(inFlight.CollisionCheck(A0, A1));
                if (t == 5 || t == 10 || t == 15)
                {
                    expected++;
                }
                if (t == 20)
                {
                    expected = 0;
                }

                Assert.AreEqual(expected, actual);

                AdvanceTime(A0);
                AdvanceTime(A1);
            }
        }

        // Test 5: A1 is on course that will pass by A0 within 0 distance and collision will occur.
        // Validation:  no warning message, First warning message, Second warning message, Third warning message.
        [TestMethod]
        public void TestMethod5(byte[] A0, byte[] A1)
        {
            double expected = 0;
            double actual;


            InFlight inFlight = new InFlight();
            //int t, is time in this case. 
            for (int t = 0; t >= 30; t++)
            {
                actual = inFlight.WarningMessage(inFlight.CollisionCheck(A0, A1));
                if (t == 5 || t == 10 || t == 15)
                {
                    expected++;
                }


                Assert.AreEqual(expected, actual);

                AdvanceTime(A0);
                AdvanceTime(A1);
            }
        }
    }
}
