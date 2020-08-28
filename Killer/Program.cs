using System;
using System.Collections.Generic;
using System.Linq;

namespace Killer
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length < 2)
            {
                Console.WriteLine("Usage: Killer.exe <sum> <count> [<excludenum1> <excludenum2>...]");
            }
            var sum = int.Parse(args[0]);
            var count = int.Parse(args[1]);

            var exclude = new List<int>();
            while(exclude.Count < args.Length - 2)
            {
                exclude.Add(int.Parse(args[exclude.Count + 2]));
            }

            var arr = new int[count];
            var res = new List<int[]>();
            CheckNumAtIndex(arr, sum, exclude, 0, 1, res);
            foreach(var result in res)
            {
                Console.WriteLine(string.Join(',', result));
            }
        }

        private static void CheckNumAtIndex(int[] arr, int sum, List<int> exclude, int index, int min, List<int[]> result)
        {
            for(var myNum = min; myNum <= 10 - arr.Length + index; myNum++)
            {
                if (exclude.Contains(myNum))
                    continue;
                arr[index] = myNum;
                var mySum = SumToIndex(arr, index);
                if (mySum > sum)
                    return;
                if (index == arr.Length - 1 && mySum == sum)
                {
                    AddToResult(arr, result);
                }
                if(index != arr.Length - 1)
                    CheckNumAtIndex(arr, sum, exclude, index + 1, myNum + 1, result);
            }
        }

        private static int SumToIndex(int[] arr, int index)
        {
            var i = 0;
            for(var j = 0; j <= index; j++)
            {
                i += arr[j];
            }
            return i;
        }

        private static void AddToResult(int[] arr, List<int[]> result)
        {
            result.Add(arr.ToArray());
        }
    }
}
