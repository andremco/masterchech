class API {

    static getApiUrl(){
        return process.env.REACT_APP_API_URL;
    }

    static getApiKeyHeader(){
        return process.env.REACT_APP_API_KEY_HEADER;
    }

    static get(resource, funcCallback){
        const apiUrl = API.getApiUrl();
        const apiKeyHeader = API.getApiKeyHeader();
        if(!apiUrl || !apiKeyHeader){
            throw new Error("null environments variables!");
        }

       fetch(apiUrl + resource, {
           headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'APIKey': apiKeyHeader
           },
           method: 'GET'
       }).then((response) => response.json()).then(funcCallback);
    }

    static post(resource, data, funcCallback){
        const apiUrl = API.getApiUrl();
        const apiKeyHeader = API.getApiKeyHeader();
        if(!apiUrl || !apiKeyHeader){
            throw new Error("null environments variables!");
        }

        fetch(apiUrl + resource, {
            headers: {
             'Accept': 'application/json',
             'Content-Type': 'application/json',
             'APIKey': apiKeyHeader
            },
            method: 'POST',
            body: JSON.stringify(data)
        }).then((response) => response.json()).then(funcCallback);
    }
 }

 export default API;