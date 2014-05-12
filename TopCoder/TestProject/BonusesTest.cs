using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for BonusesTest and is intended
    ///to contain all BonusesTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BonusesTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for getDivision
        ///</summary>
        [TestMethod()]
        public void getDivisionTest()
        {
            Bonuses target = new Bonuses(); // TODO: Initialize to an appropriate value
            int[] points = { 485, 324, 263, 143, 470, 292, 304, 188, 100, 254, 296,
 255, 360, 231, 311, 275,  93, 463, 115, 366, 197, 470 }; // TODO: Initialize to an appropriate value
            int[] expected = { 8,  6,  4,  2,  8,  5,  5,  3,  1,  4,  5,  4,  6,  3,  5,  4,  1,  8,
  1,  6,  3,  8 }; // TODO: Initialize to an appropriate value
            int[] actual;
            actual = target.getDivision(points);
            bool result = expected.SequenceEqual(actual);
            Console.WriteLine(result);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
