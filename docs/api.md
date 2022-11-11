
### API

Basic API's are included in Information server, there you can Get/Add/Delete/Update your Entieties, however curl questions and API client such as Postman can be also used if wished. Below are examples, how proper question shall look like.

Get Question

```
GET http://10.92.80.10:1026/v2/entities/
fiware-service: robot_info
fiware-servicepath: /demo```

Add
```
POST http://10.92.80.10:1026/v2/entities/
content-type: application/json
fiware-service: robot_info
fiware-servicepath: /demo

    {
    "id": "ON001356",
    "type": "Order",
    "productID": {
      "value": "MY83_014K97",
      "type": "String"
    },
    "planParts": {
      "value": 8000,
      "type": "Integer"
    },
    "prodParts": {
      "value": 8000,
      "type": "Integer"
    },
    "prodPartsIO": {
      "value": 7423,
      "type": "Integer"
    },
    "startTime": {
        "value": "2022-06-18 12:17:55",
        "type": "Datetime"
    },
    "finishedTime": {
      "value": "2022-06-19 11:25:20",
      "type": "Datetime"
    },
    "deadline": {
        "value": "2022-08-19 12:17:55",
        "type": "Datetime"
    },
    "orderStatus": {
      "value": "Finished",
      "type": "String"
    },
    "workingStation": {    
      "value": "Robot1",
      "type": "String"
    }
  
Update

```
PUT http://10.92.80.10:1026/v2/entities/Robot1/attrs/writeProductstatus?type=Product
fiware-service: robot_info 
fiware-servicepath: /demo
content-type: application/json

{
   "value": ["robotVersiohhmer","tegjdst255","ttteasdst3",262,1,2,33],
   "type": "command"
}
```


Add a subscription

```
POST http://10.92.80.10:1026/v2/subscriptions
content-type: application/json
fiware-service: robot_info
fiware-servicepath: /demo

{
    "description": "Test subscription",
    "subject": {
        "entities": [
        {
            "idPattern": ".*",
            "type": "OrderReq"
        }
        ],
        "condition": {
            "attrs": [] 
        }
    },
    "notification": {
        "http": {
            "url": "http://quantumleap:8668/v2/notify"
        },
        "attrs": [],
        "metadata": ["dateCreated", "dateModified"]
    }
}

```
