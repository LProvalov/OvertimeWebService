import React from 'react';
import Checkbox from './Checkbox';

export default class CheckboxList extends React.Component{
    constructor(props){
        super(props);
        this.state = {items: [{text: "item#1"}, {text: "item#2"}, {text: "item#3"}]};

        this.itemList = this.itemList.bind(this);
    }

    itemList(){
        return this.state.items.map((item, index) => 
            <Checkbox id={this.props.id ? this.props.id + "_" + index.toString() : 
            "item_" + index.toString()} key={index.toString()} text={item.text}/>
        );
    }

    render(){
        const listItem = this.itemList();
        return(
            <div>
            {listItem}
            </div>
        );
    }
}