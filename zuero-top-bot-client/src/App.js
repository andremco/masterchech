import React from 'react';
import { Navbar, FormGroup, NavbarBrand, Input, Label, Button } from 'reactstrap';
import TableList from "./components/TableList";
import Form from "./components/Form";
import './App.css';

function App(){
  return (<div>
    <Navbar className="app-navbar fixed-top">
      {/* <NavbarBrand href="https://telegram.me/ZueroTopBot" target="_blank" className="app-navbar-brand">@</NavbarBrand> */}
      <NavbarBrand href="https://telegram.me/ZueroTopBot" target="_blank" className="app-navbar-brand">Receitas</NavbarBrand>
    </Navbar>
    <div className="container d-flex h-100">
      <div className="align-self-center w-100">
          <TableList></TableList> 
          <Form></Form>
      </div>
    </div>
    <div className="footer">
      {/* <p>Bot for telegram &#129302;</p> */}
      <p>Receitas &#129302;</p>
    </div>
  </div>);
}

export default App;
