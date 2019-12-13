# ShaNetHolidayApi
Rpc api fetchs all public holiday of available countries using https://github.com/Shaenn/ShaNetHoliday project

# Running via Docker

## Building docker image
```
docker build -t shanetholidayapi .
```
## Running via docker-compose
After you built docker image, you can run the docker-compose command below to start shanetholidayapi service
```
docker-compose -f docker-compose.yml up
```
You can change the port in docker-compose.yml to host it on a different port of localhost

# Example Request
then you will be able to request the http://localhost:5000/holiday url with the following example body 

```json
{
    "id":1,
    "jsonrpc":"2.0",
    "method": "PublicHolidays",
    "params":{
	"startYear" : 2019,
	"endYear" : 2020
    }
}
```
