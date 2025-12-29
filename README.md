# LCB Clone

**Reference Website:** https://www.leg.state.nv.us/

This project is a **learning-focused clone** of the Nevada Legislative Counsel Bureau public website. It is intended to deepen my understanding of **C# and ASP.NET Core web development**, with an emphasis on **maintainable API architecture** realistic data models, and enterprise-style project structure.

This repository is **actively under development** and is not intended for production use.

---

## Goals

- Learn C# and .NET in the context of web application development
- Design a robust, modular REST API
- Create a frontend to display and manipulate API data
- Implement role-based access (users vs administrators)
- Model core NELIS concepts, including:
  - Legislators
  - Bills
  - Committees
  - Sessions
  - Committee Meetings
  - Interim Meetings and schedules
- Allow administrators to perform authenticated POST/PUT/DELETE operations

---

## Current Focus

- Legislator domain model
- Legislator API routes
- Overall project structure and layering

---

## Technology Stack

- C#
- .NET 8
- ASP.NET Core (Minimal APIs, with planned transition to controllers)
- Entity Framework Core
- Neovim
- .NET CLI build tooling

---

## Planned Work

### API (Highest Priority)

- Session model
- Bill model
- Resolution model
- Petition model
- Budget model
- Committee model
- Floor session model

### Unit Testing (Second Priority)

- Create tests for:
  - Creating a legislator
  - Retrieving a single legislator
  - Retrieving all legislators
  - Updating a legislator
  - Deleting a legislator

### Frontend (Lower Priority)

- Blazor-based frontend
- Initial NELIS homepage

### Desktop Client (Exploratory)

- Research cross-platform options
- Target Linux and Windows compatibility

---

## Completed

- Root (`/`) route and basic HTML/CSS homepage
- Understanding and implementation of DTOs

---

## Development Approach

- Build backend functionality first
- Add unit tests after each feature
- Develop HTML pages incrementally
- Apply styling after core functionality is stable

---

## Status

**Active learning project**
