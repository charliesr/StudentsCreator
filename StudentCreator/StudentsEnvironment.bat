@echo off
set StudentTypeValue = %StudentFileType%
IF "%StudentTypeValue%"=="" (setx StudentFileType "txt")