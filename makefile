# *****************************************************************************
# JiraSVN MAKEFILE
# *****************************************************************************
!MESSAGE JiraSVN make utility
!MESSAGE
.SILENT:
# *****************************************************************************
# TOOLS
MSBuild=%WinDir%\Microsoft.NET\Framework\v3.5\MSBuild.exe /nologo
DevEnv="$(VS90COMNTOOLS)..\IDE\devenv.exe"
# *****************************************************************************

all : prerequisites always
	$(DevEnv) JiraSvn.sln /Rebuild Release /Out bin\build.log

build : prerequisites always
    $(MSBuild) JiraSvn.sln /t:Clean;Rebuild /v:q /p:Platform="Any CPU" /p:Configuration=Debug \
        /fileLogger /fileLoggerParameters:LogFile=bin\build.log;Verbosity=Detailed;Encoding=UTF-8

clean : always
    if exist bin\* @rd /q /s .\bin
    mkdir .\bin
    $(MSBuild) JiraSvn.sln /t:Clean /v:q /p:Platform="Any CPU" /p:Configuration=Debug

# *****************************************************************************

prerequisites : \
    keys\jirasvn.snk \
    bin\version.txt \
    addcopy

keys\jirasvn.snk :
    ECHO WARNING: Using shared key, you should replace $@ with your own key
    copy keys\trash.snk $@

bin\version.txt :
    tools\StampVersion.exe /nologo /major:2 /minor:{0:yy} /build:{0:MMdd} /revision:{0:hmm} > bin\version.txt

addcopy : always
    tools\StampCopyright.exe /nologo tools\copyright.txt src\*.csproj

# *****************************************************************************

always: