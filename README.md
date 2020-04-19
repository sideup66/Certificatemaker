# Certificatemaker
Create a certificate that is customizable and compatible with titaniumwebproxy in this project.

This tool is pretty straightforward to use, it will add the certificate to the user who installs titaniumwebproxy based of customized settings
in the config.ini file. This can simply be edited with a text editor of your liking


USAGE:
titaniumwebproxycertmaker.exe /install -- installs a certificate
titaniumwebproxycertmaker.exe /uninstall -- uninstalls a certificate based on the RootCert.pfx file in its directory and delete the RootCert.pfx file
titaniumwebproxycertmaker.exe /reinstall -- will uninstall the cert and generate a new one and install it in same fashion of the above switches
