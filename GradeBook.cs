using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
	public class GradeBook : GradeTracker
	{


		public GradeBook(string name = "There is no name")
		{
			Console.WriteLine("gradebook ctor");
			Name = name;
			_grades = new List<float>();
		}


		public override void AddGrade( float  grade)
		{
			if(grade >= 0 && grade <= 100)
			{
				_grades.Add(grade);
			}
		}

		public bool throwawaylowest { get; set; }

		public override GradeStatistics ComputeStatistics()
		{
			GradeStatistics stats = new GradeStatistics();
			

			float sum = 0f;

			foreach( float grade in _grades)
			{
				stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
				stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
				sum += grade; 
			}

			stats.AverageGrade = sum / _grades.Count;
			return stats;
		}


		public override void WriteGrades(TextWriter textWriter)
		{
			foreach(float grade in _grades)
			{
				textWriter.WriteLine(grade);
			}
			textWriter.WriteLine("*****");
		}


		

		protected List<float> _grades;

		
	}
}
