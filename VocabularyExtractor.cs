//Name:         Roger Silva Santos Aguiar
//Function:     This class extracts the vocabulary from a collection of documents.
//Initial date: February 19, 2021
//Last update:  February 21, 2021

using System;
using System.Linq;
using System.Collections.Generic;
public class VocabularyExtractor
{
    private string vocabularyLayout;
    private string collection;
    private string [] file = null;
    private List<string> vocabulary = new List<string>();
            
    public VocabularyExtractor(string collection)
    {
        Collection = collection;
    }
    public List<string> ExtractVocabulary()
    {        
        ConvertDocumentToArrayOfWords();        
        IEnumerable<string> extractedVocabulary = File.Distinct();
        Vocabulary = extractedVocabulary.ToList();    
        return Vocabulary;            
    }

    public string[] ConvertDocumentToArrayOfWords()
    {
        char[] separators = {' ', ',', '.', '|', '-', '_', 
                             '{', '}', '(', ')', '[', ']', 
                             '?', '!', ':', ';', '=', '+', 
                             '/', '*', '"', '@', '#', '$', '%', '&'};
        File = Collection.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        return File;
    }

    public string DisplayVocabulary()
    {
        vocabularyLayout += "Index\tTerms\n";

        for(int indexVocabulary = 0; indexVocabulary < Vocabulary.Count; indexVocabulary++)            
            vocabularyLayout += $"{(indexVocabulary + 1).ToString()}\t{Vocabulary[indexVocabulary]}\n"; 

        return vocabularyLayout;
    }
    public string Collection { get => collection; set => collection = value; }
    public List<string> Vocabulary { get => vocabulary; set => vocabulary = value; }
    public string[] File { get => file; set => file = value; }
}