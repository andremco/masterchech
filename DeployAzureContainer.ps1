az container create --name webapi --resource-group masterchech `
                    --image masterchech.azurecr.io/master-chech-webapi:latest `
                    --registry-login-server masterchech.azurecr.io `
                    --registry-username masterchech `
                    --registry-password Ua7PUM2hqH7wE/qbu9TGmrmMT9sHzsRt `
                    --dns-name-label webapi232323 `
                    --query ipAddress.fqdn