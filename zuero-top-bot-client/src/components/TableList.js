import React from 'react';
import { Table, Alert } from 'reactstrap';
import IconActions from './IconActions'
import API from "./API";

class TableList extends React.Component{

  constructor(props){
    super(props);

    this.state = {
      isLoading: false,
      visibleAlert: true,
      payload: {
        data: []
      }
    }

  }

  getDescriptions = (data) => {
    this.setState({payload: data,isLoading: false});
  }

  onDismissAlert = () => {
    this.setState({ visible: false });
  }

  componentDidMount(){

    API.get("description", this.getDescriptions);

  }

  render () 
  {
    return (<div className="col-lg-6 col-md-12 mx-auto">
      <div className="table-responsive-sm" style={ { marginTop: "80px"} }>
        <h3>Receitas cadastradas</h3>
        {
          this.state.payload.data.length == 0 && !this.state.isLoading && 
            <Alert color="info" isOpen={this.state.visibleAlert} toggle={this.onDismissAlert}>
              Nenhuma receita cadastradas ainda :(
            </Alert>
        }
        {
          this.state.payload.data.length > 0 && 
            <Table style={ {marginBottom: "75px"} }>
              <thead>
                <tr>
                  <th></th>
                  <th>Categoria</th>
                  <th>Descrição</th>
                  <th>Ações</th>
                </tr>
              </thead>
              <tbody>
                {
                  this.state.payload.data.map((item, i) => <tr key={i}>
                    <td>{item.id}</td>
                    <td>{item.nameCategory}</td>
                    <td>{item.description}</td>
                    <td><IconActions></IconActions></td>
                  </tr>)
                }
              </tbody>
            </Table>
        }
                    
      </div>
    </div>);
  }
}
export default TableList;