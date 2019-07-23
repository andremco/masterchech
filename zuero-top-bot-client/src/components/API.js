class API {
    static get(resource, func1, func2){
        const apiUrl = process.env.REACT_APP_API_URL;
        const apiKeyHeader = process.env.REACT_APP_API_KEY_HEADER;
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
 }

 export default API;