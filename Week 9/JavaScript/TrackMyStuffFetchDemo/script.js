/* Now we are going to listen for the DOMContentLoaded event to start
off our JS file */

document.addEventListener("DOMContentLoaded", () =>
    {

        // Select my containers and buttons at the top of my JS file
        // within that DOMContentLoaded listener lambda

        // Select my div containers by their id
        const loginContainer = document.getElementById("login-container");
        const userContainer = document.getElementById("user-container");

        // Select my elements such as buttons and text to update
        const loginButton = document.getElementById("login-button");
        const logoutButton = document.getElementById("logout-button");
        const welcomeMessage = document.getElementById("welcome-message");
        const itemsList = document.getElementById("items-list");

        // Check if a uesr is already logged in
        // First, I'm going to create something to hold my logged in user if they exist
        // Otherwise, it's null
        const storedUser = JSON.parse(localStorage.getItem("user")); // it will look in our local storage for that key, it'll take its value, and then that value which is the json string that represents the user will get parsed into stored user
        if(storedUser) // if storedUser is not empty
        {
            updateUIForLoggedInUser(storedUser);
        }



        // Add an event listener that listens for a click to the login button
        // Once that happens, use fetch to send HTTP request to API for the user
        // Listening for a click event on our login button that will send
        // an HTTP request to GET the user from our API using Fetch
        loginButton.addEventListener("click", async () =>{
            // When the user clicks the login button, we enter this event listener
            // We want to take whatever username string they entered in our text input
            // and store it here
            const username = document.getElementById("username").value;
            if (username){
                // Use a try-catch to handle any sort of errors that may arise
                // during the handling of our HTTP request

                try {
                    // Create something to hold our response that we get back from our API
                    const response = await fetch(`http://localhost:5192/Users/${username}`);
                    
                    // Once we send the request and get the reply, we will store that user object
                    // in our const user
                    const user = await response.json();

                    // Store the user locally on the browser so that if the page reloads,
                    // I don't have to log back in every single time

                    // We call localStorage.setItem(), give it a string as a key, and then
                    // the value will be the json string represenation of our user we got from the API above

                    // the key is the user (logged in user), the value is the json string that represents this object

                    localStorage.setItem("user", JSON.stringify(user));

                    // Here I'm going to add a call to a function that will update the UI if a user is found
                    // Calling our UI update function
                    updateUIForLoggedInUser(user);
                }
                catch (error)
                {
                    console.error("Error logging in: ", error);// console.error will make it red but could also do console.log
                }

            } // End if to check username has anything in it
        });// Closing the loginButton.addEventListener("clck") aka end of the loginButton event listener
   
        // This will fire off when a user is logged in and then choose to log out via our logout button
        
        logoutButton.addEventListener("click", () => {
            // upon logout, get rid of the local storage item with the key user
            // the local storage item is the json object for a whole uesr
            localStorage.removeItem("user"); //could also do localStorage.clear 
            // We unhide the login-container div
            loginContainer.style.display = "block";
            // We hide the user container div
            userContainer.style.display = "none";
        }); // end of the logoutButton event listener
       
        // This function will update the UI for my logged in user once they are found
        function updateUIForLoggedInUser(user) {
            // Selecting my loginContainer div and updating it so that its style is display: none;
            // We're doing this programmatically using JS (instead of the other way when it was "none;" inline in index.html)
            loginContainer.style.display = "none"; 

            // Updating the welcome message based on the username
            welcomeMessage.textContent = `Welcome, ${user.userName}`; // this field needs to match what you have in Swagger/your C# code exactly 
            
            // Unhiding the user container
            userContainer.style.display = "block";

            // When we update the UI for a logged in user, we are going to call our
            // fetchUserItems() function and get their items for them
            fetchUserItems(user.userId);

        }; // End function updateUIForLoggedInUser

// Function that fetches user items from our backend and then calls the renderUserItems function
// to reflect the changes on our page
        async function fetchUserItems(userId)
        {
            try {
                // Sending a request for our logged in user's items based on their userId
                const response = await fetch(`http://localhost:5192/Items?userId=${userId}`);// doesn't conflict with the above response because it's in its own block and we didn't use var (idk?)
               
                // Store the list of items - parsing the response into our const items
                const items = await response.json();
                // Call to a function to render our items in our HTML that our browser sees
                renderItemsList(items);

            } catch (error)
            {
                console.error("Error fetching items: ", error);
            }
        }; // end fetchUserItems function
        
        // Here is a function that will ues DOM manipulation to display our list of items on our page
        function renderItemsList(items)
        {
            itemsList.innerHTML = '';
            // for each item in our items list, we will update the HTML to display that item within the ol element of our HTML file

            items.forEach(item => {
                // For each item, we create an li (list item) element within 
                // our ordered list
                const listItem = document.createElement("li");
                // We give the list item text content related ot our item that we want to display
                // We use dot notation to access the fields of our item
                // We need the fields to match with the json that comes back so this is case sensitive

                listItem.textContent = `${item.category} - ${item.description} - $${item.originalCost}`;
                
                // Once we've created our list item and given it relevant text content from our json return,
                // we need to actually stick it into the list
                itemsList.appendChild(listItem);
            });
        }

    }); // End of document.addEventListener("DOMContentLoaded")