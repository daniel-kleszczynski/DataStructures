using DataStructures.Lib;
using NUnit.Framework;
using System;
using System.Linq;

namespace DataStructures.Tests
{
    [TestFixture]
    public class SingleLinkedListTests
    {
        private SingleLinkedList<int> _list;

        [SetUp]
        public void Setup()
        {
            _list = new SingleLinkedList<int>();
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        public void AddLast_CalledManyTimes_CountReturnsCorrectValue(int[] numbers)
        {
            foreach (int number in numbers)
                _list.AddLast(number);

            Assert.That(_list.Count, Is.EqualTo(numbers.Length));
        }

        [Test]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        public void AddLast_CalledManyTimes_FirstValueIsCorrect(int[] numbers)
        {
            foreach (int number in numbers)
                _list.AddLast(number);

            Assert.That(_list.First.Value, Is.EqualTo(numbers.First()));
        }

        [Test]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        public void AddLast_CalledManyTimes_LastValueIsCorrect(int[] numbers)
        {
            foreach (int number in numbers)
                _list.AddLast(number);

            Assert.That(_list.Last.Value, Is.EqualTo(numbers.Last()));
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        public void AddFirst_CalledManyTimes_CountReturnsCorrectValue(int[] numbers)
        {
            foreach (int number in numbers)
                _list.AddFirst(number);

            Assert.That(_list.Count, Is.EqualTo(numbers.Length));
        }

        [Test]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        public void AddFirst_CalledManyTimes_FirstValueIsCorrect(int[] numbers)
        {
            foreach (int number in numbers)
                _list.AddFirst(number);

            Assert.That(_list.First.Value, Is.EqualTo(numbers.Last()));
        }

        [Test]
        public void AddFirst_EmptyList_LastReturnsAddedNode()
        {
            const int AddedValue = 7;
            
            _list.AddFirst(AddedValue);

            SingleLinkedListNode<int> addedNode = _list.Find(AddedValue);
            Assert.That(_list.Last, Is.EqualTo(addedNode));
        }

        [Test]
        public void First_NothingAdded_ReturnsNull()
        {
            Assert.That(_list.First, Is.Null);
        }

        [Test]
        public void Last_NothingAdded_ReturnsNull()
        {
            Assert.That(_list.Last, Is.Null);
        }

        [Test]
        public void Clear_FirstReturnsNull()
        {
            int[] numbers = new int[] { 1, 2, 3 };

            foreach (int number in numbers)
                _list.AddFirst(number);

            _list.Clear();

            Assert.That(_list.First, Is.Null);
        }

        [Test]
        public void Clear_LastReturnsNull()
        {
            int[] numbers = new int[] { 1, 2, 3 };

            foreach (int number in numbers)
                _list.AddFirst(number);

            _list.Clear();

            Assert.That(_list.Last, Is.Null);
        }

        [Test]
        public void Clear_CountReturnsZero()
        {
            int[] numbers = new int[] { 1, 2, 3 };

            foreach (int number in numbers)
                _list.AddFirst(number);

            _list.Clear();

            Assert.That(_list.Count, Is.EqualTo(0));
        }

        [Test]
        public void Find_LinkedListIsEmpty_ReturnsNull()
        {
            const int SomeValue = 3;
            Assert.That(_list.Find(SomeValue), Is.Null);
        }

        [Test]
        public void Find_LinkedListDoesNotContainValue_ReturnsNull()
        {
            const int ValueNotPresent = 4;
            int[] numbers = new int[] { 1, 2, 3 };

            Assert.That(_list.Find(ValueNotPresent), Is.Null);
        }

        [Test]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 1, 2, 3 }, 2)]
        public void Find_ValueIsPresentOnce_ReturnsNodeWithValue(int[] numbers, int searchedValue)
        {
            foreach (int number in numbers)
                _list.AddLast(number);

            SingleLinkedListNode<int> node = _list.Find(searchedValue);

            Assert.That(node.Value, Is.EqualTo(searchedValue));
        }

        [Test]
        public void Find_ValueIsPresentManyTimes_ReturnsFirstNodeWithValue()
        {
            const int SearchedValue = 2;

            _list.AddLast(1);
            _list.AddLast(SearchedValue);

            SingleLinkedListNode<int> expectedNode = _list.Last;

            _list.AddLast(SearchedValue);

            Assert.That(_list.Find(SearchedValue), Is.EqualTo(expectedNode));
        }

        [Test]
        public void FindLast_LinkedListIsEmpty_ReturnsNull()
        {
            const int SomeValue = 3;
            Assert.That(_list.FindLast(SomeValue), Is.Null);
        }

        [Test]
        public void FindLast_LinkedListDoesNotContainValue_ReturnsNull()
        {
            const int ValueNotPresent = 4;
            int[] numbers = new int[] { 1, 2, 3 };

            Assert.That(_list.FindLast(ValueNotPresent), Is.Null);
        }

        [Test]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 1, 2, 3 }, 2)]
        public void FindLast_ValueIsPresentOnce_ReturnsNodeWithValue(int[] numbers, int searchedValue)
        {
            foreach (int number in numbers)
                _list.AddLast(number);

            SingleLinkedListNode<int> node = _list.FindLast(searchedValue);

            Assert.That(node.Value, Is.EqualTo(searchedValue));
        }

        [Test]
        public void FindLast_ValueIsPresentManyTimes_ReturnsLastNodeWithValue()
        {
            const int SearchedValue = 2;

            _list.AddLast(1);
            _list.AddLast(SearchedValue);
            _list.AddLast(SearchedValue);

            SingleLinkedListNode<int> expectedNode = _list.Last;

            _list.AddLast(3);

            Assert.That(_list.FindLast(SearchedValue), Is.EqualTo(expectedNode));
        }

        [Test]
        [TestCase(new int[] { }, 3)]
        [TestCase(new int[] { 1, 2 }, 3)]
        public void Contains_ListDoesNotContainValue_ReturnsFalse(int[] numbers, int numberToContain)
        {
            foreach (int number in numbers)
                _list.AddLast(number);

            Assert.That(_list.Contains(numberToContain), Is.False);
        }

        [Test]
        [TestCase(new int[] { 4, 5, 7 }, 4)]
        [TestCase(new int[] { 2, 4, 5 }, 4)]
        public void Contains_ListContainsValue_ReturnsTrue(int[] numbers, int numberToContain)
        {
            foreach (int number in numbers)
                _list.AddLast(number);

            Assert.That(_list.Contains(numberToContain), Is.True);
        }

        [Test]
        public void RemoveFirst_ListIsEmpty_ThrowsInvalidOperationException()
        {
            TestDelegate del = () => _list.RemoveFirst();
            Assert.Throws<InvalidOperationException>(del);
        }

        [Test]
        public void RemoveFirst_OnOnlyNode_FirstReturnsNull()
        {
            _list.AddLast(3);
            _list.RemoveFirst();
            Assert.That(_list.First, Is.Null);
        }

        [Test]
        public void RemoveFirst_OnOnlyNode_LastReturnsNull()
        {
            _list.AddLast(3);
            _list.RemoveFirst();
            Assert.That(_list.Last, Is.Null);
        }

        [Test]
        public void RemoveFirst_OnOnlyNode_CountReturnsZero()
        {
            _list.AddLast(3);
            _list.RemoveFirst();
            Assert.That(_list.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveFirst_ManyNodesPresent_FirstReturnsNextNode()
        {
            const int NextValue = 2;

            _list.AddLast(1);
            _list.AddLast(NextValue);

            _list.RemoveFirst();

            Assert.That(_list.First.Value, Is.EqualTo(NextValue));
        }

        [Test]
        //
        public void RemoveFirst_AtLeastTwoNodesInTheList_LastReturnsSameNodeBeforeAndAfter()
        {
            const int SecondValue = 2;

            _list.AddLast(1);
            _list.AddLast(SecondValue);

            _list.RemoveFirst();

            Assert.That(_list.Last.Value, Is.EqualTo(SecondValue));
        }

        [Test]
        public void RemoveLast_ListIsEmpty_ThrowsInvalidOperationException()
        {
            TestDelegate del = () => _list.RemoveLast();
            Assert.Throws<InvalidOperationException>(del);
        }

        [Test]
        public void RemoveLast_OnOnlyNode_FirstReturnsNull()
        {
            _list.AddLast(3);
            _list.RemoveLast();
            Assert.That(_list.First, Is.Null);
        }

        [Test]
        public void RemoveLast_OnOnlyNode_LastReturnsNull()
        {
            _list.AddLast(3);
            _list.RemoveLast();
            Assert.That(_list.Last, Is.Null);
        }

        [Test]
        public void RemoveLast_OnOnlyNode_CountReturnsZero()
        {
            _list.AddLast(3);
            _list.RemoveLast();
            Assert.That(_list.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveLast_AtLeastTwoNodesInList_LastReturnsPreviousNode()
        {
            const int PreviousValue = 2;

            _list.AddLast(PreviousValue);
            _list.AddLast(4);
            _list.RemoveLast();

            Assert.That(_list.Last.Value, Is.EqualTo(PreviousValue));
        }

        [Test]
        public void RemoveLast_AtLeastTwoNodesInList_FirstReturnsSameNodeBeforeAfter()
        {
            const int FirstValue = 5;

            _list.AddLast(FirstValue);
            _list.AddLast(9);

            _list.RemoveLast();

            Assert.That(_list.First.Value, Is.EqualTo(FirstValue));
        }

        [Test]
        public void Remove_SelectedNodeIsNull_ThrowsArgumentNullException()
        {
            SingleLinkedListNode<int> selectedNode = null;
            _list.AddFirst(1);

            TestDelegate del = () => _list.Remove(selectedNode);

            Assert.Throws<ArgumentNullException>(del);
        }

        [Test]
        public void Remove_SelectedNodeIsNotPresentInList_ThrowsInvalidOperationException()
        {
            var selectedNode = new SingleLinkedListNode<int>(2);
            _list.AddFirst(1);

            TestDelegate del = () => _list.Remove(selectedNode);

            Assert.Throws<InvalidOperationException>(del);
        }

        [Test]
        [TestCase(new int[] { 1 }, 0)]
        [TestCase(new int[] { 1, 2, 3 }, 2)]
        public void Remove_AtLeastOneNodeIsPresent_CountReturnsCorrectValue(int[] valuesToAdd, int expectedCount)
        {
            foreach (int value in valuesToAdd)
                _list.AddLast(value);

            _list.Remove(_list.First);

            Assert.That(_list.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Remove_SelectFirstNode_FirstReturnsSecondNode()
        {
            _list.AddLast(1);
            _list.AddLast(2);
            SingleLinkedListNode<int> selectedNode = _list.First;
            SingleLinkedListNode<int> secondNode = _list.Last;

            _list.Remove(selectedNode);

            Assert.That(_list.First, Is.EqualTo(secondNode));
        }

        [Test]
        public void Remove_SelectLastNode_LastReturnsPreviousNode()
        {
            _list.AddLast(1);
            _list.AddLast(2);
            SingleLinkedListNode<int> selectedNode = _list.Last;
            SingleLinkedListNode<int> previousNode = _list.First;

            _list.Remove(selectedNode);

            Assert.That(_list.Last, Is.EqualTo(previousNode));
        }

        [Test]
        public void Remove_OnlyNodeInList_FindByValueReturnsNull()
        {
            const int SelectedValue = 2;
            _list.AddFirst(SelectedValue);
            SingleLinkedListNode<int> selectedNode = _list.Find(SelectedValue);

            _list.Remove(selectedNode);

            Assert.That(_list.Find(SelectedValue), Is.Null);
        }

        [Test]
        public void Remove_SelectNodeWhichIsNotLast_RemovedNodeDoesNotPointToNextNode()
        {
            _list.AddLast(1);
            _list.AddLast(2);
            SingleLinkedListNode<int> nodeToRemove = _list.First;

            _list.Remove(nodeToRemove);

            Assert.That(nodeToRemove.Next, Is.Null);
        }

        [Test]
        public void Remove_SelectNodeWhichIsNotFirst_PreviousNodeDoesNotPointToRemovedNode()
        {
            _list.AddLast(1);
            _list.AddLast(2);
            SingleLinkedListNode<int> nodeToRemove = _list.Last;

            _list.Remove(nodeToRemove);

            Assert.AreNotEqual(nodeToRemove, _list.First.Next);
        }

        [Test]
        public void AddBefore_NullNewNodeParam_ThrowsArgumentNullException()
        {
            _list.AddLast(4);
            SingleLinkedListNode<int> selectedNode = _list.Last;
            SingleLinkedListNode<int> newNode = null;

            TestDelegate del = () => _list.AddBefore(selectedNode, newNode);

            Assert.Throws<ArgumentNullException>(del);
        }

        [Test]
        public void AddBefore_NullSelectedNodeParam_ThrowsArgumentNullException()
        {
            SingleLinkedListNode<int> selectedNode = null;
            SingleLinkedListNode<int> newNode = new SingleLinkedListNode<int>(4);

            _list.AddLast(5);

            TestDelegate del = () => _list.AddBefore(selectedNode, newNode);

            Assert.Throws<ArgumentNullException>(del);
        }

        [Test]
        public void AddBefore_SelectedNodeNotPresentInList_ThrowsInvalidOperationException()
        {
            var notPresentNode = new SingleLinkedListNode<int>(5);
            var newNode = new SingleLinkedListNode<int>(4);

            TestDelegate del = () => _list.AddBefore(notPresentNode, newNode);

            Assert.Throws<InvalidOperationException>(del);
        }
       
        [Test]
        public void AddBefore_AddedNodePointsToSelectedNode()
        {
            const int SelectedValue = 3;
            var newNode = new SingleLinkedListNode<int>(4);

            _list.AddFirst(SelectedValue);
            SingleLinkedListNode<int> selectedNode = _list.Find(SelectedValue);

            _list.AddBefore(selectedNode, newNode);

            Assert.That(newNode.Next, Is.EqualTo(selectedNode));
        }

        [Test]
        public void AddBefore_PreviousNodePointsToAddedNode()
        {
            var newNode = new SingleLinkedListNode<int>(4);
            _list.AddLast(3);
            _list.AddLast(5);

            _list.AddBefore(_list.Last, newNode);

            Assert.That(_list.First.Next, Is.EqualTo(newNode));
        }

        [Test]
        public void AddBefore_SelectFirstNode_FirstReturnsNewNode()
        {
            const int SelectedValue = 1;
            var newNode = new SingleLinkedListNode<int>(4);
            _list.AddLast(SelectedValue);
            SingleLinkedListNode<int> selectedNode = _list.Find(SelectedValue);

            _list.AddBefore(selectedNode, newNode);

            Assert.That(_list.First, Is.EqualTo(newNode));
        }

        [Test]
        public void AddBefore_AtLeastOnNodePresent_CountReturnsCorrectValue()
        {
            const int ExpectedCount = 2;
            const int SelectedValue = 1;
            var newNode = new SingleLinkedListNode<int>(4);

            _list.AddLast(SelectedValue);
            SingleLinkedListNode<int> selectedNode = _list.Find(SelectedValue);

            _list.AddBefore(selectedNode, newNode);

            Assert.That(_list.Count, Is.EqualTo(ExpectedCount));
        }

        [Test]
        public void AddBefore_NotFirstNodeIsSelected_FirstReturnsSameNode()
        {
            _list.AddLast(1);
            _list.AddLast(2);

            var newNode = new SingleLinkedListNode<int>(4);
            SingleLinkedListNode<int> storedFirstNode = _list.First;

            _list.AddBefore(_list.Last, newNode);

            Assert.That(_list.First, Is.EqualTo(storedFirstNode));
        }

        [Test]
        public void AddAfter_NullNewNodeParam_ThrowsArgumentNullException()
        {
            _list.AddLast(4);
            SingleLinkedListNode<int> selectedNode = _list.Last;
            SingleLinkedListNode<int> newNode = null;

            TestDelegate del = () => _list.AddAfter(selectedNode, newNode);

            Assert.Throws<ArgumentNullException>(del);
        }

        [Test]
        public void AddAfter_NullSelectedNodeParam_ThrowsArgumentNullException()
        {
            SingleLinkedListNode<int> selectedNode = null;
            SingleLinkedListNode<int> newNode = new SingleLinkedListNode<int>(4);

            _list.AddLast(5);

            TestDelegate del = () => _list.AddAfter(selectedNode, newNode);

            Assert.Throws<ArgumentNullException>(del);
        }

        [Test]
        public void AddAfter_SelectedNodeNotPresentInList_ThrowsInvalidOperationException()
        {
            var notPresentNode = new SingleLinkedListNode<int>(5);
            var newNode = new SingleLinkedListNode<int>(4);

            TestDelegate del = () => _list.AddAfter(notPresentNode, newNode);

            Assert.Throws<InvalidOperationException>(del);
        }

        [Test]
        public void AddAfter_SelectedNodePointsToAddedNode()
        {
            const int SelectedValue = 3;
            var newNode = new SingleLinkedListNode<int>(4);

            _list.AddFirst(SelectedValue);
            SingleLinkedListNode<int> selectedNode = _list.Find(SelectedValue);

            _list.AddAfter(selectedNode, newNode);

            Assert.That(selectedNode.Next, Is.EqualTo(newNode));
        }

        [Test]
        public void AddAfter_AtLeastTwoNodesInList_AddedNodePointsToNextNode()
        {
            const int SelectedValue = 3;
            const int NextValue = 5;

            _list.AddLast(SelectedValue);
            _list.AddLast(NextValue);

            SingleLinkedListNode<int> newNode = new SingleLinkedListNode<int>(4);
            SingleLinkedListNode<int> selectedNode = _list.Find(SelectedValue);
            SingleLinkedListNode<int> nextNode = _list.Find(NextValue);

            _list.AddAfter(selectedNode, newNode);

            Assert.That(newNode.Next, Is.EqualTo(nextNode));
        }

        [Test]
        public void AddAfter_AtLeastOneNodeInList_CountReturnsCorrectValue()
        {
            const int ExpectedCount = 2;
            const int SelectedValue = 1;
            var newNode = new SingleLinkedListNode<int>(4);

            _list.AddLast(SelectedValue);
            SingleLinkedListNode<int> selectedNode = _list.Find(SelectedValue);

            _list.AddAfter(selectedNode, newNode);

            Assert.That(_list.Count, Is.EqualTo(ExpectedCount));
        }

        [Test]
        public void AddAfter_LastNodeIsSelected_LastReturnsNewNode()
        {
            var newNode = new SingleLinkedListNode<int>(2);
            _list.AddLast(1);

            _list.AddAfter(_list.Last, newNode);

            Assert.That(_list.Last, Is.EqualTo(newNode));
            
        }

        [Test]
        public void AddAfter_NotLastNodeIsSelected_LastReturnsSameNode()
        {
            _list.AddLast(1);
            _list.AddLast(2);

            var newNode = new SingleLinkedListNode<int>(3);
            SingleLinkedListNode<int> storedLastNode = _list.Last;

            _list.AddAfter(_list.First, newNode);

            Assert.That(_list.Last, Is.EqualTo(storedLastNode));
        }
    }
}
