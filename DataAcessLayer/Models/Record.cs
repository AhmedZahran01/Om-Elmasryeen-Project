using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Models
{
    public class Record : INotifyPropertyChanged
    {

        public int Id { get; set; }
         
        public int DoctorIdDoctor { get; set; }
        public int PatientIdPatient { get; set; }
 
        public virtual Doctor DoctorIdDoctorNavigation { get; set; } = null!;
        public virtual Patient PatientIdPatientNavigation { get; set; } = null!;
         
        private int doctorId;
        public int DoctorId
        {
            get { return doctorId; }
            set
            {
                if (doctorId != value)
                {
                    doctorId = value;
                    OnPropertyChanged(nameof(DoctorId));
                }
            }
        }

        private int patientId;
        public int PatientId
        {
            get { return patientId; }
            set
            {
                if (patientId != value)
                {
                    patientId = value;
                    OnPropertyChanged(nameof(PatientId));
                }
            }
        }

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                if (date != value)
                {
                    date = value;
                    OnPropertyChanged(nameof(Date));
                }
            }
        }

        private string diagnosis = string.Empty; //تشخبص   diagnosis  
        public string Diagnosis
        {
            get { return diagnosis; }
            set
            {
                if (diagnosis != value)
                {
                    diagnosis = value;
                    OnPropertyChanged(nameof(Diagnosis));
                }
            }
        }

        private string prescription = string.Empty; //روشتة Prescription 
        public string Prescription
        {
            get { return prescription; }
            set
            {
                if (prescription != value)
                {
                    prescription = value;
                    OnPropertyChanged(nameof(Prescription));
                }
            }
        }

        private Doctor doctor = null!;
        public virtual Doctor Doctor
        {
            get { return doctor; }
            set
            {
                if (doctor != value)
                {
                    doctor = value;
                    OnPropertyChanged(nameof(Doctor));
                }
            }
        }

        private Patient patient = null!;
        public virtual Patient Patient
        {
            get { return patient; }
            set
            {
                if (patient != value)
                {
                    patient = value;
                    OnPropertyChanged(nameof(Patient));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
