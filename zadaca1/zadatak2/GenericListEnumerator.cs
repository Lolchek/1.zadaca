using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using zadatak2;
namespace zadatak4 
{
    public class GenericListEnumerator<T> : IEnumerator<T>
    {
        public IGenericList<T> _collection { get; set; }
        private int current = 0;
        public GenericListEnumerator(IGenericList<T> collection)
        {
            _collection = collection;
        }
        public T Current
        {
            get {return this._collection.GetElement(current-1); }
        }

        public void Dispose()
        {
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            if (this.current == _collection.Count)
            {
                return false;
            }
            ++current;
            return true;
        }

        public void Reset()
        {
        }
    }
}
