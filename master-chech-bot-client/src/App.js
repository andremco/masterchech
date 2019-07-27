import React from 'react';
import { Navbar, FormGroup, NavbarBrand, Input, Label, Button, Nav, NavItem, NavLink, UncontrolledDropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap';
import LoadingOverlay from 'react-loading-overlay'
import PacmanLoader from '@bit/davidhu2000.react-spinners.pacman-loader';
import { BrowserRouter as Router, Route, Link } from 'react-router-dom'
import TableList from "./components/TableList";
import Form from "./components/Form";
import './App.css';
import dotenv from 'dotenv';

dotenv.config()



class App extends React.Component{

  constructor(props){
    super(props);
  }

  render () { 
    return (
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

              <Route path="/" exact component={() => <Form setLoading={this.setLoading}></Form>} />
              <Route path="/receitas/" component={TableList} />

            </div>
          </div>
          <div className="footer">
            <p>Bot for telegram &#129302;</p>
          </div>
        </Router>)
    };
}

export default App;
