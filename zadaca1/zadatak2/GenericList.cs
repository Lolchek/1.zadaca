using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using zadatak4;


namespace zadatak2
    //default(X) - defaultna vrijednost objekta X.
{
    public class GenericList<X> : IGenericList<X>
    {
        int number = 0;
            public X[] _internalStorage { get; set; }
        public int size { get; set; }

        public GenericList()
        {
            _internalStorage = new X[4];
            this.size = 4;
        }
        public GenericList(int initialSize)
        {
            _internalStorage = new X[initialSize];
            this.size = initialSize;
        }
        public void Add(X item)
        {
            if (this.Count >= this.size)
            {
                this.size *= 2;
                this._internalStorage = new X[this.size];
            }
            this._internalStorage[this.Count] = item;
            number++;
        }

        public bool Remove(X item)
        {
            int j = -1;
            for (int i = 0; !this._internalStorage[i].Equals(default(X)); i++)
            {
                if (this._internalStorage[i].Equals(item))
                {
                    j = i;
                }
            }
            return RemoveAt(j);
        }

        public bool RemoveAt(int index)
        {
            if (this.size < index + 1 || index < 0)
            {
                return false;
            }
            for (int i = index; i < this.Count; i++)
            {
                //kad dodje do zadnjeg ne uzima sljedeceg pa stavlja na mjesto zadnjeg nego postavi 0
                if (i == this.size - 1)
                {
                    number--;
                    _internalStorage[i] = default(X);
                    return true;
                }
                _internalStorage[i] = _internalStorage[i + 1];

            }
            return true;
        }

        public X GetElement(int index)
        {
            if (index < this.Count || index >= 0)
            {
                return _internalStorage[index];
            }
            else
                throw new IndexOutOfRangeException();
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this._internalStorage[i].Equals(item))
                    return i;
            }
            return -1;
        }


        public void Clear()
        {
            for (int i = 0; i < this.Count; i++)
            {
                this._internalStorage[i] = default(X);
            }
            number = 0;
        }

        public bool Contains(X item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this._internalStorage[i].Equals(item))
                    return true;
            }
            return false;
        }



        public int Count
        {
            get
            {
               /* int number = 0;
                int i = 0;
                while (this._internalStorage[i] != null && i < this.size - 1)
                {
                    number++;
                    i++;
                }*/
                return number;
            }
        }

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
