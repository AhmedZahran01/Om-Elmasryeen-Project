using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace DataAcessLayer.Models
{
    public class Patient :ModelBase
    {
        #region MyRegion
       
        public Patient()
        {
            Admissions = new HashSet<Admission>();
            Appointments = new HashSet<Appointment>();
            Records = new HashSet<Record>();
            Surgeries = new HashSet<Surgery>();
        }

        public string Address { get; set; } = null!;
        public DateTime BirthDate { get; set; }

        #endregion
        public virtual ICollection<Admission> Admissions { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Record> Records { get; set; }
        public virtual ICollection<Surgery> Surgeries { get; set; }

    }
}
