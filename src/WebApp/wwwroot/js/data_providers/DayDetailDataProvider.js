import HttpService from '../services/HttpService';

class DayDetailDataProvider{
    constructor(props) {
        
    }

    getAllDaysByMonthAndOwnerId(date, ownerId){
        console.log("Date:" + date);
        console.log("OwnerId:" + ownerId);
        if(!!date){
            let promise = new Promise((resolve, reject)=>{
                let httpService = new HttpService();
                httpService.GET("http://localhost:53038/api/DayEvents", [{head:'Access-Control-Allow-Origin', value:'http://localhost:53038/'}]).then((response)=>{
                    console.log("Responce is:");
                    console.log(response);
                    resolve(response);
                });
            });
            return promise;
        }
        return null;
    }

    getDayCommentByDayIdAsync(dayId){
        let promise = new Promise((resolve, reject)=>{
            let httpService = new HttpService();
            httpService.GET("http://localhost:53038/api/DayEvents/" + dayId, [{head:'Access-Control-Allow-Origin", value:"http://localhost:53038/'}]).then((response)=>{
                console.log(response);
            });
        });
        return promise;
    }
}

export default DayDetailDataProvider;

