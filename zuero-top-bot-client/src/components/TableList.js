import React from 'react';
import { Table } from 'reactstrap';
import IconActions from './IconActions'

function TableList(props){
    return (<div className="col-lg-6 col-md-12 mx-auto">
    <div className="table-responsive-sm" style={ { marginTop: "80px" } }>
      <h3>Receitas cadastradas</h3>
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
            <td><IconActions></IconActions></td>
          </tr>
          <tr>
            <th scope="row">2</th>
            <td>Jacob</td>
            <td>Thornton</td>
            <td><IconActions></IconActions></td>
          </tr>
          <tr>
            <th scope="row">3</th>
            <td>Larry</td>
            <td>the Bird</td>
            <td><IconActions></IconActions></td>
          </tr>
        </tbody>
      </Table>            
    </div>
  </div>);
}

export default TableList;