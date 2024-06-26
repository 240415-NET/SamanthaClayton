import React, {useState, useEffect} from 'react'
// ^ In order to use state, import the hook.  Same with useEffect.

// If I have a child component, that will only be rendered from within it's
// parent, I will import it here, the same way I've been importing things to 
// render within App.tsx.
import ItemList from './ItemList';

// Create an interface to type my props, thanks TypeScript
interface UserInfoProps {
    loggedInUserFromApp: any; 
}

function UserInfo({loggedInUserFromApp} : UserInfoProps) {

    // Creating a spot in our component's state to hold the logged in user
    // that we pull from localStorage.
    //const [userFromLocalStorage, setUser] = useState<any>(null);
    // This time, we will set the itemList to be of type "any[]" so that
    // our state knows to store a list of objects for us. We then initialize 
    // it to an empty array.
    const [itemListFromAPI, setItemList] = useState<any[]>([]);

    // useEffect to check localStoage for a logged in user
    useEffect(() => {
        // Storing our user pulled from localStorage
        //const storedUser = JSON.parse(localStorage.getItem("user") || "null");
        //if(storedUser) {
            //setUser(storedUser);
          //  fetchUserItems(storedUser.userId);
       // }
       fetchUserItems(loggedInUserFromApp.userId);
        //not that useEffect takes in a dpeneendecy, i nthis case the loggedinuserfromapp
        // prop that came in from app.tsx, we use it's depnednecy array and don't leave it empty 
    }, [loggedInUserFromApp]); // Empty array of dependencies for useEffect (otherwise, this will
            // fire off forever)

    async function fetchUserItems(userId : string) {
        try {

            // Fetch to get the items list for the logged in user
            const response = await fetch(`http://localhost:5192/Items?userId=${userId}`);
            const itemList = await response.json();

            // Call the setItemList "setter" for our state to store

        } catch (error) {
            console.error("Error fetching uesr items: ", error);
        }

    } //end fetchUserItems


// Using conditional rendering via a ternary operation
// If userFromLocalStorage has a value (i.e., is not null),
// then we render this component.  Otherwise, (i.e., before)
// someone has logged in at all, it is not rendered on our page.
  //return userFromLocalStorage ? (
return (
    <div id="user-container">
        {/* <h2 id = "welcome-message">Welcome, {userFromLocalStorage.userName}!</h2> */}
        <h2 id = "welcome-message">Welcome, {loggedInUserFromApp.userName}!</h2>
        <br />
        <h4>Your items:</h4>
        {/* Here we will cal lthe ItemList child component. Since we explicitly
        state that it expects a prop, we will get an error if we do not pass it
        the props it expects (Just like our other functions!)  Here we set
        the itemsFormUserInfo prop eqal to the itemListFromAPI that we stored in
        THIS component's state.
        
        In this case, we have passed state information from one component to
        another, by passing it as a prop. */}
        <ItemList itemsFromUserInfo = {itemListFromAPI}/> {/*render the item list*/}

    </div>
  ) //: null; // Render nothing if a user is not currently logged in
}

export default UserInfo