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

        private void ExtractButton_Clicked(object sender, EventArgs e)
        {
            // Get the input word and trim any leading or trailing whitespace
            string wordInput = InputEntry.Text.Trim();

            // Check if the input word is valid
            if (!IsValidInput(wordInput))
            {
                OutputLabel.Text = "Invalid input. Please enter a single word without spaces.";
                return;
            }

            // Create lists to store the vowels and the word without vowels
            List<char> vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };
            List<char> vowelOutput = new List<char>();
            List<char> withoutVowelOutput = new List<char>();

            // Iterate over each character in the input word
            foreach (char ch in wordInput)
            {
                if (vowels.Contains(ch))
                {
                    // Add the vowel to the vowelOutput list if it hasn't been added before
                    if (!vowelOutput.Contains(ch))
                    {
                        vowelOutput.Add(ch);
                    }
                }
                else
                {
                    // Add non-vowel characters to the withoutVowelOutput list
                    withoutVowelOutput.Add(ch);
                }
            }

            // Display the vowels included in the word
            OutputLabel.Text = "Vowel(s) included in the word:";
            foreach (char vowel in vowelOutput)
            {
                int vowelCount = wordInput.Count(ch => ch == vowel);
                OutputLabel.Text += $"\n- {vowel} ({vowelCount} time(s))";
            }

            // Create a string from the withoutVowelOutput list and display it
            string wordWithoutVowels = new string(withoutVowelOutput.ToArray());
            OutputLabel.Text += $"\n\nWord without vowels: {wordWithoutVowels}";

            // Clear the input entry
            InputEntry.Text = string.Empty;
        }

        // Validate the input word
        private bool IsValidInput(string input)
        {
            // Check if the input word is not null, empty, contains spaces, and consists only of alphabetic characters
            return !string.IsNullOrWhiteSpace(input) && !input.Contains(" ") && input.All(char.IsLetter);
        }
    }
}
