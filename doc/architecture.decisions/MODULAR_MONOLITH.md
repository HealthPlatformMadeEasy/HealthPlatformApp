# Modular Monolith

## Status

proposed

## Context

Chose the architecture that would fit our needs.

## Decision

Advantage of implement a modular monolithic:

* Easy deployment – One executable file or directory makes deployment easier.

* Development – When an application is built with one code base, it is easier to develop.

* Performance – In a centralized code base and repository, one API can often perform the same function that numerous
  APIs perform with microservices.

* Simplified testing – Since a monolithic application is a single, centralized unit, end-to-end testing can be performed
  faster than with a distributed application.

* Easy debugging – With all code located in one place, it’s easier to follow a request and find an issue.

## Consequences

Disadvantage of implement a modular monolithic:

* Slower development speed – A large, monolithic application makes development more complex and slower.

* Scalability – You can’t scale individual components.

* Reliability – If there’s an error in any module, it could affect the entire application’s availability.

* Barrier to technology adoption – Any changes in the framework or language affects the entire application, making
  changes often expensive and time-consuming.

* Lack of flexibility – A monolith is constrained by the technologies already used in the monolith.

* Deployment – A small change to a monolithic application requires the redeployment of the entire monolith.
