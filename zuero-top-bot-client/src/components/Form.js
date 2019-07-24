import React from 'react';
import { FormGroup, Input, Label, Button, Alert, FormFeedback } from 'reactstrap';
import { Formik, ErrorMessage } from 'formik'
import ModalConfirmSuccess from "./ModalConfirmSuccess";

const SpinnerPage = () => {
  return (
    <div>
      <div class="spinner-border spinner-border" role="status">
        <span class="sr-only">Loading...</span>
      </div>
    </div>
  );
}

class Form extends React.Component {

    constructor(props){
        super(props);

        this.state = {
            openModalSuccess: false
        }
        this.toggleSuccess = this.toggleSuccess.bind(this);
        this.openOrCloseModalSuccess = this.openOrCloseModalSuccess.bind(this);
    }

    toggleSuccess() {
        this.openOrCloseModalSuccess();
    }

    openOrCloseModalSuccess(){
        this.setState(prevState => ({
                openModalSuccess: !prevState.openModalSuccess
            }));
    }

    validate = (values) => {

        let errors = {};
    
        if (!values.category || values.category.toLowerCase() === 'selecione') {
            errors.category = 'O campo categoria é obrigatório!';
        } 
        
        if(!values.description) {
            errors.description = 'O campo categoria é obrigatório!';
        }
    
        return errors;
    }
    
    onSubmit = (values, props) => {
        props.setSubmitting(false);


        
        this.openOrCloseModalSuccess();
    }
    
    form = (props) => (
        <React.Fragment>
            <form onSubmit={props.handleSubmit}>
                <FormGroup>
                    <Label for="category">Categoria</Label>
                    <Input type="select" name="category" id="category" onChange={props.handleChange}
                    onBlur={props.handleBlur} value={props.values.category} invalid={(props.errors.category) ? true : false}>
                        <option value="selecione">Selecione</option>
                        <option value="receita">Receita</option>
                    </Input>
                    {props.errors.category && <FormFeedback>{props.errors.category}</FormFeedback>}
                    
                </FormGroup>
                <FormGroup>
                    <Label for="description">Descrição</Label>
                    <Input type="textarea" name="description" id="description" onChange={props.handleChange}
                    onBlur={props.handleBlur} value={props.values.description} invalid={(props.errors.description) ? true : false}/>
                    {props.errors.description && <FormFeedback>{props.errors.description}</FormFeedback>}
                </FormGroup>
                <FormGroup style={{height: "80px"}}>
                    <Button outline color="info" style={{float: "right"}} disabled={props.isSubmitting}>Enviar</Button>      
                </FormGroup> 
            </form>
        </React.Fragment>)

    render(){
        var initialValues = {category: '', description: ''}

        return(<div className="col-lg-6 col-md-12 mx-auto" style={{marginTop: "80px"}}>
            {/* <SpinnerPage></SpinnerPage> */}
            <h3>Cadastrar receita</h3>
            <Formik initialValues={initialValues} onSubmit={this.onSubmit} validate={this.validate}>
                {this.form}
            </Formik>
            {this.state.openModalSuccess && <ModalConfirmSuccess openModal={this.state.openModalSuccess} toggle={this.toggleSuccess}></ModalConfirmSuccess>}
        </div>);
    }

}

export default Form;