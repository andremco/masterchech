import React from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import API from "./API";
import LoadingOverlay from 'react-loading-overlay'
import PacmanLoader from '@bit/davidhu2000.react-spinners.pacman-loader';

class ModalConfirmDelete extends React.Component {

    constructor(props){
      super(props);

      this.state = {
        isLoading: false,
      }
    }

    responseApi = (response) => {
      this.setState({ isLoading: false})
      this.props.toggle();
      this.props.getDescriptions();
    }

    deleteDescription = () => {

      var id = this.props.descriptionId;

      this.setState({ isLoading: true})

      API.delete("description/" + id, this.responseApi)
    }

    render(){
      return(<React.Fragment>
              <LoadingOverlay active={this.state.isLoading} 
                  spinner={<PacmanLoader size={20} color="#61dafb" style={{width:"5px !important", height:"5px !important"}}/>}>
              </LoadingOverlay>
              <Modal isOpen={this.props.openModal} toggle={this.props.toggle} className={this.props.className}>
                <ModalHeader toggle={this.props.toggle}>Deseja excluir o item?</ModalHeader>
                <ModalBody>
                  Você está certo disso? Valendo um milhão de reais
                </ModalBody>
                <ModalFooter>
                  <Button color="danger" onClick={this.deleteDescription}>Sim</Button>{' '}
                  <Button color="secondary" onClick={this.props.toggle}>Não</Button>
                </ModalFooter>
              </Modal>
      </React.Fragment>)
    };
}

export default ModalConfirmDelete;