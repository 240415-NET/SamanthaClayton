// Importing useState so that our component
// can remember its state as the user uses
// the app, makes changes, calls our backend
// and stores things, etc.
// I will also import another hook called
// "useEffect" which is another prebuilt React
// hook.
// useEffect will be used to interact with localStorage, which
// is "external" to react.  useEffect can be used to interact
// with all sorts of external systems like other front end
// libraries, animation libraries, really whatever you'd need -
// from within our components
import React, {useState, useEffect} from 'react'

// Create an interface to hold my props
interface LogInProps {
    setUserFromApp: (user: any) => void; // what we're taking in as a prop
    // is setUser (a function) it'll take in a user of any type
    // it's a function and it rturns a void, if we wanted it to return
    //soemthhing => string
}

// Within my function Login(), which is my react functional
// component for user login stuff, I will write my log in
// logic, including my localStorage logic and API calls
// to my backend.
// was originally function Login() {
// Updated my login functional component to take a prop form
// App.tsx.  In this case, the prop is the state setter
// FROM App.tsx.
// 
//function Login(setUser : LogInProps) {
function Login({setUserFromApp} : LogInProps) {
    // First, I will intialize our state when a user first
    // arrives at our application
    // We can think of username as our "field" and setUserName as
    // our "setter"
    // State is an under the hood object built into every
    // component in React.
    const [username, setUsername] = useState(''); // Storing our username input string and setting it to an empty string
    //const [userObject, setUserObject] = useState<any>(null); // Storing our user object, setting it to null if nobody is logged in


    // // Here we will use our useEffect hook that is built into react and
    // // imported above to check localStorage and see if there is a usre
    // // object stored in there

    // useEffect(() => {
    //     // First, we create a variable to store our user (if they exist)
    //     // We call JSON.parse() to try to create an object based on the user json in local storage
    //     // If the user exists, they are parsed and brought in
    //     // If they don't exist, we will store a null insid of our uesrFromLocalStorage variable
    //     const userFromLocalStorage = JSON.parse(localStorage.getItem("user") || "null");

    //     // If there is an actual value (so we found a user after all),
    //     // in userFromLocalStorage, we will store that in our state, by
    //     // calling the setUserObject "setter" that we declared above.
    //     if(userFromLocalStorage)
    //         {
    //             setUserObject(userFromLocalStorage);
    //         }
    // }, []); //useEffect by default wants the function containing the logic that you want useEffect to do and an optional array of dependencies.  If you weren't going to call the state, you could get away with not having the [].
    // // If you call useState from within useEffect, remember to pass in an empty array before closing the final
    // // parenthesis.  This is due to the behabior of useEffect.

    // Here we will create a function thta we will call when our
    // login button is clicked that will make the fetch request 
    // to our API
    // We can do 'async'/'await' or something else (didn't catch what he said the alternative was)

    async function handleUserLogin()
    {
        // First, we check to see if the uesrname in our state is still null
        // When the user clicks our login button, the username should be stored in our state
        if(username)
            {
                // If username is NOT empty or null, we will use a try-catch to send our GET request
                try
                {
                    // Fetch GET to our aPI for our user
                    const response = await fetch (`http://localhost:5192/Users/${username}`);

                    //Parse our response body as json, we must remember to await this as it is asynchronous
                    const userFromAPI = await response.json();

                    //Storing our userObject data.  We need ot store it in
                    // localStorage (browser) and we need to store it in our
                    // state for our component's use
                    localStorage.setItem("user", JSON.stringify(userFromAPI));
                    //setUserObject(userFromAPI);
                    // Calling the setUser function we took in as a prop 
                    // now that App.tsx is managing the user state
                   //setUser(userFromAPI);
                   setUserFromApp(userFromAPI);


                } catch (error) { // If the fetch goes wrong, we will send the error message to the console like before
                    console.error("Error logging in: ", error);
                }
            }

    } //end handleUserLogin()





// Here in the return, we will render what the user will se
// and call any of our logic written above    
// We will use conditional rendering in our return.
// IF The user is logged in, we will render nothing for our
// login component.  If a user is NOT logged in, we will 
// render the login form.

// if NOT userObject, using the logical not (!) operator
  //return !userObject ? (
  return (
    <div id = "login-container">
        <h2>Login</h2>
        <input
            type = "text"
            id = "username"
            placeholder = "username"
            value = {username}
            onChange = {(userNameFromInputField) => setUsername(userNameFromInputField.target.value)}
        
        
        
        /> {/* Again, we need to close our normally self closing tags for React*/}
        <br />
        {/* This is our login button.  When it is clicked, we will call handleUserLogin()
        from above */}
        <button onClick = {handleUserLogin}>Login</button>
    </div>
  ) //: null; // if a userObject is found/if the userObject is
  // NOT NULL, we render null (notihng at all).
  // We do not want this component rendering if we have a logged in user.
}

export default Login