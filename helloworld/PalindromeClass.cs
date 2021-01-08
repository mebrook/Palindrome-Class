using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace palindromes

{
    class PalindromeClass
    {
        //The following main function takes in an array of letters and returns a list of words containing that letter within our input paragraph.
        //It also contains some default function arguments for the sake of testing our class functions.
        public static void Main(string[] args)
        {
            PalindromeClass palindromeClass = new PalindromeClass();
            if (args.Length == 0)
            {
                Console.Write("Please provide a letter");
            }
            else
            {
                int i = 0;
                foreach(string arg in args)
                {
                    Console.WriteLine("This is "+ i +"letter: "  + arg);

                    Console.Write("\nIs the word dad a palindrome?: " + palindromeClass.isPalindromeWord("dad"));
                    Console.Write("\nNumber of palindrome words in the input paragraph is: " + palindromeClass.PalindromeWordCounter(arg));
                    Console.WriteLine("\nNumber of palindrome sentences: " + palindromeClass.PalindromeSentenceCounter(arg));
                    Console.WriteLine("\nThese are the unique words with count 1 in the input paragraph: \n");
                    foreach (KeyValuePair<string, int> pair in palindromeClass.UniqueWordFinder(arg))
                    {
                        Console.Write(pair + "\n");
                    };

                    foreach (string word in palindromeClass.WordsWithLetter(arg, "I am Margaret! Do geese see god? no on no on no on! dad"))
                    {
                        Console.Write("\nThe word " + word + "contains the letter " + arg + "\n");
                    }
                    i += 1;
                }
                

            }
            
        }
        //The following function takes in a string and returns true if the string is a palindrome and false otherwise.
        //First it checks to see if the first and last letter of the input string are the same. If this is false, the function returns false.
        //It also initially checks if the input string is null or empty, in which case the function returns false.
        //It will then check if the input string is only one letter (ie "I" or "a"), in which case the function returns true.
        //Lastly, it runs the palindrome finding algorithm as follows:
            //the function iterates through the first half of the string, checking if the current letter is equal to its counterpart on the second
            //half of the string( ie it checks if the third letter and the third letter from the end of the string are the same. If this is true for all
            //of the letters in the input string, then the function returns true.

        public Boolean isPalindromeWord(string inputString)
        {

            bool isPalindrome = false;

            if (string.IsNullOrEmpty(inputString) || inputString.ToCharArray()[0] != inputString.ToCharArray()[inputString.Length - 1])
            {
                return isPalindrome;
            }
            else if (inputString.Length == 1)
            {
                isPalindrome = true;
                return isPalindrome;
            }
            else
            {
                for (int i = 0; i < (inputString.Length / 2); i++) 
                {
                    if (inputString.ToCharArray()[i] == inputString.ToCharArray()[inputString.Length - i - 1])
                    {
                        isPalindrome = true;
                    }
                    else { return isPalindrome; }



                }
                return isPalindrome;
            }
        }
        //The following function takes in a paragraph and returns the number of palindrome words within the provided paragraph.
        //It requires the paragraph be provided as a string.
        //First, it splits the paragraph into an array of words. Next it iterates through each word and does the following:
            //1) remove punctuation and any character that is not a letter
            //2) Passes the word to the the isPalindromeWord function above. If this returns true, then our counter
            //is increased by 1.
        public int PalindromeWordCounter(string inputParagraph)
        {
            int numPalindromeWords = 0;


            string[] paragraphWords = inputParagraph.Split(' ');

            foreach (string word in paragraphWords)
            {
                string strippedWord = Regex.Replace(word, @"[^\w\s]", "");
                if (isPalindromeWord(strippedWord.ToLower()))
                {
                    numPalindromeWords += 1;
                }

            }
            return numPalindromeWords;
        }
        //The following function takes in a paragraph and returns the number of palindrome sentences within the provided paragraph.
        //It requires the paragraph be provided as a string.
        //First, it splits the paragraph into an array of sentences. Next it iterates through each sentence and does the following:
        //1) remove punctuation and any character that is not a letter
        //2)concatenate the words in each sentence (ie strip the spaces in the sentence)
        //3) Passes this new word to the the isPalindromeWord function above. If this returns true, then our counter
        //is increased by 1.

        public int PalindromeSentenceCounter(string inputParagraph)
        {
            int numPalindromeSentences = 0;

            inputParagraph = inputParagraph.Replace("?", ".");

            string[] paragraphSentences = Regex.Split(inputParagraph, @"(?<=[\.!\?])\s+");


            foreach (string sentence in paragraphSentences)
            {
                string newSentence = Regex.Replace(sentence, @"[^\w\s]", "");
                string concatSentence = newSentence.Replace(" ", "").ToLower();
                if (isPalindromeWord(concatSentence))
                {
                    numPalindromeSentences += 1;
                }
            }

            return numPalindromeSentences;
        }
        //The following function takes in a paragraph and returns key value pairs of the unique words within that paragraph and their word count.
        //The function uses a dictionary to keep track of each word in the paragraph and its running word count.
        //First it splits the paragraph into an array of words. Next it iterates through each word and does the following:
            //1)Removes punctuation
            //2)checks the dictionary to see if the word has already been added. If it has not been added, then the word is added to the dictionary with a count
            //of 1. Otherwise it is added to the dictionary with an increased count by 1.

        //Lastly the function returns all of the key value pairs in the dictionary with a value of 1.
        public List<KeyValuePair<string, int>> UniqueWordFinder(string inputParagraph)
        {

            string[] words = inputParagraph.Split(' ');
            var wordKeeper = new Dictionary<string, int>();

            foreach (string word in words)
            {
                string strippedWord = Regex.Replace(word, @"[^\w\s]", "");


                if(wordKeeper.ContainsKey(strippedWord))
                {
                    wordKeeper[strippedWord] += 1;
                } else
                {
                    wordKeeper.Add(strippedWord, 1);
                }
            }

            List<KeyValuePair<string, int>> uniqueWords = wordKeeper.Where(x => x.Value == 1).ToList();

            return uniqueWords;

        }
        //The following function takes in a letter and a paragraph and returns a list of all of the words in the paragraph containing that letter.
        //First it splits the paragraph into an array of words. Then it iterates through this array and checks to see if each word contains the input
        //letter. If the word contains the letter, then it is added to a separate array, which is then returned after we finish iterating through the array.
        public List<string> WordsWithLetter(string letter, string inputParagraph)
        {
            string[] paragraphWords = inputParagraph.Split(' ');
            List<string> wordsWithLetter = new List<string>();
            foreach (string word in paragraphWords)
            {
                string strippedWord = Regex.Replace(word, @"[^\w\s]", "");
                if (strippedWord.Contains(letter))
                {
                    wordsWithLetter.Add(strippedWord);
                }

            }

            return wordsWithLetter;
        }
    }
}
