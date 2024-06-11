// This will be our JavaScript file
// It is attached to our HTML file via a script tag at the bottom
// of the body element

// First, we have to wait for the DOM to fully finish loading
// Inside of our JS file, we can refrence all the HTML (and the DOM structure)
// of our index.html using the "document" object.
/*
We don't have to instantiate it or create it or anything.
We can just start using it.

We reference our document object then use dot notation to run a function
to add an event listener. The event we are going to listen for is
"DOMContentLoaded".

addEventListener(some kind of event )
DOMContentLoaded - wait for all of our stuff in HTML to be loaded before we run JS
*/
document.addEventListener('DOMContentLoaded', () => {
    /*
    All of our DOM manipulation will be done within this lambda
    within addEventListener.
    
    Now we'll start to work with our HTML elements as JavaScript variables/objects

    To select our button (in our HTML), we will use getElementById
    */
    const changeTextButton = document.getElementById("changeTextButton"); // can be "" or '' or ``

    /* Now we will add a listener to that button we selected and stored in changeTextButton above */

    changeTextButton.addEventListener("click", () => {
        console.log("Yep, my button was clicked and the HTML should be updated");
        /* To update the text inside of our p-tag, we will select it
        via its Id as we did for the button above.  The name of our
        JS variable does not need to match the name of the ID in the 
        html element we select.  It can be good to keep them 1:1 if you want
        to, but it's not an enforced standard.  So you can call this paragraph 
        instead of textToChange, for example.*/
        const paragraph = document.getElementById("textToChange");
        paragraph.textContent = "This is my new text that is coming in from my JS code";

    }); // Closing the button.addEventListener() method

}); // Closing the document.addEventListenter method


console.log("The script has also loaded");

