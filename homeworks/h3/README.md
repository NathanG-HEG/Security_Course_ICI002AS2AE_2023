# Homework 3 - Attaaack

## x) Read and summarize (This subtask x does not require tests with a computer. Some bullets per article is enough for your summary, feel free to write more if you like) 

### € Costa-Gazcón 2021: Practical Threat Intelligence and Data-Driven Threat Hunting Chapter 4: Mapping the Adversary (all but "Testing yourself", which is left as voluntary bonus)
- The ATT&CK Framework is a model that allows for labeling and studying capacities of a threat actor.
- It is a common ground for defender and attacker.
- 14 tactics are used to represent different goals:
    - Reconnaissance
    - Resource deployment (Assessing resources)
    - Initial access
    - Execution
    - Persistence
    - Privilege escalation
    - Defense evasion
    - Credential access
    - Discovery
    - Lateral movement
    - Collection
    - Command and control
    - Exfiltration
    - Impact
- [The ATT&CK matrix](https://attack.mitre.org/) is a tool that list different techniques.
- Use the ATT&CK navigator to show the modus operandi of an attacker.
- Formbook is an infostealer in the form of a form-grabbing software.
- Formbook can be described as follow using the ATT&CK Framework:

    1. Steal authorization and login credentials: Credential Access:

        a) T1555 – Credentials from Password Stores

        i) T1555.003 – Credentials from Web Browsers

        b) T1056 – Input Capture

        i) T1056.001 – Keylogging
    2. Keylog information, even if victims use a virtual keyboard, auto-fill, or if they copy and paste: Collection:

        a) T1056 – Input Capture

        i) T1056.001 – Keylogging
        Take screenshots: Collection:

        a) T1113 – Screen Capture


## y) Write an answer with references (this subtask does not require tests with a computer). Answer in the context of Mitre ATT&CK, and pick examples that are different from the chapter in task x. 

### Define tactic and give an example.
A tactic is the reasoning behind a technique, or the goal behind the technique used.

[(The MITRE Corporation. 2022)](https://attack.mitre.org/tactics/enterprise/)

### Define technique and subtechnique, and give an example of each.
A technique is the method used to achieve a goal, fulfill a tactic.

E.g. Spearphishing attachment is a **sub-technique** of the Phishing **technique**.

[(The MITRE Corporation. 2022)](https://attack.mitre.org/techniques/T1566/001/)

### Define procedure, and give an example of each.
A procedure is a set or a list of (sub-)techniques used to achieve a goal.

## a) Webgoat: A3 Sensitive data exposure 

### Insecure Login: 2 Let's try
1. Open [WireShark](https://www.wireshark.org/) (as example, but you can use whatever).
1. Start listening on interface lo, loopback.
1. Enter any data and submit the field using "log in".
1. Apply as a filter *http*.
1. Locate and double click the HTTP packet starting with *POST /WebGoat/start.mvc HTTP/1.1\r\n*
1. Check the content of the line-based plain text data.
1. See the json object 
```json
{"username":"CaptainJack","password":"BlackPearl"}
```
![WireShark screenshot](Wireshark-screenshot.png)
![Packet screenshot](Packet-screenshot.png)

## n) Voluntary bonus: "Testing yourself" in Costa-Gazcón: Practical Threat Intelligence and Data-Driven Threat Hunting Chapter 4: Mapping the Adversary
Not done

## m) Voluntary difficult bonus: WebGoat: SQL Injection (advanced).
Part 1 done in [homework 2](../h2/README.md#n-voluntary-difficult-bonus-webgoat-sql-injection-advanced).

Still no idea how to login as Tom.
