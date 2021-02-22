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
    private string txtFile;
    string txtFilePath;

    public TextFileReader(string txtFile)
    {
        TxtFile = txtFile;
    }
    
    public string ReadTextFile()
    {               
        string lineOfFile;
               
        System.IO.StreamReader file = new System.IO.StreamReader(TxtFile);

        for(int textFileLineCounter = 0; (lineOfFile = file.ReadLine()) != null; textFileLineCounter++)
        {
            this.textFile += lineOfFile; 
            textFileLineCounter++;
        }       
        return this.textFile.ToUpper();
    }

    public string GetTextFileLayout() => $"\n{TxtFilePath}\n{this.textFile}";

    public string TxtFile { get => txtFile; set => txtFile = value; }
    public string TxtFilePath { get => txtFilePath; set => txtFilePath = value; }
}