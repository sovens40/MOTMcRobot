using System;
using System.Collections.Generic;
using System.IO;

namespace Infrastructure
{
    public class CommandReader
    {
        private readonly string filePath;

        public CommandReader(string filePath)
        {
            this.filePath = filePath;
        }

        public List<string> Read()
        {
            var lines = File.ReadAllLines(filePath);
            if (lines.Length == 0)
            {
                throw new Exception("Command file is blank");
            }

            var commands = new List<string>();
            //Trim commands of whitespace and ensure they are uppercase
            foreach (var line in lines)
            {
                commands.Add(line.Trim().ToUpper());
            }

            return commands;
        }
    }
}
