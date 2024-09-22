using DataAcessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.IsisMtt.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Services
{
    public class AdmissionsService
    {
        private hospitalContext _context;

        public AdmissionsService()
        {   _context = new() ; }

        public IEnumerable<Admission> GetAll()
         => _context.Admissions.Include(a => a.patient)  .OrderBy(a => a.entryDate) .ToList();

        public void Add(Admission newAdmission)
        { 
            _context.Admissions.Add(newAdmission);
            _context.SaveChanges();
        }

        public void Update(Admission updatedAdmission)
        {
            var existingAdmission = _context.Admissions.Find(updatedAdmission.Id);

            if (existingAdmission != null)
            {
                existingAdmission.entryDate = updatedAdmission.entryDate;
                existingAdmission.exitDate = updatedAdmission.exitDate;
                existingAdmission.patientId = updatedAdmission.patientId; 
                _context.SaveChanges();

            }
        }

        public void Delete(int admissionId)
        {
            var admissionToDelete = _context.Admissions.Find(admissionId);

            if (admissionToDelete != null)
            {
                _context.Admissions.Remove(admissionToDelete);
                _context.SaveChanges();
            }
        }

    }
}
