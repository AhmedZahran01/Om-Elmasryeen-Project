using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Models
{
    public class Admission :INotifyPropertyChanged
    {
        #region Poco Class

        public int Id { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime DischargeDate { get; set; }
        public int _PatientId { get; set; }
        public virtual Patient _Patient { get; set; } = null!;
        private DateTime _EntryDate;
        private DateTime _ExitDate; //تاريخ الخروج 

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
            get { return _PatientId; }
            set
            {
                if (_PatientId != value)
                {
                    _PatientId = value;
                    OnPropertyChanged(nameof(patientId));
                }
            }
        }

        public virtual Patient patient
        {
            get { return _Patient; }
            set
            {
                if (_Patient != value)
                {
                    _Patient = value;
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
