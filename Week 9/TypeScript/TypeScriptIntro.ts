console.log("Here");


// This is my TypeScrpipt file.  Notice that it ends in a .ts
// extension. This file cannot be run as it is by node. We need to call the
// TypeScript Compiler using the tsc NameOFile.ts to compile it
// (essentially translate it) into a .js file. Then you can use
// node NameOfFile.js to run that generated JavaScript file.
// If you intend to work with a .ts in your project 2, generate the
// .js file and attach that via the script tag in your HTML's
// file body.

// Simple/Variable Types: These come in from JS. They are things like
// string, number, boolean, etc. WE can use typescript's explicit
// typing on these variables via the following syntax.

let myBoolean: boolean = true;
let accountBalance: number = 13.74;
let petName: string = "Ziggy";

// Unless disabled in the tsconfig.json file, we can still use implicit/
// inferred typing in typescript. However, the compiler will catch you
// while you're coding if you try to violate the type of that variable

let username = "jon123";
//username = 143; - This results in an error because TS is still enforcing
//its type system even for variables whose type was inferred.

// Tuples
// Tuples are useful when you want an array with both a fixed number of elements
// within it and different but defined types for each element
let myFirstTuple: [string, number, boolean];
myFirstTuple = ["This is inside my tuple at element 0. It HAS to be a string", 5, false];
console.log(myFirstTuple);
// This sum is outside of the scope of the addTwoNumbers function
let sum: number = 9;

// Functions
// Functions work similarly to JS, but we can do things like define return and
// argument types
function addTwoNumbers(x: number, y: number): number {
    let sum : number = 0;
    sum = x + y;
    return sum;
}

console.log(addTwoNumbers(3.67, 113.7));


console.log(sum);

// Arrays
// Arrays in TS are going to work the same as in JS with the added
// benefit of type safety
// (behaves like a list in C#)
let numberList: number[] = [5, 12, 9, 88];
numberList.push(55);

let petNameList: string[] = ['pancake', 'ellie'];
// petNameList.push(10); - won't let you add a number

console.log(numberList);
console.log(petNameList);

petNameList.forEach((petName) => {
    console.log(petName)
});

//Enums
// A special data structure (also in many other languages such as
// C# and java) that represent a group of constants.
// They can be either string or numeric.
// Enums are useful when you want to group together
// a set of specific values
enum Cardinals {
    North = "north",
    East = "east",
    South = "south",
    West = "west"
}

console.log(Cardinals.East);

enum numericalCardinals {
    North = 1,
    East = 2,
    South = 4,
    West = 8
}
console.log(numericalCardinals.West);

// Type aliases
// Type aliases are used to create a new name for a user defined type
// Here we say that we have a "pet" type and it must be either "cat" or
// "dog". If we try to give a variable of type "pet" 
type pet = "cat" | "dog";

let ellie: pet = "dog";
//let pancake: pet = "gator"; gives an error

// Here we define a user defined type of type userId and say that it MUST be a number

type userId = number;
let myUserId: userId = 9384938;

// Interfaces
// Interfaces are used to define the structure of an object
// They provide a way to ensure that an objcet adheres to a specific "shape"
// This can be leveraged ot make sure we get specific types of JSON 
// return for example
interface User {
    userId: string;
    userName: string;
    age?: number; // We can use the question mark to mark a property in an interface as optional.
    // It's not that the property will be null, but that it's not required to be in the
    // objects of this interface at all.
}

let josh : User = {userId: "123-456", userName: "Josh"};
console.log(josh);

// Classes
// Classes can provide implementation details like methods and constructors
// whereas interfaces are used to define only the structure of the object.
// Classes are the blueprint for objects and their behaviors and can be
// instantiated; Interfaces cannot.

interface Animal {
    species: String;
}


// Classes can have access modifiers
// public - can be seen from anywhere in our code
// private - can ONLY be seen from within the class the field is declared in (not its children)
// protected - can be seen from the class it was declared in as well as its child classes
// default in TypeScript is public if you don't set one

class Bird implements Animal {
    species: string;
    private birdHeight: number; // have to give a default value or some way in a constructor for it to get a value
    birdWeight: number;
    birdColor: string;
    
    constructor(species: string, height: number, weight: number, color: string)
    {
        this.species = species;
        this.birdHeight = height;
        this.birdWeight = weight;
        this.birdColor = color; 
    } 
    // Unlike interfaces, we can define methods that belong to objects of this class
    birdCall() : string{
        return `I am a ${this.species}`;
    }
}

let yellowWarbler = new Bird("yellow warbler", 5, 0.36, "yellow");
console.log(yellowWarbler.birdCall());

class Dunlin extends Bird {

    constructor(species: string, height: number, weight: number, color: string)
    { super(species, height,weight, color); // Calling the constructor inherited from Bird

    }
    dunlinActivities() : string {
        return `*Things that dunlins like to do!*`

    
    // because birdHeight is private can't do ${this.birdHeight} in the string above
    //could do that if it's public or protected

    }
}

// Now if we create a new Dunlin object, it has access to all of the methods
// and fields from both bird and Dunlin, and it inherits the implementation
// of the Animal interface implemented in Bird

let myDunlin = new Dunlin("Dunlin", 7, 3, "gray");
console.log(myDunlin.birdCall());
console.log(myDunlin.dunlinActivities());

// We made birdHeight private, so we can use the bird constructor
// But we can't do 
// console.log(myDunlin.birdheight);

// Casting 
let num : number = 12;
console.log(num as unknown as string);

type Admin = {
    name: string,
    adminDuties: string[]
}

type NormalEmployee = {
    name: string,
    startDate: Date;
}

type SuperEmployee = Admin & NormalEmployee; // This would be an example of
// an intersection type that gets the properties of both of the types that
// compose it. (Not something you see in C#).
// In our SuperEmployee, the name fields collapse into a single field.

let ross : SuperEmployee = {
    name: "Ross",
    adminDuties: [
        "change diapers",
        "drive to/from school",
        "solve rubik's cubes",
        "some more things to do",
        "and another one"
    ],
    startDate: new Date()
}

console.log(ross);

// Union Type
type UnionDemo = string | number;
let myUnion : UnionDemo = "any string";// or any number, can't give it a boolean or anything else

type Employee = Admin | NormalEmployee;
let unionRoss : Employee = ross; // can do this because ross is already an admin so it works

type Comparable = string | number;

//Type guard
// A function that does stuff based on what input type it gets
function comparableTypeGuard(arg: Comparable)
{
    if(typeof arg === "string")
        {
            return `stuff related to arg being a string`; 
        }
    if(typeof arg ==="number")
        {
            return arg * arg;
        }
}

let myComparable : Comparable = 20;
let myNewComparable  : Comparable = "thank goodness it's friday";

console.log(comparableTypeGuard(myComparable));
console.log(comparableTypeGuard(myNewComparable));


