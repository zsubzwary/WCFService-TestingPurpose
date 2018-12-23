using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StudentService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StudentService.svc or StudentService.svc.cs at the Solution Explorer and start debugging.
    public class StudentService : IStudentService
    {
        private static spDatabase database = new spDatabase();


        public List<Student> getAllStudents()
        {
            return database.Students.ToList();
        }

        public Student getStudentOnBasisOfID(String id)
        {
            int ID = int.Parse(id);
            var res = database.Students.Where(s => s.id == ID).FirstOrDefault();
            return res!=null ? res : new Student() { id = -1, age = -1, name ="" } ;
        }

        public Student saveStudentToDB(String name, int age)
        {
            Student student = new Student() { age = age, name =name };
            try
            {
                database.Students.Add(student);
                database.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return student;
        }

        public Student updateStudentInDB(int id, string name, int age)
        {
            Student student = database.Students.Where(s => s.id == id).FirstOrDefault();
            student.name = name;
            student.age = age;

            database.SaveChanges();

            return student;

        }

        public ReturningStatus deleteFromDB(string ID)
        {
            int id = int.Parse(ID);
            Student s = database.Students.Where(b => b.id == id).SingleOrDefault();
            
            if (s != null) { database.Students.Remove(s); database.SaveChanges(); }
            var a = new ReturningStatus { status = $"Student with ID {id} has been removed.", extraInfo = String.Empty, operationSuccessful = true };
            return a;
        }
    }


    public class ReturningStatus
    {
        public String status { get; set; }
        public String extraInfo { get; set; }
        public bool operationSuccessful { get; set; }
    }
}
