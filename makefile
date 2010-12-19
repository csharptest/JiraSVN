# *****************************************************************************
# JiraSVN MAKEFILE
# *****************************************************************************
!IF EXIST(src\version.txt)
!INCLUDE src\version.txt
!ENDIF
#
!MESSAGE JiraSVN make utility $(Major).$(Minor).$(Build).$(Revision)
!MESSAGE
.SILENT:
# *****************************************************************************
# TOOLS
MSBuild=%WinDir%\Microsoft.NET\Framework\v3.5\MSBuild.exe /nologo

!IF "$(VS90COMNTOOLS)" != ""
DevEnv="$(VS90COMNTOOLS)..\IDE\devenv.exe"
!ELSE
!ERROR Visual studio not found, check env setting VS90COMNTOOLS
!ENDIF
# *****************************************************************************

all : prerequisites always
	$(DevEnv) JiraSvn.sln /Rebuild Release /Out bin\Release\build.log

build : prerequisites always
    $(MSBuild) JiraSvn.sln /t:Clean;Rebuild /v:q /p:Platform="Any CPU" /p:Configuration=Debug \
        /fileLogger /fileLoggerParameters:LogFile=bin\Debug\build.log;Verbosity=Detailed;Encoding=UTF-8

clean : always
    if exist bin\* @rd /q /s .\bin
    mkdir .\bin
    mkdir .\bin\Debug
    mkdir .\bin\Release
    $(MSBuild) JiraSvn.sln /t:Clean /v:q /p:Platform="Any CPU" /p:Configuration=Debug

# *****************************************************************************

prerequisites : \
    keys\jirasvn.snk \
    src\version.txt \
    addcopy

keys\jirasvn.snk :
    ECHO WARNING: Using shared key, you should replace $@ with your own key
    copy keys\trash.snk $@

#creates new version number by running: nmake.exe -a src\version.txt
src\version.txt :
    tools\StampVersion.exe /nologo /major:2 /minor:{0:yy} /build:{0:MMdd} /revision:{0:hmm} > src\version.txt

addcopy : always
    tools\StampCopyright.exe /nologo tools\copyright.txt src\*.csproj

# *****************************************************************************

always: