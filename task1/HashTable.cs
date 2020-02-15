using System;
using static System.Console;


namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(ReadLine());
            string[] values = (ReadLine().Split(' '));
            var hashTable = new HashTable(number, number);

            foreach (string value in values)
            {
                int x = int.Parse(value);
                hashTable.Insert(x);
            }

            for (int i = 0; i <= hashTable.getMaxIndex(); ++i)
            {
                Write(i + ": ");
                if ((ListNode<int>)hashTable.Get(i) != null)
                {
                    ((ListNode<int>)hashTable.Get(i)).printList();
                }
                WriteLine();
            }
        }
    }

    class HashTable
    {
        //The num to calculate hash-function (N)
        private int number;
        // The max index in Array 
        private int maxIndex;

        //Hash table 
        public Array<ListNode<int>> values;

        // Constructor, set capacity and number
        public HashTable(int capacity, int numberToCalc)
        {
            this.number = numberToCalc;
            values = new Array<ListNode<int>>(capacity);
            maxIndex = 0;
        }

        public void Insert(int newValue)
        {
            // Hash function
            int index = newValue % number;
            // Set max index in hash table
            if (maxIndex < index)
            {
                maxIndex = index;
            }
            // Create new list if null
            if (values.Get(index) == null)
            {
                values.Set(new ListNode<int>(), index);
            }
            // Get list by index
            var list = (ListNode<int>)values.Get(index);
            // Insert new value into the list
            list.Insert(newValue);
            // Set this list in hash table
            values.Set(list, index);
        }

        //Get list from hash table by its index
        public object Get(int index) => values.Get(index);

        //Get max index from hash table
        public int getMaxIndex() => maxIndex;
    }

    class Array<T>
    {
        object[] values; //store the values of the array
        int size = 0; //array size
        int capacity; //current array capacity
        public object[] Values { get => values; set => values = value; }
        public int Size { get => size; set => size = value; }
        public int Capacity { get => capacity; set => capacity = value; }

        public Array(int capacity)
        {
            Values = new object[capacity];
            this.Capacity = capacity;
        }

        public void Insert(int newValue)
        {
            if (Size < Capacity)
            {
                Values[Size] = newValue;
                Size++;
            }
            else
            {
                // Copy elements to a new array
                for (int i = 0; i < Size; i++)
                {
                    (new object[Capacity])[i] = Values[i];
                }
                (new object[Capacity])[Size] = newValue;
                Values = (new object[Capacity]);
                Size++;
            }
        }
        //Insert new value to the position defined by index
        public void Insert(int newValue, int index)
        {
            if (Size >= Capacity)
            {
                for (int i = 0; i < Size; i++)
                {
                    (new object[Capacity])[i] = Values;
                }
                Values = (new object[Capacity]);
            }
            if (index < Capacity)
            {
                for (int i = Capacity - 1; i > index; --i)
                {
                    Values[i] = Values[i - 1];
                }
                Values[index] = newValue;
                Size++;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        //Get the element of the array
        public object Get(int index) // Index of the element into array
        {
            if (index >= Capacity)
            {
                throw new IndexOutOfRangeException();
            }
            return Values[index]; 
        }
        public void Set(T value, int index)
        {
            if (index >= Capacity)
            {
                throw new IndexOutOfRangeException();
            }
            Values[index] = value;
        }
        //Get array size
        public int getSize() => this.Size;
        //Get array capacity
        public int getCapacity() => this.Capacity;
    }

    class ListNode<T>
    {
        // The first value of the list 
        private ListNode firstValue;
        // The last value of the list 
        private ListNode lastValue;

         ListNode FirstValue { get => firstValue; set => firstValue = value; }
         ListNode LastValue { get => lastValue; set => lastValue = value; }

        public void Insert(int newValue)
        {
            ListNode list = new ListNode
            {
                Value = newValue
            };
            if (FirstValue == null)
            {
                FirstValue = list;
                LastValue = list;
            }
            else
            {
                LastValue.next = list;
                LastValue = list;
            }
        }

        // Print all elements of the list 
        public void printList()
        {
            ListNode t = FirstValue;
            while (t != null)
            {
                Write(t.Value + " ");
                t = t.next;
            }
        }

    }

    class ListNode
    {
        private int value;
        public ListNode next; //null or next element
        public int Value { get => value; set => this.value = value; }
        public void Insert(int newValue) => Value = newValue;

    }

}
