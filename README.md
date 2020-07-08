# UCCNC_LineBackup
GCode line backup plugin for UCCNC

While program is running the current line will keep saving to a buffer with 2 backups in case of corruption. 
In any case if current run didn't finish (RESET, program stop, UCCNC crash, power loss, other event), 
on next UCCNC start a message will show with information about previous run. 
Otherwise if program finish the backups are deleted and no message will be shown.

![Screenshot](https://raw.githubusercontent.com/sn4k3/UCCNC_LineBackup/master/Example.png)

# Instalation

1. Copy the .dll file to plugin folder
2. Enable plugin under UCCNC settings
3. Restart UCCNC

# Usage Tip

1. If you plan resume the work, is good practice to start from previous line and not the actual shown by the plugin.