//Name:         Roger Silva Santos Aguiar
//Function:     This class extracts the vocabulary from a collection of documents.
//Initial date: February 19, 2021
//Last update:  February 20, 2021

using System;
using System.Linq;
using System.Collections.Generic;
public class VocabularyExtractor
{
    private string vocabularyLayout;
    private string collection;

    private string file;
    
    public string Collection { get => collection; set => collection = value; }
    
    public VocabularyExtractor(string collection)
    {
        Collection = collection;
    }
    public List<string> ExtractVocabulary()
    {        
        string[] vocabulary = ConvertDocumentToArrayOfWords(Collection);
        IEnumerable<string> extractedVocabulary = vocabulary.Distinct();
        return extractedVocabulary.ToList();                
    }

    public string[] ConvertDocumentToArrayOfWords(string file)
    {
        char[] separators = {' ', ',', '.', '|', '-', '_', 
                             '{', '}', '(', ')', '[', ']', 
                             '?', '!', ':', ';', '=', '+', 
                             '/', '*', '"', '@', '#', '$', '%', '&'};
        return file.Split(separators, StringSplitOptions.RemoveEmptyEntries);
    }

    public string DisplayVocabulary(List<string> vocabulary)
    {
        vocabularyLayout += "Index\tTerms\n";

        for(int indexVocabulary = 0; indexVocabulary < vocabulary.Count; indexVocabulary++)            
            vocabularyLayout += $"{(indexVocabulary + 1).ToString()}\t{vocabulary[indexVocabulary]}\n"; 

        return vocabularyLayout;
    }
}