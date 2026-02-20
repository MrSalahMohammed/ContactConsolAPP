***full Contacts Console App Using .Net Framework***
----
**Used Technologies**

- C#
- ADO .NET
- SQL Server 2022
----

**Architecture**

This App Uses Three Layer Architecture:
- DataAccessLayer  (Responsible about Recieve Data From DataBase To use it at BusinessLayer)
  
- BusinessLayer (Responsible about Recieve Data From DataAccessLayer & Make clsContacts class and clsCountries class) - References To DataAccessLayer
  - This layer to Make the data ready to be read by ANY Presentation Layer Like Windows, Android, ...etc.
  - Has Access Only on DataAccessLayer
    
- PresentationLayer (Responsible about Showing App UI & Data to end User) - References To BusinessLayer
  - A console App .net Framework Presentation Layer
  - Has Access Only on BusinessLayer

----

**Data Base**

has Two Tables:
- Contacts:
  - ID
  - FirstName
  - LastName
  - Email
  - Phone
  - Address
  - DateOfBirth
  - CountryID
  - ImagePath

- Countries:
  - ID
  - CountryName
 
----

This APP is ready to Make API
