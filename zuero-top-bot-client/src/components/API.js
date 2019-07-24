class API {

    static getApiUrl(){
        return process.env.REACT_APP_API_URL;
    }

    static getApiKeyHeader(){
        return process.env.REACT_APP_API_KEY_HEADER;
    }

    static get(resource, func1, func2){
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
       }).then(func1).then(func2);
    }

    static post(resource, data, func1, func2){
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
        }).then(func1).then(func2);
    }
 }

 export default API;