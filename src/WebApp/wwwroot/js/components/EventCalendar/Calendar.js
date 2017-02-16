import React, {Component} from 'react';
import CalendarMonth from './CalendarMonth';
import CalendarEvent from './CalendarEvent';

const CE = new CalendarEvent();

class Calendar extends Component {
    constructor(props) {
        super(props);
        this.state = {
            currentDate: props.date ? props.date : new Date(),
            events: props.events ? props.events : [],
            selectedDay: 0
        };

        this.getControlsButtons = this.getControlsButtons.bind(this);
        this.handlePrevButton = this.handlePrevButton.bind(this);
        this.handleNextButton = this.handleNextButton.bind(this);
        this._getCalendarLine = this._getCalendarLine.bind(this);
        this.getCalendarLines = this.getCalendarLines.bind(this);
    }

    _getCalendarLine(lineItems){
        const itemsView = lineItems.map((item, index) => {
            let dayClassName = "";
            if(item.event){
                dayClassName = CE.EventTypeEnum().properties[item.event.type].name + "-item";
            }
            if(this.state.selectedDay == item.day && item.day != 0){
                dayClassName += (dayClassName.length > 0 ? " " : "") + "selected-day";
            }
            return (
                <span key={index.toString()} className={dayClassName} 
                    onClick={this.handleOnDayClick.bind(this, item)}>
                    {item.day.toString()}
                </span>
            );
        });
        return (
            <div className="lineItem">
            {itemsView}
            </div>
        );
    }

    getCalendarLines(){
        let model = new CalendarMonth(this.state.currentDate);
        const daysArray = model.getDaysArray();
        let weekArray = [];
        for(let i = 0; i < daysArray.length; i += 7){
            let sliceIndex = i + 7 <= daysArray.length ? i + 7 : daysArray.length;
            let wA = daysArray.slice(i, sliceIndex).map((day, index) => {
                let ret = { "day": day, "currentDate": this.state.currentDate };
                for(let i = 0; i < this.state.events.length; ++i){
                    let val = this.state.events[i];
                    let eventDate = val.getDate();
                    if(day != 0 && eventDate.getFullYear() == this.state.currentDate.getFullYear() &&
                    eventDate.getMonth() == this.state.currentDate.getMonth() &&
                    eventDate.getDate() == day){
                        ret = {"day": day, "currentDate": this.state.currentDate, "event": val};
                        break;
                    }
                };
                return ret;
            });
            if(wA[0].day != 0 || wA[6].day != 0) {
                weekArray.push(wA);
            }
        }
        return weekArray.map((item, index) => { 
            return (
                <div key = {index.toString()}>
                {this._getCalendarLine(item)}
                </div>
            );
        });
    }

    handlePrevButton(e){
        this.setState((prev, props) => {
            prev.currentDate.setMonth(prev.currentDate.getMonth() - 1);
            return {                 
                currentDate: prev.currentDate,
                selectedDay: 0
                };
        });
    }

    handleNextButton(e){
        this.setState((prev, props) => {
            prev.currentDate.setMonth(prev.currentDate.getMonth() + 1);
            return {                 
                currentDate: prev.currentDate,
                selectedDay: 0
                };
        });
    }

    handleOnDayClick(dayObject){
        if(dayObject.day > 0){
            this.setState({
                selectedDay: dayObject.day
            });
            if(this.props.onDayClick)
                this.props.onDayClick(dayObject);
        }
    }

    getControlsButtons(){
        return (
            <div className="calendar-controls">
                <input type="button" value="prev month" onClick={this.handlePrevButton}/>
                {this.state.currentDate.toLocaleDateString()}
                <input type="button" value="next month" onClick={this.handleNextButton}/>
            </div>
        );
    }
    
    render() {
        return (
            <div className="calendar">
                {this.getControlsButtons()}
                {this.getCalendarLines()}
            </div>
        );
    }
}

export default Calendar;