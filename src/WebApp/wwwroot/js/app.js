import React from 'react';
import ReactDOM from 'react-dom';

import Clock from './components/Clock';
import Calendar from './components/EventCalendar/Calendar';
import CalendarEvent from './components/EventCalendar/CalendarEvent';
import DayViewer from './components/DayViewer/DayViewer';
import DayDetailDataProvider from './data_providers/DayDetailDataProvider';

class AppComponent extends React.Component {
    constructor(){
        super();
        this.state={
            selectedEventId: null
        };
        this.onDayClickHandler = this.onDayClickHandler.bind(this);
    }
    onDayClickHandler(obj){
        console.log(obj);
        if(obj.event){
            this.setState({
                selectedEventId: obj.event.id
            });
        } else {
             this.setState({
                selectedEventId: null
            });
        }
    }
    app(){
        const CE = new CalendarEvent();
        const dataProvider = new DayDetailDataProvider();
        console.log('app started');
        dataProvider.getAllDaysByMonthAndOwnerId(new Date(), 0);
        return (
        <div>
            <Clock />
            <br/>
            <div className="event-calendar">
                <Calendar date={new Date()} events={events} onDayClick={this.onDayClickHandler}/>
            </div>
            <div className="view">
                <DayViewer dataProvider={dataProvider} selectedEventId={this.state.selectedEventId}/>
            </div>
        </div>);
    }
    render() {
        return (
            <div>
            {this.app()}
            </div>
        );
    }
}

ReactDOM.render(<AppComponent/>,
 document.getElementById('root'));
