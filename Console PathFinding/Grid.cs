using System;
using System.Collections.Generic;
using System.Text;

namespace Console_PathFinding
{
	public class Grid
	{
		int x;
		int y;
		public  List<Node> path = new List<Node>();
		public static Dictionary<CustomVector2, Node> NodeMap = new Dictionary<CustomVector2, Node>();
		public static Dictionary<int, CustomVector2> NodeId = new Dictionary<int, CustomVector2>();
		int[][] _map;
		public Grid (int x) 
		{
			this.x = x;
			this.y = x;
		}
		public Grid(int[][] map) 
		{
			_map = map;	
			for(int i = 0; i < map.Length; i++) 
			{
				for(int j = 0; j < map[i].Length; j++) 
				{
					bool block = map[i][j] == 0 ? true : false;
					SetNode(i, j, block);
					
				}
			}
		}
		public int GetSize() 
		{
			return NodeMap.Count;
		}
		public void GenarateGrid() 
		{
			int count = 0;
			for(int i = 0; i < x; i++) 
			{
				for(int j = 0; j < y; j++)
				{
					SetNode(i, j,true);
					count++;


				}
			}
		}

		private static void SetNode(int i, int j,bool block)
		{
			Node temp = new Node(i, j, block);
			NodeMap.Add(temp.position, temp);
		}

		public void Print()
		{
			for (int i = 0; i < _map.Length; i++) 
			{
				for(int j = 0; j < _map[i].Length; j++) 
				{
					if(path.Contains(NodeMap[new CustomVector2(i, j)])) 
					{
						Console.Write("[X]");
					}
					else if(!NodeMap[new CustomVector2(i, j)].walkable) 
					{
						Console.Write("[0]");
					}
					else 
					{
						Console.Write("[ ]");
					}
					
				}
				Console.WriteLine();
			}
		}
	}
}
