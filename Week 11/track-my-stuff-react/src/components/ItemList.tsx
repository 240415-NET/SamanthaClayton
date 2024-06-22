import React from 'react'


// WE will leverage typescript's type system and make sure that
// we get objects to render that conform to our specifications of an
// item for our app
interface Item {
    userId: string;
    itemId : string;
    category: string;
    originalCost: number;
    purchaseDate: Date;
    description: string;
}

// This is an additional interface containing the list of items
// that we will pass as a prop from UserInfo to ItemList

interface ItemListProps {
    itemsFromUserInfo: Item[];
}

//ItemList receives an "argument" (called a Prop in react)
// from it's parent UserInfo
function ItemList({itemsFromUserInfo}: ItemListProps) {



  return (
    <div id="item-list-container">
        <ol id="item-list">
            {/* CTRL + forward slash does this for you */}
            {/* Here I will use the JavaScript array.map()
            method to render my line items based on the item
            list that is passed in as a prop when this
            component is rendered.
            
            "We're going to break into TypeScript"*/}

            {/* Lists in react expect something from each item
            in the list - a key.  Think of it as a primary key that
            React can use to refer to each item that we are going to
            dynamically render
             */}
            {itemsFromUserInfo.map((individualItem) => 
            (
                <li key={individualItem.itemId}>
                    {individualItem.category} - {individualItem.description} - {individualItem.originalCost}
                </li>
            ))}


            
        </ol>
    </div>
  )
}

export default ItemList