import React, {useEffect, useState} from 'react';
import logo from './logo.svg';
import './App.css';
import Login from './components/Login';
import UserInfo from './components/UserInfo';

function App() {
      //<any> is the type definition, 'anything that we put in there'
    // similar to using T with C# functions?
    const [userObject, setUserObject] = useState<any>(null); // Storing our user object, setting it to null if nobody is logged in

    // Here we will use our useEffect hook that is built into react and
    // imported above to check localStorage and see if there is a usre
    // object stored in there

    useEffect(() => {
      // First, we create a variable to store our user (if they exist)
      // We call JSON.parse() to try to create an object based on the user json in local storage
      // If the user exists, they are parsed and brought in
      // If they don't exist, we will store a null insid of our uesrFromLocalStorage variable
      const userFromLocalStorage = JSON.parse(localStorage.getItem("user") || "null");

      // If there is an actual value (so we found a user after all),
      // in userFromLocalStorage, we will store that in our state, by
      // calling the setUserObject "setter" that we declared above.
      if(userFromLocalStorage)
          {
              setUserObject(userFromLocalStorage);
          }
  }, []); //useEffect by default wants the function containing the logic that you want useEffect to do and an optional array of dependencies.  If you weren't going to call the state, you could get away with not having the [].
  // If you call useState from within useEffect, remember to pass in an empty array before closing the final
  // parenthesis.  This is due to the behabior of useEffect.

  return (
    <div className="App">

      {/* We shifted the conditional rendering to App.tsx.  The code
      below checks to see if our userObject in App.tsx's state exisets.  If it doesn, we don't
      render the login component */}
      {!userObject && <Login setUserFromApp = {setUserObject}/>}
  

      {/* Origially these were <Login /> and <UserInfo  /> before we lifted the above into App.tsk (from login.tsx) */}
      {/* <UserInfo loggedInUser = {userObject}/> */}
      {userObject && <UserInfo loggedInUserFromApp = {userObject}/>}
    </div>
  );
}

export default App;
