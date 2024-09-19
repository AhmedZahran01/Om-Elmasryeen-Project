using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Models
{
    public class Record
    {
        public int Id { get; set; }
        public int DoctorIdDoctor { get; set; }
        public int PatientIdPatient { get; set; }
        public DateTime Date { get; set; }
        public string Diagnosis { get; set; } = null!;  //تشخبص Diagnosis 
        public string Prescription { get; set; } = null!;  //روشتة Prescription  

        public virtual Doctor DoctorIdDoctorNavigation { get; set; } = null!;
        public virtual Patient PatientIdPatientNavigation { get; set; } = null!;

    }
}
