//Name:         Roger Silva Santos Aguiar
//Function:     This class receives text file, read it line by line and returns the one to the method that called.
//Initial date: February 19, 2021
//Last update:  February 19, 2021

using System;
using System.IO;
using System.Text;

public class TextFileReader
{
    private string textFile;

    public string ReadTextFile(string txtFile)
    {               
        string lineOfFile;
               
        System.IO.StreamReader file = new System.IO.StreamReader(txtFile);

        for(int textFileLineCounter = 0; (lineOfFile = file.ReadLine()) != null; textFileLineCounter++)
        {
            textFile += lineOfFile; 
            textFileLineCounter++;
        }       
        return textFile;
    }

    public string GetTextFileLayout(string txtFilePath) => $"\n{txtFilePath}\n{textFile}";
}