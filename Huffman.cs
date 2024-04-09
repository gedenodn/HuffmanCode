using System;
namespace Haffman
{
    public class Huffman
    {
        public static Dictionary<char, string> Encode(string input)
        {
            Dictionary<char, int> frequencies = new Dictionary<char, int>();
            foreach (char c in input)
            {
                if (!frequencies.ContainsKey(c))
                    frequencies[c] = 0;
                frequencies[c]++;
            }

            PriorityQueue<Node> queue = new PriorityQueue<Node>((a, b) => a.Frequency.CompareTo(b.Frequency));
            foreach (var kvp in frequencies)
            {
                queue.Enqueue(new Node { Symbol = kvp.Key, Frequency = kvp.Value });
            }

            while (queue.Count > 1)
            {
                Node left = queue.Dequeue();
                Node right = queue.Dequeue();
                Node parent = new Node { Symbol = '\0', Frequency = left.Frequency + right.Frequency, Left = left, Right = right };
                queue.Enqueue(parent);
            }

            Node root = queue.Dequeue();
            Dictionary<char, string> codes = new Dictionary<char, string>();
            EncodeHelper(root, "", codes);
            return codes;
        }

        private static void EncodeHelper(Node node, string prefix, Dictionary<char, string> codes)
        {
            if (node == null)
                return;
            if (node.Left == null && node.Right == null)
            {
                codes[node.Symbol] = prefix;
            }
            else
            {
                EncodeHelper(node.Left, prefix + "0", codes);
                EncodeHelper(node.Right, prefix + "1", codes);
            }
        }
    }

}