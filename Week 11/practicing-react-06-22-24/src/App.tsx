import React from 'react';
import './App.css';

function App() {

  let name : string; // Declaring a variable 'name' and the type is string.
  let age : number;
  let isStudent : boolean;
  let hobbies : string[];
  let role : [number, string]; // Declaring a variable 'role' and this is a
  // tuple where you have 1 number and 1 string.  A tuple has a fixed
  // number of values and we say what the type of those values will be.
  // To assign a value to this, you would do role = [5, "hi"];


  //let person : Object;
  // You can do this, but this is not a recommended way
  // to do this because an object can have a lot of properties inside of it.
  // For example, it can have age, name, etc.  How do we know that this person
  // object has all of those properties?  So we use something called a 'type'
  // keyword or an 'interface' keyword.  For now, we'll add in 'type' stuff before
  // we declare the person.

    // We are going to add in the 'type' stuff now so we can declare a
  // variable of that type.  It's a good practice to keep first letter
  // of the type a capital letter.


  type Person = {
    name : string;
    age? : number;   // If you want to make a property optional, add a ?

  };

  let person : Person = {
    name: "Samantha",
    age: 36, // can remove this if you want because age is optional
  }

  let lotsOfPeople : Person[];

  // What if we want our age variable to be a number and a string?
  // We use something called union.
  let age2 : number | string;
  
  // If we want to define a function
  //function printName(name) {
  //  console.log(name);
  //}

  // When do you the above, you get an error saying "'name'
  // implicitly has an 'any' type"
  // So what you do is give it the type
  function printName(name : string) {
    console.log(name);
  }

  printName("Samantha"); // This will print it to the "Console" inside of the dev tools in the browser

  // There are 2 ways to define a function
  let printName2: Function;
  // You can do this, but just like objects, there's better ways to assign a function.
  // So what we can do is properly define the function of how many times it'll contain.
  // It's going to take the name, which is a string and it'll return a void (since we're
  // just printing to the console.)
  // let functionName : (argumentName:argumentType) => returnType;
  // returnType could be a string, number, void, a custom return type like a Person
  // object
  let printName3 : (name:string) => void;
  let printName4 : (name: string) => never;
  // void returns undefined
  // never doesn't return anything

  // If we want a variable to have any value, can use 'any' as the type
  // This isn't recommended because in TypeScript, you want to give specific types.
  let name2: any;

  // Instead of any, you can use unknown. This is recommended instead of any.
  let name3: unknown;

  // Aliases:  There are 2 types of aliases:
  // 1. Type
  // 2. Interface

  type Person2 = {
    name: string;
    age?: number;
  }

  interface Person3 { // no = for an interface
    name: string;
    age?: number;
  }

  // Explaining type:  Let's say you have type X and type Y

  type X = {
    a: string;
    b: number;
  }

  type Y = {
    c: string;
    d: number;
  }
// What if you want to use the properties in type X inside of type Y?

type Y2 = X & {
  c: string;
  d: number;
}

// Y2 will include all of the Y2 properties and all of X's properties too

let y2: Y2 = {
  a: "yo",
  b: 52,
  c: "hey there",
  d: 4,
}

// Now let's look at an interface

interface A {
  w: string;
  x: number;
}
interface B {
  y: string;
  z: number
}

// If you want to extend A in the B interface
interface B2 extends A {
  y: string;
  z: number
}

let b2 : B2 = {
  w: "hey",
  x: 5,
  y: "hi",
  z: 5
}

// He goes onto say that interfaces are a lot easier to extend,
// which I don't really get because there's not much difference between
// interface B2 extends A {
// type Y2 = X & {

// What if you want the properties of an interface (B2) inside of a type (X2)?
type X2 = B2 & {
  j: string;
  k: number
}

// Can also have an interface that has the properties of a type 
interface A2 extends X {
  l: string;
  m: number;
}

  

  return (
    <div className="App">
      Hello World!
    </div>
  );
}

export default App;
