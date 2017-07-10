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
            Console.WriteLine("Archivo Origen:");
            source = Console.ReadLine();
            Console.WriteLine("Archivo destino:");
            dest = Console.ReadLine();

            X509Store objStore = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            objStore.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection certs = null;
            X509Certificate2 objCert = null;
            if (objStore.Certificates != null)
                /* foreach (X509Certificate2 objCertTemp in objStore.Certificates)
                     if (objCertTemp.HasPrivateKey)
                     {
                         objCert = objCertTemp;
                         break;
                     }*/
                certs = objStore.Certificates.Find(X509FindType.FindBySerialNumber, "3a 8a 6f 91 6e fa 10 27 77 1d 93 31 82 64 c7 fd", true);
            objCert = certs[0];

            if (objCert == null)
                Console.WriteLine("No hay certificados  con clave privada");
            else
            {
                PDF.SignHashed(source, dest, objCert, "Prueba", "Argentina", true);

            }
        }


    }
}
