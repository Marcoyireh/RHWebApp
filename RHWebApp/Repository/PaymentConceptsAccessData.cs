using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RHWebApp;
using RHWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RHWebApp.Repository
{
    public class PaymentConceptsAccessData
    {
        private SqlConnection con;


        private readonly IConfiguration _configuration;

        //public PaymentConceptsAccessData(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        private void connection()
        {
            var builder = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
            IConfiguration _configuration = builder.Build();
            var connetctionString = _configuration.GetConnectionString("RH").ToString();

            //var connetctionString = _configuration.GetSection("ConnectionStrings").GetSection("RHWebAppContext").Value.ToString();
            //string conecctionString = "Data Source=localhost;Initial Catalog=RHWeb;Integrated Security=True;Connect Timeout=30;";
            con = new SqlConnection(connetctionString);

        }







        public List<PaymentConcepts> GetByEmployeeId(int EmployeeId)
        {
            connection();  

            var list = new List<PaymentConcepts>();
            con.Open();
            SqlCommand cmd = new SqlCommand("GetPaymentConceptsByEmployeeId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            var param = cmd.CreateParameter();
            param.ParameterName = "EmployeeId";
            param.Value = EmployeeId;
            cmd.Parameters.Add(param);
            SqlDataReader drlector = cmd.ExecuteReader();


            while (drlector.Read())
            {
                PaymentConcepts oPaymentConcepts = new PaymentConcepts();
                oPaymentConcepts.EmployeeId = Convert.ToInt32(drlector["EmployeeId"]);
                oPaymentConcepts.Name = drlector["Name"].ToString().Trim();
                oPaymentConcepts.Concept = drlector["Concept"].ToString().Trim();
                oPaymentConcepts.Amount = Convert.ToDouble(drlector["Amount"].ToString());
                oPaymentConcepts.Operation = Convert.ToBoolean(drlector["Operation"].ToString());
                oPaymentConcepts.RoleDescription = drlector["RoleDescription"].ToString().Trim();

                list.Add(oPaymentConcepts);
            }
            con.Close();
            return list;
        }
    }
}
