using DataBaseA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseA.Models;


namespace DataBaseA.Services
{
    public class CertificateService
    {
        private readonly CertificateRepository _repository;

        public CertificateService(CertificateRepository repository)
        {
            _repository = repository;
        }

        public CertificateModel GetFullCertificate(int certificateId)
        {
            return _repository.GetCertificate(certificateId);
        }
    }
}
