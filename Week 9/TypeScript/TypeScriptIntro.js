var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
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
var myBoolean = true;
var accountBalance = 13.74;
var petName = "Ziggy";
// Unless disabled in the tsconfig.json file, we can still use implicit/
// inferred typing in typescript. However, the compiler will catch you
// while you're coding if you try to violate the type of that variable
var username = "jon123";
//username = 143; - This results in an error because TS is still enforcing
//its type system even for variables whose type was inferred.
// Tuples
// Tuples are useful when you want an array with both a fixed number of elements
// within it and different but defined types for each element
var myFirstTuple;
myFirstTuple = ["This is inside my tuple at element 0. It HAS to be a string", 5, false];
console.log(myFirstTuple);
// This sum is outside of the scope of the addTwoNumbers function
var sum = 9;
// Functions
// Functions work similarly to JS, but we can do things like define return and
// argument types
function addTwoNumbers(x, y) {
    var sum = 0;
    sum = x + y;
    return sum;
}
console.log(addTwoNumbers(3.67, 113.7));
console.log(sum);
// Arrays
// Arrays in TS are going to work the same as in JS with the added
// benefit of type safety
// (behaves like a list in C#)
var numberList = [5, 12, 9, 88];
numberList.push(55);
var petNameList = ['pancake', 'ellie'];
// petNameList.push(10); - won't let you add a number
console.log(numberList);
console.log(petNameList);
petNameList.forEach(function (petName) {
    console.log(petName);
});
//Enums
// A special data structure (also in many other languages such as
// C# and java) that represent a group of constants.
// They can be either string or numeric.
// Enums are useful when you want to group together
// a set of specific values
var Cardinals;
(function (Cardinals) {
    Cardinals["North"] = "north";
    Cardinals["East"] = "east";
    Cardinals["South"] = "south";
    Cardinals["West"] = "west";
})(Cardinals || (Cardinals = {}));
console.log(Cardinals.East);
var numericalCardinals;
(function (numericalCardinals) {
    numericalCardinals[numericalCardinals["North"] = 1] = "North";
    numericalCardinals[numericalCardinals["East"] = 2] = "East";
    numericalCardinals[numericalCardinals["South"] = 4] = "South";
    numericalCardinals[numericalCardinals["West"] = 8] = "West";
})(numericalCardinals || (numericalCardinals = {}));
console.log(numericalCardinals.West);
var ellie = "dog";
var myUserId = 9384938;
var josh = { userId: "123-456", userName: "Josh" };
console.log(josh);
// Classes can have access modifiers
// public - can be seen from anywhere in our code
// private - can ONLY be seen from within the class the field is declared in (not its children)
// protected - can be seen from the class it was declared in as well as its child classes
// default in TypeScript is public if you don't set one
var Bird = /** @class */ (function () {
    function Bird(species, height, weight, color) {
        this.species = species;
        this.birdHeight = height;
        this.birdWeight = weight;
        this.birdColor = color;
    }
    // Unlike interfaces, we can define methods that belong to objects of this class
    Bird.prototype.birdCall = function () {
        return "I am a ".concat(this.species);
    };
    return Bird;
}());
var yellowWarbler = new Bird("yellow warbler", 5, 0.36, "yellow");
console.log(yellowWarbler.birdCall());
var Dunlin = /** @class */ (function (_super) {
    __extends(Dunlin, _super);
    function Dunlin(species, height, weight, color) {
        return _super.call(this, species, height, weight, color) || this; // Calling the constructor inherited from Bird
    }
    Dunlin.prototype.dunlinActivities = function () {
        return "*Things that dunlins like to do!*";
        // because birdHeight is private can't do ${this.birdHeight} in the string above
        //could do that if it's public or protected
    };
    return Dunlin;
}(Bird));
// Now if we create a new Dunlin object, it has access to all of the methods
// and fields from both bird and Dunlin, and it inherits the implementation
// of the Animal interface implemented in Bird
var myDunlin = new Dunlin("Dunlin", 7, 3, "gray");
console.log(myDunlin.birdCall());
console.log(myDunlin.dunlinActivities());
// We made birdHeight private, so we can use the bird constructor
// But we can't do 
// console.log(myDunlin.birdheight);
// Casting 
var num = 12;
console.log(num);
// an intersection type that gets the properties of both of the types that
// compose it. (Not something you see in C#).
// In our SuperEmployee, the name fields collapse into a single field.
var ross = {
    name: "Ross",
    adminDuties: [
        "change diapers",
        "drive to/from school",
        "solve rubik's cubes",
        "some more things to do",
        "and another one"
    ],
    startDate: new Date()
};
console.log(ross);
