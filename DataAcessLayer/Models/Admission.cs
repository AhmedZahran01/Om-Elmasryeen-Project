using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Models
{
    public class Admission : INotifyPropertyChanged  // Admission  قبول     
    {
        #region Poco Class

        public int                     Id          { get; set; }
        private DateTime           AdmissionDate   { get; set; }
        private DateTime           DischargeDate   { get; set; }
        public int                 Patient2Id     { get; set; }

        public virtual Patient Patient2 { get; set; } = null!;

        private  DateTime           _EntryDate;
        private DateTime           _ExitDate;         //تاريخ الخروج 

        #endregion

        #region Implementations

        public DateTime entryDate
        {
            get { return _EntryDate; }
            set
            {
                if (_EntryDate != value)
                {
                    _EntryDate = value;
                    OnPropertyChanged(nameof(entryDate));
                }
            }
        }

        public DateTime exitDate
        {
            get { return _ExitDate; }
            set
            {
                if (_ExitDate != value)
                {
                    _ExitDate = value;
                    OnPropertyChanged(nameof(exitDate));
                }
            }
        }

        public int patientId
        {
            get { return Patient2Id; } 
            set
            {
                if (Patient2Id != value)
                {
                    Patient2Id = value;
                    OnPropertyChanged(nameof(patientId));
                }
            }
        }

        public virtual Patient patient
        {
            get { return Patient2; }
            set
            {
                if (Patient2 != value)
                {
                    Patient2 = value;
                    OnPropertyChanged(nameof(patient));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


    }
}
