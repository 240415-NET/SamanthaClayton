import React, {useState, useEffect} from 'react'
// ^ In order to use state, import the hook.  Same with useEffect.

function UserInfo() {

    // Creating a spot in our component's state to hold the logged in user
    // that we pull from localStorage.
    const [userFromLocalStorage, setUser] = useState<any>(null);
    // This time, we will set the itemList to be of type "any[]" so that
    // our state knows to store a list of objects for us. We then initialize 
    // it to an empty array.
    const [itemListFromAPI, setItemList] = useState<any[]>([]);

    // useEffect to check localStoage for a logged in user
    useEffect(() => {
        // Storing our user pulled from localStorage
        const storedUser = JSON.parse(localStorage.getItem("user") || "null");
        if(storedUser) {
            setUser(storedUser);
        }
    }, []); // Empty array of dependencies for useEffect (otherwise, this will
            // fire off forever)

// Using conditional rendering via a ternary operation
// If userFromLocalStorage has a value (i.e., is not null),
// then we render this component.  Otherwise, (i.e., before)
// someone has logged in at all, it is not rendered on our page.
  return userFromLocalStorage ? (

    <div id="user-container">
        <h2 id = "welcome-message">Welcome, {userFromLocalStorage.userName}!</h2>
        <br />
        <h4>Your items:</h4>

    </div>
  ) : null; // Render nothing if a user is not currently logged in
}

export default UserInfo