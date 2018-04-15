using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace hackerRank
{
    class Program
    {
        static void Main(string[] args)
        {
            //  CommonInts(args);

            //CallMaxProfit();
           // bbSort2(args);
            IdentSubstringsInBiggerString(args);
        }


        //Identify unique substrings inside a larger string  
        private static void IdentSubstringsInBiggerString(string[] args)
        {
            var biggerString = Console.ReadLine();
            var stringDictionary = new Dictionary<string,int>();

            if (biggerString != null)
            {
                var count = biggerString.Length;
                var outerCounter = 0;

                while (outerCounter < count)
                {
                    for (var a = 0; a <= count; a++)
                    {
                        for (var b = 0; b <= count; b++)
                        {
                            //traverse bigger string, set substring length to be whatever b is minus a 
                            var subStringLength = b - a;

                            //if subStringLength is bigger than 0 we can grab the current letter in cursor plus the next letter
                            //but check to make sure we don't go out of bounds of the bigger string 
                            //and make sure we didn't add the substring to the dictionary already
                            if (subStringLength > 0 && subStringLength <= count &&
                                !stringDictionary.ContainsKey(biggerString.Substring(a, subStringLength)))
                            {
                                stringDictionary[biggerString.Substring(a, subStringLength)] = stringDictionary.Count();
                            }

                        }
                    }

                    outerCounter++;
                }
            }

            foreach (var key in stringDictionary.Keys)
            {
                Console.WriteLine(key);
            }
            Console.WriteLine($"number of substrings: {stringDictionary.Count()}");
            Console.ReadLine();
        }

        private static void bbSort2(string[] args)
        {
            var arr1 = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse).ToList();

            var sortedList = arr1;

            var count = arr1.Count();
            var counter = 0;

            while (counter < count)
            {
                for (var x = 0; x < count; x++)
                {
                    if (x + 1 >= count || arr1[x] < arr1[x + 1]) continue;
                    var biggerNum = arr1[x];
                    var smallerNum = arr1[x + 1];

                    sortedList[x] = smallerNum;
                    sortedList[x + 1] = biggerNum;
                }
                counter++;
            }

            foreach (var num in sortedList)
            {
                Console.WriteLine(num);
            }
            Console.ReadLine();
        }


        private static void bbSort(string[] args)
        {
            var arr1 = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse).ToList();

            var sortedList = arr1;

            var index = 0;
            var count = arr1.Count();

            while(index < count)
            {
                var num = arr1[index];

                for (var x = 0; x < count; x++)
                {
                    if (x + 1 >= count || arr1[x] < arr1[x + 1]) continue;
                    var smallerNum = arr1[x + 1];
                    var biggerNum = arr1[x];

                    sortedList[x] = smallerNum;
                    sortedList[x + 1] = biggerNum;
                }
                index++;
            }

            foreach (var item in sortedList)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        private static void CommonIntsV2(string[] args)
        {
            var arr1 = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse).ToList();
            var arr2 = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse).ToList();

            var commonDict = new Dictionary<int, int>();

            for (int x = 0; x < arr1.Count(); x++)
            {
                var num = arr1[x];
                if (!commonDict.ContainsKey(num))
                {
                    commonDict.Add(num, 1);
                }
                else
                {
                    commonDict[num]++;
                }
            }

            for (int x = 0; x < arr2.Count(); x++)
            {
                if (commonDict.ContainsKey(arr2[x]))
                {
                    var keyCount = commonDict[arr2[x]];
                    for (var j = 0; j < keyCount; j++)
                    {
                        Console.WriteLine(arr2[x]);
                        commonDict[arr2[x]]--;
                    }
                    //

                }
            }
            Console.ReadLine();
        }

        private static void CommonInts(string[] args)
        {
            var arr1 = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse).ToList();
            var arr2 = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse).ToList();

            var commonList = new List<int>();

            for (int x = 0; x < arr1.Count(); x++)
            {
                var num = arr1[x];
                for (int j = 0; j < arr2.Count(); j++)
                {
                    if (arr2[j] == num)
                    {
                        commonList.Add(num);
                        arr2.RemoveAt(j);
                        break;
                    }
                }
            }

            foreach (var i in commonList)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }

        private static void CallMaxProfit()
        {
            int[] stockPricesYesterday = { 10, 7, 5, 8, 11, 9 };

            var maxProfit = GetMaxProfit(stockPricesYesterday);
            Console.WriteLine(string.Format("Max Profit: {0}", maxProfit));
            Console.ReadLine();
        }

        private static int GetMaxProfit(int[] stockPricesYesterday)
        {
            var maxProfit = 0;

            var lowestPrice = 0;
            var highestPrice = 0;

            //get lowest number
            for(int x = 0; x < stockPricesYesterday.Length; x++){
                lowestPrice = stockPricesYesterday[x];
                for(int y = 0; y < stockPricesYesterday.Length; y++)
                {
                    if(stockPricesYesterday[y] < lowestPrice)
                    {
                        lowestPrice = stockPricesYesterday[y];
                    }else if(stockPricesYesterday[y] > highestPrice)
                    {
                        highestPrice = stockPricesYesterday[y];
                    }
                }
            }          

            maxProfit = highestPrice - lowestPrice;

            return maxProfit;
        }



 


        //5 2 3 4 1 7
        private static void BubbleSortV2(string[] args)
        {
            var arr1 = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var sortedList = arr1.ToList<int>();

            var totalSize = sortedList.Count();
            var index = 0;

            while (index < totalSize)
            {
                for (int x = 0; x < totalSize; x++)
                {
                    if (x + 1 < totalSize && sortedList[x] >= sortedList[x + 1])
                    {
                        var smallerNumber = sortedList[x + 1];
                        sortedList[x + 1] = sortedList[x];
                        sortedList[x] = smallerNumber;
                    }
                }
                index++;
            }

            foreach (var x in sortedList)
            {
                Console.WriteLine(x);
            }
            Console.ReadLine();
        }

        

        private static void Fib_Iterative(int len)
        {
            int a = 0, b = 1, c = 0;
            Console.Write($"{a} {b}");

            for(int i = 2; i < len; i++)
            {
                c = a + b;
                Console.Write($" {c}");
                a = b;
                b = c;
            }
            Console.ReadLine();
        }





        private static void UseSingleton()
        {
            for(int x = 0; x < 6; x++)
            {
                Singleton.Instance.SayHi();
            }
          
        }
   
        private static void TestLinkedList(string[] args)
        {
            LinkedList<LLTest> list = new LinkedList<LLTest>();

            for (var i = 0; i < 123456; i++)
            {
                var a = new LLTest(i, i, i, i);

                list.AddLast(a);
                var curNode = list.First;

                for (var k = 0; k < i / 2; k++) // In order to insert a node at the middle of the list we need to find it
                    curNode = curNode.Next;

                list.AddAfter(curNode, a); // Insert it after
            }

            decimal sum = 0;
            foreach (var item in list)
                sum += item.A;
        }


        private static void ReverseWord(string[] args)
        {
            var word = Console.ReadLine();
            var reversedWordSb = new StringBuilder();

            for (int x = word.Length - 1; x >= 0; x--)
            {
                reversedWordSb.Append(word[x]);
            }

            Console.WriteLine(reversedWordSb.ToString());
            Console.ReadLine();

        }
        
        //1,2,2,3,5,
        //3,4,7,7,8,9
        private static void MergeAndSort(string[] args)
        {
            var arr1 = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var arr2 = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var mergedList = new List<int>();

            mergedList.AddRange(arr1);
            mergedList.AddRange(arr2);

            var totalSize = mergedList.Count();
            var index = 0;

            while (index < totalSize)
            {

                for (int x = 0; x < totalSize; x++)
                {
                    if (x + 1 < mergedList.Count() && mergedList[x] >= mergedList[x + 1])
                    {
                        var smallerNumber = mergedList[x + 1];
                        mergedList[x + 1] = mergedList[x];
                        mergedList[x] = smallerNumber;
                    }
                }
                index++;
            }

            foreach (var x in mergedList)
            {
                Console.WriteLine(x);
            }
            Console.ReadLine();
        }

        // 5 2 10 7
        private static void BubbleSort(string[] args)
        {

            int[] numbers = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var secondNumList = numbers.ToList<int>();
            var thirdNumList = new List<int>();

            var arrLastIndex = numbers.Length - 1;
            for (int x = 0; x <= arrLastIndex; x++)
            {
                var number = GetSmallestNumber(secondNumList); //secondNumList.Min();
                thirdNumList.Add(number);
                secondNumList.Remove(number);
            }

            foreach (var x in thirdNumList)
            {
                Console.WriteLine(x);
            }
            Console.ReadLine();

        }

        public static int GetSmallestNumber(List<int> intList)
        {
            var anotherList = intList.ToList();
            var smallestNumber = 0;

            for (int x = 0; x < intList.Count(); x++)
            {
                var number = intList[x];

                for (int i = 0; i < anotherList.Count(); i++)
                {
                    if (anotherList[i] > number)
                    {
                        anotherList.Remove(anotherList[i]);
                    }
                    if (anotherList[i] == number && anotherList.Where(n => n != number).Count() == 1)
                    {
                        smallestNumber = anotherList.First(n => n != number);
                        break;
                    }
                }
                if (anotherList.Count() == 1)
                {
                    smallestNumber = anotherList.First();
                    break;
                }
            }

            return smallestNumber;
        }

        private void AddDisperateTypesToArrayList()
        {
            var arrList = new ArrayList();
            arrList.Add(1);
            arrList.Add("me");
            foreach (var j in arrList)
            {
                Console.WriteLine(j);
            }
            Console.ReadLine();
        }

        //// 5 2 10 7
        //private static void BubbleSort(string[] args)
        //{

        //    int[] numbers = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        //    var secondNumList = numbers.ToList<int>();
        //    var thirdNumList = new List<int>();

        //    var arrLastIndex = numbers.Length - 1;
        //    for (int x = 0; x <= arrLastIndex; x++)
        //    {
        //        var number = secondNumList.Min();
        //        thirdNumList.Add(number);
        //        secondNumList.Remove(number);
        //    }

        //    foreach (var x in thirdNumList)
        //    {
        //        Console.WriteLine(x);
        //    }
        //    Console.ReadLine();

        //}



        private static void MoveAnimal(Animal animal)
        {
            animal.Move();
        }

        private static void RansomNoteV3(string[] args)
        {
            Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));

            string[] tokens_m = Console.ReadLine().Split(' ');
            // int m = Convert.ToInt32(tokens_m[0]);
            // int n = Convert.ToInt32(tokens_m[1]);

            string[] magazine = Console.ReadLine().Split(' ');
            string[] ransom = Console.ReadLine().Split(' ');

            var exceptions = magazine.Except(ransom);

            var m2 = magazine.Where(m => !exceptions.Contains(m)).ToArray();

            Array.Sort(ransom);
            Array.Sort(m2);

            bool arraysAreEqual = ransom.Distinct().SequenceEqual(m2.Distinct());

            var canUseMagazine = arraysAreEqual ? "Yes" : "No";

            Console.WriteLine(canUseMagazine);
            Console.ReadLine();
        }

        private static void RansomNoteV4(string[] args)
        {
            Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));

            string[] tokens_m = Console.ReadLine().Split(' ');
            // int m = Convert.ToInt32(tokens_m[0]);
            // int n = Convert.ToInt32(tokens_m[1]);

            string[] magazine = Console.ReadLine().Split(' ');
            string[] ransom = Console.ReadLine().Split(' ');
            var wList = new List<string>();

            Array.Sort(ransom);
            Array.Sort(magazine);

            var exceptions = magazine.Except(ransom);

            var m2 = magazine.Where(m => !exceptions.Contains(m)).ToArray();



            var canUseMagazine = "Yes";

            for (int x = 0; x < ransom.Length; x++)
            {
                var word = ransom[x];
                if (wList.Contains(word))
                    continue;

                if (Array.BinarySearch(m2, word) == -1)
                {
                    canUseMagazine = "No";
                    break;
                }

                wList.Add(word);
                if (ransom.Count(w => w.Equals(word)) > m2.Count(w => w.Equals(word)))
                {
                    canUseMagazine = "No";
                    break;
                }

            }

            Console.WriteLine(canUseMagazine);
            Console.ReadLine();
        }



        private static void RansomNote(string[] args)
        {
            Console.SetIn(new StreamReader(Console.OpenStandardInput(16384)));

            string[] tokens_m = Console.ReadLine().Split(' ');
            // int m = Convert.ToInt32(tokens_m[0]);
            // int n = Convert.ToInt32(tokens_m[1]);

            string[] magazine = Console.ReadLine().Split(' ');
            string[] ransom = Console.ReadLine().Split(' ');

            Array.Sort(ransom);
            Array.Sort(magazine);
            var wList = new List<string>();

            var canUseMagazine = "Yes";
            var exceptions = magazine.Except(ransom);

            for (int x = 0; x < ransom.Length; x++)
            {
                var word = ransom[x];
                if (wList.Contains(word) || exceptions.Contains(word))
                    continue;
                if (Array.BinarySearch(magazine, word) == -1)
                {
                    canUseMagazine = "No";
                    break;
                }

                wList.Add(word);
                if (ransom.Count(w => w.Equals(word)) > magazine.Count(w => w.Equals(word)))
                {
                    canUseMagazine = "No";
                    break;
                }

            }
            Console.WriteLine(canUseMagazine);
            Console.ReadLine();
        }



        private static void RansomNoteV2(string[] args)
        {
            Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));
            string[] tokens_m = Console.ReadLine().Split(' ');
            int m = Convert.ToInt32(tokens_m[0]);
            int n = Convert.ToInt32(tokens_m[1]);

            string[] magazine = Console.ReadLine().Split(' ');
            string[] ransom = Console.ReadLine().Split(' ');

            var ransomDict = new Dictionary<string, int>();
            var magDict = new Dictionary<string, int>();
            var canUseMagazine = "Yes";
            foreach (var word in ransom)
            {

                if (ransomDict.ContainsKey(word))
                    continue;

                var wordCount = ransom.Count(w => w.Equals(word));
                ransomDict.Add(word, wordCount);
            }
            foreach (var word in magazine)
            {
                if (!ransom.Contains(word))
                    continue;

                if (magDict.ContainsKey(word))
                    continue;

                var wordCount = magazine.Count(w => w.Equals(word));
                magDict.Add(word, wordCount);
            }

            foreach (var key in ransomDict.Keys)
            {
                var rCount = ransomDict[key];
                if (!magDict.ContainsKey(key) || magDict[key] < rCount)
                {
                    canUseMagazine = "No";
                    break;
                }
            }

            Console.WriteLine(canUseMagazine);
            Console.ReadLine();
        }



    }
}
