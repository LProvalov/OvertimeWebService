import React, {Component} from 'react';
import DayDetailDataProvider from '../../data_providers/DayDetailDataProvider';

class DayViewer extends Component {
    constructor(props){
        super(props);
        this.state = {
            comment: ""
        };

        this._getDayComment = this._getDayComment.bind(this);
        this.componentWillReceiveProps = this.componentWillReceiveProps.bind(this);
    }

    componentWillReceiveProps(nextProps) {
        nextProps.dataProvider.getDayCommentByDayIdAsync(nextProps.selectedEventId).then( 
            (response)=>{
                if(this.props.selectedEventId == response.dayId) 
                    this.setState({comment: response.comment});
            });
    }

    _getDayComment(dayId){
        // Added check on instanceof DataProvider
        if(this.props.dataProvider){
            const comment = this.props.dataProvider.getDayCommentByDayId(dayId);
            return (
                <div>
                    {comment}
                </div>
            );
        }        
    }

    render() {
        const comment = this.state.comment;
        return (
            <div>
                {comment}
            </div>
        );
    }
}

export default DayViewer;