using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
	public abstract class GradeTracker
	{
		public abstract void AddGrade(float grade);
		public abstract GradeStatistics ComputeStatistics();
		public abstract void WriteGrades(TextWriter textWriter);

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				if (String.IsNullOrEmpty(value))
				{
					throw new ArgumentException("Name cannot be null or empty");
				}
				if (_name != value)
				{
					var oldValue = _name;
					_name = value;
					if (NameChanged != null)
					{
						NameChangedEventArgs args = new NameChangedEventArgs();
						args.OldValue = oldValue;
						args.NewValue = value;
						NameChanged(this, args);
					}
				}
			}
		}
		
		

		public event NamedChangedDelegate NameChanged;

		private string _name;
	}
}
