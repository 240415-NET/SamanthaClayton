## Option 1:  What I did for GroceryList2Classy

1. If they enter the wrong thing, re-display the menu.
1. Because the switch is in another file, can't easily use the "return;" keyword for the 'exit the application' option (would need to pass it back to the main menu)
1. Repeats the menu when you return from other methods so you can select another option

- Do
    - Display menu
    - Set keepAlive = true to KEEP menu going
    - Try-Catch
        - Try to parse user entry into an integer
        - Catch if it can't be turned into an integer & display message
    - If user wants to exit, then end do-while loop (set keepAlive = false)
    - If user selected something else, call Menu Handler method
        - Menu Handler Method in separate file
            - Switch statement
                - Case 1: Show the list
                - Case 2: Call AddSubMenu method
                - Case 3: Call RemoveSubMenu method
                - Case 4: Call ModifySubMenu method
                - Default: Display message to select another option
- While keepAlive = true

## Option 2: What Jonathan did for TrackMyStuff

1. Doesn't display the menu again if the uesr enters the wrong thing
1. No need to initalize multiple keepAlive variables
1. Doesn't repat the menu when you're done with a certain option


- Display the menu
- Do
    - Try-Catch
        - Try
            - To parse user entry into an integer
            - Set keepAlive = true so do-while loop will end
            - Switch statement
                - Case 1: Call UserCreationMenu()
                - Case 2: not done yet
                - Case 3: return;
                - Default: Display message to select another option & keep the while loop going (set keepAlive = false)
        - Catch
            - Keep do-while loop going (set keepAlive = false)
            - Display message

## Option 3:
1. If you put the switch statement outside of the try-catch, then when it catches an error, it'll keep going to the switch statement and you'll get 2 error messages.
- Do
    - Display the menu
    - Try-Catch
        - Try
            - To parse user entry into an integer
            - Set keepAlive = true to end the do-while loop
        - Catch
            - Display message
            - Keep do-while loop going (set keepAlive= false)
        - Switch statement
            - Case 1: 
            - Case 2:
            - Case 3: return;


## Option 4: Multiple do-while loops
1. If the person chooses an integer 4, the second do-while loop will repeat forever

- Do
    - Display the menu
    - Try-Catch
        - Try
            - To parse user entry into an integer
            - End the do-while loop
        - Catch
            - Display message
            - Keep do-while loop going
- Do
    - Switch statement
        Case 1:
        Case 2:
        Case 3:
        Default: Keep do-while loop going


