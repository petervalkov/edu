namespace _04._Salaries
{
	using System;
	using System.Collections.Generic;

	public class Program
	{
		static List<int>[] employeesHierarchy;
		static long[] salaries;
		static long totalSalary;

		public static void Main(string[] args)
		{
			int employeesCount = int.Parse(Console.ReadLine());
			employeesHierarchy = new List<int>[employeesCount];
			salaries = new long[employeesCount];

			for (int i = 0; i < employeesHierarchy.Length; i++)
			{
				employeesHierarchy[i] = new List<int>();
				string managedEmployees = Console.ReadLine().Trim();

				for (int j = 0; j < managedEmployees.Length; j++)
				{
					if (managedEmployees[j] == 'Y')
					{
						employeesHierarchy[i].Add(j);
					}
				}
			}

			for (int i = 0; i < employeesHierarchy.Length; i++)
			{
				totalSalary += CalculateSalary(i);
			}

			Console.WriteLine(totalSalary);
		}

		private static long CalculateSalary(int employeeId)
		{
			if (salaries[employeeId] != 0)
			{
				return salaries[employeeId];
			}

			if (employeesHierarchy[employeeId].Count == 0)
			{
				salaries[employeeId] = 1;
				return salaries[employeeId];
			}

			for (int i = 0; i < employeesHierarchy[employeeId].Count; i++)
			{
				salaries[employeeId] += CalculateSalary(employeesHierarchy[employeeId][i]);
			}

			return salaries[employeeId];
		}
	}
}
