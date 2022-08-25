"""
To run:

$FLASK_APP="server" flask run -h 0.0.0.0 -p 5011 
 
"""
from flask import Flask, request
from datetime import datetime
import json
app = Flask(__name__)
dt = datetime.now()
jsona = "Sub1"
jsonb = "Sub2"
jsonc = "Sub3"
jsond = "Sub4"

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

@app.route("/Subscription1")
def wannacry():
    return jsona
    
@app.route("/Subscription2")
def wannacry2():
    return jsonb
    
        
@app.route("/Subscription3")
def wannacry3():
    return jsonc
    

@app.route("/Subscription4")
def wannacry4():
    return jsond

print (dt)
