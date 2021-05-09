using DataStructures.UI.ViewModelBase;
using NUnit.Framework;

namespace DataStructures.UiTests.ViewModelBase
{
    [TestFixture]
    public class BindableBaseTests
    {
        [Test]
        public void SetProperty_NewValueIsDifferent_PropertyChangedIsRaisedWithPropertyName()
        {
            //Arrange
            var viewModel = new TestViewModel();
            string expectedPropertyName = nameof(viewModel.Number);
            string receivedPropertyName = string.Empty;

            viewModel.PropertyChanged += (s, e) =>
            {
                receivedPropertyName = e.PropertyName;
            };

            //Act
            viewModel.Number = 7;

            //Assert            
            Assert.That(receivedPropertyName, Is.EqualTo(expectedPropertyName));
        }

        [Test]
        public void SetProperty_NewValueIsTheSame_PropertyChangedIsNotRaised()
        {
            const int SameValueToSet = 7;
            var viewModel = new TestViewModel();
            bool isPropertyChangedRaised = false;

            viewModel.Number = SameValueToSet;

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
        private int _number;

        public virtual int Number
        {
            get { return _number; }
            set { SetProperty(ref _number, value); }
        }

    }
}
