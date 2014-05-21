using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for MasterbrainTest and is intended
    ///to contain all MasterbrainTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MasterbrainTest
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
        ///A test for possibleSecrets
        ///</summary>
        [TestMethod()]
        public void possibleSecretsTest()
        {
            Masterbrain target = new Masterbrain(); // TODO: Initialize to an appropriate value
            string[] guesses = { "6172", "6162", "3617" }; // TODO: Initialize to an appropriate value
            string[] results = { "3b 0w", "2b 1w", "0b 3w" }; // TODO: Initialize to an appropriate value
            int expected = 14; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.possibleSecrets(guesses, results);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
