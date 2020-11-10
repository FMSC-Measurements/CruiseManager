The installer can be ran in two modes: Install for all users or Install for just the current user.

You can control which mode the installer runs by using `/ALLUSERS` or `/CURRENTUSER` when running the installer from the command line.

Once the application has been installed new versions will install using the same install mode as before. 

When running in 'All Users' mode. The installer will install to the machines Program Files(x86) folder. Also template files will be copied over into the documents folder for each user on the PC. Selecting a custom install location will be disabled.

When running in 'Current User' mode. The installer will install to the `%localAppData%\Programs\` directory and templates will only be copied into the current users documents folder.

When templates are deployed the are first unpacked into the `{app}/Templates` folder and then copied into the users Documents folder. At the end of the install process the `{app}/Templates` is deleted. This is to prevent accumulation of old templates over time. 