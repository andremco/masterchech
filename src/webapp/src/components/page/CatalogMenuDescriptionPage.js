import React from 'react';
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux';
import { getAllCategories } from "../../actions/categories";
import { getAllMenuDescriptions, createMenuDescription, deleteMenuDescription, updateMenuDescription } from "../../actions/menuDescriptions";
import { FormGroup, Input, Label, Button, Alert, FormFeedback } from 'reactstrap';
import { Formik } from 'formik'
import ModalConfirmSuccess from "../modals/ModalConfirmSuccess";
import LoadingOverlay from 'react-loading-overlay'
//import PacmanLoader from '@bit/davidhu2000.react-spinners.pacman-loader';
import { MDBDataTable } from 'mdbreact';
import IconActions from '../modals/IconActions'
import "@fortawesome/fontawesome-free/css/all.min.css";
import 'mdbreact/dist/css/mdb.css'

class CatalogMenuDescriptionPage extends React.Component {

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
                    <Button outline color="info" style={{float: "right"}} disabled={props.isSubmitting} className={"btn-sm"}>Enviar</Button>      
                </FormGroup> 
            </form>
        </React.Fragment>
    )

    componentDidMount(){
        this.props.actions.getAllCategories();
        this.props.actions.getAllMenuDescriptions();
    }

    render(){
        var initialValues = {category: '', description: ''}

        return(<React.Fragment>
                <div className="col-lg-6 col-md-12 mx-auto" style={{marginTop: "80px"}}>
                    <LoadingOverlay active={this.props.loading} 
                        spinner={
                          // <PacmanLoader size={20} color="#61dafb" style={{width:"5px !important", height:"5px !important", zIndex: "9999" }}/>
                        }>
                    </LoadingOverlay>
                    <h3>Cadastrar menu</h3>
                    <Formik initialValues={initialValues} onSubmit={this.onSubmit} validate={this.validate}>
                        {this.form}
                    </Formik>
                    {this.state.openModalSuccess && <ModalConfirmSuccess openModal={this.state.openModalSuccess} toggle={this.openOrCloseModalSuccess}></ModalConfirmSuccess>}
                </div>
                <div className="col-lg-6 col-md-12 mx-auto" style={{marginTop: "25px", marginBottom: "55px"}}>
                    <MenuDescriptionsTable data={this.props.menuDescriptions} 
                      getAllMenuDescriptions={this.props.actions.getAllMenuDescriptions} 
                      deleteMenuDescription={this.props.actions.deleteMenuDescription}
                      updateMenuDescription={this.props.actions.updateMenuDescription}>
                    </MenuDescriptionsTable>
                </div>
        </React.Fragment>
        );
    }

}

const MenuDescriptionsTable = (props) => {
  var data = {
    columns: [
      {
        label: '#',
        field: 'id',
        sort: 'asc',
        width: 80
      },
      {
        label: 'Categoria',
        field: 'nameCategory',
        sort: 'asc',
        width: 80
      },
      {
        label: 'Descrição',
        field: 'description',
        sort: 'asc',
        width: 200
      },
      {
        label: 'Ações',
        field: 'actions',
        width: 80
      }
    ],
    rows: [
    ]
  };

  if(props){
    for(let index in props.data){
      var id = props.data[index].description

      data.rows[index] = {
        id: props.data[index].id,
        nameCategory: props.data[index].nameCategory,
        description: props.data[index].description,
        actions: <IconActions description={props.data[index]} 
                              deleteMenuDescription={props.deleteMenuDescription}
                              updateMenuDescription={props.updateMenuDescription}>
                  </IconActions>
      }
    }
  }

  if(data.rows.length > 0){
    return (<React.Fragment>
      <h3>Catálogo/Menu do Master Chech!</h3>
      <MDBDataTable
        striped
        bordered
        hover
        data={data}
        paginationLabel={["Anterior", "Próximo"]}
        infoLabel={["Exibindo", "para", "total de", "resultados"]}
        entriesLabel={"Exibir"}
        searchLabel={"Pesquisar"}
      />
    </React.Fragment>);
  }

  return null

}

export const mapStateToProps = state => {
    return state
} 

export const mapDispatchToProps = dispatch => {
    return {
        actions: bindActionCreators({
           getAllCategories,
           getAllMenuDescriptions,
           createMenuDescription,
           deleteMenuDescription,
           updateMenuDescription    
        }, dispatch)
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(CatalogMenuDescriptionPage);