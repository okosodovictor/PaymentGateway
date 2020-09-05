# Payment Gateway

Payment Gateway API:

Tools Used:

IDE: Visual studio 2019.
Database: Microsoft SQL server.

Architecture: 
Onion Architecture which is also called Hexagonal architecture.

How to run the project:
The solution has two project in the presentation layer, the security and paymentGateway API.

The Payment gateway API expose two REST endpoint
1. Post request. To submit payment request from merchant to Paymentgateway API.
2. Get request. To get payment detail from Paymentgateway API.

Start by running from visual studio 2019 the security project as well as payment gateway API project. Generate Jwt bearer token from security service Url to access the  resources in Paymentgateway API.

Sample request:

POST Request:

{
  "merchantId": "?",
  "cardHolderName": "?",
  "cardNumber": "?",
  "cardCvv": "?",
  "expiryYear": "?",
  "expiryMonth": "?",
  "amount": ?,
  "currency": "?"
}

Response:
{
    "reference": "3589c59f",
    "status": 1 
}

For simplicity Status are :
0 => Pending
1 => Success
2 => Failed

Another way to run the project is containerization.

Cd into the project solution and run the command below to build container image.

1. docker build -t okosodovictor/security -f .\docker\security.Dockerfile .
2. docker build -t okosodovictor/payment -f .\docker\payment.Dockerfile .

3. docker run -it -p 8085:80 okosodovictor/security
4. docker run -it -p 8080:80 okosodovictor/paymentgateway

5. docker push okosodovictor/payment
6. docker push okosodovictor/security

Setup a kubernetes:

The deployment and services Yaml file can be found inside kubernetes folder as well kustomization.yaml.
Run command below:

1. kubectl apply -k .\kubernetes\
To test locally execute below command.
a. kubectl get pods
b. kubectl port-forward svc/payment 8080:80
c. kubectl port-forward svc/security 8085:80



