using DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataStructureUnitTest
{
    
    
    /// <summary>
    ///This is a test class for TreeAlgorithmTest and is intended
    ///to contain all TreeAlgorithmTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TreeAlgorithmTest
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
        ///A test for InOrderTraversal
        ///</summary>
        [TestMethod()]
        public void InOrderTraversalTest()
        {
            TreeAlgorithm target = new TreeAlgorithm(); // TODO: Initialize to an appropriate value
            TreeNode<int> root = Utility.CreateBinarySearchTree();
            target.InOrderTraversal(root);
        }

        /// <summary>
        ///A test for PostOrderTraversal
        ///</summary>
        [TestMethod()]
        public void PostOrderTraversalTest()
        {
            TreeAlgorithm target = new TreeAlgorithm(); // TODO: Initialize to an appropriate value
            TreeNode<int> root = Utility.CreateBinarySearchTree();
            target.PostOrderTraversal(root);
        }

        /// <summary>
        ///A test for PreOrderTraversal
        ///</summary>
        [TestMethod()]
        public void PreOrderTraversalTest()
        {
            TreeAlgorithm target = new TreeAlgorithm(); // TODO: Initialize to an appropriate value
            TreeNode<int> root = Utility.CreateBinarySearchTree();
            target.PreOrderTraversal(root);
        }
    }
}
