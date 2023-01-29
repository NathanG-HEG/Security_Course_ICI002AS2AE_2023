# Homework 2 - GOAT

## x) Read and summarize (This subtask x does not require tests with a computer. Some bullets per article is enough for your summary, feel free to write more if you like)

### OWASP: OWASP 10 2021 
**A05:2021 – Security Misconfiguration**
- As softwares get more configurable, vulnerabilities from misconfiguration are increasing
- Examples of misconfiguration: unnecesary features up and runnning, default accounts credentials, over informative error message, out of date software
- Examples of prevention mechanism: locked down environmnent (Dev, QA, Prod), minimal installation, permissions review, segmented architecture, containerization, ACLs, settings verification processes


**A06:2021 – Vulnerable and Outdated Components**
- Keep track which versions are components and dependencies you use
- Keep track of support lifetime of software
- Scan for vulnerabilities and subscribe to security news related to software you use
- Remove unused or unnecessary features
- Obtain components from official sources over secure pipelines
- Consider deploying patch to protect against issues if components are unmaintained


**A03:2021 – Injection**
- High incidence rate
- Sanitize user input
- Use parameterized queries
- Test all parameters (cookies, JSON, SOAP, etc.)
- Never use client-side data sanitization


### Any episode from Darknet Diaries.

### Pick a CVE, and briefly explain it & why it matters
**[CVE-2022-41323](https://cve.mitre.org/cgi-bin/cvename.cgi?name=CVE-2022-41323)**

*In Django 3.2 before 3.2.16, 4.0 before 4.0.8, and 4.1 before 4.1.2, internationalized URLs were subject to a potential denial of service attack via the locale parameter, which is treated as a regular expression.*

Local parameters in url treated by Django < 3.2.16 were treated as a regex, meaning that a very long parameter could utilize a lot of CPU resources and cause a denial of service. International URL means translating an url in native language script into ascii text.

E.g attack
```
日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語日本語.idn.icann.org
```

This attack has no impact on the service apart from availability. However it is extremely simple to execute.


## a) Sequel. Solve SQLZoo: 

### 0 SELECT basics
1.
```SQL
SELECT population FROM world WHERE name = 'Germany';
```
2.
```SQL
SELECT name, population FROM world WHERE name IN ('Sweden', 'Norway', 'Denmark');
```
3.
```SQL
SELECT name, area FROM world WHERE area BETWEEN 200000 AND 250000;
```

### 2 SELECT from World, from first subtask to 5 "France, Germany, Italy"
1.
```SQL
SELECT name, continent, population FROM world;
```
2.
```SQL
SELECT name FROM world WHERE population > 200000000;
```
3.
```SQL
SELECT name, gdp/population as GDP_per_capita FROM world WHERE population > 200000000;
```
4.
```SQL
SELECT name, population/1000000 as population_in_millions FROM world WHERE continent = 'South America';
```
5.
```SQL
SELECT name, population FROM world WHERE name IN ('France', 'Germany', 'Italy');
```
6.
```SQL
SELECT name FROM world WHERE name LIKE '%United%';
```
7.
```SQL
SELECT name, population, area FROM world WHERE area > 3000000 OR population > 250000000;
```
8.
```SQL
SELECT name, population, area FROM world WHERE (population > 250000000 AND area < 3000000) OR (population < 250000000 AND area > 3000000);
```
9.
```SQL
SELECT name, ROUND(population/1000000,2), round(gdp/1000000000,2) FROM world WHERE continent = 'South America';
```
10. 
```SQL
SELECT name, ROUND(GDP/population/1000,0)*1000 as per_capita_GDP FROM world WHERE GDP > 1000000000000;
``` 
11. 
```SQL
SELECT name, LEN(name), capital, LEN(capital) FROM world WHERE LEN(name) = LEN(capital);
``` 
12. 
```SQL
SELECT name, capital FROM world WHERE LEFT(name, 1) = LEFT(capital, 1) AND name <> capital;
``` 
13. 
```SQL
# Beurk
SELECT name
FROM world
WHERE name LIKE '%A%'
AND name LIKE '%E%'
AND name LIKE '%I%'
AND name LIKE '%O%'
AND name LIKE '%U%'
AND name LIKE '%a%'
AND name LIKE '%e%'
AND name LIKE '%i%'
AND name LIKE '%o%'
AND name LIKE '%u%'
AND name NOT LIKE '% %';
``` 

## b) Injected. Solve WebGoat:

### A1 Injection (intro)
Solution in [homework 1](../h1/README.md#sql-injection-intro)

## m) Voluntary bonus: Pick your tasks from SQLZoo 1, 3-9.

## n) Voluntary difficult bonus: WebGoat: SQL Injection (advanced).

## o) Voluntary difficult bonus: Install a relational database, show CRUD operations using SQL

## q) Voluntary difficult bonus: Demonstrate aggregate functions (SUM, COUNT) with your own data you created in the previous step.

## p) Voluntary difficult bonus: Install a practice target for SQL injections, exploit it.

## r) Voluntary difficult bonus: Demonstrate JOIN with your own database