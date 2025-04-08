# Frutin
Buy fast and fresh fruits and vegetables

```bash
Note : This project is still under development.
```

## Description
This site is an online store for fresh fruits and vegetables that aims to simplify the process of purchasing daily food products for users. Using this platform, customers can choose the fruits and vegetables they need from a diverse collection without having to leave their home and have them delivered to their doorstep in the shortest possible time.

By focusing on providing fresh products, competitive prices, and fast and reliable service, this site solves the problems associated with in-person shopping, such as time-consuming, crowded stores, and limited product variety.

## Prerequisites
    -> BackEnd
        - Asp.Net MVC
        - Entity Framework

    -> FrontEnd 
        - jquery
        - Bootstrap

    -> Database 
        - Sql Server

## Features
- Registration and Login.
- Create a Store.
- Payment System.
- Content Search and Filtering.

## Project Architecture

 - DataLayer : In this layer, models and connections to the database are created. The repository pattern is also used, in such a way that a generic repository is used to connect to each table. The dependency of this repository is removed using "dependency injection", which ensures compliance with the rules of solidity and object orientation.
 
 - UtilityLayer : This layer has built-in tools, such as sending emails and converting Gregorian dates to Solar dates.


[Made By Hirmaan](https://github.com/HirmaanR)
