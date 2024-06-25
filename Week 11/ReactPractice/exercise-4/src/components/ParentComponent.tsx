import React, { useState } from 'react'
import ChildComponent from './ChildComponent'

function ParentComponent() {


  return (

    <div>
    <h1>Parent Component</h1>
    Here is text being displayed in the ParentComponent.<br></br>
    We'll pass the string "<strong>hello</strong>" to the ChildComponent.<br></br>
    <br></br>
    <ChildComponent prop1FromParent={"hello"}/>
    </div>
  )

}

export default ParentComponent