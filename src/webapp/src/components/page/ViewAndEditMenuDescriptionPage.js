import React from 'react';
import { Table, Alert } from 'reactstrap';
import IconActions from '../modals/IconActions'
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux';
import { getAllMenuDescriptions, deleteMenuDescription } from "../../actions/menuDescriptions";
import { loaded, loading } from "../../actions/loading";
import LoadingOverlay from 'react-loading-overlay'
import PacmanLoader from '@bit/davidhu2000.react-spinners.pacman-loader';

class ViewAndEditMenuDescriptionPage extends React.Component{

  constructor(props){
    super(props);

    this.state = {
      visibleAlert: true,
    }

  }

  onDismissAlert = () => {
    this.setState({ visibleAlert: false });
  }

  componentDidMount(){
    this.props.actions.getAllMenuDescriptions()
  }

  enableLoading = () => {
    this.props.actions.loading();
  }

  disableLoading = () => {
    this.props.actions.loaded();
  }

  render () 
  {
    return (<div className="col-lg-6 col-md-12 mx-auto">
              <LoadingOverlay active={this.props.loading} 
                spinner={<PacmanLoader size={20} color="#61dafb" style={{width:"5px !important", height:"5px !important"}}/>}>
              </LoadingOverlay>
              <div className="table-responsive-sm" style={ { marginTop: "80px"} }>
                <h3 className="text-center">Catálogo/Menu do Master Chech!</h3>
                {
                  this.props.menuDescriptions.length == 0 && !this.props.loading && 
                    <Alert color="info" isOpen={this.state.visibleAlert} toggle={this.onDismissAlert}>
                      Nenhum catálogo/menu do Master Chech criado! :(
                    </Alert>
                }
                {
                  this.props.menuDescriptions.length > 0 && 
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
                          this.props.menuDescriptions.map((item, i) => <tr key={i}>
                            <td>{item.id}</td>
                            <td>{item.nameCategory}</td>
                            <td>{item.description}</td>
                            <td><IconActions descriptionId={item.id} getAllMenuDescriptions={this.props.actions.getAllMenuDescriptions} 
                                  deleteMenuDescription={this.props.actions.deleteMenuDescription}></IconActions></td>
                          </tr>)
                        }
                      </tbody>
                    </Table>
                }
                            
              </div>
            </div>);
  }
}

export const mapStateToProps = state => {
  return state
} 

export const mapDispatchToProps = dispatch => {
  return {
      actions: bindActionCreators({
        getAllMenuDescriptions,
        deleteMenuDescription,
        loading,
        loaded    
      }, dispatch)
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(ViewAndEditMenuDescriptionPage);