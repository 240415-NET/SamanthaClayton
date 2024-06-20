// We will still import React from 'react'
// But now for our class component, we need to import
// the Component base class that our component will
// inherit from.
// We will not use 'state' - that's functional. We have to
// manage state within our component ourselves.

import React, {Component} from 'react';

// Class components cannot benefit from things like
// hooks, which means that we need to manually store our own
// state.  No easy useState to update our underlying
// under-the-hood State object.

// Define an interface that will hold the component's state
// The class will extend the interface and inherit from
// the Component base class

interface CounterClassState {
    count: number;
}

// Here we will actually define our class component.
class ClassBasedCounter extends Component<{}, CounterClassState>{
    constructor(props: {}) {
        // We can think of props as arguments to our components,
        // whether class-based or functional.
        // Because this is a class component, we need to take in a 
        // props object argument and pass it to the super() constructor
        // we inherited from Component (prebuilt react class)
        super(props);
        // Additionally, we will set our state to 0
        // Specifically, we are setting count's value to 0
        // and storing count in our state object
        // that belongs to our ClassBasedCounter
        // Notice that we lose access to things like setState()
        // and we have to do this fairly manually
        this.state = { count: 0 };
    }
    // Our increment function looks a little different 
    // We need to reference our state object directly in order
    // to update it.
    // Here we reach in and grab the current value of count and
    // then replace the count in our state object with count + 1.
    increment = () => this.setState({count: this.state.count + 1});
    decrement = () => this.setState({count: this.state.count - 1});
    
    // Because we are in a class, a class cannot simply "return" anything
    // We will create a method called render(), thathten contains the 
    // returned HTML
    render() {
        return(
        <div>
            <h3> This is my class-based counting component</h3>
            <br />
            {/* in my class based component, count is being stored in
            this.state.count. we need to reach into the state to read it */}
            <p>Count: {this.state.count}</p>
            <button onClick={this.increment}>Increment the count!</button>
            <button onClick={this.decrement}>Decrement the count!</button>
        </div>
        );
    }

} // End ClassBasedCounter
// Outside of class's scope/code block, we again need to export our component
// os that we can import and use it elsewheree.
// Otherwise we can't see it anywhere outside of htis file
export default ClassBasedCounter;