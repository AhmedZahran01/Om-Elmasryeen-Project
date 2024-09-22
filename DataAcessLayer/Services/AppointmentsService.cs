using DataAcessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Services
{
    public class AppointmentsService
    {
        private readonly hospitalContext _context;

        public AppointmentsService()
        {
            _context = new hospitalContext();
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _context.Appointments
                .Include(a => a._Doctor)
                .Include(a => a.Patient)
                .OrderBy(a => a.Date)
            .ToList();
        }

        public IEnumerable<Appointment> GetAllByDoctor(int doctorId)
        {
            return _context.Appointments
                .Where(a => a.Doctor == doctorId)
                .Include(a => a.Patient)
                .OrderBy(a => a.Date)
            .ToList();
        }

        public void Add(Appointment newAppointment)
        {
            _context.Appointments.Add(newAppointment);
            _context.SaveChanges();
        }

        public void Update(Appointment updatedAppointment)
        {
            var existingAppointment = _context.Appointments.Find(updatedAppointment.Id);

            if (existingAppointment != null)
            {
                existingAppointment.Date = updatedAppointment.Date;
                existingAppointment.Doctor = updatedAppointment.Doctor;
                existingAppointment.PatientId = updatedAppointment.PatientId;

                _context.SaveChanges();
            }
        }

        public void Delete(int appointmentId)
        {
            var appointmentToDelete = _context.Appointments.Find(appointmentId);

            if (appointmentToDelete != null)
            {
                _context.Appointments.Remove(appointmentToDelete);
                _context.SaveChanges();
            }
        }

    }
}
