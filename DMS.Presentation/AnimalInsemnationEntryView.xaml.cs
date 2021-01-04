using DMS.BusinessLayer;
using DMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DMS.Presentation
{
    /// <summary>
    /// Interaction logic for AnimalInsemnationEntryView.xaml
    /// </summary>
    public partial class AnimalInsemnationEntryView : UserControl, IEntryViewControl
    {

        AnimalInsemnationsHandler insemnationHandler;
        AnimalInsemnation currAnimalInsemnation;
        //List<Animal> animalList;        //Although we need to work for Cattle in the project, but polymorphism will allow animalList to contain Cattle objects. 02-Jan
        public AnimalInsemnationEntryView()
        {
            InitializeComponent();

            //Added - 2 Jan, 2015

            insemnationHandler = new AnimalInsemnationsHandler();
            //animalList = new List<Animal>();

            comboBoxMother.ItemsSource = new AnimalsHandler().GetCattlesFemale();

        }

		private void SaveButton_Click(object sender, RoutedEventArgs e)

		{ 
        }

        public void Save()
        {
            try
            {
                currAnimalInsemnation = new AnimalInsemnation();

                currAnimalInsemnation.Comments = textBoxComments.Text;
                currAnimalInsemnation.CurrCattle = (Cattle)comboBoxMother.SelectedItem;
                currAnimalInsemnation.DateofInsemnation = datePickerInsemnation.SelectedDate.Value;

                insemnationHandler.Add(currAnimalInsemnation);
            }

            catch (Exception fexp)
            {
                MessageBox.Show(fexp.Message);
                return;
            }

            textBoxComments.Text = "";
            comboBoxMother.SelectedIndex = -1;
            datePickerInsemnation.Text = "";

        }


        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        private void EntryGrid_Loaded(object sender, RoutedEventArgs e)
        {

        }
	}
}
