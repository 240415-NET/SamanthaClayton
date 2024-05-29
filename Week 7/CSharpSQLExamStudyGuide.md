# C#/SQL Exam Study Guide

## Git
    1. What is Git?
    2. What is Gitbash?
    3. How do we create a branch?
    4. How do we clone a repo?
    5. Git add, commit, push, & pull
    6. What does Git allow us to do in a collaborative environment?

## C#/OOP
    1. What are the OOP fundamentals? (4 Pillars of OOP)
        1. Abstraction
        2. Encapsulation
        3. Inheritance
        4. Polymorphism
    2. What does the syntax look like for
        1. Implementing an interface
        2. Inheriting from a parent class
        3. Declaring a collection of some specific type
    3. Exception handling (Try-Catch-Finally)
    4. Within a class...
        1. What are class members? (fields/methods)
        2. How do we declare a property (using {get; set;})?
        3. What is a constructor? What does it allow us to do?
            1. How/when do we call it?
    5. Access modifiers (public vs. private vs. internal)
    6. Control Flow
        1. Loops
        2. If-elseif-else
        3. Switch
        4. Comparison operators (==, !=, >=, <=)
        5. For loops vs. foreach
    7. What is an interface?
        1. How are they used?
        2. How do they compare/contrast to a class?
    8. List vs. dictionary
        1. Both are collections, but how do they differ?
    9. What does the .csproj file in our project contain?
        1. Metadata about our project (e.g., its name)
        2. Package reference we brought in via Nuget (thing we 'dotnet add'-ed)
        3. Project references to other .csproj files that we want to bundle together, such as xUnit testing projects

## SQL
    1. SQL Sublanguages (DML, DQL, DDL, DCL)
        1. Data Query Langguage (DQL) - SELECT
        2. Data Definition Language (DDL) - CREATE, DROP, ALTER, TRUNCATE
        3. Data Manipulation Language (DML) - INSERT, UPDATE, DELETE
        4. Data Control Language (DCL)* - GRANT, REVOKE 
    2. SELECTS with filters inside (SELECT WHERE)
    3. Basics of Joins
        1. What is a join?
        2. What do they do/return for us?
        3. Inner vs. outer join & left vs. right joins
        4. Null values in a table & joins - how do nulls behave within a join query?
    4. What are the properties of a primary key in SQL? (unique & not null)
    5. What is a foreign key?

## ADO.NET
    1. What is ADO.NET at a high level?
    2. What does it let us do in our projects?
    3. What is a connection string?
    4. What is the datareader in ADO.NET?
        1. What is its behavior?
            1. Read only: can't use it to put things in
            2. Forward only: advances through a row, column by column, and cant go back