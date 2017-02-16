
class CalendarEvent {
    constructor(props){
        if(props){
            this.date = (props.date && props.date instanceof Date) ? props.date : new Date();
            this.type = (props.type) ? props.type : 0;
            this.id = (props.id) ? props.id : null;
        }
    }

    getDate(){ return this.date; }
    getType(){ return this.type; }
    getId(){ return this.id; }
    
    EventTypeEnum(){
        return {
            UNDEFINED: 0,
            COMMENT: 1,
            SIMPLE_EVENT: 2,            
            properties: {
                0: {name: "undefined", value: 0, code: "U"},
                1: {name: "comment", value: 1, code: "C"},
                2: {name: "simpleEvent", value: 2, code: "SE"}                
            }
        }
    }
}

export default CalendarEvent;