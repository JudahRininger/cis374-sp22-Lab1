using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DSA.DataStructures.Trees;

namespace Lab1
{
    class Program
    {
        private static List<Double> avgInsertionTimes;
        private static List<Double> avgLookupTimes;
        private static List<Double> avgRemoveTimes;
        private static List<Double> avgHeight;
        private static int MAX;

        static void Main(string[] args)
        {
            avgInsertionTimes = new List<Double>();
            avgLookupTimes = new List<Double>();
            avgRemoveTimes = new List<Double>();
            avgHeight = new List<Double>();
            MAX = 10000000;

            var intKeyValuePairs = new List<KeyValuePair<int, int>>();

            for (int i = 0; i < MAX; i++)
            {
                intKeyValuePairs.Add(new KeyValuePair<int, int>(i, i + 42));
            }

            // Only one:
            //var KeyValueMap = new DictionaryKeyValueMap<int, int>();
            //var KeyValueMap = new BinarySearchTreeKeyValueMap<int, int>();
            //var KeyValueMap = new AVLTreeKeyValueMap<int, int>();
            var KeyValueMap = new RedBlackTreeKeyValueMap<int, int>();

            // Only one:
            //Console.WriteLine("Hash Table");
            //Console.WriteLine("BST");
            //Console.WriteLine("AVL");
            Console.WriteLine("Red-Black");

            Console.WriteLine("Ordered:");
            for (int c = 0; c < 10; c++)
            {
                // Only one:
                //KeyValueMap = new DictionaryKeyValueMap<int, int>();
                //KeyValueMap = new BinarySearchTreeKeyValueMap<int, int>();
                //KeyValueMap = new AVLTreeKeyValueMap<int, int>();
                KeyValueMap = new RedBlackTreeKeyValueMap<int, int>();

                //CreateKeyValueMap<int, int>(KeyValueMap, intKeyValuePairs);
            }
            //Console.Write("InsertionTime - ");
            //Console.WriteLine(Queryable.Average(avgInsertionTimes.AsQueryable()));
            //Console.Write("LookupTime - ");
            //Console.WriteLine(Queryable.Average(avgLookupTimes.AsQueryable()));
            //Console.Write("RemoveTime - ");
            //Console.WriteLine(Queryable.Average(avgRemoveTimes.AsQueryable()));
            //Console.Write("Height -  ");
            //Console.WriteLine(Queryable.Average(avgHeight.AsQueryable()));

            Console.WriteLine("Unordered:");
            avgInsertionTimes = new List<Double>();
            avgLookupTimes = new List<Double>();
            avgRemoveTimes = new List<Double>();
            avgHeight = new List<Double>();
            for (int c = 0; c < 10; c++)
            {
                intKeyValuePairs.Shuffle();
                // Only one:
                //KeyValueMap = new DictionaryKeyValueMap<int, int>();
                //KeyValueMap = new BinarySearchTreeKeyValueMap<int, int>();
                //KeyValueMap = new AVLTreeKeyValueMap<int, int>();
                KeyValueMap = new RedBlackTreeKeyValueMap<int, int>();

                CreateKeyValueMap<int, int>(KeyValueMap, intKeyValuePairs);
            }
            Console.Write("InsertionTime - ");
            Console.WriteLine(Queryable.Average(avgInsertionTimes.AsQueryable()));
            Console.Write("LookupTime - ");
            Console.WriteLine(Queryable.Average(avgLookupTimes.AsQueryable()));
            Console.Write("RemoveTime - ");
            Console.WriteLine(Queryable.Average(avgRemoveTimes.AsQueryable()));
            Console.Write("Height -  ");
            Console.WriteLine(Queryable.Average(avgHeight.AsQueryable()));
        }


        public static void CreateKeyValueMap<TKey, TValue>(
                IKeyValueMap<TKey,TValue> keyValueMap,
                List<KeyValuePair<TKey, TValue>> keyValuePairs )
        {
            Stopwatch stopwatch = new Stopwatch();
            Stopwatch stopwatch2 = new Stopwatch();
            Stopwatch stopwatch3 = new Stopwatch();

            stopwatch.Start();
            foreach( var kvp in keyValuePairs)
            {
                keyValueMap.Add(kvp.Key, kvp.Value);
            }
            stopwatch.Stop();
            avgHeight.Add(keyValueMap.Height);
            stopwatch2.Start();
            foreach (var kvp in keyValuePairs)
            {
                keyValueMap.Get(kvp.Key);
            }
            stopwatch2.Stop();
            stopwatch3.Start();
            foreach (var kvp in keyValuePairs)
            {
                keyValueMap.Remove(kvp.Key);
            }
            stopwatch3.Stop();


            avgInsertionTimes.Add(stopwatch.Elapsed.TotalSeconds);
            //Console.WriteLine(stopwatch.Elapsed.TotalSeconds);
            avgLookupTimes.Add(stopwatch2.Elapsed.TotalSeconds);
            avgRemoveTimes.Add(stopwatch3.Elapsed.TotalSeconds);
            //Console.WriteLine(stopwatch.Elapsed.TotalSeconds);
            //Console.WriteLine(keyValueMap.Height);

        }


        public static void QueryKeyValueMap<TKey, TValue>(
                IKeyValueMap<TKey, TValue> keyValueMap,
                List<KeyValuePair<TKey, TValue>> keyValuePairs)
        {
           
        }

        public static void RemoveKeyValueMap<TKey, TValue>(
                IKeyValueMap<TKey, TValue> keyValueMap,
                List<KeyValuePair<TKey, TValue>> keyValuePairs)
        {
            
        }

        //... Relic of an idiotic time when I didn't realize that the DictionaryKeyValueMap was a thing :(

        //public static void HashtableTester(List<KeyValuePair<int, int>> intKeyValuePairs)
        //{
        //    var keyValueMap = new Hashtable();
        //    Stopwatch stopwatch = new Stopwatch();
        //    Stopwatch stopwatch2 = new Stopwatch();
        //    Stopwatch stopwatch3 = new Stopwatch();

        //    for (int c = 0; c < 10; c++)
        //    {
        //        stopwatch.Reset();
        //        stopwatch2.Reset();
        //        stopwatch3.Reset();
        //        stopwatch.Start();
        //        foreach (var kvp in intKeyValuePairs)
        //        {
        //            keyValueMap.Add(kvp.Key, kvp.Value);
        //        }
        //        stopwatch.Stop();
        //        stopwatch2.Start();
        //        foreach (var kvp in intKeyValuePairs)
        //        {
        //            var helloMrCaseyHowAreYou = keyValueMap[kvp.Key];
        //        }
        //        stopwatch2.Stop();
        //        stopwatch3.Start();
        //        foreach (var kvp in intKeyValuePairs)
        //        {
        //            keyValueMap.Remove(kvp.Key);
        //        }
        //        stopwatch3.Stop();
        //        avgInsertionTimes.Add(stopwatch.Elapsed.TotalSeconds);
        //        avgLookupTimes.Add(stopwatch2.Elapsed.TotalSeconds);
        //        avgRemoveTimes.Add(stopwatch3.Elapsed.TotalSeconds);
        //    }
        //    Console.Write("Average Insertion Time: ");
        //    Console.WriteLine(Queryable.Average(avgInsertionTimes.AsQueryable()));
        //    Console.Write("Average Lookup Time: ");
        //    Console.WriteLine(Queryable.Average(avgLookupTimes.AsQueryable()));
        //    Console.Write("Average Remove Time: ");
        //    Console.WriteLine(Queryable.Average(avgRemoveTimes.AsQueryable()));

        //}
    }
}
