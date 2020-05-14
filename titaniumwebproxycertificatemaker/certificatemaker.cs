using System;
using Titanium.Web.Proxy;
using System.IO;

namespace titaniumwebproxycertificatemaker
{
    class certificatemaker
    {
        static void Main(string[] args)
        {
            //read in the config file, if it exists
            //read in the config file, if there is one, if not, use a default settings
            //declare cert values with default entries
            string CertIssuerName = "CertificateGenerator";
            string CertName = "CertMakername";
            try
            {
                if (File.Exists("UserConfig.ini"))
                {
                    string line;
                    StreamReader reader = new StreamReader("UserConfig.ini");
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains("CertIssuerName:"))
                        {
                            CertIssuerName = line.Replace("CertIssuerName:", "");
                        }
                        if (line.Contains("CertName:"))
                        {
                            CertName = line.Replace("CertName:", "");
                        }
                    }

                }
            }
            catch
            {
                Console.WriteLine("There was a problem reading the Configuration File! default values will be used...");
            }

            //read in the switch provided that tells us whether to make a cert or remove an existing cert
            foreach (string arg in args)
            {
                if (arg.ToString().ToLower().Contains("/install"))
                {
                    //install the certficiate
                    Console.WriteLine("Installing certificate,please wait...");
                    Console.WriteLine("You may get a prompt to install a certificate with the name you specified. Please click YES on the prompt...");
                    InstallCert(CertIssuerName, CertName);
                }
                else if (arg.ToString().ToLower().Contains("/uninstall"))
                {
                    //Uninstall the certificate
                    Console.WriteLine("Uninstalling certificate, please wait...");
                    UninstallCert();
                }
                else if (arg.ToString().ToLower().Contains("/reinstall"))
                {
                    //reinstall the certificate by uninstalling, then installing the certificate
                    Console.WriteLine("Reinstalling certificate, please wait...");
                    UninstallCert();
                    InstallCert(CertIssuerName, CertName);
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
            Console.WriteLine("Press enter to continue...");
            Console.WriteLine("This program uses Titanium Web proxy, which is licensed under the MIT License agreement");
            Console.WriteLine("Info can be found here: https://github.com/justcoding121/Titanium-Web-Proxy/");
            Console.ReadKey();
        }
        private static void InstallCert(string CertIssuerName, string CertName)
        {
            //make a certificate and install it based on what is in the config file

            //declare a proxy object
            ProxyServer proxyServer = new ProxyServer();
            proxyServer.CertificateManager.RootCertificateIssuerName = CertIssuerName;
            proxyServer.CertificateManager.RootCertificateName = CertName;
            //install the certificate into the system root store
            proxyServer.CertificateManager.EnsureRootCertificate(false,true,true);

        }
        private static void UninstallCert()
        {
            //uninstall the created certificate
            ProxyServer proxyServer = new ProxyServer();
            proxyServer.CertificateManager.LoadRootCertificate("RootCert.pfx", "", false);
            //may not need to start the proxy here, as we are just removing a cert, to install we need to start
            proxyServer.CertificateManager.RemoveTrustedRootCertificate(true);
            //lastly we delete the file
            if (File.Exists("RootCert.pfx"))
            {
                File.Delete("RootCert.pfx");
            }
        }

    }
}
