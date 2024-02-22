# InventoryManagement
# First to create databas
  goto -> Repository-> Content -> DatabaseContext.cs
      change connection string accordingly
      
  open package manager console, by going to tools-> nuget package manager->package mangaer console  and run command update-database.


# Now run the project by by configuring multiple startup projects 
  first should be api and then ui 
  to configure multipe startup projects,  right click on solution -> configure startup projects -> select multiple startup projects and then
  bring API to top and then UI. after that make both of them to start  by selecting from drop down.
