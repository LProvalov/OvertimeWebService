class HttpServiceRequest{
    constructor(props) {
        if(!!props){
            if(!!props.headers && props.headers instanceof Array){
                this.headers = props.headers;
            }

            if(!!props.uri){
                this.uri = props.uri;
            }

            if(!!props.timeout){
                this.timeout = props.timeout;
            } else {
                this.timeout = 0;
            }

            if(!!props.timeoutCallback){
                this.timeoutCallback = props.timeoutCallback;
            } else {
                this.timeoutCallback = function(){};
            }
        }
    }

    addHeader(head, value){
        /* TODO: rewrite repeated headers */
        if(!this.headers) this.headers = [];
        this.headers.push({
            head: head,
            value: value
        });
    }

    getHeaders(){
        if(!!this.headers) return this.headers;
        else return [];
    }
    
    setTimeout(mSec, callback){
        this.timeout = mSec;
        this.timeoutCallback = callback;
    }

    setUri(uri){
        this.uri = uri;
    }
}

export default HttpServiceRequest;