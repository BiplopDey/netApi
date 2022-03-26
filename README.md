# C# Developer project

Here at Lodgify we have an issue with cookie management, people are always asking for cookies and we need a way to manage the orders because we are overwhelmed with the number of cookie orders that we receive. We think a service to handle the orders will be the right solution for our problem.

### API

We think that at least we will need the following endpoints to handle the cookie orders:

- `POST /order` this will create a cookie order.
For cookie orders, we need to know the number of cookies wanted, who wants the cookies and which type of cookies. This request should return an error if it exceeds the total budget of cookies for the month.
- `GET /order` This will return all the orders

You can add any other endpoints that you think it's needed.

### Price

The price is listed below but they may change, we want an easy way to update the prices:

- 3$ for a Gingerbread Cookie
- 3.5$ for a Chocolate Chip Cookie
- 3.2$ for a Dinosaurus Cookie
- 2.1$ for a Macaroon Cookie

### Persistence

Also, these services will need to store this data somewhere. For now, we think that a file might be a good idea. We would like to register each order received as soon as possible in the file. 

### Restrictions

The cookie manager won't accept any new order if the monthly cap of 200$ in orders has been reached. 

### Readme

- Provide a readme with any information that you think is needed or can help to understand the decisions that you took while creating the service.
- If you had any issues when implementing this service you can also add some comments about it.
- Also, include a way to call the API from CLI.
