import React from 'react';
import { createContext, useState, ReactNode } from 'react';

// Defining an interface for our context value
interface MessageContextType{
    message: string; // the message that will be shared/displayed around our app
    setMessage: (message: string) => void; // Function that acts as a setter to update our message
}

// Create a conext wiht some (or null) default value that is then exported
// In order to use context, we create & export 2 things: the context & its contextProvider
export const MessageContext = createContext<MessageContextType | null>(null);

// Here we wlll define the props for our context provider
// We are going to use the ReactNode type (which comes in with React)
// to simpify this
interface MessageContextProviderProps {
    children: ReactNode;
}

function MessageContextProvider({children} : MessageContextProviderProps) {

    // Inside of our MessageContextProvider functional component,
    // we will save state information.
    const [message, setMessage] = useState<string>("Hello from my MessageContext.tsx!");

  return (
    <MessageContext.Provider value={{message, setMessage}}>
        {children}
    </MessageContext.Provider>
)
}

export default MessageContextProvider