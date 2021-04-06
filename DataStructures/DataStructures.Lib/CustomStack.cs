using System;
using System.Linq;

namespace DataStructures.Lib
{
    public class CustomStack<T>
    {
        private const int EmptyStackPosition = -1;

        private T[] _array;
        private int _currentPosition = EmptyStackPosition;

        public CustomStack(int size)
        {
            if (size < 1)
                throw new ArgumentOutOfRangeException("Stack size must be greater than 0.");

            _array = new T[size];
        }

        public bool IsEmpty => _currentPosition == EmptyStackPosition;

        public bool IsFull => _currentPosition == _array.Length - 1;

        public void Push(T item)
        {
            if (IsFull)
                throw new StackOverflowException();

            _currentPosition++;
            _array[_currentPosition] = item;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            return _array[_currentPosition];
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            T currentValue = _array[_currentPosition];
            _currentPosition--;
            return currentValue;
        }

        public void Clear()
        {
            _currentPosition = EmptyStackPosition;
        }

        public bool Contains(T value)
        {
            return _array.Contains(value);
        }
    }
}
