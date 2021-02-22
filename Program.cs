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
            string[] collectionOfDocuments = Directory.GetFiles(@"TextFiles");               
            InverseDocumentFrequency inverse = new InverseDocumentFrequency(collectionOfDocuments);                           
            inverse.GetDocumentsFromCollection();
            
            VocabularyExtractor vocabularyExtractor = new VocabularyExtractor(inverse.DocumentsFromCollection);
            vocabularyExtractor.ExtractVocabulary();
            Console.WriteLine(vocabularyExtractor.DisplayVocabulary(vocabularyExtractor.Vocabulary));
            int [,] matrixOfInverseFrequency = inverse.GetInverseDocumentFrequency();    
            Console.WriteLine("The end");        
            //double [,] termFrequenceMatrix = inverse.GetTermFrequencyMatrix(matrixOfInverseFrequency);
            //Console.WriteLine(inverse.GetLayoutOfMatrix(vocabulary, matrixOfInverseFrequency, termFrequenceMatrix));                          
        }        
       
    }
}
