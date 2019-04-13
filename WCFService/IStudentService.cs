using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStudentService" in both code and config file together.


        /// <summary>
        /// The interface responsible for the data
        /// </summary>
    [ServiceContract]
    public interface IStudentService
    {
        /// <summary>
        /// Get all students
        /// </summary>
        /// <returns>a list of all students</returns>
        [OperationContract]
        [WebInvoke(
            Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json ,UriTemplate = "/Students"
            )]
        List<Student> getAllStudents();



        /// <summary>
        /// returns a student that has a particular ID
        /// </summary>
        /// <param name="id">a primary key</param>
        /// <returns>returns a student that has a particular ID</returns>
        [OperationContract]
        [WebInvoke(
            Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Students/{id}"
    )]
        Student getStudentOnBasisOfID(String id);


        /// <summary>
        /// save student to DB
        /// </summary>
        /// <param name="name">name of student</param>
        /// <param name="age">age of student</param>
        /// <returns>an object holding that student</returns>
        [OperationContract]
        [WebInvoke(
            Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Students/Save?name={name}&age={age}"
    )]
        Student saveStudentToDB(String name, int age);



        /// <summary>
        /// updates student in DB
        /// </summary>
        /// <param name="id">id of student</param>
        /// <param name="name">name of student</param>
        /// <param name="age">age of student</param>
        /// <returns>an object</returns>
        [OperationContract]
        [WebInvoke(
            Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Students/Update?id={id}&name={name}&age={age}"
    )]
        Student updateStudentInDB(int id, String name, int age);



        /// <summary>
        /// deletes student from DB
        /// </summary>
        /// <param name="id">id of student</param>
        /// <returns>Status</returns>
        [OperationContract]
        [WebInvoke(
            Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Students/Delete/{id}"
    )]
        ReturningStatus deleteFromDB(String id);



        /// <summary>
        /// search student by name
        /// </summary>
        /// <param name="name">name of student</param>
        /// <returns>list of student matchiing searching criteria</returns>
        [OperationContract]
        [WebInvoke(
            Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Students/SearchByName/{name}"
    )]
        List<Student> searchByName(String name);

    }
}
