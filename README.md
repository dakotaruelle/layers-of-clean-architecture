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
