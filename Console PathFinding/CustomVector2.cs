using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Console_PathFinding
{
	public struct CustomVector2 : IEquatable<CustomVector2>
	{
		public int x;
		public int y;
		public static CustomVector2 Up = new CustomVector2(0, 1);
		public static CustomVector2 Down = new CustomVector2(0, -1);
		public static CustomVector2 Left = new CustomVector2(-1, 0);
		public static CustomVector2 right = new CustomVector2(1, 0);
		public static CustomVector2 UpRight = new CustomVector2(1, 1);
		public static CustomVector2 UpLeft = new CustomVector2(-1, 1);
		public static CustomVector2 DownRight = new CustomVector2(1, -1);
		public static CustomVector2 DownLeft = new CustomVector2(-1, -1);
		public static CustomVector2[] Directions = new CustomVector2[] { Up, Down, Left, right };
		public static CustomVector2[] Directions8 = new CustomVector2[] { Up, Down, Left, right, UpLeft, UpRight, DownLeft, DownRight };
		
		public CustomVector2(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
		public CustomVector2(CustomVector2 v)
		{
			this.x = v.x;
			this.y = v.y;
		}
		public override string ToString()
		{
			return $"<{x},{y}>";
		}
		public override bool Equals(object obj)
		{
			if (!(obj is CustomVector2)) return false;
			return Equals(obj);
		}
		public bool Equals(CustomVector2 other)
		{
			return other.x == this.x && other.y == this.y;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(x, y);
		}

		public static bool operator ==(CustomVector2 left, CustomVector2 right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(CustomVector2 left, CustomVector2 right)
		{
			return !(left == right);
		}
		public static CustomVector2 operator +(CustomVector2 left, CustomVector2 right)
		{
			return new CustomVector2(left.x + right.x, left.y + right.y);
		}
		public static CustomVector2 operator -(CustomVector2 left, CustomVector2 right)
		{
			return new CustomVector2(left.x - right.x, left.y - right.y);
		}
		public static CustomVector2[] GetDirections()
		{	
			return Directions;

		}
	}
}
