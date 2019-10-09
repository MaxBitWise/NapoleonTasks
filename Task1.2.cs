using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void QuickSortWithOddFirst(int[] array)
        {
            int size = 0;
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] % 3 == 0)
                    size++;
            }
            int[] OddArray = new int[size];
            int[] RestArray = new int[array.Length - size];

            int OddCounter = 0;
            int RestCounter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 3 == 0)
                {
                    if (size > 0)
                    {
                        OddArray[OddCounter] = array[i];
                        OddCounter++;
                    }
                }
                else
                {
                    RestArray[RestCounter] = array[i];
                    RestCounter++;
                }       
            }
            if(OddCounter > 0)
            {
                QuickSort(OddArray, 0, OddCounter - 1);
            }
            QuickSort(RestArray, 0, RestCounter - 1);

            OddCounter = 0;
            RestCounter--;

            for (int i = 0; i < array.Length; i++)
            {
                if(OddCounter < OddArray.Length)
                {
                    array[i] = OddArray[OddCounter];
                    OddCounter++;
                }
                else
                {
                    array[i] = RestArray[RestCounter];
                    RestCounter--;
                }
            }
        }
        static void QuickSort(int[] array, int left, int right)
        {
            int leftCounter = left;
            int rightCounter = right;

            int pivot = array[(left + right) / 2];

            while(leftCounter <= rightCounter)
            {
                while (array[leftCounter] < pivot) leftCounter++;
                while (array[rightCounter] > pivot) rightCounter--;

                if(leftCounter <= rightCounter)
                {
                    int tmp = array[leftCounter];
                    array[leftCounter] = array[rightCounter];
                    array[rightCounter] = tmp;

                    leftCounter++;
                    rightCounter--;
                }
            }
            if (leftCounter < right)
                QuickSort(array, leftCounter, right);
            if (rightCounter > left)
                QuickSort(array, left, rightCounter);
        }

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            if((size >= 2) && (size <= 10000))
            {
                string StringArr = Console.ReadLine();

                string[] SplittedStringArray = StringArr.Split(' ');
                int[] IntArray = new int[size];

                for (int i = 0; i < size; i++)
                {
                    IntArray[i] = int.Parse(SplittedStringArray[i]);
                }
                QuickSortWithOddFirst(IntArray);


                for (int i = 0; i < size; i++)
                {
                    Console.Write(Convert.ToString(IntArray[i]) + ' ');
                }
                Console.ReadKey();
            }
        }
    }
}
