import React, { useState } from 'react';
import './App.css';
import InputField from './components/InputField';


// He starts of by converting function App () {
// "into an arrow function"
// by doing
// const App = () => {
// When you hover over that, it shows a popup that says
// const App : () => JSX.Element
// The "JSX.Element" is what is returned by the function
// It's the div that it's the return statement
// "What is the exact type of this function? It's a functional
// component, so we enter ": React.FC" to provide it the type."
// There are a lot of othre types, like React.ReactNode.


const App:React.FC = () => {

  //const [ToDo, setToDo] = useState("");
  // We are supposed to give this 'state' a type since we're using TypeScript
  // You do that by putting the type in <> after useState
  const [ToDo, setToDo] = useState<string>("");
  // If you want to accept multiple types, you can do union
  //const [ToDo, setToDo] = useState<string | number>("");
  // Or if you want to do an array of strings
    //const [ToDo, setToDo] = useState<string[]>("");



  return (
    <div className="App">
      <span className = "heading">Taskify (our App name)</span>
      <InputField ToDo={ToDo} setTodo={setToDo} />
    </div>
  );
}

export default App;
