import React, {useState} from 'react'

// We are going to make ChildComponent take in arguments/props
// Before we do that, we have to use an interface to define
// the type of those props
interface ChildComponentPropsFromParent {
    prop1FromParent: any; 
}


// Now in ChildComponent, we pass in the prop

function ChildComponent({prop1FromParent} : ChildComponentPropsFromParent) {

    const [valueToDisplay, setValueToDisplay] = useState<any>("");
   // setValueToDisplay({prop1FromParent} + "look, the child modified it");

    return (
    <div>Child component is now displaying it: {prop1FromParent}</div>
  )
}

export default ChildComponent