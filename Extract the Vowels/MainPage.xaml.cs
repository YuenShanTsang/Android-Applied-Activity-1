using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Extract_the_Vowels
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void AnalyzeButton_Clicked(object sender, EventArgs e)
        {
            string inputWord = InputEntry.Text.ToLower();

            List<char> vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };
            List<char> vowelList = new List<char>();
            List<char> nonVowelList = new List<char>();

            foreach (char c in inputWord)
            {
                if (vowels.Contains(c))
                {
                    if (!vowelList.Contains(c))
                    {
                        vowelList.Add(c);
                    }
                }
                else
                {
                    nonVowelList.Add(c);
                }
            }

            ResultLabel.Text = "Vowels in the word:";
            foreach (char vowel in vowelList)
            {
                int vowelCount = inputWord.Count(c => c == vowel);
                ResultLabel.Text += $"\n- {vowel} ({vowelCount} occurrence(s))";
            }

            string wordWithoutVowels = new string(nonVowelList.ToArray());
            ResultLabel.Text += $"\n\nWord without vowels: {wordWithoutVowels}";
        }
    }
}