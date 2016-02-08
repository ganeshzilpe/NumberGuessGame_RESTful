# NumberGuessGame_RESTful
Created Number Guessing game with RESTful service and Silverlight

Service:
Implement the NumberGuess service as a RESTful service. Host the service on localhost of .Net Development server or IIS Express server.

Client 1: 
Create an ASP .Net Web Application or MVC 4 Web Application (in .Net Framework 4) to consume the RESTful service 

Client 2:
Develop Silverlight Application with animation to consume the RESTful service.

Tool/IDE
Visual Studio version: 2013

Solution 1: NumberGuessGame
This RESTful project. In this solution, there are two projects:
1.	NumberGuessGame: This is Rest Service and I have used WCF Service Application template.
2.	NumberGuessRESTApplication: This is client and I have used .Net Web Application template. 
How to run: To run this solution, open solution in Visual Studio and make project NumberGuessRESTApplication as a Start Up project and run the solution as Start with Debugging.

Solution 2: NumberGuess_Silverlight
In this solution, there are two projects:
3.	NumberGuess_REST: This is Rest Service and I have used WCF Service Application template.
4.	SilverlightApplication1 and SilverlightApplication1.Web: are together made client. 
How to run: To run this solution, open solution in Visual Studio and make project SilverlightApplication1.Web as a Start Up project and run the solution as Start without Debugging. If there is any problem showing any exception then run the solution as Start Debugging. And open the project in Internet Explorer and Silverlight is more compatible with it than Chrome or Firefox

