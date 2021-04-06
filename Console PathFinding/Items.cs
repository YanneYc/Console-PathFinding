using System;
using System.Collections.Generic;
using System.Text;

namespace Console_PathFinding
{
	public interface Items<T> : IComparable<T> 
	{
		public int Index { get; set; }
	}
}
