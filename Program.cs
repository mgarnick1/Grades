using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.IO;

namespace Grades
{
	class Program
	{

		static void GiveBookAName(ref GradeBook book)
		{
			//book = new GradeBook();
			//book.Name = "The New Gradebook";
		}

		static void IncrementNumber(ref int number)
		{
			number = 42;
		}

		static void Main(string[] args)
		{
			//SpeechSynthesizer synth = new SpeechSynthesizer();
			//synth.Speak("Hello, World");

			//Arrays();
			//Immutable();
			//PassByValueAndRef();
			//string name1 = "Scott";

			//string name2 = "scott";

			//bool areEqual = name1.Equals(name2, StringComparison.CurrentCultureIgnoreCase);
			//Console.WriteLine(areEqual);


			//GradeBook book = new GradeBook("Scotts book");
			//FileStream stream = null;
			//StreamReader reader = null;
			IGradeTracker book = CreateGradeBook();
			//ThrowAwayGradeBook book = new ThrowAwayGradeBook("Scotts book");
			try
			{

				using (FileStream stream = File.Open("grades.txt", FileMode.Open))
				using (StreamReader reader = new StreamReader(stream))
				{


					string line = reader.ReadLine();
					while (line != null)
					{
						float grade = float.Parse(line);
						book.AddGrade(grade);
						line = reader.ReadLine();
					}


					//string[] lines = File.ReadAllLines("grades.txt");
					//foreach (string line in lines)
					//{
					//	float grade = float.Parse(line);
					//	book.AddGrade(grade);
					//}
				}
			}
			catch (FileNotFoundException)
			{
				Console.WriteLine("Could not locate the file grades.txt, please check the name again!");
				return;
			}
			catch (UnauthorizedAccessException)
			{
				Console.WriteLine("Sorry, you do not have access to the file.");
				return;
			}
			//finally
			//{
			//	if(reader != null)
			//	{
			//		reader.Close();
			//	}
			//	if (stream != null)
			//	{
			//		stream.Close();
			//	}
			//}

			//book.AddGrade(91);
			//book.AddGrade(89.1f);
			//book.AddGrade(75);
			book.DoSomething();
			book.WriteGrades(Console.Out);
			try
			{
				//Console.WriteLine("Please enter a name for the book");
				//book.Name = Console.ReadLine();
			}
			catch (ArgumentException)
			{
				Console.WriteLine("Invalid name");
			}

			GradeStatistics stats = book.ComputeStatistics();
			book.NameChanged += OnNameChanged;
			book.NameChanged += OnNameChanged2;
			//book.Name = "Allens book";
			WriteNames(book.Name);
			//int number = 20;
			//WriteBytes(number);

			//WriteBytes(stats.AverageGrade);

			Console.WriteLine(stats.AverageGrade);
			Console.WriteLine(stats.HighestGrade);
			Console.WriteLine(stats.LowestGrade);
			Console.WriteLine("{0} {1}",
			stats.LetterGrade, stats.Description);

			//GradeBook book2 = book;
			//book2.AddGrade(75);
		}

		private static IGradeTracker CreateGradeBook()
		{
			IGradeTracker book = new ThrowAwayGradeBook("Scotts book");
			return book;
		}

		private static void OnNameChanged2(object sender, NameChangedEventArgs args)
		{
			Console.WriteLine("*****");
		}

		private static void OnNameChanged(object sender, NameChangedEventArgs args)
		{
			Console.WriteLine("Name changed from {0} to {1} ",  
				args.OldValue, args.NewValue);
		}

		private static void WriteBytes(int value)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			WriteByteArray(bytes);
		}


		private static void WriteBytes(float value)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			WriteByteArray(bytes);
		}

		private static void WriteByteArray(byte[] bytes)
		{
			foreach (byte b in bytes)
			{
				Console.Write("0x{0:X} ", b);
			}
			Console.WriteLine();
		}

		private static void WriteNames(params string[] names )
		{
			foreach(string name in names)
			{
				Console.WriteLine(name);
			}
		}

		//private static void Arrays()
		//{
		//	float[] grades;
		//	grades = new float[3];



		//	AddGrades(grades);

		//	foreach(float grade in grades) 
		//	{
		//		Console.WriteLine(grade);
		//	}
		//}

		private static void AddGrades(float[] grades)
		{
			if (grades.Length >= 3)
			{
				grades[0] = 91f;
				grades[1] = 89.1f;
				grades[2] = 75f;
			}
		}

		private static void Immutable()
		{
			string name = " Scott ";
			name = name.Trim();
			//Console.WriteLine(name);

			//DateTime date = DateTime.Now;
			DateTime date = new DateTime(2014, 1, 1);

			date = date.AddHours(25);

			Console.WriteLine(date);
			Console.WriteLine(name);
		}

		//private static void PassByValueAndRef()
		//{
		//	GradeBook g1 = new GradeBook();
		//	GradeBook g2 = g1;

		//	GiveBookAName(ref g2);
		//	Console.WriteLine(g2.Name);

		//	g1 = new GradeBook();

		//	//g1.Name = "Mark's book";
		//	//Console.WriteLine(g2.Name);
		//	int x1 = 4;
		//	IncrementNumber(ref x1);
		//	Console.WriteLine(x1);
		//}
	}
}
