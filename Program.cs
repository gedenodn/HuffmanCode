using Haffman;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter something:");
        string input = Console.ReadLine();
        Dictionary<char, string> codes = Huffman.Encode(input);

        Console.WriteLine("Encoded codes:");
        foreach (var kvp in codes)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
}