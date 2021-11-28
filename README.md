<h1  align="left"><p><strong>ASCOPC</strong>
 <img align="right" src="https://lh3.googleusercontent.com/pw/AM-JKLXeR7TQRtQPvfx4s-h7sJSg3GUYt9AkOYCEi2vcZTneC3x7ye_z3wHO_BV2VUggnsCbuz-9yKYOoMQaW6NyX9NC1sgJdvQKbQ3Ojis1SS2rameaymJ64SdqX406-Q6_HkNspHXmOAWetj65POzitEgG=w500-h600-no?authuser=0" width="35" height="40">


<h3 align="center">

 [About](#about) - [Build with](#build-with) - [Settings](#settings) - [Disclaimer](#disclaimer) - [TODO's](#todos)

</h3>

# About
This project is a computer build service <br>
It is being developed following the example of clean architecture (DDD) <br>
### Source of inspiration
[Biolerplate](https://github.com/aspnetcorehero/Boilerplate)
[Ember](https://github.com/TheWayToJunior/Ember-Refactoring)

<p>
<br>

## Build with

* ASP.NET Core 6 
* ASP.NET Core BlazorWebAssebmly 6 
* ASP.NET Core Restfull-WebAPI 
<p>
<br>

# Settings
docker soon....
<p>
<br>

# Disclaimer
*This course work plan is preliminary, because the list of tasks to be solved in the process of creating a new version of the application may undergo significant processing. As the functionality is created, the plan will be revised.*
<p>
<br>

# TODOs
* [x] Repository registration github.com
* [x] Implement all entities
    * [x] Builds 
    * [x] User
    * [x] Role
    * [x] Manufacturer
    * [x] Components
* [x] Add Repository to each entities
* [x] Make the first migration
* [x] Add Services to each entities
* [x] Add [Citilink](https://www.citilink.ru/) parser for autofill components
* [x] Add FillProvider to manage fill grab components couple with entities
* [x] Add UnitOfWork
* [x] Add custom DependencyInjection
* [x] Add DbInitializer
* [x] Add DbTransaction to manage transactions
* [ ] Deploy the application on the docker
* [x] Add DTO / Requests & Responses
* [x] Add Commands and AutoMapper
* [x] Link the above additions through the MediatR pattern
* [ ] Add commands to each operation
* [x] Implement the possibility of adding to the cart citilink.ru items