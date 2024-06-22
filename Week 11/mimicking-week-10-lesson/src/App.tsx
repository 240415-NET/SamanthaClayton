import React from 'react';
import logo from './logo.svg';
import './App.css';
import FunctionalCounter from './components/FunctionalCounter';

// In order to call a component and its functionality
// and in order to render it from inside of another
// component, we will need to import it.
// The component exports itself to make it available
// for import across our application.
// When you start typing the name of the component,
// you can hit tab and it'll fill in the rest for you.


// This is our root component called App.
// We will create our own components that we will then
// nest inside of our call from App later on.
// App is a FUNCTIONAL component.
// It is a TypeScript function that returns HTML
// (with some slight syntax differnces) that is rendered
// in the browser.
function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h1>React Demo - Counter - THIS IS IN APP.TSX</h1>
        <FunctionalCounter />

      </header>
    </div>
  );
}

export default App;
