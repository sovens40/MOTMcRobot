using Domain.Enums;
using Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit.Tests
{
    [TestClass]
    public class RobotControllerTest
    {
        private static int gridLength = 5;
        private CommandValidator commandValidator = new CommandValidator(gridLength);
        
        [TestMethod]
        public void CanMoveOneNorth()
        {
            var commands = new List<string> { "PLACE 0,0,NORTH", "MOVE", "REPORT" };
            var robot = new RobotController(gridLength, commandValidator).Execute(commands);
            Assert.AreEqual(1, robot.PositionX);
            Assert.AreEqual(0, robot.PositionY);
            Assert.AreEqual(Facing.NORTH, robot.Facing);
        }

        [TestMethod]
        public void CanMoveOneEast()
        {
            var commands = new List<string> { "PLACE 0,0,EAST", "MOVE", "REPORT" };
            var robot = new RobotController(gridLength, commandValidator).Execute(commands);
            Assert.AreEqual(0, robot.PositionX);
            Assert.AreEqual(1, robot.PositionY);
            Assert.AreEqual(Facing.EAST, robot.Facing);
        }

        [TestMethod]
        public void CanStartNorthAndMoveOneNorthAndOneRight()
        {
            var commands = new List<string> { "PLACE 0,0,NORTH", "MOVE", "RIGHT", "MOVE", "REPORT" };
            var robot = new RobotController(gridLength, commandValidator).Execute(commands);
            Assert.AreEqual(1, robot.PositionX);
            Assert.AreEqual(1, robot.PositionY);
            Assert.AreEqual(Facing.EAST, robot.Facing);
        }

        [TestMethod]
        public void CanStartEastAndMoveOneEASTAndOneLeft()
        {
            var commands = new List<string> { "PLACE 0,0,EAST", "MOVE", "LEFT", "MOVE", "REPORT" };
            var robot = new RobotController(gridLength, commandValidator).Execute(commands);
            Assert.AreEqual(1, robot.PositionX);
            Assert.AreEqual(1, robot.PositionY);
            Assert.AreEqual(Facing.NORTH, robot.Facing);
        }

        [TestMethod]
        public void CanStartSouthAndMoveOneSouthAndOneRight()
        {
            var commands = new List<string> { "PLACE 5,5,SOUTH", "MOVE", "RIGHT", "MOVE", "REPORT" };
            var robot = new RobotController(gridLength, commandValidator).Execute(commands);
            Assert.AreEqual(4, robot.PositionX);
            Assert.AreEqual(4, robot.PositionY);
            Assert.AreEqual(Facing.WEST, robot.Facing);
        }

        [TestMethod]
        public void CanStartWestAndMoveOneWestAndOneLeft()
        {
            var commands = new List<string> { "PLACE 5,5,WEST", "MOVE", "LEFT", "MOVE", "REPORT" };
            var robot = new RobotController(gridLength, commandValidator).Execute(commands);
            Assert.AreEqual(4, robot.PositionX);
            Assert.AreEqual(4, robot.PositionY);
            Assert.AreEqual(Facing.SOUTH, robot.Facing);
        }

        [TestMethod]
        public void FallProtectionNorthBoundary()
        {
            var commands = new List<string> { "PLACE 5,5,WEST", "MOVE", "RIGHT", "MOVE", "REPORT" };
            var robot = new RobotController(gridLength, commandValidator).Execute(commands);
            Assert.AreEqual(5, robot.PositionX);
            Assert.AreEqual(4, robot.PositionY);
            Assert.AreEqual(Facing.NORTH, robot.Facing);
        }

        [TestMethod]
        public void FallProtectionEastBoundary()
        {
            var commands = new List<string> { "PLACE 5,5,SOUTH", "MOVE", "LEFT", "MOVE", "REPORT" };
            var robot = new RobotController(gridLength, commandValidator).Execute(commands);
            Assert.AreEqual(4, robot.PositionX);
            Assert.AreEqual(5, robot.PositionY);
            Assert.AreEqual(Facing.EAST, robot.Facing);
        }

        [TestMethod]
        public void FallProtectionSouthBoundary()
        {
            var commands = new List<string> { "PLACE 0,0,EAST", "MOVE", "RIGHT", "MOVE", "REPORT" };
            var robot = new RobotController(gridLength, commandValidator).Execute(commands);
            Assert.AreEqual(0, robot.PositionX);
            Assert.AreEqual(1, robot.PositionY);
            Assert.AreEqual(Facing.SOUTH, robot.Facing);
        }

        [TestMethod]
        public void FallProtectionWestBoundary()
        {
            var commands = new List<string> { "PLACE 0,0,NORTH", "MOVE", "LEFT", "MOVE", "REPORT" };
            var robot = new RobotController(gridLength, commandValidator).Execute(commands);
            Assert.AreEqual(1, robot.PositionX);
            Assert.AreEqual(0, robot.PositionY);
            Assert.AreEqual(Facing.WEST, robot.Facing);
        }

        [TestMethod]
        public void CanPlaceRobotTwice()
        {
            var commands = new List<string> { "PLACE 0,0,NORTH", "MOVE", "Right", "MOVE", "PLACE 3,3,WEST", "REPORT" };
            var robot = new RobotController(gridLength, commandValidator).Execute(commands);
            Assert.AreEqual(3, robot.PositionX);
            Assert.AreEqual(3, robot.PositionY);
            Assert.AreEqual(Facing.WEST, robot.Facing);
        }
    }
}
