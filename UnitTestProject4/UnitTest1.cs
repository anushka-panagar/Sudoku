using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject4
{
    [TestClass]
    public class UnitTest1
    {
        // Passed 9 x 9 2D array for Testing
        int[,] arr1 = { { 5, 3, 4, 6, 7, 8, 9, 1, 2 }, { 6, 7, 2, 1, 9, 5, 3, 4, 8 }, { 1, 9, 8, 3, 4, 2, 5, 6, 7 }, { 8, 5, 9, 7, 6, 1, 4, 2, 3 }, { 4, 2, 6, 8, 5, 3, 7, 9, 1 }, { 7, 1, 3, 9, 2, 4, 8, 5, 6 }, { 9, 6, 1, 5, 3, 7, 2, 8, 4 }, { 2, 8, 7, 4, 1, 9, 6, 3, 5 }, { 3, 4, 5, 2, 8, 6, 1, 7, 9 } };

        [TestMethod]
        public void CheckRowTest()
        {
            try
            {
                // Check the expected and actual
                // Using Assert if the values are not equal Indicate that the Test Failed 
                bool expected = true;
                Sudoku.Sudoku.CheckRow(arr1);
                bool actual = Sudoku.Sudoku.CheckRow(arr1);
                Assert.AreEqual(expected, actual, "true", "Test Passed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred: " + ex.Message);
                throw ex;
            }

        }

        [TestMethod]
        public void CheckColumnTest()
        {
            try
            // Check the expected and actual
            // Using Assert if the values are not equal Indicate that the Test Failed 
            {
                bool expected = true;
                Sudoku.Sudoku.CheckColumn(arr1);
                bool actual = Sudoku.Sudoku.CheckColumn(arr1);
                Assert.AreEqual(expected, actual, "true", "Test Passed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred: " + ex.Message);
                throw ex;
            }
        }

        [TestMethod]
        public void CheckMatrixTest()
        {
            try
            {
                // Check the expected and actual
                // Using Assert if the values are not equal Indicate that the Test Failed 
                bool expected = true;
                Sudoku.Sudoku.CheckMatrix(arr1);
                bool actual = Sudoku.Sudoku.CheckMatrix(arr1);
                Assert.AreEqual(expected, actual, "true", "Test Passed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred: " + ex.Message);
                throw ex;
            }
        }
    }
}
