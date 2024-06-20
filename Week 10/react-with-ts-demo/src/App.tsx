import React from 'react';
import logo from './logo.svg';
import './App.css';

// In order to call a component and its functionality as well as render it from
// inside of another component, we will need to import it.  So the component
// exports itself to make itself available for import across our app.
// When you start typing FunctionalCounter, you can hit tab and it'll finish the
// rest of it for you.
import FunctionalCounter from './components/FunctionalCounter';
import ClassBasedCounter from './components/ClassBasedCounter';

// This is our root component called App.  We will create our own components
// that we then nest inside of our call from App later on.
// Notice that App is a FUNCTIONAL component.
// It's a TS function that returns HTML (with some slight syntax differences)
// that is then rendered in the browser.
function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h1>React Counter Functional-Class Demo</h1>
        {/* Here we include our functional component */}
        <FunctionalCounter/>
        <br />
        {/* Here we will include our class-based component */}
        <ClassBasedCounter/>
        
      </header>
    </div>
  );
}

export default App;
