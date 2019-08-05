class API {

    static getApiUrl(){
        return process.env.REACT_APP_API_URL;
    }

    static getApiKeyHeader(){
        return process.env.REACT_APP_API_KEY_HEADER;
    }

    static get(resource){
        const apiUrl = API.getApiUrl();
        const apiKeyHeader = API.getApiKeyHeader();
        if(!apiUrl || !apiKeyHeader){
            throw new Error("null environments variables!");
        }

       return fetch(apiUrl + resource, {
           headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'APIKey': apiKeyHeader
           },
           method: 'GET'
       });
    }

    static post(resource, data){
        const apiUrl = API.getApiUrl();
        const apiKeyHeader = API.getApiKeyHeader();
        if(!apiUrl || !apiKeyHeader){
            throw new Error("null environments variables!");
        }

        return fetch(apiUrl + resource, {
            headers: {
             'Accept': 'application/json',
             'Content-Type': 'application/json',
             'APIKey': apiKeyHeader
            },
            method: 'POST',
            body: JSON.stringify(data)
        });
    }

    static delete(resource){
        const apiUrl = API.getApiUrl();
        const apiKeyHeader = API.getApiKeyHeader();
        if(!apiUrl || !apiKeyHeader){
            throw new Error("null environments variables!");
        }

       return fetch(apiUrl + resource, {
           headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'APIKey': apiKeyHeader
           },
           method: 'DELETE'
       });
    }
 }

 export default API;