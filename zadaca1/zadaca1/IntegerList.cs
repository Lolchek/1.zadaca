using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    public class IntegerList : IIntegerList
    {
        int number = 0;
        public int[] _internalStorage { get; set; }
        public int size { get; set; }

        public IntegerList()
        {
            _internalStorage = new int[4];
            this.size = 4;
        }
        public IntegerList(int initialSize)
        {
            _internalStorage = new int[initialSize];
            this.size = initialSize;
        }
        public void Add(int item)
        {
            if (this.Count >= this.size)
            {
                this.size *= 2;
                this._internalStorage = new int[this.size];
            }
            this._internalStorage[this.Count] = item;
            number++;

        }

        public bool Remove(int item)
        {
            int j = -1;
            for (int i = 0; i < this.Count; i++)
            {
                if (this._internalStorage[i] == item)
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
                    _internalStorage[i] = 0;
                    return true;
                }
                _internalStorage[i] = _internalStorage[i + 1];

            }
            number--;
            return true;
        }

        public int GetElement(int index)
        {
            if (index < this.size || index >= 0)
            {
                return _internalStorage[index];
            }
            else
                throw new IndexOutOfRangeException();
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < this.size; i++)
            {
                if (this._internalStorage[i] == item)
                    return i;
            }
            return -1;
        }


        public void Clear()
        {
            for (int i = 0; i < this.size; i++)
            {
                this._internalStorage[i] = 0;
            }
            number = 0;
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < this.size; i++)
            {
                if (this._internalStorage[i] == item)
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
                while (this._internalStorage[i] != 0 && i < this.size - 1)
                {
                    number++;
                    i++;
                }*/
                return number;
            }
        }
    }
}