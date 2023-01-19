# Homework 1 - First steps
## x) Read and summarize. (This subtask x does not require tests with a computer. Some bullets per article is enough for your summary)
### Hutchins et al 2011: Intelligence-Driven Computer Network Defense Informed by Analysis of Adversary Campaigns and Intrusion Kill Chains, chapters Abstract, 3.2 Intrusion Kill Chain and 3.3 Courses of Action
- Hello
- Hello
### Karvinen 2020: Command Line Basics Revisited
- reviewed shell command line
- use command tool to navigate the file system,
- manipulate files,
- connect to distant computer or virtual machines,
- administrate your computer's software with package managers

## a) Bandit oh-five. Solve Over The Wire: Bandit the first five levels (0-4).
- Level 0: Connected via SSH using the following command and adding it to the list of known hosts
```shell
ssh -p 2220 bandit0@bandit.labs.overthewire.org
```
- Level 1: Logged in as bandit1 using the password stored in the Readme file (Read it with *cat*)
- Level 2: Logged in as bandit2 using the password stored in the - file (Read it with *cat <-*)
- Level 3: Logged in as bandit3 using the password stored in 'spaces in this filename' (Read it with *cat spaces\ in\ this\ filename*)
- Level 4: Logged in as bandit4 using the password stored in ~/inhere/.hidden (Read it with *cat inhere/.hidden*, find it with *ls -a inhere*)

## b) Bullseye. Install Debian 11-Bullseye virtual machine in VirtualBox. (See also: Karvinen 2021: Install Debian on VirtualBox)
1. Download Debian image, I chose GNOME GUI, but it doesn't really matter.
2. Download and install Oracle VirtualBox.
4. Create a new Virtual machine in VBox, I set 4Gb of memory, 32Gb of virtual disk, and 2 CPU.
3. Add the image to the Storage devices manager in the VM settings.
4. Choose Debian Graphical installer or Live install
5. Here I can not go further as I cannot virtualize Debian with Microsoft Hyper-V

I will use Kali as I have it already prepared in both VBox and WSL 2.0. I will demonstrate instead how to log in via ssh to an headless VM.
1. Create a port forwading rule in your VM's NAT network card settings (Go to advanced).
2. The rule should be as follow Name: any; protocol: TCP; Host IP: can be let empty; Host port: any high port; Guest IP: can be let empty; Guest port: 22.
3. Start the VM and make sure OpenSSH is installed and running *sudo systemctl status ssh*
3. If the program is not installed run *sudo apt install openssh-server*
3. If the program is not active run *sudo systemctl enable ssh --now*
3. Start the VM in headless mode by clicking on *Headless start*
4. Connect to the VM via SSH with the following command:
```shell
ssh -p $choosen_host_port $username@localhost
```

To exit and shutdown the machine run the command *shutdown* with the right privilege.

## c) WebGoat. Install WebGoat practice target. (See also: Karvinen 2021: Install Webgoat 8 - Learn Web Pentesting)
- Did not need to install JRE as my Kali already have OpenJDK 17
- Downloaded the packaged Java app from terokarvinen.com
- Started the server with *java -jar blabla.jar*
- Connected to http://localhost:8080/WebGoat/login via the browser and created my user.

## d) Hacker warmup. Solve these tasks on WebGoat
### General: HTTP Basics
- Found the magic number by checking the header request when submiting the form
### General: Developer tools
- Used Firefox Dev tools to call the phoneHome() function and found the answer in the console
- Found the "network" request and the field networkNum in it.

## n) Voluntary bonus: Banditry. Solve Over the Wire: Bandit 5-7.
- Level 5: Found password in file inhere/-file07 using *cat <-file07*
- Level 6: Found password in file inhere/maybehere07/.file2 using *find -size 1033c*. This finds all files of size 1033 bytes. It is a hidden file!
- Level 7: Found password in /var/lib/dpkg/info/bandit7.password using *find -size 33c -user bandit7 -group bandit6 -type f*

## o) Voluntary bonus: My fundaments. What do you consider the fundamentals of security? What would you teach the first day?
I think the CIA triade is a good point and should be discussed more, I think that if you don't know what the teacher is talking about, you mostly hear a lot of
concpets you may have heard about before but do not truly understand. I would not start with example of attacks, tools, etc, as levels in class vary greatyl.

## p) Voluntary bonus: Johnny Tables. Solve Webgoat: A1 Injection (intro).




