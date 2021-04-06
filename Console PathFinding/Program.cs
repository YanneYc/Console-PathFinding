using System;

namespace Console_PathFinding
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] map = new int[][] {
			new int[]{0,0,0,0,1,1,0,0,0,0}
		   ,new int[]{0,0,0,0,1,1,0,0,0,0},
			new int[]{0,0,0,1,0,0,0,0,0,0},
			new int[]{0,0,0,1,0,0,1,0,0,0},
			new int[]{0,0,0,1,0,0,1,0,0,0},
			new int[]{0,0,0,1,1,0,1,0,0,0},
			new int[]{0,1,1,1,1,0,1,0,0,0},
			new int[]{0,0,0,1,0,0,1,0,0,0},
			new int[]{0,0,0,1,0,0,1,0,0,0},
			new int[]{0,0,0,0,0,0,1,0,0,0},
			};
			Grid gird = new Grid(map);
			Console.WriteLine("Map [] = walkable , [1] = block");
			gird.Print();
			Console.WriteLine();
			bool x =AStar.Search(gird.GetSize(),Grid.NodeMap[new CustomVector2(0,0)], Grid.NodeMap[new CustomVector2(0, 9)], ref gird.path);
			Console.WriteLine("[X] = path");
			gird.Print();

		
		}
	}
}
