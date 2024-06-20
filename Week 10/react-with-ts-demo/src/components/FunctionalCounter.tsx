// First off, I will import React (so I get access to all the React library methods,
// we may or may not use them).
// I also import something called useState.  useState is a "hook".
// Hooks allow functional components to remember and pass information
// related to their "state"
// State referring to changes or updates based on user interaction

import React, {useState} from 'react';

// Creating a function - the React.FC gives us access to stuff
// So here we declare our functional component definition.  We can use
// this syntax or the traditional "function MyFunctionalComponent = {}"
// syntax.  Whatever is easier to wrap your head around.
// We want to bring in the
// React.FC 
// No real reason or advantage to doing one or the other:
// const FunctionalCounter : React.FC = () => {}
// -OR-
// function FunctionalCounter() {}
const FunctionalCounter : React.FC = () => {
    // Declare a variable to hold a count (the amount of times the user
    // clicks a button).  This will track our component's "state."
    // setCount is a predefined method in React.
    const [count, setCount] = useState(0);
    // he tried this and it didnt work
    // const count = useState(0);
    //const setCount = useState(0);
    
    // This functional component will be both our logic and our HTML.
    // Create a function that will increment our count
    const increment = () => setCount(count + 1); 
    
    // Create a function that will decrement the count
    const decrement = () => setCount(count - 1);

    // Once we create our variables for state, bring in whatever
    // arguments from outsie of our component we need.  Create functions
    // to do things based on those inputs, etc.
    // We will create a return.
    // This return is where our HTML that will be rendered will be written.
    // For the div below, he started with <div className = ''> and that was
    // a slight difference from normal HTML wheere it's <div class=...

    return (
        <div>
            <h3>This is my functional counting component</h3>
            {/* This is a commnet inside of my TSX file's HTML.
            This wil not render.
            Notice below we have a slight change to our break tag
            with the ending forward slash.  HTML written inside
            of a react component does not like self closing tags.
            There are some other slight syntax differences that we
            will encounter as we use react. */}
            <br />
            {/* Inside of return for my component, it expects HTML.
            We can break out of our HTML and call upon TypeScript by using
            curling braces*/}
            <p>Count: {count}</p>
            <button onClick={increment}>Increment the count</button>
            <button onClick={decrement}>Decrement the count</button>



        </div>
    );
}

//function FunctionalCounter2() {
//}

// Whatever syntax for writing our TypeScript function for our component, we 
// must remember to export it at the end.  This is what will make it visible
// across our application.
export default FunctionalCounter;
//export default FunctionalCounter2;
