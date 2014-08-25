Practicum-Meals
===============
Requirements:
-------------
Build a console application that accepts time of day and meal ids as inputs and outputs meal.  The output is governed by various rules. 
Other Related Requirements:

1. Object Oriented
2. Readable
3. Maintainable
4. Testable

Project Infrastructure:
-----------------------
Infrastructure required:

1. Windows OS
2. Dot Net 4.5 Installed.
3. Powershell verion 4. For Building and testing (Although >3 should work, but I have only tested on 4.)
4. MSTest Framework. For unit testing
5. Visual Studio 2013. Debuggin


Thrid Party Components:
-----------------------
1. Castle Windsor for IOC and DI

Project Architectural Overview:
--------------------------------
Maintainability can be achieved by 
a) having deep understanding of the project
b) Simplictic coding
c) Reducing the over all regression burden 
d) Simplified deployment to production, with limited risk

All of the above can be achived if the project is broken down in various services.  The console application will be responsiblie
to compose all the services and display output.  From the definition of the project we can identify the following services:
1) UI
2) Business Process
3) Business Rules
4) Input Rules

To address c) Reduce regression burden and d) Simplified Deployment, its necessary that these components evolve indepedently of each 
other.  Secondly by definition of SOA, each component must have a well defined boundry and must share only contracts. The 
contract identified are 
1. Dishes that can be served,
2. Meal - to represent Morning Or Night
3. Input Rules
4. Business Rule

Assuming that this Business process is going to evolve beyond night and morning meals, the implementation of the 'Meal' contract 
must be generated dynamically and more importantly built from the users input.  Also, as the process grows, changes and upgrades 
to the Meals implementation should not affect - or rather - risk to break the user experience. Secondly, it is an added benifit,
if the upgrade of 'Meals' implementation - does not require re compiling of UI.  This applies to all the components and not just 
the 'Meal' implementation.

Project Implementation Details:
-------------------------------
|Serivce | Project Name|
|--------|-------------|
|UI| Practicum.Console|
|Input Rules| Practicum.Rules|
|Business Rules| Practicum.Meal.Rules|
|Business Process| Practicum.Meal|
|Contracts| Practicum.Contracts|


The UI project is the startup project and is responsible to install and prepare DI.  The MealBuilder composes the 
Businss Process and Input Rules services.  All objects are resolved using Windsor.  First the basic
input rules are evaulated.  Castle Windsor builds up the collection of Input Rules.  Its important to note that  the UI
is unaware of how many rules are define and only expects a collection of rules to be passed in.  The input in validated
through each rule and only if all the rules are evaulated successfully- the business process object is built.
Based on the first input parameter, a morning or night meal class is built by conventation -i.e. if the input parameter 
is 'morning' an instance of 'MorningMeal' is create.  This gives us the flexibility of the 2 components upgrading independently. 
The business process also has its set of rules defined.  These rules are injected and are evaulated for each of the meal input
Here again, its important to note, that the Business Process in unaware of how many rules are defined or what the rules are.
Infact, all the services run on a solid assumption that the services they depndent on exist at runtime. 

Building and Execution
----------------------
A powershell script is included which build the solution and copies the necessary libraries into the "Application" folder.
Please run Practicum.Console to see everything in action.
The powershell script also executes unit tests for each of the component.

from Powershell use the command 

```powershell
.\Deploy.ps1
```

from Command Prompt

```
powershell.exe -noexit -file Deploy.ps1
```


