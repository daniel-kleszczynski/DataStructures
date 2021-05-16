using DataStructures.UI.Command;
using NUnit.Framework;
using System;

namespace DataStructures.UiTests.Command
{
    [TestFixture]
    public class RelayCommandTests
    {
        [Test]
        public void CanExecute_ExecuteDelegateIsNull_ReturnsFalse()
        {
            //Arrange
            Action<object> execute = null;
            Func<object, bool> canExecute = (o) => true;
            RelayCommand command = new RelayCommand(execute, canExecute);

            //Act
            bool result = command.CanExecute(null);

            //Assert
            Assert.That(result, Is.False);
;        }

        [Test]
        public void CanExecute_CanExecuteDelegateIsNull_ReturnsTrue()
        {
            //Arrange
            Action<object> execute = (o) => { };
            Func<object, bool> canExecute = null;
            RelayCommand command = new RelayCommand(execute, canExecute);

            //Act
            bool result = command.CanExecute(null);

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanExecute_CanExecuteDelegateReturnsFalse_ReturnsFalse()
        {
            //Arrange
            Action<object> execute = (o) => { };
            Func<object, bool> canExecute = (o) => false;
            RelayCommand command = new RelayCommand(execute, canExecute);

            //Act
            bool result = command.CanExecute(null);

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void CanExecute_CanExecuteDelegateReturnsTrue_ReturnsTrue()
        {
            //Arrange
            Action<object> execute = (o) => { };
            Func<object, bool> canExecute = (o) => true;
            RelayCommand command = new RelayCommand(execute, canExecute);

            //Act
            bool result = command.CanExecute(null);

            //Assert
            Assert.That(result, Is.True);
        }
    }
}
