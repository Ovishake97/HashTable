using System;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
             Console.WriteLine("Enter the sentence");
            string sentence = Console.ReadLine();
            string[] splitMessage = sentence.Split(" ");
            MyMapNode<string, int> mapNode = new MyMapNode<string, int>(splitMessage.Length);
            
            for (int i = 0; i < splitMessage.Length; i++) {
                mapNode.Add(splitMessage[i],i);
            }
            Console.WriteLine("Enter the word where you require to know the frequency");
            string word = Console.ReadLine();
            mapNode.GetFrequency(word);
            Console.WriteLine("Enter the word that you want to remove");
            string remove = Console.ReadLine();
            mapNode.Remove(remove);
            mapNode.Display();
            Console.ReadLine();
        }
    }
}
