import React from 'react';

export default class LaserButton extends React.Component{
    constructor(props){
        super(props);
    }

    activateLaser(e){
        console.log(e);
        e.preventDefault();
        console.log("Laser have been activated");
    }

    render(){
        return (<button onClick={this.activateLaser}>
        {this.props.text}
        </button>);
    }
}