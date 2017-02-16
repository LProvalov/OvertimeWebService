
class CalendarMonth {
    constructor(props){
        let todayDate;
        if(props && props instanceof Date){
            todayDate = props;
        } else {
            todayDate = new Date();
        } 
        this.selectedYear = this.currentYear = todayDate.getFullYear();
        this.selectedMonth = this.currentMonth = todayDate.getMonth();
        this.selectedDate = this.currentDate = todayDate.getDate();
        this.monthsDays = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
    }
    _isIntercalaryYear(year){
        if(year % 4 != 0) return false;
        if(year % 100 != 0) {
            return true;
        } else {
            if(year % 400 == 0) return true;
        }
        return false;
    }

    setSelectedDate(year, month, date){
        this.selectedYear = year;
        this.selectedMonth = month;
        this.selectedDate = date;
    }

    _offsetFromBeginningOfMonth(currentYear, currentMonth){
        let currentDate = new Date(currentYear, currentMonth, 1);
        let currentDay = currentDate.getDay();
        if(currentDay == 0) currentDay = 7;
        return currentDay - 1;
    }
    
    getDaysArray(){
        let daysArray = new Array(42);
        const offset = this._offsetFromBeginningOfMonth(this.selectedYear, this.selectedMonth);
        for(let i = 0; i < offset; i++){
            daysArray[i] = 0;
        }
        if(this._isIntercalaryYear(this.selectedDate)) this.monthsDays[1] = 29;
        else this.monthsDays[1] = 28;
        let maxDayInMonth = this.monthsDays[this.selectedMonth];
        for(let i = offset, j = 1; i < daysArray.length; i++){
             daysArray[i] = j <= maxDayInMonth ? j++ : 0;
         }
        return daysArray;
    }
}

export default CalendarMonth;