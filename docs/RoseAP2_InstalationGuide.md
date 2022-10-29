### Introduction

To run ROSE AP2, you need to open Visual Studio Code. In new window find a Clone Git Repository:

![image](https://user-images.githubusercontent.com/103100980/192727858-c6e1cf64-cf61-4a95-b996-c79961e3c1d4.png)
 , above appear a text field to provide repository URL or pick a repository source:  ![image](https://user-images.githubusercontent.com/103100980/192727886-d1a71517-39b9-4646-83de-6058d0113e1b.png)

Paste a repository URL and choose a place on your disc, where Rose-AP1 and Rose-AP2 should be cloned. 

### Information Server

To run Infomation Server, open a repository in Visual Studio code and perform these steps:
1.	Chose folder API and with a right-click button chose an option:  Open in Integrated Terminal.
2.	Run a command docker-compose up, altenatively you can just right click on docker-compose.yml and choose a command Compose Up -  This is docker for pdf server, if you won't use PDF's in your application you can skip this point.
![image](https://user-images.githubusercontent.com/103100980/198825387-ac37d251-4ffa-4e60-85a3-86a0c0cc4f39.png)

3.	Put in console commands visible below: 


  ```  -	npm install -g @angular/cli```

  ```  -	npm install```

  ```  -	npm install bootstrap```

  ```  -	npm i @zxing/browser@latest –save```

  ```  -	npm i @zxing/library@latest --save```

  ```  -	npm i @zxing/ngx-scanner@3.5.0 --save```

  
4.	After install every component find a file named docker-compose.yml  in a folder Client and with a right mouse button choose an option Compose Up. - Hier we compose our information server. 

![image](https://user-images.githubusercontent.com/103100980/198825414-b16c4dbe-b154-4fa4-8ee9-d839b81f3715.png)

5.	Server Works, webpage can be visible on localhost:4100

Terminal should look like this : ![image](https://user-images.githubusercontent.com/103100980/192731321-45c8e88b-3231-46a9-aa1b-e4b4b3da3d2e.png)
