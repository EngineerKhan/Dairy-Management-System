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
    /// Interaction logic for CalfEntryView.xaml
    /// </summary>
    public partial class CalfEntryView : UserControl, IEntryViewControl
    {

        AnimalsHandler animalHandler;
        Calf currCalf;
        //List<Animal> animalList;        //Although we need to work for Cattle in the project, but polymorphism will allow animalList to contain Cattle objects. 02-Jan
        public CalfEntryView()
        {
            InitializeComponent();

            //Added - 2 Jan, 2015

            animalHandler = new AnimalsHandler();
            //animalList = new List<Animal>();

            comboBoxAnimalType.ItemsSource = animalHandler.GetAnimalTypes();

            

            comboBoxBreed.ItemsSource = animalHandler.GetAnimalBreeds();
            comboBoxSource.ItemsSource = animalHandler.GetAnimalSources();

            //Commented on 01-Apr. No Status required for Calf
            //comboBoxStatus.ItemsSource = animalHandler.GetAnimalStatuses();
            comboBoxGender.ItemsSource = animalHandler.GetGenders();

            //Added on 01-April - Add Artificial Insemination in Fathers Tab
            List<Cattle> maleCattleList = new List<Cattle>();
            maleCattleList = animalHandler.GetCattlesMale();

            Cattle artificialInsemnation = new Cattle();
            artificialInsemnation.TagNo = "Artificial Insemnation";

            maleCattleList.Add(artificialInsemnation);
            comboBoxFather.ItemsSource = maleCattleList;

            //Added on 02-April - Add Artificial Insemination in Fathers Tab
            List<Cattle> femaleCattleList = new List<Cattle>();
            femaleCattleList = animalHandler.GetCattlesFemale();

            Cattle otherFarm = new Cattle();
            otherFarm.TagNo = "Other Farm";

            femaleCattleList.Add(otherFarm);
            comboBoxMother.ItemsSource = femaleCattleList;

        }

		private void SaveButton_Click(object sender, RoutedEventArgs e)

		{ }

		public void Save()
		{
            currCalf = new Calf();

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

            //Added Apr-02. Bug Fixed

            if (!datePickerDOB.SelectedDate.HasValue)
            {
                MessageBox.Show("Kindly Enter Date of Birth");
                return;
            }

            //CheckTextBoxes(this);


            #endregion

            try
            {

                currCalf.Price = 0;

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

                currCalf.CurrPhysicalAttribs = physicalAttrib;

                currCalf.TagNo = textBoxTagNo.Text;
                currCalf.BirthDate = datePickerDOB.SelectedDate.Value;

                //Only IDs needed for insertion

                currCalf.Breed = new AnimalBreed();
                currCalf.Breed.ID = ((MasterTables)comboBoxBreed.SelectedItem).ID;


                currCalf.Gender = new Gender();
                currCalf.Gender.Description = ((MasterTables)comboBoxGender.SelectedItem).Description;  //Modified 31 March

                currCalf.Source = new AnimalSource();
                currCalf.Source.ID = ((MasterTables)comboBoxSource.SelectedItem).ID;


                currCalf.Type = new AnimalType();
                currCalf.Type.ID = ((MasterTables)comboBoxAnimalType.SelectedItem).ID;

                //Commented on 01-Apr. No Status required for Calf
                //currCalf.Status = new AnimalStatus();
                //currCalf.Status.ID = ((MasterTables)comboBoxStatus.SelectedItem).ID;


                currCalf.OtherDetails = textBoxDescription.Text;

                Cattle mother = new Cattle();
                Cattle father = new Cattle();

                mother = (Cattle)comboBoxMother.SelectedItem;
                father = (Cattle)comboBoxFather.SelectedItem;

                currCalf.Mother = mother;
                currCalf.Father = father;

                //Added on Paril-02. Static Polymorphism for Calf Procedure
                //Whether it is for just calf
                //calf and mother
                //calf and father
                //or both 

                if (mother.TagNo == "Other Farm")
                {
                    if (father.TagNo == "Artificial Insemnation")
                    {
                        animalHandler.Add(currCalf);
                    }
                    else
                    {
                        animalHandler.Add(currCalf, father.ID,'N');
                    }
                }
                else
                {
                    if (father.TagNo == "Artificial Insemnation")
                    {
                        animalHandler.Add(currCalf, mother.ID, 'Y');
                    }
                    else
                    {
                        animalHandler.Add(currCalf, father.ID, mother.ID);
                    }
                }
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

            datePickerDOB.SelectedDate = null;

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

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
	}
}
