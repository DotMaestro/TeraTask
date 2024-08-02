# TeraTask
Two microservices for internet banking


# Project Setup

## Prerequisites

Make sure you have Docker installed. You can download it from [Docker's official website](https://www.docker.com/products/docker-desktop).

## Instructions

1. **Clone the Project**
2. **Build Both Solutions**

## Running the Project

1. Open the root folder in CMD.
2. Run the following Docker commands:

    ```sh
    docker-compose -f docker-compose.yml -f docker-compose.override.yml build
    docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
    ```

## Accessing the Services

Open two browser windows:

1. **TransferService**: [http://localhost:6002/swagger/index.html](http://localhost:6002/swagger/index.html)
2. **AccountService**: [http://localhost:6001/swagger/index.html](http://localhost:6001/swagger/index.html)

## Using the TransferService API

Send a request with this AccountNumber (it is the only number that is not randomly generated while seeding the database):

`AA18BF98-4C3B-434B-8D39-3621D914DCFF`

For the `Amount`, you can send both negative and positive numbers (e.g., 400 or -400). The API will return the ID of the transfer.

## Checking the Account Balance

In the AccountService, check the account balance with the same AccountNumber. Initially, the balance is 0.

## Cleaning Up

After you are finished checking, don't forget to remove the containers with this command:

```sh
docker-compose -f docker-compose.yml -f docker-compose.override.yml down

