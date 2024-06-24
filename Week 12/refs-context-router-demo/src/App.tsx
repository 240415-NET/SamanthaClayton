import React from "react";
import NavBar from "./components/NavBar";
import Home from "./components/Home";
import Dashboard from "./components/Dashboard";
import About from "./components/About";
// Import router that I downloaded with npm install
import { BrowserRouter, Route, Routes } from "react-router-dom";
import MessageContextProvider from "./context/MessageContext";
// To give child components access to a context, we have to wrap them in the
// context provider.  In our Home (and in any other child components of App.tsx
// that want to see the context), they import the context itself.
// In our App.tsx parent, we import the context provider.

function App() {
  return (
    <MessageContextProvider>
      <BrowserRouter>
        <NavBar />
        <Routes>
          <Route path="/" Component={Home} />
          <Route path="/about" Component={About} />
          <Route path="/dashboard" Component={Dashboard} />
        </Routes>
      </BrowserRouter>
    </MessageContextProvider>
  );
}

export default App;
