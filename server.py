"""
To run:

$FLASK_APP="server" flask run -h 0.0.0.0 -p 5011 
 
"""
from flask import Flask, request
from datetime import datetime
import json
app = Flask(__name__)

# in falls, es kommt neue subscription here neue variable
jsona = "Sub1"
jsonb = "Sub2"
jsonc = "Sub3"
jsond = "Sub4"
# jsone = "Sub5"

@app.route("/notification/VersionReq", methods=['GET', 'POST'])
def Sub1():
    print(request.path)
    print(request.method)
    print(request.json)
    print(json.dumps(request.json, indent=4))

    global jsona
    jsona = json.dumps(request.json)

    return ""

@app.route("/notification/RobotToServer", methods=['GET', 'POST'])
def Sub2():
    print(request.path)
    print(request.method)
    print(request.json)
    print(json.dumps(request.json, indent=4))

    global jsonb
    jsonb = json.dumps(request.json)

    return ""

@app.route("/notification/ServerToRobot", methods=['GET', 'POST'])
def Sub3():
    print(request.path)
    print(request.method)
    print(request.json)
    print(json.dumps(request.json, indent=4))

    global jsonc
    jsonc = json.dumps(request.json)

    return ""

@app.route("/notification/OrderReq", methods=['GET', 'POST'])
def Sub4():
    print(request.path)
    print(request.method)
    print(request.json)
    print(json.dumps(request.json, indent=4))

    global jsond
    jsond = json.dumps(request.json)

    return ""


# für neue subscription 

# @app.route("/notification/OrderReq", methods=['GET', 'POST'])
# def Sub5():
#     print(request.path)
#     print(request.method)
#     print(request.json)
#     print(json.dumps(request.json, indent=4))

#     global jsone
#     jsone = json.dumps(request.json)

#     return ""


@app.route("/Subscription1")
def Forward1():
    return jsona
    
@app.route("/Subscription2")
def Forward2():
    return jsonb
    
        
@app.route("/Subscription3")
def Forward3():
    return jsonc

@app.route("/Subscription4")
def Forward4():
    return jsond
    

# für neue subscription 

# @app.route("/Subscription5")
# def Forward5():
#     return jsone