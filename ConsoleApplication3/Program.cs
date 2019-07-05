using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
    public class Sudoku
    {
        /// <summary>
        /// Static Main Method which evaluates the validation of sudoku and return true or false
        /// </summary>
        public static void Main()
        {
            // Initialize variables i and j for looping 2D array
            int i, j;

            // Initialize an empty 2D array of 9 x 9
            int[,] arr1 = new int[9, 9];

            Console.WriteLine("Input 9 x 9 Matrix Elements");

            // loop through the row of the 2D array rows and then columns
            for (i = 0; i < 9; i++)
            {
                for (j = 0; j < 9; j++)
                {
                    // Write the Input for the Sudoku matrix
                    Console.Write("Element - [{0},{1}] : ", i, j);

                    try
                    {
                        // Convert the Written array element into Integer
                        arr1[i, j] = Convert.ToInt32(Console.ReadLine());

                        // Validation Check for input values ; checking whether the range is from 1-9
                        if (arr1[i, j] > 9 || arr1[i, j] < 0)
                        {
                            Console.WriteLine("Element - [{0},{1}] out of allowed range (1-9)", i, j);
                            // Decrement the counter to enter same element again
                            j--;
                        }
                    }

                    // FormatException if the element entered is space or alphabet ; any element other than number 1-9
                    // This check forbids the check of numbers from 1-9 while checking in row,column and matrix validations
                    catch (FormatException)
                    {
                        Console.WriteLine("element - [{0},{1}] is not an integer", i, j);
                        j--;
                    }
                }
            }


            // If Row, Column and Matrix Validation Returns True, Sudoku is Validated
            if (Sudoku.CheckRow(arr1) && Sudoku.CheckColumn(arr1) && Sudoku.CheckMatrix(arr1))
            {
                Console.WriteLine("Sudoku is Valid - TRUE");
            }
            else
            {
                Console.WriteLine("Sudoku is Not Valid - FALSE");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Method checks the row have distinct values from 1-9 which passes the 2D array as param
        /// </summary>
        /// <param name="arr1"></param>
        /// <returns>true or false</returns>
        public static bool CheckRow(int[,] arr1)
        {
            bool result = false;
            try
            {
                for (int i = 0; i < 9; i++)
                {
                    // Get every selected row
                    var row = Enumerable.Range(0, 9).Select(x => arr1[i, x]);
                    // Check if the distinct count is not equal 9 or any one of the row is not equal 9 break the loop return false; else true
                    if (row.Distinct().Count() != 9)
                    {
                        result = false;
                        break;
                    }
                    result = true;
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred: " + ex.Message);
                throw ex;
            }
        }

        /// <summary>
        ///  Method checks the column have distinct values from 1-9 which passes the 2D array as param
        /// </summary>
        /// <param name="arr1"></param>
        /// <returns>true or false</returns>
        public static bool CheckColumn(int[,] arr1)
        {
            bool result = false;
            try
            {
                for (int i = 0; i < 9; i++)
                {
                    // Get every selected column
                    var column = Enumerable.Range(0, 9).Select(x => arr1[x, i]);
                    // Check if the distinct count or any one of the column is not equal 9 break the loop and return false; else true
                    if (column.Distinct().Count() != 9)
                    {
                        result = false;
                        break;
                    }
                    result = true;
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred: " + ex.Message);
                throw ex;
            }
        }


        #region
        /// <summary>
        /// Checks the 3 x 3 matrix from 9 x 9 2D array whether they have 1-9 distinct values 
        /// </summary>
        /// <param name="arr1"></param>
        /// <returns>true or false</returns>
        public static bool CheckMatrix(int[,] arr1)
        {
            bool result = false;
            // To store and Check 3x3 matrix, initialize an empty 3 x 3 array
            int[,] arr2 = new int[3, 3];
            try
            {
                // Loop through the 9x9 array with increments of 3, which could get us 3 x 3 array's row number and column number
                for (int i = 0; i < 9; i += 3)
                {
                    for (int j = 0; j < 9; j += 3)
                    {
                        // pass the row, column and 9 x 9 array which generates the region and returns back 3 x 3 array to check the values 
                        // After Receiving the 3 x 3 array ; convert the 2D array into 1D where checking the distinct values of the array is easier 
                        int[] tmp = ConvertArray(TestRegion(arr1, i, j));

                        // Check the 1D array's unique / distinct items
                        IEnumerable<int> uniqueItems = tmp.Distinct<int>();

                        // If the count of any of the 1D array is not equal to 9 return false for validation and break the loop
                        if (uniqueItems.Distinct().Count() != 9)
                        {
                            result = false;
                            break;
                        }
                        result = true;
                    }
                    if (result == false)
                    {
                        break;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred: " + ex.Message);
                throw ex;
            }
        }
        #endregion

        /// <summary>
        /// Gets the 3 x 3 matrix on the basis of 9 x 9 array passed , startingRow and starting Column
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="startRow"></param>
        /// <param name="startCol"></param>
        /// <returns> 3x3 2D array(tmpArray)</returns>
        public static int[,] TestRegion(int[,] arr1, int startRow, int startCol)
        {
            // initialize 3 x 3 array to store the sub arrays
            int[,] tmpArray = new int[3, 3];
            // loop from the startRow upto the next 3 items as the array is 3 x 3
            for (int i = startRow; i < startRow + 3; i++)
            {
                // loop from the startCol upto the next 3 items as the array is 3 x 3
                for (int j = startCol; j < startCol + 3; j++)
                {
                    // after getting the array indexes assign that indexed value to the new tempArray of 3 x 3
                    tmpArray[i - startRow, j - startCol] = arr1[i, j];
                }
            }

            return tmpArray;
        }

        /// <summary>
        /// Converts 2D array into 1D array
        /// </summary>
        /// <param name="array"></param>
        /// <returns>1D array(tempArray)</returns>
        public static int[] ConvertArray(int[,] array)
        {
            // passing 2D array as paramter
            // initialize 1D array
            int[] tempArray = new int[9];
            // set the counter to 0 for the count of 1D arrray
            int counter = 0;
            // loop through 3 items of 9 x 9 array passed
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // for every row and column of 2D array, assign it to the 1D array which corresponds to the counter variable as indexes
                    tempArray[counter++] = array[i, j];
                }
            }
            return tempArray;
        }

    }
}

