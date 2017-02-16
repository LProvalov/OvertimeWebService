
import HttpServiceRequest from './HttpServiceRequest';

class HttpService {
    constructor() {
        this.XHR = ("onload" in new XMLHttpRequest()) ? XMLHttpRequest : XDomainRequest;
        this.GET = this.GET.bind(this);
        this.GETRequest = this.GETRequest.bind(this);
    }

    GET(uri, headers){
        console.debug("Get Uri:", uri);
        let request = new HttpServiceRequest({
            uri: uri,
            headers: headers
        });
        return this.GETRequest(request);
    }

    GETRequest(request){
        if(request instanceof HttpServiceRequest){
            let xhr = new this.XHR();
            return new Promise((resolve, reject) => {
                xhr.open("get", request.uri, true);
                /* --- Set request headers --- */
                let rHeaders = request.getHeaders();
                for(let i = 0; i < rHeaders.length; i++){
                    console.log("setHeader:" + rHeaders[i].head + " value:" + rHeaders[i].value);
                    xhr.setRequestHeader(rHeaders[i].head, rHeaders[i].value);
                }
                /* --- Set timeout --- */
                xhr.timeout = request.timeout;
                xhr.ontimeout = request.timeoutCallback;
                /* --- TODO: Implement other events --- */
                console.log("HttpService.GET - Request");
                console.log(request);
                xhr.send();

                xhr.onreadystatechange = (() => {
                    if(xhr.readyState != this._RequestStates().DONE) return;
                    /* --- TODO: Implement HttpServiceResponce class --- */
                    resolve({
                        status: xhr.status,
                        statusText: xhr.statusText,
                        data: xhr.responseText
                    });
                }).bind(this);
            });
        }
        return null;
    }

    Post(){

    }

    _RequestStates(){
        return {
            UNSENT : 0,
            OPENED : 1,
            HEADERS_RECEIVED : 2,
            LOADING : 3,
            DONE : 4
        }
    }
}

export default HttpService;

