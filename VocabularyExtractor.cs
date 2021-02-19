//Name:         Roger Silva Santos Aguiar
//Function:     This class extracts the vocabulary from a collection of documents.
//Initial date: February 19, 2021
//Last update:  February 19, 2021

using System;
using System.Linq;
using System.Collections.Generic;
public class VocabularyExtractor
{
    private string vocabularyLayout;

    public List<string> ExtractVocabulary(string collection)
    {
        char[] separators = {' ', ',', '.'};
        string[] vocabulary = collection.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        IEnumerable<string> extractedVocabulary = vocabulary.Distinct();
        return extractedVocabulary.ToList();                
    }

    public string DisplayVocabulary(List<string> vocabulary)
    {
        vocabularyLayout += "Index\tTerms\n";

        for(int indexVocabulary = 0; indexVocabulary < vocabulary.Count; indexVocabulary++)            
            vocabularyLayout += $"{(indexVocabulary + 1).ToString()}\t{vocabulary[indexVocabulary]}\n"; 

        return vocabularyLayout;
    }
}