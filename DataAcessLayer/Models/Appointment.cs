using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Models
{
    public class Appointment : INotifyPropertyChanged
    {
        #region Poco Class
       
        public int                    Id                        { get; set; }
        private DateTime             _Date                      { get; set; }
        public int               _Doctor2Id               { get; set; }
        public int               _Patient2Id             { get; set; }

        public virtual Doctor  _Doctor2        { get; set; } = null!;
        public virtual Patient _Patient2      { get; set; } = null!;

        #endregion


        #region Implementations
       
        public DateTime Date
        {
            get { return _Date; }
            set
            {
                if (_Date != value)
                {
                    _Date = value;
                    OnPropertyChanged(nameof(Date));
                }
            }
        }

        public int Doctor
        {
            get { return _Doctor2Id; }
            set
            {
                if (_Doctor2Id != value)
                {
                    _Doctor2Id = value;
                    OnPropertyChanged(nameof(Doctor));
                }
            }
        }

        public int PatientId
        {
            get { return _Patient2Id; }
            set
            {
                if (_Patient2Id != value)
                {
                    _Patient2Id = value;
                    OnPropertyChanged(nameof(PatientId));
                }
            }
        }

        public virtual Doctor _Doctor
        {
            get { return _Doctor2; }
            set
            {
                if (_Doctor2 != value)
                {
                    _Doctor2 = value;
                    OnPropertyChanged(nameof(_Doctor));
                }
            }
        }

        public virtual Patient Patient
        {
            get { return _Patient2; }
            set
            {
                if (_Patient2 != value)
                {
                    _Patient2 = value;
                    OnPropertyChanged(nameof(Patient));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion


    }
}
