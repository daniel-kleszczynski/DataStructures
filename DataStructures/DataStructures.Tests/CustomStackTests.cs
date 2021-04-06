using DataStructures.Lib;
using NUnit.Framework;
using System;
using System.Linq;

namespace DataStructures.Tests
{
    [TestFixture]
    public class CustomStackTests
    {
        const int StackSize = 10;

        private CustomStack<int> _stack;

        [SetUp]
        public void Setup()
        {
            _stack = new CustomStack<int>(StackSize);
        }

        [Test]
        public void IsEmpty_StackIsEmpty_ReturnsTrue()
        {
            Assert.That(_stack.IsEmpty, Is.True);
        }

        [Test]
        public void IsEmpty_StackIsNotEmpty_ReturnsFalse()
        {
            _stack.Push(1);
            Assert.That(_stack.IsEmpty, Is.False);
        }

        [Test]
        [TestCase(0)]
        [TestCase(StackSize - 1)]
        public void IsFull_StackIsNotFull_ReturnsFalse(int pushesCount)
        {
            for (int i = 0; i < pushesCount; i++)
                _stack.Push(i);

            Assert.That(_stack.IsFull, Is.False);
        }

        [Test]
        public void IsFull_StackIsFull_ReturnsTrue()
        {
            for (int i = 0; i < StackSize; i++)
                _stack.Push(i);

            Assert.That(_stack.IsFull, Is.True);
        }

        [Test]
        public void Push_StackIsFull_ThrowsStackOverflowException()
        {
            TestDelegate del = () =>
            {
                for (int i = 0; i < StackSize + 1; i++)
                    _stack.Push(i);
            };

            Assert.Throws<StackOverflowException>(del);
        }

        [Test]
        public void Push_PeekReturnsPushedValue()
        {
            int number = 7;
            _stack.Push(number);
            Assert.That(_stack.Peek(), Is.EqualTo(number));
        }

        [Test]
        public void Peek_StackIsEmpty_ThrowsInvalidOperationException()
        {
            TestDelegate del = () => _stack.Peek();
            Assert.Throws<InvalidOperationException>(del);
        }

        [Test]
        public void Pop_StackIsEmpty_ThrowsInvalidOperationException()
        {
            TestDelegate del = () => _stack.Pop();
            Assert.Throws<InvalidOperationException>(del);
        }

        [Test]
        public void Push_CalledMultipleTimes_PopReturnsPushedValuesInLifoOrder()
        {
            //Arrange
            var inputs = Enumerable.Range(1, StackSize).ToArray();
            var expectedOutputs = inputs.Reverse().ToArray();

            //Act
            for (int i = 0; i < inputs.Length; i++)
                _stack.Push(inputs[i]);

            for (int i = 0; i < expectedOutputs.Length; i++)
            {
                int output = _stack.Pop();

                //Assert
                if (output != expectedOutputs[i])
                    Assert.Fail("Numbers are not poped from the stack in LIFO order");
            }
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void StackConstruction_ZeroOrNegativeSizeParameter_ThrowsArgumentOutOfRangeException(int size)
        {
            TestDelegate del = () => new CustomStack<int>(size);
            Assert.Throws<ArgumentOutOfRangeException>(del);
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3 })]
        public void Clear_IsEmptyReturnsTrue(int[] numbers)
        {
            foreach (int number in numbers)
                _stack.Push(number);

            _stack.Clear();

            Assert.That(_stack.IsEmpty, Is.True);
        }

        [Test]
        [TestCase(new int[] { }, 3)]
        [TestCase(new int[] { 1, 2 }, 3)]
        public void Contains_StackDoesNotContainValue_ReturnsFalse(int[] numbers, int numberToContain)
        {
            foreach (int number in numbers)
                _stack.Push(number);

            Assert.That(_stack.Contains(numberToContain), Is.False);
        }

        [Test]
        public void Contains_StackContainsValue_ReturnsTrue()
        {
            const int numberToContain = 3;
            int[] numbers = new int[] { 1, 2, 3 };

            foreach (int number in numbers)
                _stack.Push(number);

            Assert.That(_stack.Contains(numberToContain), Is.True);
        }
    }
}
