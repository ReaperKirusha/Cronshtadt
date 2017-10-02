
#include <iostream>
#include <cstdlib> // для system
using namespace std;

int* Func_merge(int first[], int second[]) {

	List<T> ReturnList = new List<T>();
	int maxi = first.Count;
	int maxj = second.Count;
	T elementi, elementj;
	int i = 0, j = 0;
	while (i < maxi || j < maxj)
	{


		if (i < maxi && j < maxj)
		{


			elementi = first.ElementAt(i);
			elementj = second.ElementAt(j);
			if ((elementi.CompareTo(elementj) < 0))
			{
				ReturnList.Add(elementi);
				i++;
			}
			else
			{
				ReturnList.Add(elementj);
				j++;
			}
		}
		else
		{
			if (i < maxi)
			{
				ReturnList.Add(first.ElementAt(i));
				i++;
			}
			else
			{

				ReturnList.Add(second.ElementAt(j));
				j++;
			}
		}
	}
	return ReturnList;
}

 int* mergesort(int main[])
{
	int last = main.Count - 1;
	if (last < 1)
	{
		return main;
	}
	int mid = last / 2;
	List<T> firstlist = new List<T>();
	List<T> secondlist = new List<T>();
	for (int i = 0; i <= mid; i++)
	{
		firstlist.Add(main.ElementAt(i));
	}
	for (int i = mid + 1; i < last + 1; i++)
	{
		secondlist.Add(main.ElementAt(i));
	}
	firstlist = mergesort(firstlist);
	secondlist = mergesort(secondlist);
	return Func_merge(firstlist, secondlist);

}
 
 int main() {
	 return 1;
 }