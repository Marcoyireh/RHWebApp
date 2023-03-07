using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RHWebApp;
using RHWebApp.Models;

namespace Layer.AccessData
{
    public class PaymentConceptsAccessData
    {
        public static List<PaymentConcepts> GetByEmployeeId(int EmployeeId)
        {
            var list = new List<PaymentConcepts>();
            string conecctionString = "Data Source=localhost;Initial Catalog=RHWeb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False""Data Source=MORALES\\SQL2012;DataBase=BD_Empresa;Integrated Security=true";
            SqlConnection cn = new SqlConnection(conecctionString);
            cn.Open();
            SqlCommand cmd = new SqlCommand("GetPaymentConceptsByEmployeeId", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            var param = cmd.CreateParameter();
            param.ParameterName = "EmployeeId";
            param.Value = paramValue;
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
                
                list.Add(oPaymentConcepts);
            }
            return list;
        }

    }
}