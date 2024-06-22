import React, { useState } from 'react'
import ChildComponent from './ChildComponent'

function ParentComponent() {


  return (

    <div>
    Here is text being displayed in the ParentComponent.<br></br>
    We'll pass the string "hello" to the ChildComponent.<br></br>
    <br></br>
    <ChildComponent prop1FromParent={"hello"}/>
    </div>
  )

}

export default ParentComponent