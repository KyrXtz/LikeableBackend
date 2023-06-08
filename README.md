# LikeableBackend: A Powerful Engine for the 3D Printing Community
Imagine a platform where 3D printing enthusiasts could share their creative endeavors, accrue likes, favorites, and even receive orders for their impressive prints. This is what Likeable sets out to offer. To bring this to life, the LikeableBackend was created using .NET 6, utilizing a well-structured Hexagonal/Onion architecture with microservices at its core.
## The Backbone of Good Engineering
The LikeableBackend isn't merely about ensuring functionality. It represents an embodiment of principled engineering practices. Underlying the code, you'll find principles from Domain Driven Design, Clean Code, and CQRS, all neatly separated and arranged. The design further emphasizes the classic SOLID and DRY principles, contributing to a codebase that's robust and maintainable.
## Inside the Domain Model
The domain model is the result of multiple iterations, each one adding a layer of refinement. Here's a snapshot captured in a UML diagram:
![UML Model Diagram](https://github.com/KyrXtz/LikeableBackend/blob/main/UML.drawio.png)
Let's explore the key components:

- Base Entity: The core superclass for all entities, built to provide crucial support for **auditability**.
- Deletable Entity: An extension of the Base Entity, featuring a soft-delete mechanism. This not only maintains **Data Consistency** and **Recoverability** but also leaves room for potential implementation of **Temporal Queries**.
- User: The User Aggregate sits at the heart of the system, built upon the Base User, which in turn inherits from the .Net Identity User interface.
- Item: The Item Aggregate represents the creative output of users, which can be liked, favorited, or ordered. Like other entities, it leverages **Value Objects**, ensuring **immutability** , **domain integrity** and **scalability**.
- Order: The Order Aggregate is a unique entity representing a collection of specific items. Each order receives a unique ID upon generation.
- Selected Item: Certain items can be customized when ordered. This customization is handled through SelectedItem entities, maintaining the **integrity** and **simplicity** of the Item Aggregate.

*The model consciously excludes the functionality of uploading items as it resides within a different bounded context.*

## A Peek into the Architecture
<p align="center">
  <img src="https://github.com/KyrXtz/LikeableBackend/blob/main/onion.drawio.png" />
</p>

Let's delve a little deeper into the layers that make up the LikeableBackend:

- Domain and Shared Kernel: This inner layer houses all the **business logic**, making it available through the shared kernel, while using the **specification pattern** , decoupling the actual object from the business rules it must obey.
- Application and Service: The application layer processes **commands and queries**, formatting data for interaction with the database. The service layer handles **external calls** and provides other **functional services**, like the Current User Service.
- Infrastructure: This layer takes care of **technical operations**, including **database** connection, setting up **Entity Framework Core mappings**, and applying **Filters** to the calls.
- API: The outermost layer serves as the **external interface**, enabling the frontend to **post** and **query** data.

## Getting Technical
Here's a breakdown of some key libraries used in the project

- **.NET 6**: The latest LTS iteration of Microsoft's cross-platform framework used for building cloud, web, and IoT applications.
- **MediatR**: A simple, unambitious library that helps with implementing the Mediator pattern, which in turn helps write decoupled code. It's especially useful for applications with complex business logic.
- **NLog**: A flexible logging platform for .NET, with rich log routing and management capabilities.
- **FluentValidation**: A library for building strongly-typed validation rules in an easy and maintainable manner.
- **Ardalis.GuardClauses**: A simple package that provides guard clause extensions, which helps maintain a clean and readable codebase.
- **Microsoft.EntityFrameworkCore**: An object-database mapper that enables working with a database using .NET objects.
- **Microsoft.AspNetCore.Identity.EntityFrameworkCore**: A package that provides ASP.NET Core Identity as a Razor Library, to quickly add authentication and authorization to your application.
- **Ardalis.EFCore.Extensions**: A package providing several useful extensions for working with EF Core, simplifying the codebase and increasing maintainability.
- **Microsoft.AspNetCore.Authentication.JwtBearer**: A package that allows the server to authenticate users via JSON Web Tokens.
- **Microsoft.EntityFrameworkCore.SqlServer**: A database provider allows Entity Framework Core to be used with Microsoft SQL Server.
- **Swashbuckle.AspNetCore**: A Swagger toolchain that helps build API documentation and testing tools.
- **System.IdentityModel.Tokens.Jwt**: A lower level library for handling JWT tokens, providing greater flexibility and control compared to higher level libraries.

## Wrapping up
LikeableBackend, with its carefully crafted components, forms a solid and efficient backbone for the Likeable platform.   
It ensures a dependable and responsive experience for users, while maintaining the flexibility to support future growth and innovation in the 3D printing community, for example leveraging AI for recommendations based on users' likes and favorites, ensuring the platform stays ahead of user needs and industry trends.   
Essentially LikeableBackend can be the driving force behind a platform that is opening new possibilities for creativity and commerce.
