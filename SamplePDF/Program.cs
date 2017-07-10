using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace SamplePDF
{
    class Program
    {
        static void Main(string[] args)
        {
            string source;
            string dest;
            string certSerial;
            Console.WriteLine("Source PDF File:");
            source = Console.ReadLine();
            Console.WriteLine("Destination PDF File");
            dest = Console.ReadLine();
            Console.WriteLine("Certificate Serial Number");
            certSerial = Console.ReadLine();

            X509Store objStore = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            objStore.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection certs = null;
            X509Certificate2 objCert = null;
            if (objStore.Certificates != null)
            certs = objStore.Certificates.Find(X509FindType.FindBySerialNumber, certSerial, true);

            try
            {
                objCert = certs[0];

                    PDF.SignHashed(source, dest, objCert, true);
                    Console.WriteLine("Sucess");
                    Console.ReadLine();

            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
                Console.ReadLine();
            }
        }


    }
}
