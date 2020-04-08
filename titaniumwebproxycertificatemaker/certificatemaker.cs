using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace titaniumwebproxycertificatemaker
{
    class certificatemaker
    {
        static void Main(string[] args)
        {
            //read in the switch provided that tells us whether to make a cert or remove an existing cert
            foreach (string arg in args)
            {
                if (arg.ToString().ToLower().Contains("/install"))
                {
                    //install the certficiate
                    Console.WriteLine("Installing certificate,please wait...");
                }
                else if (arg.ToString().ToLower().Contains("/uninstall"))
                {
                    //Uninstall the certificate
                    Console.WriteLine("Uninstalling certificate, please wait...");
                }
                else if (arg.ToString().ToLower().Contains("/reinstall"))
                {
                    //reinstall the certificate by uninstalling, then installing the certificate
                    Console.WriteLine("Reinstalling certificate, please wait...");
                }
                else
                {
                    //print a help message
                    Help();
                }
            }
            if (args.Length == 0)
            {
                //if there is no arg, also display the help message
                Help();
            }
        }
        private static void Help()
        {
            //show the help message for incorrect input
            Console.WriteLine("Certificatemaker instructions");
            Console.WriteLine("CertificateMaker /install to generate and install the certificate");
            Console.WriteLine("CertificateMaker /uninstall to remove the existing certificate");
            Console.WriteLine("CertificateMaker /reinstall to remove the existing certificate and install a new one");
            Console.WriteLine("Any other switch or no switch will display this help message");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private static void InstallCert()
        {
            //make a certificate and install it
        }
        private static void UninstallCert()
        {
            //uninstall the created certificate
        }
    }
}
