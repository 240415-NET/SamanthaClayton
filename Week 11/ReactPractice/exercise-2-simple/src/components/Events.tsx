import React, { useState } from "react";

function Events() {
  const change = (event: any) => {
    console.log(
      "You changed the value of the input box to: ",
      event.target.value
    );
  };

  const click = () => {
    console.log("You clicked the button!!!!!");
  };

  return (
    <div>
      <input type="text" onChange={change} />
      <button onClick={click}>Click the button</button>
      <br />
    </div>
  );
}

export default Events;
