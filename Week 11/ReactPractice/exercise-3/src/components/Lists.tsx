import React from 'react'

function Lists() {
    const dummyData = ["hi", "bye", "later", "cya"];


  return (
    <div>
        <ol id="list">
            {dummyData.map((individualItem, index) => 
            (
                <li key={index}>{individualItem}</li>
                // These 2 produce the same result as the above line
                    //<li key = {individualItem}>{individualItem}</li>
                    // <li>{individualItem}</li>
            ))}

        </ol>

            {/* These 2 options also produce the same result as the above.
            The difference between the below options and the abbove is tht
            in the line htat has dummyData.map.... there is NOT an index value
            being passed in below like there is above
            */}

        {/* <ol id="list">
            {dummyData.map((individualItem) => 
            (
                //<li key = {individualItem}>{individualItem}</li>
               //<li>{individualItem}</li>
            ))}

        </ol> */}



    </div>
  )
}

export default Lists