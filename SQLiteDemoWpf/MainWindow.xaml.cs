using System.Collections.Generic;
using System.Windows;

namespace SQLiteDemoWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        List<PersonModel> people = new List<PersonModel>();

        public MainWindow()
        {
            InitializeComponent();

            LoadPeopleList();
        }

        private void LoadPeopleList()
        {
            people = SqliteDataAccess.LoadPeople();

            WireUpPeopleList();
        }

        private void WireUpPeopleList()
        {
            PeopleListBox.ItemsSource = null;
            PeopleListBox.ItemsSource = people;
            PeopleListBox.DisplayMemberPath = "FullName";
        }

        private void UpdateListButton_OnClick(object sender, RoutedEventArgs e)
        {
            LoadPeopleList();
        }

        private void AddPersonButton_OnClick(object sender, RoutedEventArgs e)
        {
            var person = new PersonModel
            {
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text
            };

            SqliteDataAccess.SavePerson(person);

            FirstNameTextBox.Text = "";
            LastNameTextBox.Text = "";
        }
    }
}