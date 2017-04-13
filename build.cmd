@echo off
cls

.paket\paket.bootstrapper.exe
if errorlevel 1 (
  exit /b %errorlevel%
)

rem .paket\paket.exe restore
rem if errorlevel 1 (
rem  exit /b %errorlevel%
rem )

packages\FAKE\tools\FAKE.exe build.fsx %*
