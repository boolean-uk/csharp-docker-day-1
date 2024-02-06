# C# Docker Day 1 Exercise

## Learning Objectives

- Deploy the exercise.wwwapi API project to a Docker Container

## Instructions

1. Fork this repository
2. Clone your fork to your machine
3. Open the project 

## Core

Create an API with the usual GET/PUT/POST/DELETE endpoints. 

The API should serve user data for students attending a bootcamp.

The data for students should include:

* Unique ID
* First Name
* Last Name
* Date of Birth
* Course Title
* Start Date for Course
* Average Grade 

Your API should connect to an ElephantSQL database instance that can be used for storing the data.

Create a `Dockerfile` and any other associated files to allow you to deploy the application using a Docker Container.

Make sure your `

.json` file is on `.gitignore` so that it doesn't contain your private database connection strings. To assess this we will clone your repository, add our own credentials to the cloned repository and use those to test that the application works as expected.

## Extension

In addition to the Student details add in details of different Courses and reference them from the Student details as a Foreign Key relationship. The endpoints for Courses should be completed as expected.
