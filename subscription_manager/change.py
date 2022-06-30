from pyngsi.ngsi import DataModel
from pyngsi.sink import SinkOrion
from random import random
sink = SinkOrion( hostname="127.0.0.1", port="1026")
m = DataModel(id="Blasius4", type="Program")
m.add("name", "blasius4")
m.add("versionOnRobot", random())
sink.write(m.json())