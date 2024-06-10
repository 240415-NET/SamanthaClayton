console.log("Hello class!");

// Use node IntroToJS.js to run the code
// Instead of "dotnet run"

// Same comments as C# and do ; at the end of the line

let number = 20;
console.log(number);
number = "Hello world!";
console.log(number);

/* This kind of comment works in JavaScript too */

// JavaScript will run sequentially from top to bottom
// of the file. You can notice that we will not be using
// any sort of the Main method equivalent



// Variable declaration

// Let is used for variables that we want to be capable
// of being reassigned
// It is block scoped, so if I declare using let inside
// of a function, it can only be seen within
// the scope of that function


let name = "pancake";

// Const is used for constants i.e., variables
// that we do not want to change during run time
// It is also block scoped, the same way that let is
const age = 17;

// There's a third way to declare varibales in JS
// called "var" but it's kind of looked down on.
// Variables declared using var are globally scoped
// AND mutable.  This can cause many issues.
var dontDoThis = "seriously please dont";

// Data Types
// JS has some built-in primitive types. Here is an
// example of a few of them that will come up most often.


// numbers - used to represent both integers and floating point numbers
    // not really a dilineation but there are bignumbers

let myNumber = 11.5;

//strings
//represents a series of characters - we can use single
// quotes, double quotes, or backticks
// backticks are used for string literals or template strings

let dogName = "Ellie";
let steveName = 'Steve';
//String literal example
let message = `${dogName} is due for a vet appointment!`;
console.log(message);

// String literals are useful for multi-line blocks of text
let longMessage = `Here's my long message and i just love
it so much, it is really great, i mean just so great, really,
really great.  best message i have ever seen in my
whole entire life. wow.`

//We will be using these string literals liberally
// to store things like dynamic HTML updating
let htmlToUpdate = `<li>something to update</li>
                    <li> something else to update</li>`

// Beyond strings, we have booleans. They hold a true or false
let flag = true;



// In JS, we have a dileneation between things that are undefined 
// and things that are null

// Undefined - represents an uninitalized variable
let corey; // this would be undefined
console.log(corey);

// null - represents the intentional absence of any value
let ross = null;
console.log(ross);

//object data types
//objects - kind of resembles json
let person =
{
    name: "Ron",
    hobby: "Birding",
    vehicle: {// our objects can have other objects nested inside of them
        make: "Morgan",
        model: "3-wheeler"
    }
};

// We can access the properties of an object using dot notation
//just like C#
console.log(person.name);
console.log(person.vehicle.model);

//Arrays - arrays in JS behave like lists in C#.  They are
//dynamic and have their own built in functions.
// WE cna also access specific indices using the myArray[3] syntax
// They are last in, first out with things like push (add an
// to the end )

let numbers = [2, 5, 7, 10, 1];

//This method sort an array alphabetically ... dum

numbers.sort();

console.log(numbers);

// I cna also add to arrays and remove items from arrays dynamically
numbers.push(33); //adding a new item to my array
console.log(numbers);
numbers.pop(); // removes the last element of an array
console.log(numbers);

// Dates - dates in javascript are *TECHNICALLY*
// represented under the hood by an integer
//This iteger denotes the time IN MILLISECONDS
// that has passed ince the beginning of the Unix 
// file system
// So it's the time in millisecnds since Jan 1st, 1970 UTC time.

let firstDate = Date();

console.log(firstDate);
//could also do let firstDate = new Date(); but the new isn't required in JS

let firstDate2024 = Date(2024);
console.log(firstDate2024);


let Date2023 = Date(2023);
console.log(Date2023);

let DateWithNew = new Date();
console.log(DateWithNew);

let DateWithNew2 = new Date(2024);
console.log(DateWithNew2);

// Maps - equivalent to a C# dictionary
// stores things in key value pairs
// we can use the .get() function to lookup via a key

let myMap = new Map();
myMap.set("pet", "ellie");
myMap.set(2, "the value of 2");
console.log(myMap.get(2));
console.log(myMap.get("pet"));


// Sets - collection of unique values (cannot have duplicates)
let mySet = new Set ([1,3,5,6]);
console.log(mySet);
mySet.add(1); // adding a non-unique value to my set does nothing
console.log(mySet);
mySet.add(48);
console.log(mySet);

//similar to c# here
let numberagain = 10;
numberagain = numberagain + 30;
console.log(numberagain);

// Note - In JS, functions themselves are first-class objects
// like all the others above. Tha tmeans we can do some weirder
// stuff.  We can assign a function a variable, we can pass
// functions as arguments to other functions, and we can even
// return a function as the result of...

// We do have a way to check type in JS, ismilar to C#
//using "typeof"

console.log(typeof 5);
console.log(typeof 'hello');
console.log(typeof true);
console.log(typeof numberagain);
console.log(typeof firstDate);


// Type coercion in JavaScript
// Strings - when a non-string is added to a string, JS converts
// the non-string into a string and concats the value
let example = "52" + 5;
console.log(example);
console.log(typeof example);

//  Numbers - when a string or boolean is used in a math operatoin
// (except using +)
// JS converts it to a number
// For booleans, true will convert to 1 and false to 0
let otherresult = "5" -3;// works because this is - not + because + concats it
let result = '5' - 3;// works because this is - not + because + concats it
console.log(result);
console.log(typeof result);
console.log(otherresult);

let result2 = 1 + true;// since true evaluates to the number 1, this resolves to 2
console.log(result2);

// Boolean coercion - everything in JS is either "truthy" or "falsy"
// Truthy - literally everything that is not "falsy"
// Falsy - boolean value false, 0, -0, 0n, "" (empty string), null, undefined, Nan (not a number)

if(''){
    console.log("This will not run because empty strings are falsy");
}
if(27){
    console.log("This should run as any number besides 0 and -0 is truthy");
}
if(mySet){
    console.log("Again, this should run as it's not in the list of falsy values");
}

// Functions in javascript 

