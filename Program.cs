//Name:         Roger Silva Santos Aguiar
//Function:     To implement Information Retrieval algorithms
//Initial date: February 19, 2021
//Last update:  February 20, 2021
using System;
using System.IO;
using System.Collections.Generic;

namespace TR_IDF
{
    class Program
    {
        static void Main(string[] args)
        {      
            InverseDocumentFrequency inverse = new InverseDocumentFrequency(); 
            VocabularyExtractor vocabularyExtractor = new VocabularyExtractor();

            string[] collectionOfDocuments = Directory.GetFiles(@"TextFiles");            
            string documentsFromCollection = inverse.GetDocumentsFromCollection(collectionOfDocuments);
            List<string> vocabulary = vocabularyExtractor.ExtractVocabulary(documentsFromCollection);
            int [,] matrixOfInverseFrequency = inverse.GetInverseDocumentFrequency(vocabulary, collectionOfDocuments);            
            double [,] termFrequenceMatrix = inverse.GetTermFrequencyMatrix(matrixOfInverseFrequency);
            Console.WriteLine(inverse.GetLayoutOfMatrix(vocabulary, matrixOfInverseFrequency, termFrequenceMatrix));                          
        }        
       
    }
}
