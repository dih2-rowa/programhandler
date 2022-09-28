
##### Introduction

Software is divided in 2 essential parts with are working simultaneously and can’t be separate. Whole project is meant to be an advanced communication between Robot controller, PLC, and user. It allows to:
-	check a real-time data of every robot and every order
-	download and load files to robot directly from HMI
-	remotely send the files from tech provider
-	store historical data from orders

The center part of the project is a robotic cell. Robot makes the connection to PLC and Program handler which both are communication core. Through Rose AP-1 are send such information as:
-	Last modification of a program,
-	Program Version on Robot and Server
-	Length of process
-	Cycle time
-	Planned parts
-	Parts already produced
-	Amount of produced parts without irregularity
-	Date of start of production
-	Date, when order was finished
-	Deadline of an order
-	Status of the order
-	Working station
-	Actual speed of the robot
-	Status on the parts in Robot’s working area
-	Actual Order ID
Every of those information are sent to Fiware, which is a context broker, so it sends this information simultaneously to Rose-AP2 and database. Also, in case, any data changed, there is an option to send a notification to inform and performs any steps if needed. 
Rose-AP2 is a web server which shows data from Rose-AP1 in user friendly way. It has also an availability to add, delete and update entities such as robot, order or product, the way, that no knowledge of programming is needed. 


![image](https://user-images.githubusercontent.com/103100980/192736179-d6ca1c45-5278-4d5d-bb79-3ea07c6fd699.png)
