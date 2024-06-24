import React, {useContext} from 'react';
import { MessageContext } from '../context/MessageContext';

function About() {
  const {message, setMessage} = useContext(MessageContext)!;

  return (
    <div>
      <h2>About</h2>
      <p> {message}... but this time in my about component </p>
      <p>Welcome to the about.  There's about things here 
        and they are amazing.
      </p>
    </div>
  )
}

export default About