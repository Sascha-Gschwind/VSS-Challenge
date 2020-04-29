# VSS-Challenge
## Requirements
1. Use at least one text protocol, at least one binary protocol
2. Load balancing
3. Scalable service with authentication 
* Non-scalable storage (you can build it scalable if you want)
* Self-hosted preferred 
* The solution may use existing libraries and code, but those must be allowed to be published under an open software license

## Goal
1. Simple Frontend (e.g., HTML, Vue, React) 
2. Loadbalancer (e.g., traefik) 
3. Two instances of a service (your choice) (REST / HTTP / ZeroMQ / Protobuf) 
    1. Coin tracker, survey / form, monitor application health, … 
4. One KV storage backend (Protobuf)
5. Authentication (e.g., basic auth)

## Decicions
* We will implement a shopping list API
* Kubernetes for loadbalancing and basic auth
* ASP.NET Core REST API
* PostgreSQL Database
* Kubernetes -> kubemanifest.yml
* Talend API Tester Chrome Extension | Postman

## Setup/ Environments
* Visual Studio 2019 / 2017
* .NET Core 3.1
* Docker Desktop
* (PostgreSQL)

## Local Dev Environment - SQL Setup
* PostgreSQL (local installation)
* Database 'shoppinglist' with owner 'shoppinglistadmin' and password 'shoppinglistadmin'
* Table 'items' with columns 'id' (INTEGER, Primary Key) and 'value' (TEXT) with owner 'shoppinglistadmin' 

## Important dates
* Start: **25.02.2020**
* Presentation: **12.05.2020**

## Team
* Luca Tavernini
* Mike Schmid
* Sascha Gschwind

## Technologies
### Possible Technology Stack

* [Docker](https://docs.docker.com/) for deployment / used by load balancing
* [ASP.NET Core Web Api](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.1&tabs=visual-studio) for text protocol
* [gRPC](https://docs.microsoft.com/en-us/aspnet/core/grpc/?view=aspnetcore-3.1) for binary protocol
* [Kubernetes](https://kubernetes.io/docs/tutorials/kubernetes-basics/) extends docker.
