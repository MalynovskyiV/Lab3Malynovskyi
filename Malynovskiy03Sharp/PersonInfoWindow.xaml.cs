using System;
using System.Windows;

namespace Malynovskiy03Sharp
{
    /// <summary>
    /// Interaction logic for PersonInfoWindow.xaml
    /// </summary>
    public partial class PersonInfoWindow : Window
    {
        public PersonInfoWindow(Person person)
        {
            InitializeComponent();
            DataContext = new PersonInfoVM(person);

        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
    }
}
