using System;

namespace DataStructures.Lib
{
    public class SingleLinkedList<T>
    {
        private SingleLinkedListNode<T> _firstNode;
        private SingleLinkedListNode<T> _lastNode;

        public int Count { get; private set; }
        public SingleLinkedListNode<T> First => _firstNode;
        public SingleLinkedListNode<T> Last => _lastNode;

        public void AddFirst(T value)
        {
            var newNode = new SingleLinkedListNode<T>(value);
            newNode.Next = _firstNode;
            _firstNode = newNode;

            if (_lastNode == null)
                _lastNode = newNode;

            Count++;
        }

        public void AddLast(T value)
        {
            var newNode = new SingleLinkedListNode<T>(value);

            if (_lastNode == null)
            {
                _lastNode = newNode;
                _firstNode = newNode;
            }
            else
            {
                _lastNode.Next = newNode;
                _lastNode = newNode;
                _lastNode.Next = null;
            }

            Count++;
        }

        public void AddBefore(SingleLinkedListNode<T> selectedNode, SingleLinkedListNode<T> newNode)
        {
            if (selectedNode == null || newNode == null)
                throw new ArgumentNullException();

            if (!ContainsNode(selectedNode))
                throw new InvalidOperationException();

            if (selectedNode == _firstNode)
                _firstNode = newNode;

            SingleLinkedListNode<T> previousNode = FindPreviousNode(selectedNode);

            if (previousNode != null)
                previousNode.Next = newNode;

            newNode.Next = selectedNode;
            Count++;
        }

        public void AddAfter(SingleLinkedListNode<T> selectedNode, SingleLinkedListNode<T> newNode)
        {
            if (selectedNode == null || newNode == null)
                throw new ArgumentNullException();

            if (!ContainsNode(selectedNode))
                throw new InvalidOperationException();

            if (selectedNode.Next != null)
                newNode.Next = selectedNode.Next;

            if (selectedNode == _lastNode)
                _lastNode = newNode;

            selectedNode.Next = newNode;
            Count++;
        }

        public void RemoveFirst()
        {
            if (_firstNode == null)
                throw new InvalidOperationException();

            if (_firstNode == _lastNode)
            {
                _firstNode = null;
                _lastNode = null;
            }
            else
            {
                SingleLinkedListNode<T> newFirstNode = _firstNode.Next;
                _firstNode.Next = null;
                _firstNode = newFirstNode;
            }

            Count--;
        }

        public void RemoveLast()
        {
            if (_firstNode == null)
                throw new InvalidOperationException();

            if (_firstNode == _lastNode)
            {
                _firstNode = null;
                _lastNode = null;
            }
            else
            {
                SingleLinkedListNode<T> newLastNode = FindPreviousNode(_lastNode);
                newLastNode.Next = null;
                _lastNode = newLastNode;
            }

            Count--;
        }

        public void Remove(SingleLinkedListNode<T> selectedNode)
        {
            if (selectedNode == null)
                throw new ArgumentNullException();

            if (!ContainsNode(selectedNode))
                throw new InvalidOperationException();

            if (_firstNode == _lastNode)
            {
                _firstNode = null;
                _lastNode = null;
            }
            else
            {

                SingleLinkedListNode<T> previousNode = FindPreviousNode(selectedNode);

                if (_firstNode == selectedNode)
                    _firstNode = selectedNode.Next;

                if (_lastNode == selectedNode)
                    _lastNode = previousNode;

                if (previousNode != null)
                    previousNode.Next = null;

                selectedNode.Next = null;
            }

            Count--;
        }

        public void Clear()
        {
            _firstNode = null;
            _lastNode = null;
            Count = 0;
        }

        public SingleLinkedListNode<T> Find(T searchedValue)
        {
            if (_firstNode == null)
                return null;

            if (_firstNode.Value.Equals(searchedValue))
                return _firstNode;

            SingleLinkedListNode<T> currentNode = _firstNode;

            while (currentNode.Next != null)
            {
                if (currentNode.Next.Value.Equals(searchedValue))
                    return currentNode.Next;

                currentNode = currentNode.Next;
            }

            return null;
        }

        public SingleLinkedListNode<T> FindLast(T searchedValue)
        {
            if (_firstNode == null)
                return null;

            SingleLinkedListNode<T> currentNode = _firstNode;
            SingleLinkedListNode<T> foundNode = currentNode.Value.Equals(searchedValue) ? currentNode : null;

            while (currentNode.Next != null)
            {
                if (currentNode.Next.Value.Equals(searchedValue))
                    foundNode = currentNode.Next;

                currentNode = currentNode.Next;
            }

            return foundNode;
        }

        public bool Contains(T searchedValue)
        {
            return Find(searchedValue) != null;
        }

        private bool ContainsNode(SingleLinkedListNode<T> node)
        {
            if (_firstNode == null)
                return false;

            if (node == _firstNode)
                return true;

            SingleLinkedListNode<T> currentNode = _firstNode;

            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;

                if (node == currentNode)
                    return true;
            }

            return false;
        }

        private SingleLinkedListNode<T> FindPreviousNode(SingleLinkedListNode<T> selectedNode)
        {
            if (selectedNode == _firstNode)
                return null;

            SingleLinkedListNode<T> currentNode = _firstNode;

            if (currentNode.Next == null)
                return currentNode;

            while (!currentNode.Next.Value.Equals(selectedNode.Value))
                currentNode = currentNode.Next;

            return currentNode;
        }
    }

    public class SingleLinkedListNode<T>
    {
        public SingleLinkedListNode<T> Next { get; set; }
        public T Value { get; }

        public SingleLinkedListNode(T value)
        {
            Value = value;
        }
    }
}
