import React, {useState} from 'react'

function Events() {

  // In order for something to be dynamic/interactive, we need to use
  // "state."

  // useState(some default value here)
  // This is going to return 2 things:
  // 1. the value of our thing
  // 2. a function thta allows us to update the value (aka the state)

  // We define the value of our input box by using the state variable
  // We're going to have an inputBoxValue variable, the value of it will be
  // '' initially and then to change it from there, we'll use the function
  // setInputBoxValue(value we want to change it to).

  const [inputBoxValue, setInputBoxValue] = useState('');

  // We'll also 
  const [valueToDisplay, setValueToDisplay] = useState('');

  // In React, input components can't be changed by simply typing into them
  // like in HTML because it's dynamically wired to our state variable.
  // Create a button and when you click on it, run a function
  // Here we'll define the function and call it click
  // We'll call this function everytime the button is clicked.
    
    //This function will be called whenever the input box changes
    const change = (event:any) => {
      const newValue= event.target.value;
      setInputBoxValue(newValue);

      // could also just do setInputBoxValue(event.target.value)
    }
  
  // This is a new function named click.  It'll be called in the "return"
  // statement when a button is clicked.  When a user clicks, it
  // sets the value of "valueToDisplay" to be whatever it inside of the input box.




  return (
    // This is the HTML you want to render
    <div>What's your favorite number?
      
    
    {/* Instead of just having the type and id of the input box,
        we'll define the value as well. So instead of
        <input type="text" id="favorite-number-input-box"/>,
        we do the following, which makes our input value dynamic*/}
    {/* <input type="text" id="favorite-number-input-box" value = {inputBoxValue}/> */}
    {/* However, just doing the above will not allow the input value to change.
        You won't be able ot type in the input box.
        So to make that input value able to be changed.
        In order to handle simple text input in React, we need
        to add the onChange event to the input component.
        We need to create another function that will be called whenever the input box
        changes */}
        <input type="text" id="favorite-number-input-box" value = {inputBoxValue} onChange={change}></input>
        {/* Because this is an onChange event, it's a special event that will pass the 
            event object into our change function  */}

    <button onClick={click}>Click this button when you're done typing</button>

    <br />
    Here's your favorite number:
    <br />
    This one updates when you update the input box: {inputBoxValue}.<br />
    This one updates when you click the button: {valueToDisplay}.
    </div>
        
  )
}

export default Events
