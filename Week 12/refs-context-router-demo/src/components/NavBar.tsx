import React from 'react'
import { Link } from 'react-router-dom'

function NavBar() {

  return (
    <nav>
      <ul>
        <li><Link to="/">Home</Link></li> {/* Link to my home component*/}
        <li><Link to="/about">About</Link></li> {/* Link to my about component*/}
        <li><Link to="/dashboard">Dashboard</Link></li> {/* Link to my dashboard component*/}
      </ul>
    </nav>
  )
}

export default NavBar