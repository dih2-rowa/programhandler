
import requests
import json
from random import random

OCB="http://localhost:1026/v2"
headers = {"content-type": "application/json"}

ENTITY = """{
    "id": "Blasius4",
    "type": "Program",
    "name": {
        "value": "blasius4",
        "type": "String"
    },
    "versionOnRobot": {
        "value": 1,
        "type": "Float"
    }
}"""

req = requests.post(f"{OCB}/entities", ENTITY, headers=headers)
print(req.headers)
print(req.content)

SUBSCRIPTION="""{
    "description": "Test subscription",
    "subject": {
      "entities": [{"idPattern": ".*", "type": "Program"}],
      "condition": {
        "attrs": [ "versionOnRobot" ]
      }
    },
    "notification": {
      "http": {
        "url": "http://192.168.1.250:5011/notification/versionOnRobot"
      }
    }
}
"""

req = requests.post(f"{OCB}/subscriptions", SUBSCRIPTION, headers=headers)
print(req.headers)
print(req.content)

CHANGE=json.loads("""{
    "name": {
        "value": "blasius4",
        "type": "String"
    },
    "versionOnRobot": {
        "value": 7,
        "type": "Float"
    }    
}""")

CHANGE["versionOnRobot"]["value"] = random()

req = requests.patch(f"{OCB}/entities/Blasius4/attrs", json.dumps(CHANGE), headers=headers)
print(req.headers)
print(req.content)




"""
$ nc -l 5011 
POST /notification/versionOnRobot HTTP/1.1
Host: 192.168.1.250:5011
User-Agent: orion/3.1.0-next libcurl/7.61.1
Fiware-Servicepath: /
Accept: application/json
Content-Length: 205
Content-Type: application/json; charset=utf-8
Fiware-Correlator: 2f165bdc-f242-11ec-8509-0242c0a84003; cbnotif=2
Ngsiv2-AttrsFormat: normalized

{"subscriptionId":"62b338137e46c87682689730","data":[{"id":"Blasius4","type":"Program","name":{"type":"String","value":"blasius4","metadata":{}},"versionOnRobot":{"type":"Float","value":7,"metadata":{}}}]}% 
"""