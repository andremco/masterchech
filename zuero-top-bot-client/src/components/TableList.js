import React from 'react';
import { Table, Alert } from 'reactstrap';
import IconActions from './IconActions'
import API from "./API";
import LoadingOverlay from 'react-loading-overlay'
import PacmanLoader from '@bit/davidhu2000.react-spinners.pacman-loader';

class TableList extends React.Component{

  constructor(props){
    super(props);

    this.state = {
      isLoading: false,
      visibleAlert: true,
      descriptions: []
    }

  }

  responseApi = (response) => {
    if(response && response.data){
      this.setState({ descriptions: response.data, isLoading: false });
    }
    else{
      this.setState({ isLoading: false });
    }
  }

  onDismissAlert = () => {
    this.setState({ visibleAlert: false });
  }

  componentDidMount(){
    this.getDescriptions();
  }

  getDescriptions = () => {
    this.setState({ isLoading: true})
    API.get("description", this.responseApi);
  }

  render () 
  {
    return (<div className="col-lg-6 col-md-12 mx-auto">
              <LoadingOverlay active={this.state.isLoading} 
                spinner={<PacmanLoader size={20} color="#61dafb" style={{width:"5px !important", height:"5px !important"}}/>}>
              </LoadingOverlay>
              <div className="table-responsive-sm" style={ { marginTop: "80px"} }>
                <h3 className="text-center">Catálogo/Menu do Master Chech!</h3>
                {
                  this.state.descriptions.length == 0 && !this.state.isLoading && 
                    <Alert color="info" isOpen={this.state.visibleAlert} toggle={this.onDismissAlert}>
                      Nenhum catálogo/menu do Master Chech criado! :(
                    </Alert>
                }
                {
                  this.state.descriptions.length > 0 && 
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
                          this.state.descriptions.map((item, i) => <tr key={i}>
                            <td>{item.id}</td>
                            <td>{item.nameCategory}</td>
                            <td>{item.description}</td>
                            <td><IconActions descriptionId={item.id} getDescriptions={this.getDescriptions}></IconActions></td>
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