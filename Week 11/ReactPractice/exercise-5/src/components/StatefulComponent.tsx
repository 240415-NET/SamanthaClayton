import React, { useState } from 'react';


function StatefulComponent() {
const [myMessageVariable, setMyMessageVariable] = useState("This is my default message.");
const [inputBoxValue, setInputBoxValue] = useState('');

const changeInputBoxValue = (event:any) => {
    const newValue= event.target.value;
    setInputBoxValue(newValue);
}

const clickHandler = () => {
    setMyMessageVariable(inputBoxValue)
}
  return (
    <div>
        Here is your message: {myMessageVariable}.<br/><br/><br/><br/>
        What would you like the message to say instead?<br/>
        <input type="text" value={inputBoxValue} onChange={changeInputBoxValue} /><br/>
        <button onClick={clickHandler}>Click</button>

    </div>
  )
}

export default StatefulComponent