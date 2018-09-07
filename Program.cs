using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
	class Program
	{
		static void Main(string[] args)
		{
			GradeBook book = new GradeBook();
			book.AddGrade(91);
			book.AddGrade(89.1f);
			book.AddGrade(75);

			GradeStatistics stats = book.ComputeStatistics();
			Console.WriteLine(stats.AverageGrade);
			Console.WriteLine(stats.HighestGrade);
			Console.WriteLine(stats.LowestGrade);

			//GradeBook book2 = book;
			//book2.AddGrade(75);
		}
	}
}
