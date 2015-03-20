using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homewrok_OOP_002_DFClassesTwo.Generic
{
    public class GenericList<T> where T : IComparable
    {
        #region fields
        private const int InitialCapacity = 1;

        private T[] elements;
        private int count = 0;
        private int size;
        #endregion

        #region constructor
        public GenericList()         
            : this(InitialCapacity)
        {

        }
        public GenericList(int size) //constructor with capacity which is given as parameter 
        {
            this.elements = new T[size];
            this.Size = size;
        }

        #endregion

        #region Properties
        public int Count // counter to know when to double the size
        {
            get { return count; }
            //set { this.Count = count; }
        }
        public int Size // size of list
        {
            get { return this.size; }
            private set { this.size = value; }
        }
        #endregion

        #region methods
        /*
         * Implement methods for adding element, accessing element by index, removing element by index, 
         * inserting element at given position, clearing the list, finding element by its value and ToString()
         */
        public void Add(T element)  //adding element
        {
            if (count >= this.elements.Length)
            {
                DoubleSize();
            }
            this.elements[count] = element;
            count++;
        }
        public int IndexOf(T element) // accessing element by index,
        {
            return Array.IndexOf(elements, element);
        }
        public void RemoveAt(int index) // removing element by index
        {
            try
            {
                for (int i = index; i < this.elements.Length - 1; i++)
                {
                    this.elements[i] = this.elements[i + 1];
                }
                this.count--;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException("At method 'RemoveAt(int index)' : Index out of range!");
            }
        }
        public void InserAt(int index, T element) // Inserting element by index
        {
            try
            {
                if (count >= this.elements.Length-1)
                {
                    DoubleSize();
                }

                for (int i = this.count + 1; i  > index; i--)
                {
                    this.elements[i] = this.elements[i - 1];
                }
                this.elements[index] = element;
                this.count++;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException("At method 'InserAt(int index)' : Index out of range!");
            }
        }
        public void Clear()
        {
            this.elements = new T[InitialCapacity];
            this.count = 0;
            this.Size = InitialCapacity;
        } // clearing the list
        public bool FindElement(T element) // finding element by its value
        {
            return this.elements.Contains(element);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.Append(elements[i] + " ");
            }
            return sb.ToString();
        }
        public void DoubleSize() // task 6 implemented in [ADD] and in [InsertAt] methods
        {
            int size = this.elements.Length * 2;
            T[] newElements = new T[size];

            for (int i = 0; i < count; i++)
            {
                newElements[i] = this.elements[i];
            }

            this.elements = newElements;
            this.Size *= 2;
        }
        public T Min() // task 7
        {
            T min = this.elements[0];

            for (int i = 0; i < this.count; i++) 
            {
                if (min.CompareTo(this.elements[i]) > 0) 
                {
                    min = this.elements[i];
                }

            }
            return min;
        }
        public T Max() //task 7
        {
            T max = this.elements[0];
            for (int i = 0; i < this.count; i++)
            {
                if (max.CompareTo(this.elements[i]) <= 0)
                {
                    max = this.elements[i];
                }
            }
            return max;
        }
        #endregion
    }
}
