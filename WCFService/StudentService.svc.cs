using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StudentService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StudentService.svc or StudentService.svc.cs at the Solution Explorer and start debugging.

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class StudentService : IStudentService
    {
        private static spDatabase database = new spDatabase();

        /// <summary>
        /// Get all students
        /// </summary>
        /// <returns>a list of all students</returns>
        public List<Student> getAllStudents()
        {
            return database.Students.ToList();
        }


        /// <summary>
        /// returns a student that has a particular ID
        /// </summary>
        /// <param name="id">a primary key</param>
        /// <returns>returns a student that has a particular ID</returns>
        public Student getStudentOnBasisOfID(String id)
        {
            int ID = int.Parse(id);
            var res = database.Students.Where(s => s.id == ID).FirstOrDefault();
            return res!=null ? res : new Student() { id = -1, age = -1, name ="" } ;
        }


        /// <summary>
        /// save student to DB
        /// </summary>
        /// <param name="name">name of student</param>
        /// <param name="age">age of student</param>
        /// <returns>an object holding that student</returns>
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


        /// <summary>
        /// updates student in DB
        /// </summary>
        /// <param name="id">id of student</param>
        /// <param name="name">name of student</param>
        /// <param name="age">age of student</param>
        /// <returns>an object</returns>
        public Student updateStudentInDB(int id, string name, int age)
        {
            Student student = database.Students.Where(s => s.id == id).FirstOrDefault();
            if (student == null)
            {
                return new Student() { name = "" , id = -1, age = -1  };
            }
            student.name = name;
            student.age = age;

            database.SaveChanges();

            return student;

        }


        /// <summary>
        /// deletes student from DB
        /// </summary>
        /// <param name="id">id of student</param>
        /// <returns>Status</returns>
        public ReturningStatus deleteFromDB(string ID)
        {
            int id = int.Parse(ID);
            Student s = database.Students.Where(b => b.id == id).SingleOrDefault();
            
            if (s != null) { database.Students.Remove(s); database.SaveChanges(); }
            var a = new ReturningStatus { status = $"Student with ID {id} has been removed.", extraInfo = String.Empty, operationSuccessful = true };
            return a;
        }


        /// <summary>
        /// search student by name
        /// </summary>
        /// <param name="name">name of student</param>
        /// <returns>list of student matchiing searching criteria</returns>
        public List<Student> searchByName(string name)
        {
            var temp = database.Students.Where(a => a.name.Contains(name)).ToList();
            return temp;
        }
    }

    /// <summary>
    /// a class used instead of objects
    /// </summary>
    public class ReturningStatus
    {
        public String status { get; set; }
        public String extraInfo { get; set; }
        public bool operationSuccessful { get; set; }
    }
}
