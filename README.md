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



