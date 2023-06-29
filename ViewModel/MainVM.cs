using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Wpf_Notes_MVVM.Model;

namespace Wpf_Notes_MVVM.ModelView
{
    internal class MainVM : INotifyPropertyChanged
    {
        public List<Note> Notes { get; set; }
		private Note _selectedNote;

		public Note SelectedNote
		{
			get { return _selectedNote; }
			set { _selectedNote = value; OnPropertyChanged("SelectedNote"); }
		}

        public MainVM()
        {
            _selectedNote = new Note();

            using(MyAppContext context = new MyAppContext())
            {
                Notes = context.Notes.ToList();
            }
            SelectedNote = Notes[0];
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
