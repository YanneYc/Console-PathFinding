using System;
using System.Collections.Generic;
using System.Text;

namespace Console_PathFinding
{
	class AStar
	{
		public static bool Search(int size,Node start , Node end , ref List<Node> path) 
		{
			MinHeap<Node> Open = new MinHeap<Node>(size);
			HashSet<Node> Close = new HashSet<Node>();
			Open.Insert(start);
			while(Open.Count() > 0) 
			{
				Node first = Open.RemoveFirst();
				Close.Add(first);
				if(first == end)
				{
				path = RetracePath(end);
					return true;
				}
				foreach(Node neighbour in Node.GetNeighbours(first)) 
				{
					if(!neighbour.walkable || Close.Contains(neighbour)) 
					{
						continue;
					}
					int cost = first.Hcost + Node.GetDistance(neighbour, end);
					if(cost < first.Hcost || !Close.Contains(neighbour)) 
					{
						neighbour.Hcost = cost;
						neighbour.Gcost = Node.GetDistance(neighbour, end);
						neighbour.parent = first;
					}
					if (!Open.Contains(neighbour)) 
					{
						Open.Insert(neighbour);
					}
					else 
					{
						Open.SiftUp(neighbour);
					}
					
				}

			}
			return false;
		}

	

		public static List<Node> RetracePath(Node target) 
		{
			List<Node> path = new List<Node>();
			Node current = target;
			while (current != null) 
			{
				path.Add(current);
				current = current.parent;
			}
			path.Reverse();
			return path;
		}
	}
}
