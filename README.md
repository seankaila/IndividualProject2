# IndividualProject: Magic 8 Ball

# Table of contents
1. [Brief](#Brief)
2. [Architecture](#Architecture)
    1. [Database ERD](#Database-ERD)
    2. [Use Case Diagram](#Use-Case-Diagram)
    3. [Service Architecture Diagram](#Service-Architecture-Diagram)
3. [Project Management](#Project-Management)
    1. [Kanban Board](#Kanban-Board)
    2. [Full User Stories](#Full-User-Stories)
    3. [Risk Management](#Risk-Management)
4. [Testing](#Testing)
    1. [Code Coverage Report](#Code-Coverage-Report)
5. [Terraform](#Terraform)
6. [Continuous Integration Pipeline and Best-Practices](#Continuous-Integration-Pipeline-and-Best-Practices)
    1. [CI Pipeline](#CI-Pipeline)
    2. [Best practices](#Best-practices)
7. [Known Issues & Futher Improvements](#Known-Issues-&-Futher-Improvements)
8. [Final Functioning Front-End](#Final-Functioning-Front-End)
9. [Acknowledgements](#Acknowledgements)
10. [Author](#Author)

## Brief 
This project is intended to demonstrate the knowledge from training with QA. To do this I was tasked to create an application that generates an object based upon a set of predefined rules, testing the application though unit testing & deploying the application using github ations. Terrafrom will be used to reate the resources used for the project (Four app services & one Mysql Database). Data generated by these services will then be stored in a mySQL database hosted in Azure.

## Architecture

### Database Table
![image](https://user-images.githubusercontent.com/82107182/122677807-da925c00-d1db-11eb-8f42-a9390cb9b6b3.png)
Once a user asks a question, their questions and responses are recorded to a MySQL database. This Diagram describes the entities inside the database used in the project. As we can see the table is using an “ID” as a primary key, to uniquely identify rows of data from a table. The “Question” and “Answer” entity uses strings as data types and the “Probability” is represented using the data type of an integer.

### Use Case Diagram 
![image](https://user-images.githubusercontent.com/82107182/123182724-f15cdb00-d487-11eb-9912-2fe8cac91abd.png)
This diagram describes how a user will typically use the system. The user will have access to a home page. Here the user will be able to "ask a question" then be sent to an answer page where they receive a response. This response contains: The question, an answer and a probability and the ability to ask another question. The user will then have the opportunity to view the past questions and answers along with the probability assigned to them. This is the history page.

### Service Architecture Diagram
![image](https://user-images.githubusercontent.com/82107182/123182394-3af8f600-d487-11eb-90bf-6dd8cd1c4c57.png)
This service architecture diagram describes the how the data flows from each API to the end user. As we can see service 2 & 3 generate a random answer and character respectively. Service 4 then gets that data and concatenates it. Service 4 then produces a probability based on service 3s response. Therefore service 1/ The front end gets service fours output (concatenated answer & probability) and saves it to a MySQL database. The front end interacts with this database by reading and writing this data.

## Project Management 

### Kanban Board
To track and understand the progress of my project I used Azure DevOps to create a Kanban Board. This board was split up into different sections.

- Epics: These are high level categories each user story refers to. 
 ![image](https://user-images.githubusercontent.com/82107182/123100387-fd667f80-d42a-11eb-93eb-679ada12d48e.png)
- User Stories: These are derived from the Epics, detailing what a user what’s to do and why they want to do that action. 
- Tasks: These contain low level tasks needed for a user story / epic to be deemed completed.
 ![image](https://user-images.githubusercontent.com/82107182/123101003-84b3f300-d42b-11eb-9152-85c5319800cc.png)


#### Kanban Board layout: 
- New: User stories that needed to be started were stored here.
- Active: User stories that were currently being worked on.
- Closed: User stories and tasks that were completed.
![image](https://user-images.githubusercontent.com/82107182/123111345-bed5c280-d434-11eb-84c5-96f56e802939.png)

Link to Kanban Board: https://dev.azure.com/dharmindraskaila/Individual-Project-2/_boards/board/t/Individual-Project-2%20Team/Stories

#### Full User Stories
- As a user I would like to ask a question to the application. So that I can get a response generated by service 4.
- As a user I expect to see all past questions displayed on a separate page. So that it will be easier to scroll though the history of all the past questions and answers. These past questions will be pulled from a MySQL database.
- As a user I would like to see the response from a question that was asked on the home screen on an answer screen. So that I can see the Question asked, Answer and probability in a separate view.  Response should be saved to a MySQL database for later use. 
- This service should call service 2 & 3, then concatenate the responses. Assigning it a variable called Answers. So that when the API is called it gives the correct response.
- As a user I want the probability generated from the output of service 3. For example: When A is outputted the probability of 100 is given.
A = 100, B = 80, C = 60, D = 40, E = 20 (Anything else is 404). So that users can see the probability of their answers being true.
- As a user I want the output of this service to give me one of these possible answers: "A", "B", "C", "D", "E". So that we can understand the quality of the randomly generated answer.
- As a user I want the output of this service to give me one of these possible answers: "It is Certain", "Without a doubt", "You may rely on it", "Most likely", "Don't count on it", "My reply is no", "My sources say no", "Very doubtful". So that the app creates a feeling of a real 8 ball.


### Risk Management
![image](https://user-images.githubusercontent.com/82107182/123129184-a7ea9c80-d443-11eb-8a28-66a212532bcd.png)
A simple risk assessment was performed during the project. Each risk was described and evaluated along with a rating to understand the severity of the risk. To expand upon this, I provided an update to each risk checking to see if they changed in anyway.


## Testing
![image](https://user-images.githubusercontent.com/82107182/123129423-d799a480-d443-11eb-8b87-cb056eb5409f.png) <br/>
Like the last project, the AAA testing pattern was used to create appropriate tests for each service of the project. As we can see, all 13 tests passed spanning 4 different controllers (3 web APIs & 1 web app). A range of tests were included within this project. For example: Testing what would happen if a user didn’t enter a question.

### Code Coverage Report
![image](https://user-images.githubusercontent.com/82107182/123132743-f77e9780-d446-11eb-8bff-5bd020554cd5.png)
From the summary above we can see that the overall code coverage of the project is sitting at a strong 73.4%. This is a massive improvement from the last project as code that shouldn’t be tested isn’t being covered by the report generator. Giving us a better understand of the potential areas of concern. This number could have been higher, but the views haven’t been tested. This negatively affecting the coverage. To Test the views, integration testing was needed to be taught but due to time it wasn’t.

![image](https://user-images.githubusercontent.com/82107182/123133520-b935a800-d447-11eb-9353-162a0c0bf30e.png)
As we can see every controller tested had a code coverage of 100%. This a good because it means that main logic within the app doesn’t have any run times errors. But may be susceptible to logical errors that I didn’t account for or see during development. A way to fully understand the logical errors would be by conducting integration tests, which incorporate inputs from the front end.

![image](https://user-images.githubusercontent.com/82107182/123136078-70332300-d44a-11eb-8149-9df7c6147b90.png)
![image](https://user-images.githubusercontent.com/82107182/123136318-b5efeb80-d44a-11eb-99de-22a44cf43e91.png)
Strangely, one area not being covered in my tests was this history class. Used for mapping data for the database. The class above is being referenced by two tests but it’s not being covered by the code coverage. This is something I cannot explain and therefore need to do more research on testing.

## Terraform
![image](https://user-images.githubusercontent.com/82107182/123146727-1f292c00-d456-11eb-9310-1bcde8ccb128.png)
To build the resource group, all four app services, the MySQL database above and the app service plan, I used Terraform. This allowed me to create all these resources using code instead of the GUI. This is a great way of creating objects in Azure because its faster and more efficient. Allowing me to also make changes the what’s on azure if something needs changing. For example: Adding in a "project: true" tag so that my app services and MySQL Database doesn’t get deleted at 6pm.

![image](https://user-images.githubusercontent.com/82107182/123146885-50096100-d456-11eb-95b5-f01375396191.png)
The screenshot above shows me successfully making a change to my Terraform, highlighting that one change has been made. This was done by running the commands " Terraform plan" prepares the changes then "Terraform apply" to finalize the changes.

## Continuous Integration Pipeline and Best Practices

### CI Pipeline 
![image](https://user-images.githubusercontent.com/82107182/123141608-788e5c80-d450-11eb-9300-dfca8ade3840.png)
Using GitHub Actions, I was able to deploy my project to my app services in azure. To do this I used four YAML files. One for each service and one for the actual asp.net web app. To make this process look a lot less complicated and easier to follow, I should have used one YAML file instead of four.

![image](https://user-images.githubusercontent.com/82107182/123142389-47faf280-d451-11eb-920a-7a305e7a3d59.png)
As we can see the YAML files does multiple jobs, getting the project ready to publish and deploy. From the screenshot above, we can see that the build job is just checking for any build errors before going into the test job.

### Best practices
![image](https://user-images.githubusercontent.com/82107182/123172859-a5089f80-d475-11eb-823c-6ef8f14f6df0.png)
During this project’s life cycle, I adhered to multiple best practices. For example: Documenting code with inline comments, describing what certain things operations do. This was done so that people outside the project could really understand how certain functions / operations worked if they were ever to take the project off my hand and expand upon it.

![image](https://user-images.githubusercontent.com/82107182/123173183-1e07f700-d476-11eb-8628-967be0116c5f.png)
![image](https://user-images.githubusercontent.com/82107182/123173352-62939280-d476-11eb-8a0e-e285585aef7b.png)
![image](https://user-images.githubusercontent.com/82107182/123173449-8525ab80-d476-11eb-99e2-793413de7c17.png) <br/>
Another example of best practices can be seen in my use of GitIgnore file. For security reasons I didn’t push certain files up to GitHub. For Example: My Terraform files. This is because they contain sensitive information. My Main.tf contained connections strings that contained password and other sensitive information surrounding my database. These ignores were done at the very start of the project. So that there was no chance that individuals could go back though the commits and find sensitive information. From the screenshots above we know these files are being ignored because the text is greyed out on visual code (A red circle is used on visual studio). Anything that wasn’t necessary to the project wasn’t pushed up.

A very simple branching model was used within this project. As the user requirements were so small, I didn’t feel the need to do a Git flow branching model like my previous project. Instead using a couple of branches to version control my work.


## Known Issues & Futher Improvements
- The YAML file that deploys the project needs to be condensed down into one file so that it easier to understand and manage the deployment in the future. 
- On an IOS device a user can refresh the answer page by "submitting the form again" button producing multiple entries to the database. To fix this I would do some further testing with mobiles in mind.
- Find a way to test the views in the future. As the front end is just as important as the back end and needs testing too.
- Make use of variables more efficiently in terraform files. As a simple solution of duplicating the same Webapp with a different name was used in this project. Therefore, there is redundant configuration in each webapp at this moment of time.
- GitHub Actions can sometimes be down. Therefore, you won’t be able to deploy your recent changes. This is something out of my control. In the event this happens during the presentation, then referrer to a video I have made. Here you will see me making a change via a branch and deploying that change. 
![image](https://user-images.githubusercontent.com/82107182/123218166-4d912080-d4c3-11eb-8bfb-dbfa768bd43a.png)

## Final Functioning Front-End
![image](https://user-images.githubusercontent.com/82107182/122682754-3ae0c800-d1f3-11eb-9187-1e13da03184a.png)
![image](https://user-images.githubusercontent.com/82107182/122682783-5b108700-d1f3-11eb-984f-fe265a53d6f6.png)
![image](https://user-images.githubusercontent.com/82107182/122682797-7085b100-d1f3-11eb-87fc-e70f4ed37a12.png)

## Acknowledgements
- Ben Hesketh
- Dara Oladapo
- Victoria Sacre

## Author
Dharmindra Sean Kaila
