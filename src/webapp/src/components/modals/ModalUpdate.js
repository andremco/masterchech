import React from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import { FormGroup, Input, Label, FormFeedback } from 'reactstrap';
import { Formik } from 'formik'

class ModalUpdate extends React.Component {

    constructor(props){
      super(props);
    }

    deleteDescription = () => {

    }

    validate = (values) => {

        let errors = {};
    
        if (!values.category) {
            errors.category = 'O campo categoria é obrigatório!';
        } 
        
        if(!values.description) {
            errors.description = 'O campo categoria é obrigatório!';
        }
    
        return errors;
    }

    onSubmit = (values, props) => {
        props.setSubmitting(false);

        var data = {"id": this.props.description.id, "categoryId": values.category, "description": values.description}

        this.props.updateMenuDescription(data, this.props.toggle);
    }

    form = (props) => (
        <React.Fragment>
            <form onSubmit={props.handleSubmit}>
                <FormGroup>
                    <Label for="category">Categoria</Label>
                    <Input type="select" name="category" id="category" onChange={props.handleChange} disabled
                    onBlur={props.handleBlur} value={props.values.category} invalid={(props.errors.category) ? true : false}>
                        <option value="selecione">Selecione</option>
                        <option value={props.values.category}>{this.props.description.nameCategory}</option>
                    </Input>
                    {props.errors.category && <FormFeedback>{props.errors.category}</FormFeedback>}
                    
                </FormGroup>
                <FormGroup>
                    <Label for="description">Descrição</Label>
                    <Input type="textarea" name="description" id="description" onChange={props.handleChange} maxLength={250}
                    onBlur={props.handleBlur} value={props.values.description} invalid={(props.errors.description) ? true : false}/>
                    {props.errors.description && <FormFeedback>{props.errors.description}</FormFeedback>}
                </FormGroup>
                <FormGroup style={{height: "80px"}}>
                    <Button outline color="info" style={{float: "right"}} disabled={props.isSubmitting} className={"btn-sm"}>Enviar</Button>      
                </FormGroup> 
            </form>
        </React.Fragment>
    )

    render(){

        var initialValues = {category: this.props.description.categoryId, description: this.props.description.description}

        return(<React.Fragment>
              <Modal isOpen={this.props.openModal} toggle={this.props.toggle} className={this.props.className}>
                <ModalHeader toggle={this.props.toggle}>Atualizar catálogo</ModalHeader>                
                <ModalBody>
                    <Formik initialValues={initialValues} onSubmit={this.onSubmit} validate={this.validate}>
                        {this.form}
                    </Formik>    
                </ModalBody>
                <ModalFooter>
                    <Button color="secondary" onClick={this.props.toggle}>Sair</Button>
                </ModalFooter>    
              </Modal>
            </React.Fragment>)
    };
}

export default ModalUpdate;