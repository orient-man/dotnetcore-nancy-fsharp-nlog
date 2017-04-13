@echo off
cls

cd %~dp0
packages\FAKE\tools\FAKE.exe build.fsx %*