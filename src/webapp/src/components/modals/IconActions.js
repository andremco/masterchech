import React from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faTrashAlt, faEdit } from '@fortawesome/free-solid-svg-icons'
import ModalConfirmDelete from './ModalConfirmDelete';
import ModalUpdate from "./ModalUpdate";

class IconActions extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      openModalDelete: false,
      openModalUpdate: false
    };

    this.toggleModalDelete = this.toggleModalDelete.bind(this);
    this.toggleModalUpdate = this.toggleModalUpdate.bind(this);
    this.clickOnTrash = this.clickOnTrash.bind(this);
    this.clickOnEdit = this.clickOnEdit.bind(this);
    this.openOrCloseModalDelete = this.openOrCloseModalDelete.bind(this);
    this.openOrCloseModalUpdate = this.openOrCloseModalUpdate.bind(this);
  }

  clickOnTrash(){
    this.openOrCloseModalDelete();
  }

  clickOnEdit(){
    this.openOrCloseModalUpdate();
  }

  toggleModalDelete() {
    this.openOrCloseModalDelete();
  }

  toggleModalUpdate(){
    this.openOrCloseModalUpdate();
  }

  openOrCloseModalDelete(){
    this.setState(prevState => ({
      openModalDelete: !prevState.openModalDelete
      }));
  }

  openOrCloseModalUpdate(){
    this.setState(prevState => ({
      openModalUpdate: !prevState.openModalUpdate
    }))
  }

  render() {
    return (
        <React.Fragment>
          <FontAwesomeIcon icon={faEdit} color="turquoise" className="pointer" onClick={this.clickOnEdit} style={{ marginRight: "5px"}}></FontAwesomeIcon>
          <FontAwesomeIcon icon={faTrashAlt} color="red" className="pointer" onClick={this.clickOnTrash}></FontAwesomeIcon>
          <ModalUpdate openModal={this.state.openModalUpdate} toggle={this.toggleModalUpdate} description={this.props.description} 
            updateMenuDescription={this.props.updateMenuDescription}></ModalUpdate>
          <ModalConfirmDelete openModal={this.state.openModalDelete} toggle={this.toggleModalDelete} descriptionId={this.props.description.id} 
            deleteMenuDescription={this.props.deleteMenuDescription}></ModalConfirmDelete>
        </React.Fragment>
    );
  }
}

export default IconActions;