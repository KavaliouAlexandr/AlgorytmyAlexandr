using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RepeatRecursive("#", 5));
            Console.WriteLine(string.Join(", ", Change(14)));
            Console.WriteLine(QuickFib(100));
            int[] arr = { 3, 4, 1, 6, 2, 5, 8, 9 };
            BubleSort(arr);
            Console.WriteLine(string.Join(", ", arr));
            Console.WriteLine(Sum(arr, 2, 6));
            Console.WriteLine(string.Join(", ", ChangeBis(13, new int[] { 1, 2, 5, 20 })));
        }
        public static string Repeat(String s, int n)
        {
            string result = "";
            for (int i = 0; i < n; i++)
            {
                result = result + s; //result(i) <- result(i-1) + s
            }
            return result;
        }

        public static string RepeatRecursive(string s, int n)
        {
            if (n <= 0)
            {
                return "";
            }
            return RepeatRecursive(s, n - 1) + s;
        }

        //wersja rekurencyjna funkcji sumujacej elementy tablicy od start do end
        public static int Sum(int[] arr, int start, int left)
        {
            //Console.WriteLine(arr[start]);
            if (start == left)
            {
                return arr[left];
            }
            return Sum(arr, start + 1, left) + arr[start];
        }


        //wydawanie reszty dla 1, 2, 5
        public static int[] Change(int amount)
        {
            int[] arr = new int[3];
            arr[2] = amount / 5;
            amount = amount - 5 * arr[2];

            arr[1] = amount / 2;
            amount = amount - 2 * arr[1];

            arr[0] = amount / 1;
            amount = amount - 1 * arr[0];

            return arr;
        }

        //wydawanie reszty dla nominalow w tablicy
        //np. { 1, 2, 5, 20 }
        public static int[] ChangeBis(int amount, int[] nominals)
        {
            int[] reszta = new int[nominals.Length];
            for (int i = nominals.Length - 1; i >= 0; i--)
            {
                reszta[i] = amount / nominals[i];
                amount = amount - nominals[i] * reszta[i];
            }

            return reszta;
        }

        public static int Fib(int n)
        {
            if (n < 2)
            {
                return n;
            }
            return Fib(n - 2) + Fib(n - 1);
        }

        private static int FibMem(int n, int[] mem)
        {
            if (n < 2)
            {
                return n;
            }
            if (mem[n - 2] == 0)
            {
                mem[n - 2] = FibMem(n - 2, mem);
            }
            if (mem[n - 1] == 0)
            {
                mem[n - 1] = FibMem(n - 1, mem);
            }
            return mem[n - 2] + mem[n - 1];
        }

        public static int QuickFib(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            return FibMem(n, new int[n]);
        }


        public static void BubleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = arr.Length - 1; j > i; j--)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                    }
                }
            }
        }
    }
}