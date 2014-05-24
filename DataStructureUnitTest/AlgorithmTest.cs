using DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DataStructureUnitTest
{
    /// <summary>
    ///This is a test class for AlgorithmTest and is intended
    ///to contain all AlgorithmTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AlgorithmTest
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
        ///A test for MergeTwoSortedList
        ///</summary>
        [TestMethod()]
        public void MergeTwoSortedListTest()
        {
            List<int> list1 = new List<int> {1, 3, 5, 7, 9};// TODO: Initialize to an appropriate value
            List<int> list2 = new List<int> {2, 4, 6, 8, 10}; // TODO: Initialize to an appropriate value
            List<int> expected = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            List<int> actual = Algorithm.MergeTwoSortedList(list1, list2);
            CollectionAssert.AreEquivalent(expected, actual);

            list1 = new List<int> {1, 2, 3, 4, 5};
            list2 = new List<int> {6, 7, 8, 9, 10};
            expected = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            actual = Algorithm.MergeTwoSortedList(list1, list2);
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod()]
        public void MergeTwoSortedListByListNodeTest()
        {
            ListNode<int> list1 = new ListNode<int>(1);
            list1.Add(new ListNode<int>(3));
            list1.NextNode.Add(new ListNode<int>(5));
            list1.NextNode.NextNode.Add(new ListNode<int>(7));

            ListNode<int> list2 = new ListNode<int>(2);
            list2.Add(new ListNode<int>(4));
            list2.NextNode.Add(new ListNode<int>(6));
            list2.NextNode.NextNode.Add(new ListNode<int>(8));

            ListNode<int> actual = Algorithm.MergeTwoSortedListByListNode(list1, list2);
            ListNode<int> next = actual;
            while (next.NextNode != null)
            {
                Console.WriteLine(next.Value);
                next = next.NextNode;
            }

            Console.WriteLine(next.Value);
        }
    }
}
