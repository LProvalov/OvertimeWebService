import React from 'react';

export default class Clock extends React.Component{
    constructor(){
        super();
        this.state = {dateTime: new Date()};
    }

    tick(){
        this.setState( {dateTime: new Date()} );
    }

    componentWillUnmount(){
        clearInterval(this.timerId);
    }

    componentDidMount(){
        this.timerId = setInterval(() => { this.tick(); }, 1000);
    }

    render(){
        return (
            <div>
                {this.state.dateTime.toString()}
            </div>
        );
    }
}