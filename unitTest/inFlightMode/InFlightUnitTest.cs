using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InFlightUnitTest
{
   // [TestClass]
    public class InFlightUnitTest
    {

        // Test 1: A1 is on opposite course of A0.
        // Validation: no warning message, plan should be tracked till out of range.
      //  [TestMethod]
        public void TestMethod1()
        {
            double expected = 1;
            //int t, is time in this case. 
            for (int t = 0; t >= 30; t++)
            {
                //call inflightmethod.
                //InFlight.CollisionCheck();
                double actual = 1; // = inflightmethod

               // Assert.AreEqual(expected, actual); 
            }
       
            


        }

        // Test 2: A1 is on course that will pass by A0 within X (1st warning area) distance of each other.
        // Validation: no warning message, First warning message, no warning message.
   //     [TestMethod]
        public void TestMethod2()
        {

        }

        // Test 3: A1 is on course that will pass by A0 within X (2nd warning area) distance of each other.
        // Validation: no warning message, First warning message, second warning message no warning message.
 //       [TestMethod]
        public void TestMethod3()
        {

        }

        // Test 4: A1 is on course that will pass by A0 within X (3rd warning area) distance of each other.
        // Validation: no warning message, First warning message, Second warning message, Third warning message, no warning message.
  //      [TestMethod]
        public void TestMethod4()
        {

        }

        // Test 5: A1 is on course that will pass by A0 within 0 distance and collision will occur.
        // Validation:  no warning message, First warning message, Second warning message, Third warning message.
  //      [TestMethod]
        public void TestMethod5()
        {

        }

        // Test 6: A1 is  will be pass infront A0 but will not be 1st warning area range.
        // Validation: no warning message.
  //      [TestMethod]
        public void TestMethod6()
        {

        }

        // Test 7: A1 is  will be pass infront A0 within 1st warning area range.
        // Validation: no warning message, 1st warning message, no warning message.
  //      [TestMethod]
        public void TestMethod7()
        {

        }

        // Test 8: A1 is  will be pass infront A0 within  2nd warning area range.
        // Validation: no warning message, 1st warning message, 2nd warning message, no warning message.
  //      [TestMethod]
        public void TestMethod8()
        {

        }

        // Test 9: A1  is not moving. A0 is on course that will make A1 0 distance apart and collision will occur.
        // Validation:  no warning message, First warning message, Second warning message, Third warning message.
 //       [TestMethod]
        public void TestMethod9()
        {

        }

        // Test 10: A0  is not moving. A1 is on course that will make A0 0 distance apart and collision will occur.
        // Validation:  no warning message, First warning message, Second warning message, Third warning message.
//        [TestMethod]
        public void TestMethod10()
        {

        }

        // Test 11: A1 is  will be pass behind A0 but will not be 1st warning area range.
        // Validation: no warning message.
//        [TestMethod]
        public void TestMethod11()
        {

        }

        // Test 12: A1 is  will be pass behind A0 within 1st warning area range.
        // Validation: no warning message, 1st warning message, no warning message.
//        [TestMethod]
        public void TestMethod12()
        {

        }

        // Test 13: A1 is  will be pass behind A0 within  2nd warning area range.
        // Validation: no warning message, 1st warning message, 2nd warning message, no warning message.
 //       [TestMethod]
        public void TestMethod13()
        {

        }


    }
}
