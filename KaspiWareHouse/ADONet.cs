using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace KaspiWareHouse
{
    class ADONet
    {
        private static readonly string connStr = @"Server=DESKTOP-61A6HJU;Database=kaspi;User ID=sa;Password=123456;";

        public static void GetAgreementByIIN(string iin)
        {
            string commStr = @"select b.BeginDate, b.EndDate, c.AgreementName, d.CurrentBalance from Client a
                               inner join Agreement b on b.ClientId=a.id
                               inner join AgreementDict c on c.Id=b.AgreementDictId
                               inner join Account d on d.Id=b.AccountId
                               where a.IIN=@iin";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand comm = new SqlCommand(commStr, conn);
                comm.Parameters.AddWithValue("@iin", iin);
                try
                {
                    conn.Open();
                    SqlDataReader rdr = comm.ExecuteReader();
                    while (rdr.Read())
                    {
                        var isActive = DateTime.Now >= (DateTime)rdr[1] ? "Active" : "InActive";
                        Console.WriteLine($"{rdr[0]}, {rdr[2]}, {rdr[3]}, {isActive}");
                    }
                    rdr.Close();
                }
                catch(Exception ex)
                {

                }
            }
        }
    }
}
