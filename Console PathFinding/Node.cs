using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Console_PathFinding
{
	public class Node : Items<Node>
	{
		public int Index { get => idx; set => idx = value; }
		int idx;
		public int Gcost;
		public int Hcost;
		public int Fcost { get => Gcost + Hcost; }
		public Node parent;
		public bool walkable;
		public CustomVector2 position;

		public override string ToString()
		{
			return this.position.ToString();
		}
		public Node(int x, int y,bool walkable) 
		{
			this.position = new CustomVector2(x, y);
			this.walkable = walkable;
		}
		public int CompareTo(Node other)
		{
			int compare = Fcost.CompareTo(other.Fcost);
			if (compare == 0)
			{
				compare = Gcost.CompareTo(other.Gcost);
			}
			return -compare;
		}
		public static void SetBlock(Node target) => target.walkable = false;
		public static List<Node> GetNeighbours(Node target) 
		{
			List<Node> neighbours = new List<Node>();
			foreach(var direction in CustomVector2.GetDirections()) 
			{
				if(Grid.NodeMap.ContainsKey(direction + target.position)) 
				{
					neighbours.Add(Grid.NodeMap[direction + target.position]);
				}
			}
			return neighbours;
		}
		public static int GetDistance(Node current , Node target ) 
		{
			int x = (int)Math.Abs(current.position.x - target.position.x);
			int y = (int)Math.Abs(current.position.y - target.position.y);
			
				return x + y;
			
			
		}
	}
}
