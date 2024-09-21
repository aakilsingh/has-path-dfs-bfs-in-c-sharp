namespace has_path
{
    //Write a method, hasPath, that takes in an object representing the adjacency list of a directed acyclic graph and two nodes (src, dst).
    //The method should return a boolean indicating whether or not there exists a directed path between the source and destination nodes.

    public class Program
    {
        // solution with breadth first search
        public static Boolean hasPathBFS(Dictionary<string, List<string>> graph, string src, string dst)
        {

            Queue<string> queue = new Queue<string>();
            queue.Enqueue(src);

            while(queue.Count != 0)
            {
                var node = queue.Dequeue();
                if(node == dst) // checks if the current node is the destination
                {
                    return true;
                }

                foreach(string neighbour in graph.GetValueOrDefault(node))
                {
                    queue.Enqueue(neighbour);
                }
            }
            return false;
        }

        // solution with iterative depth first search
        public static Boolean hasPathDFS(Dictionary<string, List<string>> graph, string src, string dst)
        {
            Stack<string> stack = new Stack<string>();
            stack.Push(src);

            while (stack.Count != 0) {
                var node = stack.Pop();
                if(node == dst) // checks if current node is the destination
                {
                    return true ;
                }
                
                foreach(string neighbour in graph.GetValueOrDefault(node))
                {
                    stack.Push(neighbour);
                }
            
            }

            return false;
        }

        // solution with recursive depth first search
        public static Boolean hasPathRecDFS(Dictionary<string, List<string>> graph, string src, string dst)
        {
            
            if(src == dst)
            {
                return true; 
            }

            foreach(string neighbour in graph.GetValueOrDefault(src))
            {
                if (hasPathRecDFS(graph, neighbour, dst))
                {
                    return true;
                }
            }
            return false;
        }

        static void Main(string[] args)
        {
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>
            {
                {"f",new List<string>{"g","i" } },
                {"g", new List<string>{"h"} },
                {"h",new List<string>{} },
                {"i",new List<string>{"g","k"} },
                {"j",new List<string>{"i"} },
                {"k",new List<string>{} }

            };
            Console.WriteLine(hasPathBFS(graph, "f", "k"));
            Console.WriteLine(hasPathRecDFS(graph, "f", "k"));
            Console.WriteLine(hasPathDFS(graph, "f", "k"));

        }
    }
}
