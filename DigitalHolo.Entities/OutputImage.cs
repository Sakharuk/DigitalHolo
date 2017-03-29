using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHolo.Entities
{
    public class OutputImage : INotifyPropertyChanged
    {
        private byte[] _data;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
               
        public byte[] Data
        {
            get { return this._data; }

            set
            {
                if (value != this._data)
                {
                    this._data = value;
                    NotifyPropertyChanged("Data");
                }
            }
        }
    }
}
