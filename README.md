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

## Important dates
* Start: **25.02.2020**
* Presentation: **12.05.2020**

## Team
* Mike Schmid
* Luca Tavernini
* Sascha Gschwind

## Ideas
* Master-PW Verteilung
* Hangman Game
* Wett-App
* Tracking/Monitoring-App
* Issue-Reporting (z.B. Internetausfall)

## Technologies
### Possible Technology Stack
* [Traefik](https://docs.traefik.io/) for load balancing
* [Docker](https://docs.docker.com/) for deployment / used by load balancing
* [ASP.NET Core Web Api](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.1&tabs=visual-studio) for text protocol
* [React](https://reactjs.org/) with [Typescript](https://www.typescriptlang.org/) for frontend
* [gRPC](https://docs.microsoft.com/en-us/aspnet/core/grpc/?view=aspnetcore-3.1) for binary protocol
* [Protobuf](https://developers.google.com/protocol-buffers/docs/csharptutorial) for KV storage
* [Traefik Auth Middleware](https://docs.traefik.io/middlewares/basicauth/) for authentication
* [IdentityServer4](https://identityserver4.readthedocs.io/en/latest/) for authentication
