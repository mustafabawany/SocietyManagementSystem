# SocietyManagementSystem

### How to integrate Database 

<ol>
<li>Install SQL Sever Express Edition 2019 https://www.microsoft.com/en-us/download/details.aspx?id=101064</li>
<li>Install SQL Server Management Studio https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16</li> 
<li>Follow the installation procedure for SQL Server Express Edition 2019 as instructed in this video till (5:12) https://www.youtube.com/watch?v=UpvFwbe6lOs</li>
<li>Install SQL Server Management Studio as per default installation</li>
<li> After Installation, open SQL Server Management Studio, and create connection. <li>
<li>After that, open project in Visual Studio 2022</li>
<li>
    Right click on solution -> Add -> New Project, Select SQL Server Database Project 
    <img href = "">
</li>
<li>
  Enter Project Name "SocietyManagementDB". Press Create. Your solution Explorer will look like this. 
  <img href="">
</li>
<li>
Right click on SocietyManagementDB -> Import -> Script (*.sql). A window will appear as shown. 
<img>
Go to browse -> Project Folder -> SocietyManagement.sql, then click Next -> Next.
</li>
<li>Right click on SocietyManagementDB, Click on Publish. A new window will appear as shown
  <img href=""> 
</li>
<li>
Click on Edit -> Browse -> Enter Server Name same as shown in SQL Server Management Studio
<img href = " " > 
</li>
<li> Enter database name "SocietyManagement" as shown in figure. Then click "Generate Script"
<img href = " "> 
</li>
<li> Again right click on SocietyManagementDB, Click on Publish. Then go to Edit, this time stay on History and select your <default>.
<img href = " ">
</li>
<li>
Again enter database name "SoceityManagement", and click "Publish".
</li>
<li>Once it is published, go to Sql Sever Management Studio. Click on Refresh icon. Go to Databases, SocietyManagement should appear there as shown in figure.
<img href = " " >
</li>
<li>Now go to SocietyManagementSystem project, right click on Models -> Add -> New Item. Select "ADO .NET Entity Data Model", rename it as SocietyManagementData. Click Add
<img href = " ">
</li>
<li>
Click on the first option "EF Designer from databases". 
<img href = " ">
</li>
<li>
Click on New Connection. Click on Change.
<img href= " ">
</li>
<li> 
Select Microsoft SQL Server. Press OK
<img href= "">
</li>
<li>
Enter Server Name same as in SQL Server Management Studio. Click on Drop down of "Select or enter a database name". Click on SocietyManagement. Press OK.
<img href=""> 
</li>
<li>
On consecutive Nexts, this window will appear. Check mark on Tables, Remove check from Pluralize option and press Finish
<img href = " ">
</li>
<li> Follow this documentation for CRUD operations. https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/models-data/creating-model-classes-with-the-entity-framework-cs </li>
</ol>


    
