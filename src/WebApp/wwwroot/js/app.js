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
        /*let events =[ 
            new CalendarEvent({"date": new Date(2017, 1, 1), "type": CE.EventTypeEnum().UNDEFINED}),
            new CalendarEvent({"date": new Date(2017, 1, 2), "type": CE.EventTypeEnum().UNDEFINED}),
            new CalendarEvent({"date": new Date(2017, 1, 3), "type": CE.EventTypeEnum().UNDEFINED}),
            new CalendarEvent({"date": new Date(2017, 1, 18), "type": CE.EventTypeEnum().COMMENT, "id": 1}),
            new CalendarEvent({"date": new Date(2017, 1, 19), "type": CE.EventTypeEnum().COMMENT, "id": 3}),
            new CalendarEvent({"date": new Date(2017, 1, 20), "type": CE.EventTypeEnum().COMMENT, "id": 4}),
            new CalendarEvent({"date": new Date(2017, 1, 28), "type": CE.EventTypeEnum().SIMPLE_EVENT}),
            new CalendarEvent({"date": new Date(2017, 2, 8), "type": CE.EventTypeEnum().SIMPLE_EVENT}),
            new CalendarEvent({"date": new Date(2017, 2, 16), "type": CE.EventTypeEnum().SIMPLE_EVENT}),
            new CalendarEvent({"date": new Date(2017, 2, 24), "type": CE.EventTypeEnum().COMMENT, "id": 2})];
         */
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
