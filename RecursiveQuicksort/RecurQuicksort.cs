using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Sean Brady
 * 9/22/2017
 * COSC 450 Programming Excercise 1
 * Recursive Quicksort: array of random integers
*/

namespace RecursiveQuicksort
{
    class RecurQuicksort
    {
        static void Main(string[] args)
        {
            Console.WriteLine("this program recursivly sorts an array of random integers\npress ENTER to generate an array");
            Console.ReadLine();

            int[] array = new int[10];
            FillArray(array);
            Console.Write("unsorted array:\t");
            PrintArray(array);

            Console.Write("sorted array:\t");
            PrintArray(Quicksort(array, 0, array.GetLength(0) - 1));

            Console.Write("\npress any key to exit");
            Console.ReadKey();
        }

        //fill an array with random non-duplicate values
        static public void FillArray(int[] arr)
        {
            Random rnd = new Random();
            List<int> listNumbers = new List<int>(); //a list to hold generated values of the array to ensure there are no duplicates

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                do
                {
                    arr[i] = rnd.Next(1, 11);
                } while (listNumbers.Contains(arr[i])); //test to see if the generated integer is already in the array
                listNumbers.Add(arr[i]);
            }
        }

        //print all the values of an array
        static public void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.Write(arr[i] + "\t");
            }
            Console.WriteLine();
        }

        static public int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];

            while (true)
            {
                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    int temp = arr[right];
                    arr[right] = arr[left];
                    arr[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        static public int[] Quicksort(int[] arr, int left, int right)
        {
            if(left < right)
            {
                int pivot = Partition(arr, left, right); //choose pivot and sort

                if(pivot > 1)
                {
                    Quicksort(arr, left, pivot - 1); //recursively move the right value to the left
                }

                if(pivot + 1 < right)
                {
                    Quicksort(arr, pivot + 1, right); //recursively move the left value to the right
                }
            }
            return arr; //return when the left and right values meet each other
        }
    }
}