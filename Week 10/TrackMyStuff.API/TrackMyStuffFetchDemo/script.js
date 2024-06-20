/* Now we are going to listen for the DOMContentLoaded event to start
off our JS file */

document.addEventListener("DOMContentLoaded", () =>
    {

        // Select my containers and buttons at the top of my JS file
        // within that DOMContentLoaded listener lambda

        // Select my div containers by their id
        const loginContainer = document.getElementById("login-container");
        const userContainer = document.getElementById("user-container");
        const createUserContainer = document.getElementById("create-user-container");

        // Select my elements such as buttons and text to update
        const loginButton = document.getElementById("login-button");
        const logoutButton = document.getElementById("logout-button");
        const welcomeMessage = document.getElementById("welcome-message");
        const itemsList = document.getElementById("items-list");

        // These items belong to my add new item form
        const itemForm = document.getElementById("add-item-form");
        const itemCategory = document.getElementById("new-item-category");
        const itemCost = document.getElementById("new-item-cost");
        const itemDate = document.getElementById("new-item-date");
        const itemDescription = document.getElementById("new-item-description");
        // We never ended up using this selector due to HTML form behavior
        // Having the button as type submit was enough
        //const submitItemFormButton = document.getElementById("submit-item-button");

        // Here are my elements that are related to my create user functionality
        const showCreateUserButton = document.getElementById("show-create-user-button");
        const newUsernameInput = document.getElementById("new-username");
        const createUserButton = document.getElementById("create-user-button");
        const cancelCreateUserButton = document.getElementById("cancel-create-user-button");

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

        // Adding a listener for the submission of my new item form
        itemForm.addEventListener("submit", async (event) => {
            
            // This tells our page to ignore the default behavior of the form submission event
            event.preventDefault()

            // Bringing in the userId that is stored in our local storage if a user is logged in
            const loggedInUserId = JSON.parse(localStorage.getItem("user")).userId;
            if(loggedInUserId)
                {
                    // Here we will create the item object in our JS that will eventually be translated
                    // to json and sent off to our backend API

                    const newItem = 
                    {
                        userId: loggedInUserId,
                        itemId: "00000000-0000-0000-0000-000000000000", // default empty itemId since we'll generate a new one in C# but this is a sign to have a DTO
                        category: itemCategory.value,
                        originalCost: parseFloat(itemCost.value), // if you don't do parseFloat, it'll give a string that's a numerical value.  Parsing this one into a number
                        purchaseDate: itemDate.value,
                        description: itemDescription.value
                    };

                    // Here we will use Fetch to send our POST request to our API.
                    // Notice how there are some additional steps required vs. a GET request using fetch
                    try
                    {
                        // Here we use fetch to request object and then send it off to our API as a POST
                        const itemPostResponse = await fetch(`http://localhost:5192/Item`, {
                            method: "POST",
                            headers: {
                                "Content-Type" : "application/json" // headers are metadata about our request. since we're using swagger, we haven't needed to worry about them.  To see them in swagger, it's after the -H in the Curl when you send a request
                            },
                            body: JSON.stringify(newItem)  //stringify = convert this into a json string representation of whatever we pass in
                         });

                         //Refreshing the item list
                         fetchUserItems(loggedInUserId);

                         // Resetting the fields in our add-item-form in our HTML
                         itemForm.reset();

                    } catch(error)
                    {
                        console.error("Error adding item: ", error)
                    }
                }

        }); // End of the itemForm.addEventListener("submit")

        // Down here re going to be my lsteners and/or functions for my
        // create uesr feature.  This listener will take us from the login-
        //container to the create-user-container
        showCreateUserButton.addEventListener("click", () =>{
            loginContainer.style.display="none";
            createUserContainer.style.display = "block";
        }); // End of showCreateUserButton.addeventListener("click")

        // This listener will take us from the create-user-container back to the login container
        cancelCreateUserButton.addEventListener("click", () =>{
            loginContainer.style.display="block";
            createUserContainer.style.display = "none";

        }); // end cancelCreateUserButton.addeventListener


        // This listener will use fetch to send a POST request to our API and create our user
        createUserButton.addEventListener("click", () => {
            // When they click the create user button,
            // I will check that they entered something
            // Taking whatever is in the new username input when the button is clicked
            const newUsername = newUsernameInput.value;

            // We check using JS "truthy/falsy" weirdness to make sure they entered something in the text input
            if(newUsername)
            {
                // We send our fetch and under the hood, a promise created. 
                // A promise's JS analog to a C# task
                fetch(`http://localhost:5192/Users/${newUsername}`,
                    {
                        method: "POST"
                    }) // Once the promise resolved, we call .then() to do something with its result
                .then(responseFromNewUser => responseFromNewUser.json())
                .then(newlyCreatedUser => { // We can keep chaining .then() as long as we need to continue doing more work on subsequent promises
                    localStorage.setItem("user", JSON.stringify(newlyCreatedUser));
                    updateUIForLoggedInUser(newlyCreatedUser);
                    createUserContainer.style.display = "none";
                    userContainer.style.display = "block";
                })
                .catch(error => 
                    {
                        console.error("Error creating user: ", error);
                        alert(error);
                    });

            } else {
                // If the username is blank, we forcibly alert the user with a popup telling them  what they did wrong
                alert ("Username cannot be blank!)")

            }

        }); // end createUserButton.addEventListener("click")


    }); // End of document.addEventListener("DOMContentLoaded")