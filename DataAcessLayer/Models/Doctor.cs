using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace DataAcessLayer.Models
{
    public class Doctor :ModelBase
    {
        #region Poco Class

        

        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
            Records = new HashSet<Record>();
            Surgeries = new HashSet<Surgery>();
        } 

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Record> Records { get; set; }
        public virtual ICollection<Surgery> Surgeries { get; set; }

        #endregion
        
        #region Implementations

        public override string ToString()
        {
            return $"{Name} {Surname} ({Contact})";
        } 

        #endregion

    }
}
