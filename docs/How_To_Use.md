### How to use the robot program handler

After adapting and deploying it, program is supposed to be able to recive any wished order information directly on HMI and download/update programs from/to file server only by ordering it on HMI.

HMI should be prepared for operator, the way, that involved people can freely use it.

To run the robot program handler put a proper IP Address and Port. Port is prechosen to 7000 – same as in Robot Controller. 

 ![image](https://user-images.githubusercontent.com/103100980/192728633-e60c79be-57d1-4272-ace3-60364cd75f43.png)


Klick on button Check Connection to proof if connection can be established. Choose a route on Robot, where files are stored and information server. 
Programs are saved as following: ```NameOfProgram_Vx```, where x means version on the robot. While taking program from server it gets just a name, without a version, so for safety reason it is a good practice to save previously version before downloading new or rename actual program, fe. ```NameOfProgram_old.```  
HMI should be prepared by PLC programmer for OPCUA connection and working User Interface.
In this project User Interface for HMI is shown as below. It allows to check basic data from order nr and program (product). Possible is also to download and upload files 
It can be modified to show more data, according to costumer’s wish. 

![image](https://user-images.githubusercontent.com/103100980/192728805-cb5ff810-e70e-4816-915d-bc9bdf76ccf3.png)
