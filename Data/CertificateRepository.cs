using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseA.Models;

namespace DataBaseA.Data
{
    public class CertificateRepository
    {
        private readonly string _connectionString;

        public CertificateRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public CertificateModel GetCertificate(int certificateId)
        {
            var model = new CertificateModel();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                // Load main certificate
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM Certificates WHERE Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", certificateId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            model.Id = certificateId;
                            model.CertificateName = reader["CertificateName"].ToString();
                            model.IssuingAuthority = reader["IssuingAuthority"].ToString();
                            model.IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                            model.ExpiryDate = Convert.ToDateTime(reader["ExpiryDate"]);
                            model.WeldingPosition = reader["WeldingPosition"].ToString();
                            model.ProductType = reader["ProductType"].ToString();
                        }
                    }
                }

                // Load processes
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM CertificateProcessDetails WHERE CertificateId = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", certificateId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            model.Processes.Add(new ProcessModel
                            {
                                ProcessCode = reader["ProcessCode"].ToString(),
                                FillerMaterialGroup = reader["FillerMaterialGroup"].ToString(),
                                ShieldingGas = reader["ShieldingGas"].ToString()
                            });
                        }
                    }
                }
            }

            return model;
        }
    }
}
