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
    private string[] collectionOfDocuments = null;
    private string inverseFrequencyMatrixLayout = null;    
    private string documentsFromCollection = null;
    int [,] matrixOfFrequency = null;
    List<string> vocabulary = new List<string>();

    public InverseDocumentFrequency(string[] collectionOfDocuments)
    {
        CollectionOfDocuments = collectionOfDocuments;
    }
    public int [,] GetInverseDocumentFrequency()
    {        
        VocabularyExtractor vocabularyExtractor = new VocabularyExtractor(DocumentsFromCollection);
        List<string> vocabulary = vocabularyExtractor.ExtractVocabulary();
        int [,] matrixOfFrequency = new int[vocabulary.Count(),CollectionOfDocuments.Count()];
        
        for (int wordIndex = 0; wordIndex < vocabulary.Count(); wordIndex++)
        {                
            for (int documentNumber = 0; documentNumber < CollectionOfDocuments.Count(); documentNumber++)
            {
                TextFileReader reader = new TextFileReader();                
                string file = reader.ReadTextFile(CollectionOfDocuments[documentNumber]);      
                VocabularyExtractor fileConverter = new VocabularyExtractor(file); 
                                            
                string [] wordsFromDocument = fileConverter.ConvertDocumentToArrayOfWords();       
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

    public void GetDocumentsFromCollection()
    {        
        foreach (var document in CollectionOfDocuments)
        {
            TextFileReader reader = new TextFileReader();
            string file = reader.ReadTextFile(document);  
            DocumentsFromCollection += file;                  
        }          
    }
    public string[] CollectionOfDocuments { get => collectionOfDocuments; set => collectionOfDocuments = value; }
    public string DocumentsFromCollection { get => documentsFromCollection; set => documentsFromCollection = value; }
    public int[,] MatrixOfFrequency { get => matrixOfFrequency; set => matrixOfFrequency = value; }
    public List<string> Vocabulary { get => vocabulary; set => vocabulary = value; }
}