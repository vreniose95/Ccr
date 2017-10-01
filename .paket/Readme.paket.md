## General

1. PM> `.paket/paket.bootstrapper.exe` only needed for downloading or updating paket.exe
2. PM> `.paket/paket.exe restore` restore packages.
3. PM> `.paket/paket.exe auto-restore on` restore packages on build.
4.a PM> `.paket/paket.exe update` update packages.
4.b PM> `.paket/paket.exe update group GROUPNAME` update packages.
5.a PM> `.paket/paket.exe install` install packages.
5.b PM> `.paket/paket.exe install -f --createnewbindingfiles` install packages and create app.configs with redirects.
6. PM> `.paket/paket.exe outdated` Lists all dependencies that have newer versions available.

## Create packages

1. Build in release
2. PM> `.paket/paket.bootstrapper.exe` only needed for downloading paket.exe
3. PM> `.paket/paket.exe pack publish symbols`
4. Packages are in the publish folder.

Docs: https://fsprojects.github.io/Paket/getting-started.html

[![Build status](https://ci.appveyor.com/api/projects/status/2t900cbaw5xcve5t/branch/master?svg=true)](https://ci.appveyor.com/project/vreniose95/ccr/branch/master)