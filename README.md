# GrpcSyncComTest
## GlobalOverview
In this project we find both client and server to establish simple communication througth GRPC synchrounous communication 
### Client : 
the client is a console application that send the Id of project and wait for the server to response with true if the project exist in the Db otherwise false 
#### protos :
protos files are the contract between the client and the server that describe the form of the request and the response
### server : 
any grpc request will be handled by the services and send back the proper response 
#### protos 
protos are the contract between server and client , they have to be the same as in the client 
#### services
after generating the c# classes (based on the protos files) we use them to create the services to handle the requests (replace the controller in grpc based server compared to rest services)
