using System.Linq;
using System.Windows;
using Wpf_Notes_MVVM.Model;
using Wpf_Notes_MVVM.ModelView;

namespace Wpf_Notes_MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainVM();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            noteList.SelectedItem = new Note();

            noteTitle.Text = string.Empty;
            noteText.Text = string.Empty;
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            using(MyAppContext context = new MyAppContext())
            {
                context.Notes.Add(new Note { Title = noteTitle.Text, Text = noteText.Text });
                context.SaveChanges();                
                
                this.DataContext = new MainVM();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (MyAppContext context = new MyAppContext())
            {
                Note delNote = context.Notes.FirstOrDefault(x=>x.Title.Equals(noteTitle.Text));

                if (delNote!=null)
                {
                    context.Notes.Remove(delNote);
                    context.SaveChanges();
                }

                this.DataContext = new MainVM();
            }
        }
    }
}
