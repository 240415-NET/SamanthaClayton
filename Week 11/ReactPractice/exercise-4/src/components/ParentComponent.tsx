import React, { useState } from 'react'
import ChildComponent from './ChildComponent'

function ParentComponent() {

    // Define a variable and its setter method
   // const [parentValueToSendToChild, setParentValueToSendToChild] = useState<any>("");
    const [parentValueToSendToChild, setParentValueToSendToChild] = useState("");

    // There will be an input box in the return of this component
    // When someone types into that input box, it'll call this function
    const change = (event:any) => {
        // When this function is called (i.e., when someone types into the
        // input box), get the value of what they typed into the box
        // and set the variable we declared to be this new value.
        const newParentValueToSendToChildFromInputBox= event.target.value;
        setParentValueToSendToChild(newParentValueToSendToChildFromInputBox);
    }

    const click = (event: any) => {
        <ChildComponent prop1FromParent ={parentValueToSendToChild}/>
      }
  

  return (
    <div>Enter something in this input box:
    <input type="text" id="favorite-number-input-box" value = {parentValueToSendToChild} onChange={change}></input>
    In the parent component, here's your value: {parentValueToSendToChild}

    <button onClick={click}>Click this button when you want the child component to do something</button>
    <ChildComponent prop1FromParent={parentValueToSendToChild}/>


    </div>
  )

}

export default ParentComponent