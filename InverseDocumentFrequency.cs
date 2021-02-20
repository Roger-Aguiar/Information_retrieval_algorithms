//Name:         Roger Silva Santos Aguiar
//Function:     It makes the inverse document frequency of each term from the vocabulary.
//Initial date: February 19, 2021
//Last update:  February 20, 2021

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

public class InverseDocumentFrequency
{   
    private string inverseFrequencyMatrixLayout = null;
    
    public int [,] GetInverseDocumentFrequency(List<string> vocabulary, string [] collectionOfDocuments)
    {
        int [,] matrixOfFrequency = new int[vocabulary.Count(),collectionOfDocuments.Count()];
        
        for (int wordIndex = 0; wordIndex < vocabulary.Count(); wordIndex++)
        {                
            for (int documentNumber = 0; documentNumber < collectionOfDocuments.Count(); documentNumber++)
            {
                TextFileReader reader = new TextFileReader();
                VocabularyExtractor extractor = new VocabularyExtractor();
                string file = reader.ReadTextFile(collectionOfDocuments[documentNumber]);                                   
                string [] wordsFromDocument = extractor.ConvertDocumentToArrayOfWords(file);       
                var termFrequency = from term in wordsFromDocument
                                    where term == vocabulary[wordIndex]
                                    select term;                       
                matrixOfFrequency[wordIndex, documentNumber] = termFrequency.Count();                                      
            }                
        }    
        return matrixOfFrequency;                              
    }
    
    public double [,] GetTermFrequencyMatrix(int [,] matrixOfFrequency)
    {
        double [,] termFrequencyMatrix = new double [matrixOfFrequency.GetLength(0), matrixOfFrequency.GetLength(1)];

        for(int line = 0; line < termFrequencyMatrix.GetLength(0); line++)
        {
            for(int column = 0; column < termFrequencyMatrix.GetLength(1); column++)
            {
                termFrequencyMatrix[line, column] = Math.Round(1 + Math.Log2(matrixOfFrequency[line, column]), 3);
            }
        }
        return termFrequencyMatrix;
    }

    public string GetLayoutOfMatrix(List<string> vocabulary, int [,] matrix, double [,] termFrequencyMatrix)
    {        
        Console.Write("Index\tTerms\t\t");
     
        for(int numberOfDocument = 0; numberOfDocument < matrix.GetLength(1); numberOfDocument++)
        {
            Console.Write($"Document {(numberOfDocument + 1).ToString()}\t");
        }
     
        for(int column = 0; column < termFrequencyMatrix.GetLength(1); column++)
        {
            Console.Write($"TF {(column + 1).ToString()}\t");
        }
     
        Console.WriteLine();

        for(int line = 0; line < matrix.GetLength(0); line++)
        {        
            Console.Write($"{(line + 1).ToString()}\t{vocabulary[line]}\t\t");    
            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                Console.Write($"{(matrix[line,column]).ToString()}\t\t");
            }

            for(int column = 0; column < termFrequencyMatrix.GetLength(1); column++)
            {
                Console.Write($"{(termFrequencyMatrix[line, column]).ToString()}\t");
            }
            Console.WriteLine();
            
        }
        return inverseFrequencyMatrixLayout;
    }

    public string GetDocumentsFromCollection(string [] collectionOfDocuments)
    {
        string documentsFromCollection = null;

        foreach (var document in collectionOfDocuments)
            {
                TextFileReader reader = new TextFileReader();
                string file = reader.ReadTextFile(document);  
                documentsFromCollection += file;                  
            }  
        return documentsFromCollection;
    }

}