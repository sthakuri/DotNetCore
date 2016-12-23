using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Solution obj = new Solution();
            Console.WriteLine(obj.solution(1, 8, 3, 2));
            Console.WriteLine(obj.solution(2, 4, 0, 0));
            Console.WriteLine(obj.solution(3, 0, 7, 0));
            Console.WriteLine(obj.solution(9, 1, 9, 7));

            Console.WriteLine(obj.solution(2, 1, 9, 9));
        }
    }
}
