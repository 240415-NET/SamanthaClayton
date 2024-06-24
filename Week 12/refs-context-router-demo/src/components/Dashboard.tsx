
import React, {useContext} from 'react';
import { MessageContext } from '../context/MessageContext';

function Dashboard() {

  const {message, setMessage} = useContext(MessageContext)!;
  return (
    <div>
      <h2>Dashboard</h2>
      <p>{message} in my dashboard!!!!!!!!</p>
      <p>Welcome to the dashboard.  There's dashboard things here 
        and they are amazing.
      </p>
    </div>
  )
}

export default Dashboard