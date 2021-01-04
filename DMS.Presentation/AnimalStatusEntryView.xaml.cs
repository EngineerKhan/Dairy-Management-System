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
    /// Interaction logic for AnimalStatusEntryView.xaml
    /// </summary>
    public partial class AnimalStatusEntryView : UserControl, IEntryViewControl
    {
        AnimalsHandler animalHandler;
        Cattle selectedAnimal;
        int updatedStatus;
        List<AnimalStatusNew> allStatusesList;
        IEnumerable<string> maleStatus, femaleStatus;

        public AnimalStatusEntryView()
        {
            InitializeComponent();
            animalHandler = new AnimalsHandler();
            comboBoxAnimal.ItemsSource = animalHandler.GetCattles();
            List<bool> booleanList = new List<bool>();

            booleanList.Add(true);
            booleanList.Add(false);

            comboBoxMilkingStatus.ItemsSource = booleanList;

            allStatusesList = animalHandler.GetAnimalStatuses();
            //IEnumerable<AnimalStatusNew> distinctStauses = allStatusesList.Distinct();

        }

		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{ 
        }

        private void comboBoxAnimal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedAnimal = ((Cattle)comboBoxAnimal.SelectedItem);

            string gender = selectedAnimal.Gender.Description;

            //Added 14 May 2015 - Talha
            var maleSt = from st in allStatusesList
                         where (st.IsFemale == false)
                         select st.Description;

            var femaleSt = from st in allStatusesList
                           where (st.IsFemale == true)
                           select st.Description;

            //Writing Distinct in same query is making it in a form in which it is not visible in combobox
            var maleStDistinct = maleSt.Distinct();
            var femaleStDistinct = femaleSt.Distinct();

            if (gender == "M")
            {
                comboBoxStatus.ItemsSource = maleStDistinct;
                comboBoxMilkingStatus.SelectedItem = false; //Be careful - It is false as a boolean item
                comboBoxMilkingStatus.IsEnabled = false;
            }
            else
            {
                comboBoxStatus.ItemsSource = femaleStDistinct;
            }
        }

        public void Save()
        {
            try
            {
                //Added on May 14
                AnimalStatusNew ast = new AnimalStatusNew();
                ast.Description = (string)comboBoxStatus.SelectedItem;
                ast.IsMilking = (bool)comboBoxMilkingStatus.SelectedItem;

                selectedAnimal = ((Cattle)comboBoxAnimal.SelectedItem);
                string gender = selectedAnimal.Gender.Description;

                if (gender == "F")
                {
                    ast.IsFemale = true;
                }
                else
                {
                    ast.IsFemale = false;
                }

                updatedStatus = animalHandler.GetAnimalStatusID(ast);

                animalHandler.UpdateStatus(selectedAnimal, updatedStatus);
            }

            catch (Exception fexp)
            {
                MessageBox.Show(fexp.Message);
                return;
            }

            //textBoxComments.Text = "";
            //comboBoxMother.SelectedIndex = -1;
            //datePickerStatus.Text = "";

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
