import React from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faTrashAlt } from '@fortawesome/free-solid-svg-icons'
import ModalConfirmDelete from './ModalConfirmDelete';

class IconActions extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      openModal: false
    };

    this.toggle = this.toggle.bind(this);
    this.clickOnTrash = this.clickOnTrash.bind(this);
    this.openOrCloseModal = this.openOrCloseModal.bind(this);
  }

  clickOnTrash(){
    this.openOrCloseModal();
  }

  toggle() {
    this.openOrCloseModal();
  }

  openOrCloseModal(){
    this.setState(prevState => ({
        openModal: !prevState.openModal
      }));
  }

  render() {
    return (
        <React.Fragment>
          <FontAwesomeIcon icon={faTrashAlt} color="red" className="pointer" onClick={this.clickOnTrash}></FontAwesomeIcon>
          <ModalConfirmDelete openModal={this.state.openModal} toggle={this.toggle}></ModalConfirmDelete>
        </React.Fragment>
    );
  }
}

export default IconActions;