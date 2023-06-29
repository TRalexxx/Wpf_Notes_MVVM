using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Notes_MVVM.Model
{
    internal class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public Note()
        {
            Id = 0;
            Title = string.Empty;
            Text = string.Empty;
        }
    }
}
