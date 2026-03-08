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

                // -------------------------
                // MAIN CERTIFICATE
                // -------------------------
                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT c.*, h.Name AS WelderName, h.WelderCode, h.Employer
                    FROM Certificates c
                    JOIN Hitsari h ON c.WelderID = h.WelderID
                    WHERE c.Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", certificateId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            model.Id = certificateId;
                            model.CertificateName = reader["CertificateName"].ToString();
                            model.WelderName = reader["WelderName"].ToString();
                            model.WelderCode = reader["WelderCode"].ToString();
                            model.Employer = reader["Employer"].ToString();
                            model.IssuingAuthority = reader["IssuingAuthority"].ToString();
                            model.IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                            model.ExpiryDate = Convert.ToDateTime(reader["ExpiryDate"]);
                            model.WeldingPosition = reader["WeldingPosition"].ToString();
                            model.ProductType = reader["ProductType"].ToString();

                            model.MaterialThickness = Convert.ToDecimal(reader["MaterialThickness"]);
                            model.PipeDiameter = Convert.ToDecimal(reader["OutsidePipeDiameter"]);
                            model.TestSupervisorName = reader["TestSupervisorName"].ToString();
                            model.ExaminationBody = reader["ExaminationBody"].ToString();
                            model.ExaminationSignature = reader["ExaminationSignature"].ToString();
                            model.Remarks = reader["Remarks"].ToString();
                        }
                    }
                }

                // -------------------------
                // JOINT TYPES
                // -------------------------
                model.JointTypes = new List<string>();

                using (SqlCommand cmd = new SqlCommand(
                    "SELECT JointType FROM CertificateJointTypes WHERE CertificateId = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", certificateId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            model.JointTypes.Add(reader["JointType"].ToString());
                        }
                    }
                }

                // -------------------------
                // PARENT MATERIALS
                // -------------------------
                model.ParentMaterials = new List<string>();

                using (SqlCommand cmd = new SqlCommand(
                    "SELECT MaterialGroup FROM CertificateParentMaterials WHERE CertificateId = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", certificateId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            model.ParentMaterials.Add(reader["MaterialGroup"].ToString());
                        }
                    }
                }

                // -------------------------
                // PROCESS DETAILS
                // -------------------------
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
                                FillerMaterialDesignation = reader["FillerMaterialDesignation"].ToString(),
                                FillerMaterialTradeName = reader["FillerMaterialTradeName"].ToString(),
                                FillerMaterialType = reader["FillerMaterialType"].ToString(),
                                Polarity = reader["TypeOfCurrentPolarity"].ToString(),
                                Auxiliaries = reader["Auxiliaries"].ToString(),
                                ShieldingGas = reader["ShieldingGas"].ToString(),
                                WeldDetails = reader["WeldDetails"].ToString()
                            });
                        }
                    }
                }
            }

            return model;
        }
    }
}
