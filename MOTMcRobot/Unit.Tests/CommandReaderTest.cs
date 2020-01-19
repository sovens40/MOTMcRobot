﻿using Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Unit.Tests
{
    [TestClass]
    public class CommandReaderTest
    {
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ExceptionHandledIfFileIsNotFound()
        {
            new CommandReader(@"..\..\Fixtures\CommandFileDoesntExist.txt").Read();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ExceptionHandledIfFileEmpty(){
            new CommandReader(@"..\..\Fixtures\CommandFileEmpty.txt").Read();          
        }
    }
}
