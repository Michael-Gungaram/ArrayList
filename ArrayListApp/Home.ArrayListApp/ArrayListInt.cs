using System;
using System.Collections.Generic;

namespace Home.ArrayListApp
{
    public class ArrayListInt
    {
        // Private fields

        int _counter;
        int _arrayCapacity;
        int[] _myArray;

        public ArrayListInt(int ArrayCapacity)
        {
            _arrayCapacity = ArrayCapacity;
            _myArray = new int[_arrayCapacity];
            _counter = 0;
        }

        public int this[int index]
        {
            get
            {
                return _myArray[index];
            }
            set
            {
                _myArray[index] = value;
            }
        }

        /// <summary>
        /// Returns the maximum capacity of an array.
        /// </summary>
        public int Count
        {
            get { return _arrayCapacity; }
        }

        /// <summary>
        /// Get the index xxx of an array.
        /// </summary>
        public int GetIndex
        {
            get { return _counter; }
        }

        /// <summary>
        /// Tests if the array is full.
        /// </summary>
        public bool IsFull
        {
            get { return ( _counter >= _arrayCapacity ); }
        }

        /// <summary>
        /// Adds an element to an array.
        /// </summary>
        /// <param name="value">What we want to add to.</param>
        public void Add(int value)
        {
            // Iteration 1 :

            //if (IsFull)
            //    throw new ArgumentOutOfRangeException("Array cannot contain another argument because it's full.");
            //_myArray[_counter++] = value;

            if( IsFull )
            {
                Array newArray = Array.CreateInstance( typeof(Int32), _arrayCapacity * 2 );
                for (int i = 0; i < _myArray.Length; i++ )
                {
                    newArray.SetValue(_myArray[i], i);
                }
                newArray.SetValue(value, _counter++);
                _myArray = (int[])newArray;
                _arrayCapacity = _myArray.Length;
            }
            else
            {
                _myArray[_counter++] = value;
            }
        }

        /// <summary>
        /// Adds an element to a specified index.
        /// </summary>
        /// <param name="index">The index where we want to add to.</param>
        /// <param name="value">The value that we want to add.</param>
        public void Insert(int index, int value)
        {
            // Iteration 2 : 

            //int[] dump = new int[_arrayCapacity];
            //if( index < 0 || index > _arrayCapacity-1) 
            //    throw new ArgumentOutOfRangeException("Array cannot contain another argument because it's full or there's a problem with index asked.");
            //dump = _myArray;
            //_myArray[index] = value;
            //for ( int i = index+1; i < dump.Length; i++ )
            //{
            //    _myArray[i] = dump[i];
            //}

            //dump = null;

            if ( index < 0  )
                throw new ArgumentOutOfRangeException("Array cannot contain another argument because it's full or there's a problem with index asked.");
            if( IsFull )
            {
                int i = 0;
                Array newArray = Array.CreateInstance(typeof(Int32), _arrayCapacity * 2);
                for (i = 0; i < _myArray.Length; i++ )
                {
                    newArray.SetValue( _myArray[i], i );
                }
                int[] dump = (int[])newArray;
                _myArray = dump;
                _myArray[index] = value;
                _arrayCapacity = _myArray.Length;
                for (i = index + 1; i < dump.Length; i++ )
                {
                    _myArray[i] = dump[i];
                }
            }
        }

        /// <summary>
        /// Removes an element at a specified index.
        /// </summary>
        /// <param name="index">The index where we want to remove a value.</param>
        public void RemoveAt(int index)
        {
            int[] dump = new int[_arrayCapacity];
            if( index < 0 || index >= _arrayCapacity )
                throw new ArgumentException("There's a problem with the index specified.");
            dump = _myArray;
            for (int i = index; i < dump.Length; i++ )
            {
                if( i < dump.Length-1 )
                {
                    _myArray[i] = dump[i+1];
                }
            }
            _arrayCapacity -= 1;
            dump = null;
        }

        /// <summary>
        /// Get the value at an index specified.
        /// </summary>
        /// <param name="index">The index where we want the value.</param>
        /// <returns></returns>
        public int GetItem(int index)
        {
            if (index >= _arrayCapacity || index < 0)
                throw new ArgumentOutOfRangeException("There's a problem with the index asked to get.", "index");
            return _myArray[index];
        }

        /// <summary>
        /// Sets an item as a value at a specified index.
        /// </summary>
        /// <param name="index">The index where we want to set the value.</param>
        /// <param name="value">The new value which will be setted.</param>
        public void SetItem(int index, int value)
        {
            if ( index >= _arrayCapacity || index < 0 )
                throw new ArgumentOutOfRangeException( "There's a problem with the index asked to set.", "index" );
            _myArray[index] = value;
        }

        /// <summary>
        /// Clear the array.
        /// </summary>
        public void Clear()
        {
            for ( int i = 0; i < _myArray.Length; i++ )
            {
                _myArray[i] = 0;
            }
            _counter = 0;
        }
    }
}