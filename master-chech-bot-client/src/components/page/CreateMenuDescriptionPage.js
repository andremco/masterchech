import React from 'react';
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux';
import { getAllCategories } from "../../actions/categories";
import { createMenuDescription } from "../../actions/menuDescriptions";
import { FormGroup, Input, Label, Button, Alert, FormFeedback } from 'reactstrap';
import { Formik, ErrorMessage } from 'formik'
import ModalConfirmSuccess from "../modals/ModalConfirmSuccess";
import LoadingOverlay from 'react-loading-overlay'
import PacmanLoader from '@bit/davidhu2000.react-spinners.pacman-loader';

class CreateMenuDescriptionPage extends React.Component {

    constructor(props){
        super(props);

        this.state = {
            openModalSuccess: false,
        }
        this.openOrCloseModalSuccess = this.openOrCloseModalSuccess.bind(this);
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

        var data = {"categoryId": values.category, "description": values.description}

        this.props.actions.createMenuDescription(data, this.openOrCloseModalSuccess);
    }
    
    form = (props) => (
        <React.Fragment>
            <form onSubmit={props.handleSubmit}>
                <FormGroup>
                    <Label for="category">Categoria</Label>
                    <Input type="select" name="category" id="category" onChange={props.handleChange}
                    onBlur={props.handleBlur} value={props.values.category} invalid={(props.errors.category) ? true : false}>
                        <option value="selecione">Selecione</option>
                        {
                            this.props.categories && this.props.categories.map((item, i) => <option key={i} value={item.id}>{item.name}</option>) 
                        }
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
                    <Button outline color="info" style={{float: "right"}} disabled={props.isSubmitting}>Enviar</Button>      
                </FormGroup> 
            </form>
        </React.Fragment>
    )

    componentDidMount(){
        this.props.actions.getAllCategories();
    }

    render(){
        var initialValues = {category: '', description: ''}

        return(<div className="col-lg-6 col-md-12 mx-auto" style={{marginTop: "80px"}}>
            <LoadingOverlay active={this.props.loading} 
                spinner={<PacmanLoader size={20} color="#61dafb" style={{width:"5px !important", height:"5px !important"}}/>}>
            </LoadingOverlay>
            <h3>Cadastrar menu</h3>
            <Formik initialValues={initialValues} onSubmit={this.onSubmit} validate={this.validate}>
                {this.form}
            </Formik>
            {this.state.openModalSuccess && <ModalConfirmSuccess openModal={this.state.openModalSuccess} toggle={this.openOrCloseModalSuccess}></ModalConfirmSuccess>}
        </div>);
    }

}

export const mapStateToProps = state => {
    return state
} 

export const mapDispatchToProps = dispatch => {
    return {
        actions: bindActionCreators({
           getAllCategories,
           createMenuDescription    
        }, dispatch)
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(CreateMenuDescriptionPage);