using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;

namespace mvvm
{
    public class ProgressbarProgress : INotifyPropertyChanged
    {
        private decimal progress1; //default value of progress1

        public decimal progress
        {
            get => progress1; //continuous get and set of progress for object 
            
            set
            {
                progress1 = value;
                OnPropertyChanged();//fire off notification of object that value has changed
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName/*name of property changed ie: progress*/] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));//notifies gui to update specific any areas of specific object that pertains to said value
        }
    }
}
