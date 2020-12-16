# Blockchain Online Polling System

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

## Preface
Elections are regarded as the heart of any democrary. Through an election, citizens are able to choose and elect their representives, shape the government policy and hold politicians
accountable. A voting process is so important because it affects the foreground in the Parliament composition.

## Problem & Challenge
Online voting and e-democracy platforms are subject to certain problems that undermine the definitive nature and certainty of the process:

- Who controls the online platform?
- How can I be certain that the votes are counted correctly?
- Who ensures the system availability for the duration of the election?
- How can I be certain that votes are not being tampered by a third-party?

## Focus On
The fundamental idea of the Blockchain solution is to match a vote transaction to a vote cast by an elector in support of the candidate selected by the voter.

Every vote therefore benefits from the characteristics of a Blockchain transaction, namely: 
- It is non-modifiable
- It is non-repudiable
- It cannot be registered in multiple ways
- All nodes possess a valid copy.

## Proposed Solution
We propose a full-fledged e-voting system to manage the whole electoral system.
A user will walk into a government authorized center and complete his/her National Identity Number verification. Once the verification is complete, the user will be taken to a web-based portal where s/he will be presented with the voting options. The portal then sends the information of the user's vote (encrypted) to backend where the data will be decrypted and the vote's transaction from the user to the candidate will take place using the a blockchain service. 
The candidate with the most votes is elected. 
During each election time the users who have already voted - are logged in the form of an `audit-trail` which will make sure only one transaction can be made by the user during the whole election process.

## Workflow Diagram

![Untitled Diagram-Page-4](https://user-images.githubusercontent.com/23207774/102358081-87d7ad80-3fc8-11eb-8cef-073ce5606170.png)

## Tools
- [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/)
- [SQL Server 2017](https://www.microsoft.com/en-us/sql-server/sql-server-2017)
- [Docker](https://hub.docker.com/editions/community/docker-ce-desktop-windows)
- [SourceTree](https://www.sourcetreeapp.com/)

## Development Prerequisites 
- [ASP.NET Core 3.1 or higher](https://dotnet.microsoft.com/learn/aspnet/what-is-aspnet-core)
- [SQL](https://www.w3schools.com/sql/sql_intro.asp)
- [Bootstrap](https://getbootstrap.com/)
- [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
- [RabbitMq](https://www.rabbitmq.com/)

## Running Locally
We use [Docker Compose](https://docs.docker.com/compose/) to run the solution locally. To bring up the infrastrure required, the `docker-compose.infra.yml` file can be executed:

```
docker-compose -f ./docker-compose.infra.yml up -d
```

## Solution Structure

The e-voting system has been seperated into different projects, as follows:

### ESC.WebApp
This the management portal to manage an electoral process, such as voter, party, candidate registration and election creation. 

### Poll.Simulator
This is the actual online polling station where the voters will be able to cast their votes.

## Database Migrations
To seed the database prior running the application, execute the script [eco_schema_data.sql](https://github.com/hamsheed-salamut/blockchain-poll-simulator/blob/main/eco_schema_data.sql) on the sql database.
