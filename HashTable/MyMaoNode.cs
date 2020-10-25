﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
    public class MyMapNode<K, V>
    {/// As asked, a class is created with key value pairs
     /// A linked list is declared and initialised to hold the key value pairs
        public struct KeyValue<k, v>
        {
            public k Key { get; set; }
            public v Value { get; set; }
        }
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items;

        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }
        /// Following method generates hashcodes
        /// and finds out the index of the searched words
        /// The method returns only the absolute values of the index
        private int GetArrayPosition(K key)
        {
            int hash = key.GetHashCode();
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }

        /// Linked List to store and return the items
        private LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }
        /// Linked list method to return the value against a key
        /// by calling GetArrayPosition method

        public V Get(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                    return item.Value;
            }

            return default(V);
        }
        /// Method to find the frequency of a word
        public void GetFrequency(K key) { 
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            int count = 0;
            foreach (KeyValue<K, V> item in linkedList) {
                if (item.Value.Equals(Get(key)))
                {
                    count++;
                }
            }
            Console.WriteLine("Occurence of the word " + Get(key) + " is " + count);
        }

        /// Adding to the linked list
        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>()
            { Key = key, Value = value };
            linkedList.AddLast(item);
            Console.WriteLine(item.Key + " " + item.Value);
        }
        /// Method to display the elements
        public void Display()
        {
            foreach (var linkedList in items)
            {
                if (linkedList != null)
                    foreach (var element in linkedList)
                    {
                        string res = element.ToString();
                        if (res != null)
                            Console.WriteLine(element.Key + " " + element.Value);
                    }
            }
        }
    }
}