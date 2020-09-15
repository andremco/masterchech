$userNameAZCR = (az keyvault secret show --vault-name key-vault-masterchech --name USER-AZCR --query value)
$passAZCR = (az keyvault secret show --vault-name key-vault-masterchech --name PASS-AZCR --query value)
$apiKeyHeader = (az keyvault secret show --vault-name key-vault-masterchech --name API-KEY-HEADER --query value)
$botKeyTelegram = (az keyvault secret show --vault-name key-vault-masterchech --name BOT-KEY-TELEGRAM --query value)
$connectionString = (az keyvault secret show --vault-name key-vault-masterchech --name CONNECTION-STRING --query value)

az container create --name master-chech-webapi --resource-group masterchech `
                    --image masterchech.azurecr.io/master-chech-webapi:latest `
                    --registry-login-server masterchech.azurecr.io `
                    --registry-username $userNameAZCR `
                    --registry-password $passAZCR `
                    --dns-name-label master-chech-webapi `
                    --query ipAddress.fqdn `
                    --environment-variables ApiKeyValid=$apiKeyHeader BotKey=$botKeyTelegram ConnectionString=$connectionString

az container create --name master-chech-webapp --resource-group masterchech `
                    --image masterchech.azurecr.io/master-chech-webapp:latest `
                    --registry-login-server masterchech.azurecr.io `
                    --registry-username $userNameAZCR `
                    --registry-password $passAZCR `
                    --dns-name-label master-chech-webapp `
                    --query ipAddress.fqdn `
                    --environment-variables ReactAppApiUrl=$apiKeyHeader ReactAppApiKeyHeader='http://master-chech-webapi.brazilsouth.azurecontainer.io:80'