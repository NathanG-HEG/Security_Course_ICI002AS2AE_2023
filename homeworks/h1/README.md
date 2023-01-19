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