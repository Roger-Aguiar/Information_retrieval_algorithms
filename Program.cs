//Name:         Roger Silva Santos Aguiar
//Function:     To implement Information Retrieval algorithms
//Initial date: February 19, 2021
//Last update:  February 19, 2021
using System;
using System.IO;
using System.Collections.Generic;

namespace TR_IDF
{
    class Program
    {
        static void Main(string[] args)
        {
            string documentCollectionContent = null;
            string[] textFiles = Directory.GetFiles(@"TextFiles");
                                    
            foreach (var textFile in textFiles)
            {
                TextFileReader reader = new TextFileReader();
                string fileText = reader.ReadTextFile(textFile);  
                documentCollectionContent += fileText;                  
            }  

            VocabularyExtractor vocabularyExtractor = new VocabularyExtractor();
            List<string> vocabulary = vocabularyExtractor.ExtractVocabulary(documentCollectionContent);
            Console.WriteLine(vocabularyExtractor.DisplayVocabulary(vocabulary));                     
        }        
       
    }
}
