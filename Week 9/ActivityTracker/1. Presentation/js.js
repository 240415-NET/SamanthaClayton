document.addEventListener("DOMContentLoaded", () =>
{
    const loginContainer = document.getElementById("login-container");
    const loggedinContainer = document.getElementById("logged-in-container");
    const loginButton = document.getElementById("login-button");
    const logoutButton = document.getElementById("logout-button");
    const welcomeMessage = document.getElementById("welcome-message");
    const activityList = document.getElementById("activity-list");

    loginButton.addEventListener("click", async () =>{
        const username = document.getElementById("username-input-box").value;
        if (username){
            try {
                const response = await fetch(`http://localhost:5289/users?userNameToFindFromFrontEnd=${username}`)
                const user = await response.json();
                localStorage.setItem("user", JSON.stringify(user));
                updateUIForLoggedInUser(user);
            } catch(error){
                console.error("Error logging in: ", error);                
            }
        }; //end of if(username)
    }); // end of loginButtong.addEventlistener("click")

    function updateUIForLoggedInUser(user) {
        loginContainer.style.display = "none";
        welcomeMessage.textContent = `Welcome ${user.userName}!`;
        loggedinContainer.style.display= "block";
        fetchUserActivities(user.userName); 
    }; // end of the function UpdateUIForLoggedInUser(User)

    async function fetchUserActivities(username)
    {
        try{
            const response = await fetch(`http://localhost:5289/GetActivitiesbyUserName ${username}`);
            const activities = await response.json();
            renderActivityList(activities);
        } catch (error)
        {
            console.error("Error fetching activities: ", error);
        }
    }; // end of the async function fetchUserActivities

    function renderActivityList(activities){
        activityList.innerHTML ="";
        activities.forEach(activity => {

            const activityinList = document.createElement("li");
            activityinList.textContent = `${activity.activity_Description} - ${activity.activity_nameOfPerson} - ${activity.Date_Of} - ${activity.Time_Of} - ${activity.activity_isComplete}`;
            activityList.appendChild(activityinList);
        }); // end of the activities foreach loop

    };// end of the function renderActivityList
}); // end of document.AddEventListener("DOMContentLoaded")