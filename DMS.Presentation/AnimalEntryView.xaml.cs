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
    /// Interaction logic for AnimalEntryView.xaml
    /// </summary>
    public partial class AnimalEntryView : UserControl, IEntryViewControl
    {

        AnimalsHandler animalHandler;
        Cattle currCattle;
        Calf currCalf;
        //List<Animal> animalList;        //Although we need to work for Cattle in the project, but polymorphism will allow animalList to contain Cattle objects. 02-Jan
        public AnimalEntryView()
        {
            InitializeComponent();

            //Added - 2 Jan, 2015

            animalHandler = new AnimalsHandler();
            //animalList = new List<Animal>();

            comboBoxAnimalType.ItemsSource = animalHandler.GetAnimalTypes();
            comboBoxBreed.ItemsSource = animalHandler.GetAnimalBreeds();
            comboBoxSource.ItemsSource = animalHandler.GetAnimalSources();
            
            //Commented on April-01
            //Statuses should be on the basis of the gender
            //comboBoxStatus.ItemsSource = animalHandler.GetAnimalStatuses();

            List<string> genderList = new List<string>();

            genderList.Add("Male");
            genderList.Add("Female");

                comboBoxGender.ItemsSource = genderList;
            
            //Commented on 31-March. Now Gender will not be FK anymore
            //comboBoxGender.ItemsSource = animalHandler.GetGenders();
        }


        private void comboBoxGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string g = ((string)comboBoxGender.SelectedItem);

            if (g == "Male")
            {
                comboBoxStatus.ItemsSource = animalHandler.GetAnimalStatuses("N");
            }
            else
            {
                comboBoxStatus.ItemsSource = animalHandler.GetAnimalStatuses("Y");
            }
        }

		private void SaveButton_Click(object sender, RoutedEventArgs e)

		{
		}

		//Changed
		//Shifted code from Save Button to interface Save() method overriding
		public void Save()
		{
			currCattle = new Cattle();

			//string _name = textBoxName.Text;
			//string _fatherName = textBoxFatherName.Text;
			//int _salary = Convert.ToInt32(textBoxSalary.Text);

			#region Validation for valid employee data

			//Check if all text boxes are empty

			IEnumerable<TextBox> textBoxcollection = EntryGrid.Children.OfType<TextBox>();
			IEnumerable<ComboBox> comboBoxcollection = EntryGrid.Children.OfType<ComboBox>();

			foreach (TextBox box in textBoxcollection)
			{
                if (string.IsNullOrWhiteSpace(box.Text))
                {
                    if (box.Name == "textBoxDescription" || 
                        box.Name == "textBoxHeight" || 
                        box.Name == "textBoxLength" || 
                        box.Name == "textBoxWidth" || 
                        box.Name == "textBoxPrice" || 
                        box.Name == "textBoxWeight")
                    {
                        //ignore
                    }
                    else
                    {
                        MessageBox.Show("Kindly Fill all the boxes.");
                        return;
                    }
                }

			}

			foreach (ComboBox combobox in comboBoxcollection)
			{
				if (combobox.SelectedIndex == -1)
				{
					MessageBox.Show("Kindly Select all the Drop-Downs");
					return;
				}
			}

			//CheckTextBoxes(this);


			#endregion

			try
			{
                if (string.IsNullOrWhiteSpace(textBoxPrice.Text))
                {
                    currCattle.Price = 0;
                }
                else
                {
                    currCattle.Price = Convert.ToInt32(textBoxPrice.Text);
                }

				PhysicalAttributes physicalAttrib = new PhysicalAttributes();
				Entities.Size currSize = new Entities.Size();

                if (string.IsNullOrWhiteSpace(textBoxHeight.Text))
                {
                    currSize.Height = 0;
                }
                else
                {
                    currSize.Height = Convert.ToDouble(textBoxHeight.Text);
                }

                if (string.IsNullOrWhiteSpace(textBoxLength.Text))
                {
                    currSize.Length = 0;
                }
                else
                {
                    currSize.Length = Convert.ToDouble(textBoxLength.Text);
                }

                if (string.IsNullOrWhiteSpace(textBoxWidth.Text))
                {
                    currSize.Width = 0;
                }
                else
                {
                    currSize.Width = Convert.ToDouble(textBoxWidth.Text);
                }


                if (string.IsNullOrWhiteSpace(textBoxWeight.Text))
                {
                    physicalAttrib.Weight = 0;
                }
                else
                {
                    physicalAttrib.Weight = Convert.ToDouble(textBoxWeight.Text);
                }

				physicalAttrib.CurrentSize = currSize;

				currCattle.CurrPhysicalAttribs = physicalAttrib;

				currCattle.TagNo = textBoxTagNo.Text;
				currCattle.BirthDate = datePickerDOB.SelectedDate.Value;

				//List<MasterTables> masterList = new List<MasterTables>();

				//masterList.Add((MasterTables)comboBoxBreed.SelectedItem);
				//masterList.Add((MasterTables)comboBoxGender.SelectedItem);
				//masterList.Add((MasterTables)comboBoxSource.SelectedItem);

				//AnimalBreed breed = new AnimalBreed();
				//breed = (AnimalBreed)masterList[0];

				//currCattle.Breed = breed;

				//currCattle.Breed = (AnimalBreed)comboBoxBreed.SelectedItem;
				//currCattle.Gender = (Gender)comboBoxGender.SelectedItem;
				//currCattle.Source = (AnimalSource)comboBoxSource.SelectedItem;

				//Only IDs needed for insertion

				currCattle.Breed = new AnimalBreed();
				currCattle.Breed.ID = ((MasterTables)comboBoxBreed.SelectedItem).ID;


				currCattle.Gender = new Gender();

                string g = ((string)comboBoxGender.SelectedItem);

                currCattle.Gender.Description = g;


				currCattle.Source = new AnimalSource();
				currCattle.Source.ID = ((MasterTables)comboBoxSource.SelectedItem).ID;


				currCattle.Type = new AnimalType();
				currCattle.Type.ID = ((MasterTables)comboBoxAnimalType.SelectedItem).ID;


				currCattle.Status = new AnimalStatus();
				currCattle.Status.ID = ((MasterTables)comboBoxStatus.SelectedItem).ID;


				currCattle.OtherDetails = textBoxDescription.Text;

				animalHandler.Add(currCattle);

			}
			catch (FormatException fexcept)
			{
				MessageBox.Show("Kindly Enter the field in correct (numeric) format. Error on " + fexcept.Source + " .", "Invalid Entry");
				return;
			}

			//Added - 01 Jan
			//For Name/Father name not containing numbers

			catch (ArgumentException aexcept)
			{
				MessageBox.Show(aexcept.Message, "Invalid Entry!");
				return;
			}


			//Clear all the TextBoxes

			foreach (TextBox textbox in textBoxcollection)
			{
				textbox.Text = "";
			}

			foreach (ComboBox combobox in comboBoxcollection)
			{
				combobox.SelectedIndex = -1;
			}

		}
        
        private void EntryGrid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void checkBoxCalf_Checked(object sender, RoutedEventArgs e)
        {
            //textBlockFather.IsEnabled = true;
            //textBlockMother.IsEnabled = true;

            //comboBoxFather.IsEnabled = true;
            //comboBoxMother.IsEnabled = true;
        }

		public void Save2()
		{
			throw new NotImplementedException();
		}

	}
}
