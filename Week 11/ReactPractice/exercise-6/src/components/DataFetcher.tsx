import React, { useEffect, useState } from 'react'

function DataFetcher() {

// The input box value will be blank at first.  Set it up to be dynamic.
// const [inputBoxValue, setInputBoxValue] = useState('');

// The user to get will default to Bob at first, but set it up to be dynamic.
const [userToGet, setUserToGet] = useState("Bob");

// When someone changes the input box, the input box value variable should be set to the new value.
// const changeInputBoxValue = (event:any) => {
//     const newValue= event.target.value;
//     setInputBoxValue(newValue);
// }

// When someone clicks on the button, set the user to get to be whatever is in the user input box
// and then go fetch the data for that user.

// const clickHandler = () => {
//     // setUserToGet(inputBoxValue);
//     fetchUserInfo(userToGet);
// }


// Create a userInfo object that's type is what's in the interface below
const [userInfo, setUserInfo] = useState<incomingUserData | undefined>(undefined);

interface incomingUserData {
    userId: string,
    userName: string,
    firstName: string,
    emailAddress: string,
    lastName: string,
    acivitylist: string[]
}

const [message, setMessage] = useState<string |undefined>(undefined);
const [message2, setMessage2] = useState<string |undefined>(undefined);
const [message3, setMessage3] = useState<string |undefined>(undefined);


// When the page loads and whenever the state changes, fetch the data.
useEffect(() => {
    // Call the fetchUserInfo function & pass it the user we want to get
     fetchUserInfo(userToGet);
     setMessage(userInfo?.userName);
     setMessage2(userInfo?.userId);
     setMessage3(userInfo?.emailAddress);

    }, []); //Empty array of dependencies for useEffect, otherwise this will fire off forever



// This function will get user info from the API
async function fetchUserInfo(userName: string) {
    try{
        //Fetch to get the items list for the logged in user
        const response = await fetch(`http://localhost:5289/users?userNameToFindFromFrontEnd=${userName}`);
        const userInfoFromAPI = await response.json();

        //Call the setItemList "setter" for our state, to store our item list there
        setUserInfo(userInfoFromAPI);
    }catch (error) {
        console.error('Error fetching user info: ', error);
    }


}//end fetchUserItems
  return (
    <div>DataFetcher<br/>
        {/* <input type="text" value={inputBoxValue} onChange={changeInputBoxValue}/>
        <button onClick = {clickHandler}>Get my user info</button>
        <br/><br/> */}
        Username: {message}<br/>
        UserId: {message2}<br/>
        User email: {message3}<br/>
    </div>
  )
}

export default DataFetcher