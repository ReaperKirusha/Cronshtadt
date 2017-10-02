using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_with_interfaces
{
    class MyTempCollection : IEnumerable
    {
        int Array = 0;

        public IEnumerator GetEnumerator()
        {
            for (int i =0; i < 5; i++) {
                if (Array == 4)
                    yield break;
                yield return Array++;                
            }
        }

        
    }
}
