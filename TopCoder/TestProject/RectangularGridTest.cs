using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for RectangularGridTest and is intended
    ///to contain all RectangularGridTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RectangularGridTest
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
        ///A test for countRectangles
        ///</summary>
        [TestMethod()]
        public void countRectanglesTest()
        {
            RectangularGrid target = new RectangularGrid(); // TODO: Initialize to an appropriate value
            int width = 592; // TODO: Initialize to an appropriate value
            int height = 964; // TODO: Initialize to an appropriate value
            long expected = 81508708664; // TODO: Initialize to an appropriate value
            long actual;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            actual = target.countRectangles(width, height);
            watch.Stop();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
