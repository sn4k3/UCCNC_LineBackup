# UCCNC_LineBackup
GCode Lline backup plugin for UCCNC

While program is running the current line will keep saving to a buffer with 2 backups in case of corruption. 
In any case if current run didn't finish (RESET, program stop, UCCNC crash, power loss, other event), 
on next UCCNC start a message will show with information about previous run. 
Otherwise if program finish the backups are deleted.
