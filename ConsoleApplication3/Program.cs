using Sudoku;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Sudoku
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Main()
        {
            int i, j;
            int[,] arr1 = new int[9, 9];
            Console.WriteLine("Read a 9x9 2D array");
            Console.WriteLine("Input Matrix Element");
            for (i = 0; i < 9; i++)
            {
                for (j = 0; j < 9; j++)
                {
                    Console.Write("element - [{0},{1}] : ", i, j);
                    try
                    {
                        arr1[i, j] = Convert.ToInt32(Console.ReadLine());
                        if (arr1[i, j] > 9 || arr1[i, j] < 0)
                        {
                            Console.WriteLine("element [{0},{1}] out of allowed range (1-9)");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("element - [{0},{1}] is not an integer", i, j);
                    }
                }
            }
          //  if (Sudoku.CheckRow(arr1) && Sudoku.CheckColumn(arr1) && Sudoku.CheckMatrix(arr1))
            if (Sudoku.CheckRow(arr1))
            {
                Console.WriteLine("Sudoku is Valid - TRUE");
            }else
            {
                Console.WriteLine("Sudoku is Not Valid - FALSE");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr1"></param>
        /// <returns></returns>
        public static bool CheckRow(int[,] arr1)
        {
            bool result = false;
            try
            {
                for (int i = 0; i < 9; i++)
                {
                    var row = Enumerable.Range(0, 9).Select(x => arr1[i, x]);
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
        public static bool CheckColumn(int[,] arr1)
        {
            bool result = false;
            try
            {
                for (int i = 0; i < 9; i++)
                {
                    var column = Enumerable.Range(0, 9).Select(x => arr1[x, i]);
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
        /// 
        /// </summary>
        /// <param name="arr1"></param>
        /// <returns></returns>
        //public static bool CheckColumn(int[,] arr1)
        //{
        //    bool result = false;
        //    try
        //    {
        //        for (int i = 0; i < arr1.GetLength(0); i++)
        //        {
        //            for (int j = 0; j < arr1.GetLength(1); j++)
        //            {
        //                if (j == 0)
        //                {
        //                    result = true;
        //                }
        //                else if (arr1[j, i] == arr1[j - 1, i])
        //                {
        //                    result = false;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error occurred: " + ex.Message);
        //        throw ex;
        //    }
        //    return result;
        //}
        #endregion

        #region
        
        public static bool CheckMatrix(int[,] arr1)
        {
            int[,] arr2 = new int[3,3];
            int dataLen = 9;
            int matrixLen = 3;
            for(int i = 0; i < dataLen; i++)
            {
              //  int col = i % arr1.GetLength(0);
                int row = i / arr1.GetLength(0);
                for(int j = 0; j < matrixLen; j++)
                {
                    int col1 = j % arr1.GetLength(1);
              //      int row1 = j / arr1.GetLength(1);
                    arr2[row,col1] = arr1[row, col1];
                    Console.WriteLine(arr2[row, col1]);
                }
              
            }
         
            return false;

           

        
        }
        #endregion

        public static bool testRegion(int[,] arr1, int startRow, int startCol)
        {
            int[] tmp = new int[arr1.Length];
            int index = 0;
            for(int i = startRow; i < startRow + 3; i++)
            {
                for (int j = startCol; j < startCol + 3; j++)
                {
                    tmp[index] = arr1[i,j];
                    index++;
                    
                }
            }
            Console.WriteLine(tmp);
            return false;
        }
    }
}

//  return false;
//var number_count = new Dictionary<int, int>();
//for (int i = 0; i < 3 ; i++)
//{
//    for (int j = 0; j < 3; j++)
//    {
//        var number = arr1[i, j];
//        if (!number_count.ContainsKey(number))
//        {
//            number_count[number] = 0;
//        }
//        number_count[number] += 1;
//       // Console.WriteLine(number);
//    }

//}
//foreach (var key in number_count)
//{
//    if (key.Value > 1)
//    {
//        result = true;
//    }
//    else
//    {
//        result = false;
//    }
//}
