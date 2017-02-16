import React from 'react';

export default class NoteItem extends React.Component{
    constructor(props){
        super(props);

        this.state = {
            items: [],
            inputValue: ''
        };

        this.handleOnCange = this.handleOnCange.bind(this);
        this.handleOnAdd = this.handleOnAdd.bind(this);
        this.handleOnKeypress = this.handleOnKeypress.bind(this);
        this.handleOnClear = this.handleOnClear.bind(this);
    }
    handleOnCange(event){
        this.setState({inputValue: event.target.value});
    }
    handleOnKeypress(event){
        if(event.key === 'Enter'){
            this.handleOnAdd(event);
        }        
    }
    handleOnAdd(event){
        if(this.state.inputValue != ''){
            this.setState((prev, props) => {
                prev.items.push(prev.inputValue);
                return {
                    items: prev.items,
                    inputValue: ''
                }
            });
        }
    }
    handleOnClear(event){
        this.setState({
            items: [],
            inputValue: ''
        });
    }
    getItemsList(){
        return this.state.items.map((item, index) =>{
            return (
                <li key={index.toString()}>{item}</li>
            );
        });
    }
    render(){
        const inputField = (
            <div>
                <input type="text" name="noteitemInput" value={this.state.inputValue} 
                    onChange={this.handleOnCange} 
                    onKeyPress={this.handleOnKeypress} />
                <input type="button" name="noteitemAddButton" onClick={this.handleOnAdd} value="Add" />
                <input type="button" name="noteitemClear" onClick={this.handleOnClear} value="Clear" />
            </div>
        );
        return (
            <div>
                <ul>
                    {this.getItemsList()}
                </ul>
                {inputField}
            </div>);
    }
}