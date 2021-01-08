# README
This project hosts the PalindromeClass, which is a class containing various functions surrounding palindromes and unique words within some
given paragraph. 

## Requirements
This PalindromeClass.cs class should be run from the console, requiring the user to provide an array of input letters, as follows(macOS commands): 
```bash
csc PalindromeClass.cs
```
```bash 
mono PalindromeClass.exe a b c
```
## Functions

There are five functions within this class, in addition to the main function. These are as follows: 
* IsPalindromeWord: checks if the given string is a palindrome, returning true or false
* PalindromeWordCounter(string): returns the number of palindrome words in the given string
* PalindromeSentenceCounter(string): returns the number of palindrome sentences in the given string
* UniqueWordFinder(string): returns a list of the unique words and their instance counts in the given string
* WordsWithLetter(string, string): returns a list of all of the words within some given paragraph containing some given string.
