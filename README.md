JSONFileStore
=============

Simple JSONFileStore using JSON.NET.
Lets you persist simple object  to a textfile.
Usefull for simple config files.

Features
=========
* Construct a FileStore by specifying a source directory  and file name;
* Use the FileStore.Write method to write any given object as json to the specified file
* User the FileStore.Reqd method to read any persisted object in the specified file
