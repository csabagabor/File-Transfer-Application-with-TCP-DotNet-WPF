# File Transfer Application with TCP made in .Net WPF

## About this project
This application can be used to send files over the Internet. For example it can be used in a local network to send files from one computer to another. Because the application is very lightweight and does not use any busy waiting technique, it can be used to send files **extremely fast** and **securely**(because the files won't be stored on a server). The application is able to memorize previously added connections(a connection consists from a name and IP address) using **serialization**. Saved connections will be stored in the file  *"data.bin"*.
- it is a WPF application, so the UI can be changed quite easily using XAML
- application logic is in C#
- uses port 12345 by default but it can be changed easily in the project, in the class *Receive* and *Send*
- the packet size is 1KB now but can be changed easily in these classes: *Receive*, *Send*
- when using on LAN, local IP addresses need to be used and not public ones, for example: *192.168.2.100*

## Basic usage(tutorial)
- the main window has several buttons that are used to carry out an operation by opening a new window where the user can easily do what he wants  
 <img alt="Photo" src="https://user-images.githubusercontent.com/37183688/43038667-4b8fe7cc-8d26-11e8-9976-4872abcf1b47.png">   

#### **Click on the following headers to open the corresponding description/tutorial**  


<details>  
  <summary>Adding new Connection </summary>  
   After pressing the <b>Add connection</b> button, a new window appears where the user has to introduce a new name and IP:  
    <img alt="Photo" src="https://user-images.githubusercontent.com/37183688/43038696-d60f129c-8d26-11e8-84b4-27ac9794add1.png">     
 <img alt="Photo" src="https://user-images.githubusercontent.com/37183688/43038698-dd537688-8d26-11e8-9307-61aa77dbe274.png">     
</details>



<details> 
  <summary>Showing Connections </summary>  
   After pressing the <b>Show Connections</b> button, a new window appears where the already added connections are shown:    
   <img alt="Photo" src="https://user-images.githubusercontent.com/37183688/43038715-7a59d7b0-8d27-11e8-899a-b0ab0c98573b.png">  
</details>




<details> 
  <summary>Sending a File </summary>  
   After pressing the <b>Send File</b> button, a new window appears where the user can choose which file to send and to whom:   
   Fist of all choose to whom you want to send the File from the drop-down list    
  <br> <img alt="Description" src="https://user-images.githubusercontent.com/37183688/43038774-87d4ecc6-8d28-11e8-932a-57ffa70d1d80.png">      
<br> After that, click on the <b>Browse</b> button to choose the File. This will open a Dialog for you....      
 <img alt="Photo" src="https://user-images.githubusercontent.com/37183688/43038781-9f3a88a8-8d28-11e8-96c1-d5f8eaf53d75.png">       
<br> Press the Send button and wait for the other user to accept the incoming File(**Note: he must be online and on the network/Internet   to receive the File**)      
 <img alt="Photo" src="https://user-images.githubusercontent.com/37183688/43038789-c4e1d4e4-8d28-11e8-99dd-2c2012e34872.png">     
 <img alt="Photo" src="https://user-images.githubusercontent.com/37183688/43038790-c787929c-8d28-11e8-9e13-efe22f955ed5.png">    
 <img alt="Photo" src="https://user-images.githubusercontent.com/37183688/43038792-ce4e661e-8d28-11e8-8110-fafc6ba83f75.png">    
<br>When the progress bar shows 100% it means you are ready. If the file transfer was interrupted, then the progress bar will be stuck.
</details>



<details> 
  <summary>Deleting a Connection </summary>  
 <br>  After pressing the <b>Delete Connection</b> button, a new window appears where the user can choose which connection to delete(name   of connection needs to be entered and not its IP address)    
  <br>   <img alt="Photo" src="https://user-images.githubusercontent.com/37183688/43038835-bbe11b10-8d29-11e8-8f89-f41c45efb599.png">     
</details>



<details> 
  <summary>Receiving a File </summary>  
 <br> When somebody else sends you a File, a pop up appears:    
  If the person's IP who wants to send you a File is already in your connections then its name is shown else it asks you if you want   to accept the file from that IP address:    
  <br> <img alt="Photo" src="https://user-images.githubusercontent.com/37183688/43038855-f4aa829c-8d29-11e8-9860-6130e1ab59eb.png">   
 <br> After pressing <b>Yes<b/> ,choose where you want to save the file and then wait until the progress bar in the main window gets full.    
 <br> <img alt="Photo" src="https://user-images.githubusercontent.com/37183688/43038882-8a4476e6-8d2a-11e8-9bda-7520013e7a1c.png">   
 <br><img alt="Photo" src="https://user-images.githubusercontent.com/37183688/43038884-8e4c6bb8-8d2a-11e8-9b6b-1c570e896889.png">   
 <br> You are ready. Check the file in the chosen folder.    
</details>  


