using System;

namespace QuickSort
{
    class Program
    {
        public static void QuickSort(int[] array, int low, int high)
        {
            if (low >= high)
                return;
            int pivot = partition(array, low, high);
            QuickSort(array, low, pivot - 1);
            QuickSort(array, pivot + 1, high);
        }
        public static int partition(int[] array, int low, int high)
        {
            int buf;
            int marker = low;
            for (int i = low; i < high; i++)
            {
                if (array[i] < array[high])
                {
                    buf = array[marker];
                    array[marker] = array[i];
                    array[i] = buf;
                    marker += 1;
                }
            }
            buf = array[marker];
            array[marker] = array[high];
            array[high] = buf;
            return marker;
        }
        static void Main(string[] args)
        {
            ThreeElementsTest();
            EqualElementsTest();
            OneThousandElementsTest();
            EmptyArrayTest();
            BigArrayTest();
            Console.ReadKey();
        }
        public static void ThreeElementsTest()
        {
            //Тест сортировки массива из трех элементов
            int[] array = new int[] { 2, 0, 1 };
            var flag = true;
            QuickSort(array, 0, array.Length - 1);
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] < array[i + 1])
                    flag = true;
                else
                {
                    flag = false;
                    break;
                }
            }
            if (flag == true)
                Console.WriteLine("Сортировка массива из трех элементов работает корректно");
            else
                Console.WriteLine("! Сортировка массива из трех элементов работает некорректно");
        }
        public static void EqualElementsTest()
        {
            //Тест сортировки массива из 100 одинаковых элементов
            int[] array = new int[100];
            var flag = true;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 5;
            }
            QuickSort(array, 0, array.Length - 1);
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] != array[i + 1])
                {
                    flag = false;
                    break;
                }
            }
            if (flag == true)
                Console.WriteLine("Сортировка массива из 100 одинаковых чисел работает корректно");
            else
                Console.WriteLine("! Сортировка массива из 100 одинаковых чисел работает некорректно");
        }
        public static void OneThousandElementsTest()
        {
            //Тест сортировки 1000 случайных элементов
            int[] array = new int[1000];
            var flag = true;
            var rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(0, 999);
            }
            QuickSort(array, 0, array.Length - 1);
            for (int i = 0; i < 10; i++)
            {
                int number = rnd.Next(0, 999);
                if (array[number] > array[number + 1])
                {
                    flag = false;
                    break;
                }
            }
            if (flag == true)
                Console.WriteLine("Сортировка массива из 1000 случайных элементов работает корректно");
            else
                Console.WriteLine("! Сортировка массива из 1000 случайных элементов работает некорректно");
        }
        public static void EmptyArrayTest()
        {
            //Тест пустого массива
            int[] emptyArray = new int[0];
            QuickSort(emptyArray, 0, emptyArray.Length - 1);
            if (emptyArray.Length == 0)
                Console.WriteLine("Сортировка пустого массива работает корректно");
            else
                Console.WriteLine("! Сортировка пустого массива работает некорректно");
        }
        public static void BigArrayTest()
        {
            //Тест сортировки массива из 1 500 000 элементов
            int[] bigArray = new int[1500000];
            var rnd = new Random();
            var flag = true;
            for (int i = 0; i < bigArray.Length-1; i++)
            {
                bigArray[i] = 1499000 - i;
            }
            for (int i = 0; i < bigArray.Length - 1; i++)
            {
                if (bigArray[i] < bigArray[i + 1])
                    flag = true;
                else
                    flag = false;
            }
            if (flag == true)
                Console.WriteLine("Сортировка массива из 1 500 000 элементов работает корректно");
            else
                Console.WriteLine("! Сортировка массива из 1 500 000  элементов работает некорректно");
        }
    }
}
