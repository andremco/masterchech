import React from 'react';
import { Navbar, FormGroup, NavbarBrand, Input, Label, Button, Nav, NavItem, NavLink, UncontrolledDropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap';
import { BrowserRouter as Router, Route, Link } from 'react-router-dom'
import { Provider } from "react-redux";
import  initialState  from "./constants/initialState";
import  configureStore  from "./store/configureStore";
import ViewAndEditRecipesPage from "./components/page/ViewAndEditRecipesPage";
import CreateRecipePage from "./components/page/CreateRecipePage";
import './App.css';
import './store/exampleUse'
import dotenv from 'dotenv';

dotenv.config()
debugger;
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
                  <DropdownMenu right style={{left: "5px"}}>
                    <DropdownItem>
                      <Link to="/" className="item-menu-app">Cadastrar</Link>
                    </DropdownItem>
                    <DropdownItem>
                      <Link to="/receitas/" className="item-menu-app">Visualizar</Link>
                    </DropdownItem>
                  </DropdownMenu>
                </UncontrolledDropdown>
                </Nav>
            </Navbar>
            <div className="container d-flex h-100">
              <div className="align-self-center w-100">

                <Route path="/" exact component={CreateRecipePage} />
                {/* <Route path="/receitas/" component={ViewAndEditRecipesPage} /> */}

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
