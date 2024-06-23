//import { MouseEvent } from "react";

import { useState } from "react";

function ListGroup() {
  let items = ["New York", "San Francisco", "Tokyo", "London", "Paris"];
  let selectedIndex = -1; // this means that initially no item is selected
  
  // Hook
  const useStateArray = useState(-1);
  useStateArray[0] // variable (selectedIndex)
  useStateArray[1] // updater function

  // Event handler
  //const handleClick = (event: MouseEvent) => console.log(event)

  return (
    <>
      <h1>List</h1>
      {items.length === 0 && <p>No items found</p>}
      <ul className="list-group">
        {items.map((item, index) => (
          <li
            className={selectedIndex === index ? "list-group-item active" : "list-group-item"}
            key={item}
            onClick={() => {selectedIndex = index;}}
          >
            {item}
          </li>
        ))}
      </ul>
    </>
  );
}

export default ListGroup;
