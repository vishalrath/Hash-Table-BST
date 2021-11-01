using System;
using System.Collections.Generic;

namespace HashTableUc1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CountWordFrequency("To be or not to be said ok not to be said ok to");
            Console.ReadLine();
        }
        public static void CountWordFrequency(string sentence)
        {
            MyHashCode<string, int> hashtable = new MyHashCode<string, int>(10);
            string[] words = sentence.Split(' ');
            foreach (string word in words)
            {
                if (hashtable.Exists(word))
                {
                    hashtable.Add(word, hashtable.get(word) + 1);

                }
                else
                {
                    hashtable.Add(word, 1);
                }
            }
            Console.WriteLine("Displaying after add operations");
            hashtable.Display();
            Console.WriteLine("=======================================");
        }
    }
}


