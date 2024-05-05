## User Stories/Features Overview
- As a user, I want to be able to create a new profile
- As a user, I want to be able to log into my existing profile
- As a user, I want to be able to view a question, provide an answer, and see if I was correct or not
- As a user, I want to see my score
- As a user, I want to join a team
- As a user, I want to see how my score
    - Varies by show
    - Compares to general public
    - Compares to my teammates' scores
    - Changes over time


## Models
- User
    - UserType (string) - admin or general user
    - userId (int)
    - userName (string)
    - teamName (string)??
- Trivia Questions
    - question (string)
    - answers (string)
    - correct answer (string)
    - show (string)
    - right/wrong (string)
    - difficulty level (string)
    - season (int)
    - episode (int)
- Score
    - Running socre from the trivia question answers (int)
    - Average weekly score
    - Ranking number
- Bonus Questions inherits from Trivia Questions
    - bettingpoints (int)


## User Stories/Features (Detailed)
- As a user, I want to be able to create a new profile
    - Display menu to allow them to select what they want to do (Presentation Layer)
    - User chooses to create a new profile
        - Take in user selection (presentation layer)
        - Prompt user for username & take in what they enter (presentation layer)
        - Check username validation logic (logic layer & data access layer)
            - Trim the username (logic layer)
            - Make sure it's not blank (logic layer)
            - Check if user exists already (data access layer)
            - If conditions not met, re-prompt the user (presentation layer)
        - If username is valid, store the username (logic layer & data access layer)

