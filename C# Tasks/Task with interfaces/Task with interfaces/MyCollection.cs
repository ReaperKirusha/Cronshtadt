using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_with_interfaces
{
    class NodeForMyCollection<T>
    {
        public T Value { get; private set; }
        public NodeForMyCollection<T> Previous { get; private set; }
        public NodeForMyCollection<T>  Next { get; private set; }

        public NodeForMyCollection(T objT)
            { Value = objT; Previous = null; Next = null; }

        public NodeForMyCollection(T objT, NodeForMyCollection<T> objT2)
            { Value = objT; Previous = objT2; Next = null;
            objT2.SetNext(this);
            }

        public bool isFirst()
            { if (Previous == null) return true; return false; }

        public bool isLast()
            { if (Next == null) return true; return false; }

        public void SetNext(NodeForMyCollection<T> objNext)
            { Next = objNext; }

        public void SetPrevious(NodeForMyCollection<T> objNext)
        { Previous = objNext; }

        public NodeForMyCollection<T> GetNext()
        {
            return Next;
        }

        

    }
    delegate void DelegateforMyCollection(string message);
    class MyCollection<T> : ICollection<T>
    {
        public event DelegateforMyCollection Added, Removed, Cleared;

        int CountInArray;
        NodeForMyCollection<T> Last, First, Next;
        public MyCollection()
        {
            Last = null;
            First = null;
            Next = null;
            CountInArray = 0;
        }

        public int Count
        {
            get
            {
                return CountInArray;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(T item)
        {
            try
            {
                if (CountInArray == 100)
                    throw new Exception("слышь? Хватит уже");
               if(First == null)
                {
                    First = new NodeForMyCollection<T>(item);
                    Last = First;
                    CountInArray++;
                    Added?.Invoke("добавилось");
                }
                else
                {
                    Last = new NodeForMyCollection<T>(item, Last);
                    CountInArray++;
                    Added("добавилось");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Clear()
        {
            Last = null;
            First = null;          
            CountInArray = 0;
            Cleared("очищено");
        }

        public bool Contains(T item)
        {
           Next = First;
           foreach(T objT in this)
            {
                if (Equals(item, objT))
                {
                    return true;
                }
                        
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {

            Next = First;
            int i = arrayIndex;
            while (Next != null)
            {
                array[i++] = Next.Value;
                Next = Next.GetNext();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Next = First;
            while (Next != null)
            {            
                yield return Next.Value;
                Next = Next.GetNext();
            }
        }

        public bool Remove(T item)
        {
            Next = First;
            while (Next != null)
            {
                if (Next.Value.Equals(item))
                {
                    Next.Previous.SetNext(Next.GetNext());
                    Removed("убрано");
                    break;
                }
                Next = Next.GetNext();
            }
            Removed("не убрано");
            return false;
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
