﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace wpfSBIFS.Tools
{
    public class Bindable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string memberName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
