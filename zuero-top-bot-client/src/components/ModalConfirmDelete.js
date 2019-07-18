import React from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';

function ModalConfirmDelete(props){
    return(<React.Fragment>
        <Modal isOpen={props.openModal} toggle={props.toggle} className={props.className}>
          <ModalHeader toggle={props.toggle}>Deseja excluir o item?</ModalHeader>
          <ModalBody>
            Você está certo disso? Valendo um milhão de reais
          </ModalBody>
          <ModalFooter>
            <Button color="danger" onClick={props.toggle}>Sim</Button>{' '}
            <Button color="secondary" onClick={props.toggle}>Não</Button>
          </ModalFooter>
        </Modal>
      </React.Fragment>);
}

export default ModalConfirmDelete;