-- This turns everything in this line into a comment

/*
This is how you do a multiple lines of commenents.
Everything in here is a comment!  WOW!
*/

-- Before we can work with DQL (SELECT), we need data to query
-- We will begin by modeling our User object from TrackMyStuff.

-- We are going to use DDL, specifically the CREATE command to create a table

CREATE TABLE Users (
	-- Give columns names, data types, and any constraints

	-- NVARCHAR = a string of variable length.  We can give a max size if we want.
	-- the max in nvarchar(max) is telling it to use whatever built in max there
	-- is (which is like 4000 characters).
	-- PRIMARY KEY is telling it that this is going to be the way we identify which User is which
	-- It's unique
	-- You could also do NOT NULL PRIMARY KEY
	-- Is there a benefit to using NVARCHAR over VARCAR?
	-- One encodes for character strings and another encodes for unicode strings, but won't matter here
	-- turns out you can't do userId NVARCHAR(max) PRIMARY KEY 
	UserId NVARCHAR(36) PRIMARY KEY,
	-- A GUID is 36 characters
	userName NVARCHAR(30) NOT NULL
	-- NOT NULL here means this column in the database won't accept a null value

);
/* Execute the code and then you can see it in the lefthand side: TrainingDB, Tables, dbo.Users*/

-- Once our users table is created, we can then insert records into it
/* The VALUES have to be in the same order as what's in the Users() in row 36 so
have to give UserId and then UserName in ow 37*/
-- Strings are '' not ""

/* he's getting these from the Users.json in TrackMyStuff */

INSERT INTO Users (userId, userName)
VALUES ('49829828-b257-4553-91e6-ee54d7ed2076', 'David');

INSERT INTO Users (userId, userName)
VALUES ('18249e1f-e1d9-4849-8627-1875c5c169d7', 'Veda');

INSERT INTO Users (userId, userName)
VALUES ('f0a0ecd8-05c8-4e65-90b3-2c595335ac7b', 'jon');
-- Highlight the code and press execute

-- Now that we have data in our table, I can view it using a SELECT statement
-- * instead of typing individual column names

SELECT * FROM Users;

SELECT userName FROM Users;

-- There are many built-in aggregate functions we can use 

SELECT COUNT(*)
FROM Users;


