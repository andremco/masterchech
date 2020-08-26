import React from 'react';
import { Navbar, FormGroup, NavbarBrand, Input, Label, Button, Nav, NavItem, NavLink, UncontrolledDropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap';
import { BrowserRouter as Router, Route, Link } from 'react-router-dom'
import { Provider } from "react-redux";
import  initialState  from "./constants/initialState";
import  configureStore  from "./store/configureStore";
import CatalogMenuDescriptionPage from "./components/page/CatalogMenuDescriptionPage";
import './App.css';
import dotenv from 'dotenv';

dotenv.config()
const store = configureStore(initialState)

class App extends React.Component{

  constructor(props){
    super(props);
  }

  render () { 
    return (
        <Provider store={store}>
          <Router>
            <Navbar className="app-navbar fixed-top" expand="xs">
              <NavbarBrand href="https://t.me/MasterChechBot" target="_blank" className="color-app">@MasterChech</NavbarBrand>
              <Nav navbar>
                <UncontrolledDropdown nav inNavbar>
                  <DropdownToggle nav caret className="color-app">
                    Menu do Chech
                  </DropdownToggle>
                </UncontrolledDropdown>
                </Nav>
            </Navbar>
            <div className="container d-flex h-100">
              <div className="align-self-center w-100">
                <Route path="/" exact component={CatalogMenuDescriptionPage} />
              </div>
            </div>
            <div className="footer">
              <p>Bot for telegram &#129302;</p>
            </div>
          </Router>
        </Provider>
        )
    };
}

export default App;
