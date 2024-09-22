using DataAcessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Services
{

    public class AuthService
    {
        private hospitalContext HospitalContext;
        public AuthService()
        {
            HospitalContext = new();
        }

        public bool RegisterDoctor(string name, string surname, string phoneNumber, 
                                      string username, string password)
        {
            var newDoctor = new Doctor
            {
                Name = name,
                Surname = surname,
                Contact = phoneNumber,
                Username = username,
                Password = password,
                Theme = "Dark",
                Language = "ar"
            };

            HospitalContext.Doctorst.Add(newDoctor);

            try
            {
                HospitalContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool RegisterManager(string name, string surname, string phoneNumber,
                                      string username, string password)
        {
            var newManager = new Manager
            {
                Name = name,
                Surname = surname,
                Contact = phoneNumber,
                Username = username,
                Password = password,
                Theme = "Dark",
                Language = "ar"
            };


            try
            {
                HospitalContext.Managers.Add(newManager);

                HospitalContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool RegisterNurse(string name, string surname, string phoneNumber,
                                       string username, string password)
        {
            var newNurse = new Nurse
            {
                Name = name,
                Surname = surname,
                Contact = phoneNumber,
                Username = username,
                Password = password,
                Theme = "Dark",
                Language = "ar"
            };


            try
            {
                HospitalContext.Nurses.Add(newNurse);

                HospitalContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Manager LoginManager(string username, string password)
        {
            Manager manager = HospitalContext.Managers
            .AsNoTracking()
            .FirstOrDefault(m => m.Username == username && m.Password == password);


            return manager;
        }

        public Doctor LoginDoctor(string username, string password)
        {
            Doctor doctor = HospitalContext.Doctorst
            .AsNoTracking()
            .FirstOrDefault(m => m.Username == username && m.Password == password);

            return doctor;
        }

        public Nurse LoginNurse(string username, string password)
        {
            Nurse nurse = HospitalContext.Nurses
            .AsNoTracking()
            .FirstOrDefault(m => m.Username == username && m.Password == password);

            return nurse;
        }

    }
}
