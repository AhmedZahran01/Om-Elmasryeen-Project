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
        private int               _DoctorIdDoctor               { get; set; }
        private int               _PatientIdPatient             { get; set; }

        public virtual Doctor  _DoctorIdDoctorNavigation        { get; set; } = null!;
        public virtual Patient _PatientIdPatientNavigation      { get; set; } = null!;

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

        public int DoctorId
        {
            get { return _DoctorIdDoctor; }
            set
            {
                if (_DoctorIdDoctor != value)
                {
                    _DoctorIdDoctor = value;
                    OnPropertyChanged(nameof(DoctorId));
                }
            }
        }

        public int PatientId
        {
            get { return _PatientIdPatient; }
            set
            {
                if (_PatientIdPatient != value)
                {
                    _PatientIdPatient = value;
                    OnPropertyChanged(nameof(PatientId));
                }
            }
        }

        public virtual Doctor Doctor
        {
            get { return _DoctorIdDoctorNavigation; }
            set
            {
                if (_DoctorIdDoctorNavigation != value)
                {
                    _DoctorIdDoctorNavigation = value;
                    OnPropertyChanged(nameof(Doctor));
                }
            }
        }

        public virtual Patient Patient
        {
            get { return _PatientIdPatientNavigation; }
            set
            {
                if (_PatientIdPatientNavigation != value)
                {
                    _PatientIdPatientNavigation = value;
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
