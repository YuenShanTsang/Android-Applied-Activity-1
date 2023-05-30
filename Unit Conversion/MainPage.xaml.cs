using System;
using Microsoft.Maui.Controls;

namespace Unit_Conversion
{
    public partial class MainPage : ContentPage
    {
        // Arrays to hold the unit options
        private string[] speedUnits = { "Miles per hour", "Kilometers per hour", "Feet per second", "Meters per second" };
        private string[] distanceUnits = { "Miles", "Kilometers", "Feet", "Meters" };

        // Variables to store selected values
        private string selectedCategory;
        private string selectedFromUnit;
        private string selectedToUnit;
        private double inputValue;

        public MainPage()
        {
            InitializeComponent();

            // Add options to the categoryPicker
            categoryPicker.Items.Add("Speed");
            categoryPicker.Items.Add("Distance");

            // Subscribe event handlers to corresponding events
            categoryPicker.SelectedIndexChanged += CategoryPicker_SelectedIndexChanged;
            fromUnitPicker.SelectedIndexChanged += FromUnitPicker_SelectedIndexChanged;
            toUnitPicker.SelectedIndexChanged += ToUnitPicker_SelectedIndexChanged;
            convertButton.Clicked += ConvertButton_Clicked;
        }

        // Event handler for categoryPicker's SelectedIndexChanged event
        private void CategoryPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected category from the categoryPicker and convert it to a string
            selectedCategory = categoryPicker.SelectedItem?.ToString();

            // Set speed units as the item source for fromUnitPicker and toUnitPicker
            if (selectedCategory == "Speed")
            {
                fromUnitPicker.ItemsSource = speedUnits;
                toUnitPicker.ItemsSource = speedUnits;
            }
            // Set distance units as the item source for fromUnitPicker and toUnitPicker
            else if (selectedCategory == "Distance")
            {
                fromUnitPicker.ItemsSource = distanceUnits;
                toUnitPicker.ItemsSource = distanceUnits;
            }
            // Clear item source if no category is selected
            else
            {
                fromUnitPicker.ItemsSource = null;
                toUnitPicker.ItemsSource = null;
            }

            // Reset selected items and clear input and result labels
            fromUnitPicker.SelectedItem = null;
            toUnitPicker.SelectedItem = null;
            inputEntry.Text = string.Empty;
            resultLabel.Text = string.Empty;
        }

        // Event handler for fromUnitPicker's SelectedIndexChanged event
        private void FromUnitPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedFromUnit = fromUnitPicker.SelectedItem?.ToString();
        }

        // Event handler for toUnitPicker's SelectedIndexChanged event
        private void ToUnitPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedToUnit = toUnitPicker.SelectedItem?.ToString();
        }

        // Event handler for convertButton's Clicked event
        private void ConvertButton_Clicked(object sender, EventArgs e)
        {
            // Validation checks before conversion
            if (string.IsNullOrEmpty(selectedCategory))
            {
                DisplayAlert("Error", "Please select a category.", "OK");
                return;
            }

            if (string.IsNullOrEmpty(selectedFromUnit))
            {
                DisplayAlert("Error", "Please select a 'From' unit.", "OK");
                return;
            }

            if (string.IsNullOrEmpty(selectedToUnit))
            {
                DisplayAlert("Error", "Please select a 'To' unit.", "OK");
                return;
            }

            if (!double.TryParse(inputEntry.Text, out inputValue))
            {
                DisplayAlert("Error", "Please enter a valid number.", "OK");
                return;
            }

            // Perform conversion based on the selected category
            if (selectedCategory == "Speed")
            {
                ConvertSpeed();
            }
            else if (selectedCategory == "Distance")
            {
                ConvertDistance();
            }
        }

        // Method to convert speed units
        private void ConvertSpeed()
        {
            double result = 0;

            if (selectedFromUnit == "Miles per hour")
            {
                // Convert from MPR to KPH/FPS/MPS
                if (selectedToUnit == "Kilometers per hour")
                    result = inputValue * 1.60934;
                else if (selectedToUnit == "Feet per second")
                    result = inputValue * 1.46667;
                else if (selectedToUnit == "Meters per second")
                    result = inputValue * 0.44704;
                else if (selectedToUnit == "Miles per hour")
                    result = inputValue;
            }
            else if (selectedFromUnit == "Kilometers per hour")
            {
                // Convert from KPH to MPH/FPS/MPS
                if (selectedToUnit == "Miles per hour")
                    result = inputValue * 0.621371;
                else if (selectedToUnit == "Feet per second")
                    result = inputValue * 0.911344;
                else if (selectedToUnit == "Meters per second")
                    result = inputValue * 0.277778;
                else if (selectedToUnit == "Kilometers per hour")
                    result = inputValue;
            }
            else if (selectedFromUnit == "Feet per second")
            {
                // Convert from FPS to MPH/KPH/MPS
                if (selectedToUnit == "Miles per hour")
                    result = inputValue * 0.681818;
                else if (selectedToUnit == "Kilometers per hour")
                    result = inputValue * 1.09728;
                else if (selectedToUnit == "Meters per second")
                    result = inputValue * 0.3048;
                else if (selectedToUnit == "Feet per second")
                    result = inputValue;
            }
            else if (selectedFromUnit == "Meters per second")
            {
                // Convert from MPS to MPH/KPH/FPS
                if (selectedToUnit == "Miles per hour")
                    result = inputValue * 2.23694;
                else if (selectedToUnit == "Kilometers per hour")
                    result = inputValue * 3.6;
                else if (selectedToUnit == "Feet per second")
                    result = inputValue * 3.28084;
                else if (selectedToUnit == "Meters per second")
                    result = inputValue;
            }

            resultLabel.Text = result.ToString();
        }

        // Method to convert distance units
        private void ConvertDistance()
        {
            double result = 0;

            if (selectedFromUnit == "Miles")
            {
                // Convert from Miles to Kilometers/Feet/Meters
                if (selectedToUnit == "Kilometers")
                    result = inputValue * 1.60934;
                else if (selectedToUnit == "Feet")
                    result = inputValue * 5280;
                else if (selectedToUnit == "Meters")
                    result = inputValue * 1609.34;
                else if (selectedToUnit == "Miles")
                    result = inputValue;
            }
            else if (selectedFromUnit == "Kilometers")
            {
                // Convert from Kilometers to Miles/Feet/Meters
                if (selectedToUnit == "Miles")
                    result = inputValue * 0.621371;
                else if (selectedToUnit == "Feet")
                    result = inputValue * 3280.84;
                else if (selectedToUnit == "Meters")
                    result = inputValue * 1000;
                else if (selectedToUnit == "Kilometers")
                    result = inputValue;
            }
            else if (selectedFromUnit == "Feet")
            {
                // Convert from Feet to Miles/Kilometers/Meters
                if (selectedToUnit == "Miles")
                    result = inputValue * 0.000189394;
                else if (selectedToUnit == "Kilometers")
                    result = inputValue * 0.0003048;
                else if (selectedToUnit == "Meters")
                    result = inputValue * 0.3048;
                else if (selectedToUnit == "Feet")
                    result = inputValue;
            }
            else if (selectedFromUnit == "Meters")
            {
                // Convert from Meters to Miles/Kilometers/Feet
                if (selectedToUnit == "Miles")
                    result = inputValue * 0.000621371;
                else if (selectedToUnit == "Kilometers")
                    result = inputValue * 0.001;
                else if (selectedToUnit == "Feet")
                    result = inputValue * 3.28084;
                else if (selectedToUnit == "Meters")
                    result = inputValue;
            }

            resultLabel.Text = result.ToString();
        }

    }
}