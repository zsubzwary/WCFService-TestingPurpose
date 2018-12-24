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
    [ServiceContract]
    public interface IStudentService
    {
        [OperationContract]
        [WebInvoke(
            Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json ,UriTemplate = "/Students"
            )]
        List<Student> getAllStudents();


        [OperationContract]
        [WebInvoke(
            Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Students/{id}"
    )]
        Student getStudentOnBasisOfID(String id);

        [OperationContract]
        [WebInvoke(
            Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Students/Save?name={name}&age={age}"

    )]
        Student saveStudentToDB(String name, int age);

        [OperationContract]
        [WebInvoke(
            Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Students/Update?id={id}&name={name}&age={age}"

    )]
        Student updateStudentInDB(int id, String name, int age);



        [OperationContract]
        [WebInvoke(
            Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Students/Delete/{id}"

    )]
        ReturningStatus deleteFromDB(String id);



        [OperationContract]
        [WebInvoke(
            Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Students/SearchByName/{name}"

    )]
        List<Student> searchByName(String name);

    }
}
