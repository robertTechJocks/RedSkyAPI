# RedSkyAPI
Repo for interview Case Study

## How to use
This can be tested via Swagger by going to [this url](https://redskyapi.azurewebsites.net/swagger/index.html). If you want to use the API here are the available endpoints:

- GET https://redskyapi.azurewebsites.net/Products/{id}
>Fetches product info from an API and a price from the MongoDB datastore
>
> Available product IDs: 13860428, 54456119, 13264003, 12954218
> 
> Response body:
>
>```
{
    "id": 13860428,
    "name": "The Big Lebowski (Blu-ray)",
    "currentPrice": {
        "value": 10.1,
        "currencyCode": "USD"
    }
}
>```

- PUT https://redskyapi.azurewebsites.net/Products
> Updates the price of a product
>
> Example Payload: 
>```
{
    "id": 54456119,
    "name": "Creamy Peanut Butter 40oz - Good &#38; Gather&#8482;",
    "currentPrice": {
        "value": 60.02,
        "currencyCode": "USD"
    }
}
>```

