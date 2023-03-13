using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;

namespace GetSystemVariables
{
    class Program
    {

        public static void Main(string[] args)
        {
            //calling method to create text file
            //calling process method
            string variableName = Console.ReadLine();
            StartProcess(variableName);
        }

        //method to create a process
        static void StartProcess(string variableName)
        {
            //creating a process
            //creating instance of process to execute the process
            Process cmdStart = new Process();
            cmdStart.StartInfo.FileName = "cmd.exe";
            cmdStart.StartInfo.Arguments = $"/c echo %{variableName}%";
            string environmentVariable = cmdStart.StartInfo.EnvironmentVariables[variableName];
            cmdStart.Start();
            CreateFile(variableName + ": " + environmentVariable);
            Console.ReadLine();
        }

        //method to create new text file
        static void CreateFile(string data)
        {
            List<string> variableData = new List<string>();
            if (!File.Exists("EnvironmentVariables.txt"))
            {
                File.Create("EnvironmentVariables.txt").Close();
            }
            //read from text file
            string[] variableArray = File.ReadAllLines("EnvironmentVariables.txt");
            for (int i = 0; i < variableArray.Length; i++)
            {
                variableData.Add(variableArray[i]);
            }
            //write to text file
            variableData.Add(data);
            File.WriteAllLines("EnvironmentVariables.txt", variableData);
        }
    }
}