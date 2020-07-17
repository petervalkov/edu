namespace _02._Searching
{
	using System;
	using System.Linq;

	public class Program
	{
		public static void Main()
		{
			int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int elementToFind = int.Parse(Console.ReadLine());

			for (int i = 0; i < arr.Length; i++)
			{
				if (arr[i] == elementToFind)
				{
					Console.WriteLine(i);
					return;
				}
			}

			Console.WriteLine(-1);
		}
	}
}
