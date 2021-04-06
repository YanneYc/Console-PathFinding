using System;
using System.Collections.Generic;
using System.Text;

namespace Console_PathFinding
{
	class MinHeap<T> where T : Items<T>
	{
		T[] heap;
		int count = 0;

		public int Count() => count;
		public T Peek() => heap[0];
		public bool Contains(T item) => Equals(item, heap[item.Index]); 
		public MinHeap(int size)
		{
			heap = new T[size];
		}
		public void Insert(T item) 
		{
			item.Index = count;
			heap[count] = item;
			SiftUp(item);
			count++;
		}
		public T RemoveFirst() 
		{
     		T first = heap[0];
			count--;
			heap[0] = heap[count];
			heap[0].Index = 0;		
			SiftDown(heap[0]);
			return first;

		}

		public void SiftUp(T item)
		{
			int parent = (item.Index - 1) / 2;
			while(item.Index > 0 && item.CompareTo(heap[parent]) > 0) 
			{
				Swap(item, heap[parent]);
				parent = (item.Index - 1) / 2;		
			}
		}
		public void SiftDown(T item) 
		{
			int left = item.Index * 2 + 1;
			while(left < count) 
			{
				int right = item.Index * 2 + 2;
				int swapIdx = 0;
				if(right < count && heap[left].CompareTo(heap[right]) < 0) 
				{
					swapIdx = right;
				}
				else 
				{
					swapIdx = left;
				}

				if(item.CompareTo(heap[swapIdx]) < 0) 
				{
					Swap(item, heap[swapIdx]);
					left = item.Index * 2 + 1;
				}
				else 
				{
					return;
				}
			}
		}

		private void Swap(T item, T t)
		{
			int holder = item.Index;
			heap[item.Index] = t;
			heap[t.Index] = item;
			item.Index = t.Index;
			t.Index =holder;
		}
	}
}
