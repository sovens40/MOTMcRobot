using Domain.Enums;
using Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Unit.Tests
{
    [TestClass]
    public class CommandValidatorTest
    {
        private int gridLength = 5;

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionHandledIfIncorrectStartCommand()
        {
            var command = "MOVE";
            new CommandValidator(gridLength).Place(command);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionHandledIfPlaceCommandHasToManyInstructions()
        {
            var command = "PLACE 0,0,0,NORTH";
            new CommandValidator(gridLength).Place(command);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionHandledIfPlaceCommandHasMissingInstructions()
        {
            var command = "PLACE 0,NORTH";
            new CommandValidator(gridLength).Place(command);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionHandledIfPlaceCommandXIsNotAnumber()
        {
            var command = "PLACE A,0,NORTH";
            new CommandValidator(gridLength).Place(command);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionHandledIfPlaceCommandYIsNotAnumber()
        {
            var command = "PLACE 0,A,NORTH";
            new CommandValidator(gridLength).Place(command);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionHandledIfPlaceCommandFacingIsNotValid()
        {
            var command = "PLACE 0,0,WRONG";
            new CommandValidator(gridLength).Place(command);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionHandledIfPlaceXCommandIsNegativeValue()
        {
            var command = "PLACE -1,0,NORTH";
            new CommandValidator(gridLength).Place(command);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionHandledIfPlaceXCommandIsOutsideOfGrid()
        {
            var command = "PLACE 6,0,NORTH";
            new CommandValidator(gridLength).Place(command);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionHandledIfPlaceYCommandIsNegativeValue()
        {
            var command = "PLACE 0,-1,NORTH";
            new CommandValidator(gridLength).Place(command);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionHandledIfPlaceYCommandIsOutsideOfGrid()
        {
            var command = "PLACE 0,6,NORTH";
            new CommandValidator(gridLength).Place(command);
        }

        [TestMethod]
        public void SuccessfulPlaceCommand()
        {
            var command = "PLACE 0,0,NORTH";
            var robot = new CommandValidator(gridLength).Place(command);

            Assert.AreEqual(0, robot.PositionX);
            Assert.AreEqual(0, robot.PositionY);
            Assert.AreEqual(Facing.NORTH, robot.Facing);
        }
    }
}
