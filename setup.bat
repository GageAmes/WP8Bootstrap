@echo off
set /p name="Enter your application name: " %=%

fart -r -a -i *.cs,*.xaml,*.xml,*.csproj,*.resx "WP8Bootstrap" %name%
fart -r -a -i -f *.* "WP8Bootstrap" %name%
fart -r -a -i *.csproj,*.user,*.sln "WP8Bootstrap" %name%
rename WP8Bootstrap %name%

del fart.exe
del setup.bat
