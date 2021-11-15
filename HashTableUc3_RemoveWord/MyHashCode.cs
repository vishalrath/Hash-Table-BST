using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableUc3_RemoveWord
{
    public struct KeyValue<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }
    }
    class MyHashCode<K, V>
    {
        /// <summary>
        /// using hashtable count frequency
        /// </summary>
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyHashCode{K, V}"/> class.
        /// </summary>
        public MyHashCode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];

        }
        /// <summary>
        /// Gets the array position.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        protected int getArrayPosition(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }
        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public V get(K key)
        {
            int position = getArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedlist = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedlist)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;

                }
            }
            return default(V);
        }
        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(K key, V value)
        {
            int position = getArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedlist = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };
            if (linkedlist.Count != 0)
            {
                foreach (KeyValue<K, V> item1 in linkedlist)
                {
                    if (item1.Key.Equals(key))
                    {
                        Remove1(key);
                        break;
                    }
                }

            }
            linkedlist.AddLast(item);
        }
        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        public void Remove1(K key)
        {
            int position = getArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedlist = GetLinkedList(position);
            bool itemFound = false;
            KeyValue<K, V> founditem = default(KeyValue<K, V>);
            foreach (KeyValue<K, V> item in linkedlist)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    founditem = item;
                }
            }
            if (itemFound)
            {
                linkedlist.Remove(founditem);
            }

        }

        /// <summary>
        /// this method removes Specific Word
        /// </summary>
        /// <param name="word1"></param>
        public void removeSpecificWord(K word1)
        {
            int position = getArrayPosition(word1);
            LinkedList<KeyValue<K, V>> linkedlist1 = GetLinkedList(position);
            KeyValue<K, V> founditem = default(KeyValue<K, V>);
            bool itemFound = false;
            foreach (var linkedlist in items)
            {
                if (linkedlist != null)
                {
                    foreach (var element in linkedlist)
                    {
                        if (element.Key.Equals(word1))
                        {
                            itemFound = true;
                            founditem = element;

                        }

                    }

                }

            }
            if (itemFound)
            {
                linkedlist1.Remove(founditem);
            }

        }

        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedlist = items[position];
            if (linkedlist == null)
            {
                linkedlist = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedlist;

            }
            return linkedlist;

        }

        public bool Exists(K key)
        {
            int position = getArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedlist = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedlist)
            {
                if (item.Key.Equals(key))
                {
                    return true;

                }
            }
            return false;
        }

        public void Display()
        {
            foreach (var linkedlist in items)
            {
                if (linkedlist != null)
                {
                    foreach (var element in linkedlist)
                    {
                        string res = element.ToString();
                        if (res != null)
                            Console.WriteLine(element.Key + " = " + element.Value);
                    }

                }

            }

        }

    }
}
