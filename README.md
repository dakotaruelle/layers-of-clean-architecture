# The Layers of Clean Architecture

This project demonstrates the different levels of clean architecture and how you can incrementally add layers of
architecture as an application grows. The project starts with a simple .NET web api and then gradually refactors it to
follow clean architecture principles.

Each heading below represents a commit in this repository in linear order. Each commit can be checked out to see what
the project looked like at that point in time.

The project domain revolves around the concept of students and assigning them courses. The logic and domain models are 
extremely simple. They are just there to have something to work with. While the logic itself is trivial, it is the
organization of the logic that is important.

## Starting Point - (No Architecture)

This is the starting point of the application. There is no architecture, just a web api with a few methods.

## Move Data Access Logic to Gateway

The controller was directly accessing the database context (using Entity Framework as an ORM) to perform data
retrieval. This set of changes moves all data access logic to a gateway class. It is the job of this class to
perform all logic related to querying the database and returning those results.

## Move Business Logic to Interactor

Similar to the last set of changes, this moves business logic out of the controller and into a dedicated interactor
class. It is the job of the interactor to coordinate between the controller, gateway, and entities (coming later), to
perform the use cases of the application.

## Move UI Logic to Presenter

This moves the UI Logic (i.e. formatting of responses to the UI) to a presenter class. It is the job of the presenter
to handle the concerns that only the UI cares about.

## Add Models Specific to Business Layer

The previous changes organized all the logic into their respective layers. This change is aimed at types in particular,
and adds a new set of models specifically for the business layer. The goal is to remove the data access types from being
used throughout the other layers. Now, when data is retrieved from the gateway, it return business layer types instead
of data access layer types.

## Move Business and Data Access Layers into Separate Projects

Functionally, nothing is changed in this commit. The business and data access logic are now in their own separate
projects. However, in order for the data access layer to depend on the business layer, the gateway now implements an 
interface in the business layer. In .NET land, this means that the `Gateways` project has a reference to the `Interactors` 
project. This ensures that dependencies are pointed "inwards", in other words, that the business layer is the core of 
the application.

## Move Translation Logic into Separate Project

This is a smaller change. It moves the mapping logic from data access types to business types. While not strictly
necessary, in a larger project with lots of types and many interactors/gateways, it might be useful to have this logic
in a dedicated project.
