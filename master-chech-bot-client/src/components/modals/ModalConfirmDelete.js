import React from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import API from "../../API/API";
import LoadingOverlay from 'react-loading-overlay'
import PacmanLoader from '@bit/davidhu2000.react-spinners.pacman-loader';

class ModalConfirmDelete extends React.Component {

    constructor(props){
      super(props);
    }

    responseApi = (response) => {
      this.props.disableLoading();
      this.props.toggle();
      this.props.getDescriptions();
    }

    deleteDescription = () => {

      var id = this.props.descriptionId;

      this.props.enableLoading();

      API.delete("description/" + id, this.responseApi)
    }

    render(){
      return(<React.Fragment>
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