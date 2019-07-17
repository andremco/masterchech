import React from 'react';
import {
  Table,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavLink,
  UncontrolledDropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem } from 'reactstrap';
import logo from './logo.svg';
import './App.css';

// function App() {
//   return (
//     <div className="App">
//       <header className="App-header">
//         <img src={logo} className="App-logo" alt="logo" />
//         <p>
//           Edit <code>src/App.js</code> and save to reload.
//         </p>
//         <a
//           className="App-link"
//           href="https://reactjs.org"
//           target="_blank"
//           rel="noopener noreferrer"
//         >
//           Learn React
//         </a>
//       </header>
//     </div>
//   );
// }

function App(){
  return (<div>
    <Navbar className="app-navbar fixed-top">
      {/* <NavbarBrand href="https://telegram.me/ZueroTopBot" target="_blank" className="app-navbar-brand">@</NavbarBrand> */}
      <NavbarBrand href="https://telegram.me/ZueroTopBot" target="_blank" className="app-navbar-brand">Receitas</NavbarBrand>
    </Navbar>
    <div className="container d-flex h-100">
      <div className="align-self-center w-100">
          <div className="col-lg-6 col-md-12 mx-auto">
            <div /*className="table-responsive-sm"*/ style={ { marginTop: "80px" } }>
              <Table>
                <thead>
                  <tr>
                    <th></th>
                    <th>Categoria</th>
                    <th>Descrição</th>
                    <th>Ações</th>
                  </tr>
                </thead>
                <tbody>
                  <tr>
                    <th scope="row">1</th>
                    <td>Mark</td>
                    <td>Otto</td>
                    <td> - </td>
                  </tr>
                  <tr>
                    <th scope="row">2</th>
                    <td>Jacob</td>
                    <td>Thornton</td>
                    <td> - </td>
                  </tr>
                  <tr>
                    <th scope="row">3</th>
                    <td>Larry</td>
                    <td>the Bird</td>
                    <td> - </td>
                  </tr>
                </tbody>
              </Table>            
            </div>
              
          </div>
      </div>
    </div>
    <div className="footer">
      {/* <p>Bot for telegram &#129302;</p> */}
      <p>Receitas &#129302;</p>
    </div>
  </div>);
}

export default App;
