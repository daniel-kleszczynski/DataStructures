using DataStructures.UI.ViewModels.Base;
using NUnit.Framework;

namespace DataStructures.UiTests.ViewModels.Base
{
    [TestFixture]
    public class BindableBaseTests
    {
        [Test]
        public void SetProperty_NewValueIsNullOldValueIsNull_PropertyChangedIsNotRaised()
        {
            //Arrange
            int? oldValue = null;
            int? newValue = null;

            var viewModel = new TestViewModel { Number = oldValue };
            bool isPropertyChangedCalled = false;

            viewModel.PropertyChanged += (s, e) =>
            {
                isPropertyChangedCalled = true;
            };

            //Act
            viewModel.Number = newValue;

            //Assert            
            Assert.That(isPropertyChangedCalled, Is.False);
        }

        [Test]
        public void SetProperty_NewValueIsNotNullOldValueIsNull_PropertyChangedIsRaisedWithPropertyName()
        {
            //Arrange
            int? oldValue = null;
            const int NewValue = 7;

            var viewModel = new TestViewModel { Number = oldValue };
            string expectedPropertyName = nameof(viewModel.Number);
            string receivedPropertyName = string.Empty;

            viewModel.PropertyChanged += (s, e) =>
            {
                receivedPropertyName = e.PropertyName;
            };

            //Act
            viewModel.Number = NewValue;

            //Assert            
            Assert.That(receivedPropertyName, Is.EqualTo(expectedPropertyName));
        }

        [Test]
        public void SetProperty_NewValueIsNullOldValueIsNotNull_PropertyChangedIsRaisedWithPropertyName()
        {
            //Arrange
            const int OldValue = 4;
            int? newValue = null;

            var viewModel = new TestViewModel { Number = OldValue };
            string expectedPropertyName = nameof(viewModel.Number);
            string receivedPropertyName = string.Empty;

            viewModel.PropertyChanged += (s, e) =>
            {
                receivedPropertyName = e.PropertyName;
            };

            //Act
            viewModel.Number = newValue;

            //Assert            
            Assert.That(receivedPropertyName, Is.EqualTo(expectedPropertyName));
        }

        [Test]
        public void SetProperty_NewValueIsDifferentNoNulls_PropertyChangedIsRaisedWithPropertyName()
        {
            //Arrange
            const int OldValue = 4;
            const int NewValue = 7;

            var viewModel = new TestViewModel { Number = OldValue };
            string expectedPropertyName = nameof(viewModel.Number);
            string receivedPropertyName = string.Empty;

            viewModel.PropertyChanged += (s, e) =>
            {
                receivedPropertyName = e.PropertyName;
            };

            //Act
            viewModel.Number = NewValue;

            //Assert            
            Assert.That(receivedPropertyName, Is.EqualTo(expectedPropertyName));
        }

        [Test]
        public void SetProperty_NewValueIsTheSameNoNulls_PropertyChangedIsNotRaised()
        {
            const int SameValueToSet = 7;
            var viewModel = new TestViewModel { Number = SameValueToSet };
            bool isPropertyChangedRaised = false;

            viewModel.PropertyChanged += (s, e) =>
            {
                isPropertyChangedRaised = true;
            };

            //Act
            viewModel.Number = SameValueToSet;

            //Assert
            Assert.IsFalse(isPropertyChangedRaised);
        }
    }

    public class TestViewModel : BindableBase
    {
        private int? _number;

        public virtual int? Number
        {
            get { return _number; }
            set { SetProperty(ref _number, value); }
        }
    }
}
