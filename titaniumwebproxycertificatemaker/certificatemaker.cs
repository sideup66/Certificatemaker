﻿using System;
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
                else
                {
                    Console.WriteLine("Certificatemaker instructions");
                    Console.WriteLine("CertificateMaker /install to generate and install the certificate");
                    Console.WriteLine("CertificateMaker /uninstall to remove the existing certificate");
                    Console.WriteLine("Any other switch or no switch will display this help message");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
            Console.ReadLine();
        }
    }
}
