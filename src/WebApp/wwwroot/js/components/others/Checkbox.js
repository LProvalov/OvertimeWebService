import React from 'react';

export default class Checkbox extends React.Component{
    constructor(props){
        super(props);
        this.state = {is_checked: false};
        this.handleClick = this.handleClick.bind(this);
    }

    handleClick(){
        this.setState(prev => ({
            is_checked: !prev.is_checked
        }));
    }

    render(){
        return (
            <span>
            <input id={this.props.id} type="checkbox"
             onClick={this.handleClick}/>
             {this.props.text} - {this.state.is_checked.toString()}
             </span>
        );
    }
}