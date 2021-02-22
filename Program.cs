//Name:         Roger Silva Santos Aguiar
//Function:     To implement Information Retrieval algorithms
//Initial date: February 19, 2021
//Last update:  February 21, 2021
using System;
using System.IO;
using System.Collections.Generic;

namespace TR_IDF
{
    class Program
    {
        static void Main(string[] args)
        {   
            string[] collectionOfDocuments = Directory.GetFiles(@"TextFiles");               
            InverseDocumentFrequency inverse = new InverseDocumentFrequency(collectionOfDocuments);                           
            inverse.GetDocumentsFromCollection();
            
            VocabularyExtractor vocabularyExtractor = new VocabularyExtractor(inverse.DocumentsFromCollection);
            vocabularyExtractor.ExtractVocabulary();            
            int [,] matrixOfInverseFrequency = inverse.GetInverseDocumentFrequency();                     
            double [,] termFrequenceMatrix = inverse.GetTermFrequencyMatrix();
            Console.WriteLine(inverse.GetLayoutOfMatrix());                          
        }        
    }
}
