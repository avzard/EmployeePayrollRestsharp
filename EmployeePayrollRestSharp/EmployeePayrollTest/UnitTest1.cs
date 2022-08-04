using NUnit.Framework;
using EmployeePayrollRestSharp;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace EmployeePayrollTest
{
    public class RestsharpTest
    {
        RestClient client = new RestClient("http://localhost:4000");

        [SetUp]
        public void Setup()
        {
            client = new RestClient("http://localhost:4000");
        }

        
        public RestResponse GetEmployeeList()
        {
            RestRequest request = new RestRequest("/employees", Method.Get);
            
            RestResponse response = client.Execute(request);
            return response;
        }

        
        [Test]
        public void OnCallingGetAPI_ReturnEmployeeList()
        {
            
            RestResponse response = GetEmployeeList();
            
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            
            List<Employee> employeeList = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            
            Assert.AreEqual(4, employeeList.Count);

            foreach (Employee emp in employeeList)
            {
                Console.WriteLine("Id: " + emp.Id + "\t" + "Name: " + emp.Name + "\t" + "Salary: " + emp.Salary);
            }
        }
    }
}
