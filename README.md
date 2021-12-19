# EasySave ANG

Repository of the System Programming block of group 5

This file will be updated during the development of our application. For a school project of CESI EXIA, our team composed of 4 students has designed "EasySave". Our team has just integrated the software editor ProSoft. Under the responsibility of the CIO, our goal is to manage and design the "EasySave" project. This project consists in developing a backup software. As any software of the ProSoft Suite, our software "EasySave" will be integrated to the following pricing policy:

* Unit price: 200 € HT
* Annual maintenance contract 5/7 8-17h (including updates): 12% of the purchase price (annual contract with tacit renewal and revaluation based on the SYNTEC index)
---
## Tools

In this perspective we used
The following tools :
* Visual Studio 2019 16.3 or higher
* GIT
* UML editor: Visual-Paradigm
Languages and FrameWork :
* C# language
* Net.Core 3.X library


---

## Release Note V1.0:
* 25-11-2021 - Version 1 consoles EasySave v1.0: in this first version our software is realized in console line without graphical interface 
Features:
* Create a backup job defined by a name, a source path, a destination path and a backup type (full or differential)
* Create up to 5 backup jobs
* Display the created backups
* Execute one of the backup jobs or run all the jobs sequentially
* Generate log files and status files
* Use of our program by English and French speaking users

## Instructions for use:

* When launching our software a display of the name of our software will appear.
* The user has the choice of language between French and English.
* The user has the choice to create or execute a backup job.
![alt text](https://github.com/RayCookie/EasySave/blob/master/easysave/Screen/image%20(2).png)
* Create a backup job:
Entering the number 2 means that you are going to add a backup job, you will enter the name of your backup job, the source path from where you want to retrieve the folder to be backed up and also specify the path of the target folder. After entering this information, you will have to choose whether you want to have a full or differential backup.
By the way, a reminder that : 
* Full backup: Copies the entire file and folder each time a full backup is performed.
* Differential backup: Only the files modified since the last full backup are backed up.
The backup job is now created.
![alt text](https://github.com/RayCookie/EasySave/blob/master/easysave/Screen/image%20(3).png)

* Run a backup job
Entering the number 3 means that you are going to run a backup job, after that the backup jobs will be displayed and you will be asked to choose whether you want to run a particular backup or run them all sequentially.
* Create a backup job:

![alt text](https://github.com/RayCookie/EasySave/blob/master/easysave/Screen/image%20(4).png)

* Quit the application
By entering the number 0 you will quit the application.

---


## Release Note V2.0:

EasySave 1.0 has been distributed to many customers.

# Improvements:

1) Graphical Interface

Console mode is discontinued. The application is now be developed in WPF under . Net Core

2) Unlimited number of jobs

The number of backup jobs is now unlimited.

3) Cryping via CryptoSoft software

The software is able to encrypt the files using the CryptoSoft software . Only files whose extensions have been defined by the user in the general settings will be encrypted.

4) Evolution of the Log Daily file

The daily log file must contain additional information

Time required to encrypt the file (in ms)

0: no encryption

>0: encryption time (in ms)

<0: error code

5) Business Software

The presence of business software is detected, the software must prohibit the launch of a backup job. In the case of sequential work, the software will complete the work in progress and stop before starting the next work. The user will be able to define the business software in the general parameters of the software. (Note: the calculator application  is the default business software)

---


## Release Note V3.0:

The requested evolutions for this new version EasySave 3.0 are :

# Improvements:

1) Parallel backup

Backup jobs will be done in parallel (no more sequential mode).

2) Priority files management

No backup of a non-priority file can be done as long as there are priority files pending on at least one job. Files whose extensions are declared by the user in a predefined list (present in the general parameters) are considered as priority files.

3) Prohibition of simultaneous transfer of files of more than n KB

In order not to saturate the bandwidth, it is forbidden to transfer at the same time two files whose size is greater than n Kb. (n Kb can be set)

Remark: during the transfer of a file larger than n Kb, the other jobs can transfer files whose sizes are smaller (subject to the respect of the priority files rule)

4) Real-time interaction with each job or all jobs ( functinnality in progress ) 

For each backup job (or set of jobs), the user must be able to

Pause (effective pause after the current file transfer)

Play (start or resume a pause)

Stop (immediate stop of the work and the task in progress)

The user must be able to follow the progress of each job in real time (at least a percentage of progress).

5) Temporary pause if a business software is detected

If the software detects the operation of a business software, it must pause the transfer of files

Example: if the calculator application is launched, all the tasks must be paused.

6) Remote console ( funtionnality in progress)

In order to follow in real time the progress of the backups on a remote workstation, you must develop a GUI allowing a user to follow the progress of the backups on a remote workstation but also to act on them

The minimum specifications of this console are :

- Design mode: WPF and FrameWork .NetCore

- Communication via Sockets.

7) The application is Mono-instance.

The application cannot be launched more than once on the same computer


---


## Release Note V1.1:

Following the feedback, the management required us to release as soon as possible a version 1.1 that allows the user to choose the format of the log file (XML or JSON).


# Improvements:

This functionality is implemented in version 2.0

Version 1.1 must be released at the latest at the same time as version 2.0


---


## Team:
* Denfir Rayen
* Diag Mohammed
* Haddidi Slimane
* Allache Faten
* Haddouche Othmane
                 
 
