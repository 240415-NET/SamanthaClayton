// Type in RCFE and then hit tab to get the boilerplate function
// First, we import React so we can access all of the
// React library methods (which we may/may not use).
// Here's what the boilerplate import syntax looks like:
// import React from 'react'
// We'll modify that to include hooks.
// Hooks allow functional components to remember & pass info
// related to their "state."
// "State" refers to changes or updates based on user
// interactions.
// The hook we'll import is called useState.
 import React, {useState} from 'react';


function FunctionalCounter() {
    // Declare a variable to hold a count of how many times
    // a user clicks a button.  This will track our component's
    // "state."  setCount is a predefined method in React.
    const [count, setCount] = useState(0);

    // Next we'll create a function that will incrememnt the count
    const increment = () => setCount (count + 1);
    
    // Then we'll create a function that will decrement the count
    const decrement = () => setCount (count - 1);

  // The return is where our HTML to be rendered will be written
  return (
    <div>
        <h3>
            This is my functional counting component:
        </h3>
        <br />
        <p>Count: {count}</p>
        <button onClick={increment}>Increment the count</button>
        <button onClick={decrement}>Decrement the count</button>


    </div>
  );
}

export default FunctionalCounter