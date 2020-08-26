import React from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCheckCircle} from '@fortawesome/free-solid-svg-icons'


function ModalConfirmSuccess(props){
    return(<React.Fragment>
        <Modal isOpen={props.openModal} toggle={props.toggle} className={props.className}>
          <ModalHeader toggle={props.toggle}>Sucesso</ModalHeader>
          <ModalBody>
            Receita cadastrada com sucesso! <FontAwesomeIcon icon={faCheckCircle} color="green"></FontAwesomeIcon>
          </ModalBody>
          <ModalFooter>
            <Button color="success" onClick={props.toggle}>Ok</Button>
          </ModalFooter>
        </Modal>
      </React.Fragment>);
}

export default ModalConfirmSuccess;