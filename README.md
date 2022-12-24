# CS3280-Assignment6-Part1
Assignment 6 Part 1 from CS 3280 - Object Oriented Windows using C# at Weber State University with Shawn Crowder

￼
            Create an initial GUI in WPF for an airline flight reservation system that will have minimal functionality.  Please see the picture for an example of what the GUI should look like.  You may also look at the airline reservation system example program I gave you on Canvas.
There will be two different flights the user may choose from.  Each flight will have a different seating arrangement.  Two flights will need to be graphically created, each with a different seating arrangement.  How you do this is up to you.  Some ideas on how to do each flight would be to use a panel or user control filled with labels or buttons to represent the seats.
The “Choose Flight” combo box should be filled up with the two different flights that are extracted from the database Flight table.  In the combo box, both the Flight Number and Aircraft Type should be displayed.  When the form first loads, the flights should be extracted from the database and inserted into the combo box.  All other controls on the form should be disabled at this point.
            When the user selects a flight from the “Choose Flight” combo box two things should happen.  The first is that the appropriate flight should be displayed on the left of the program, and the second is that the “Choose Passenger” combo box should be enabled and loaded with the passengers on the selected flight from the database.
            The “Change Seat” and “Delete Passenger” buttons will not have any functionality for the first part of this assignment.
            When the user clicks the “Add Passenger” button another form should be displayed.  This form needs to be created for this part of the assignment.  The other form is where the new passenger’s information will be entered.  This form should allow the user to enter the passenger’s first name and last name.  It should also have a “Save” and “Cancel” button on it.  For the first part of this assignment both of these buttons will do nothing but close this form.  NOTE: Microsoft Access should be used to store the data.
            A good way to make sure no business logic is behind the UI is to create no database code (SQL or DataSet) behind the UI.  A requirement, that you must do, is to get the flights in the combo box using a separate method in another class, that gets the flights, creates an object for each flight, adds each object to a generic list, returns that list to the UI, then that list is bound to the combo box to display the data. (See example below).  This same requirement must also be done for Passengers.
All methods need to have exception handling.  Top level methods need to handle the exception and alert the user to the exception, and lower level called methods need to raise the exception up to calling methods. Make sure all business logic is in separate classes and not behind the UI.
 
Note: If you have a 64bit OS, then connecting to Access may be a problem.  If you get a strange error try compiling in 32 bit in Visual Studio.  To do this right click on the project and choose properties.  Then select "Build", then for "Platform Target" choose "x86".
WPF
cboFlights.ItemsSource = clsFlightManager.GetFlights();
 
Where the method GetFlights returns a List<clsFlight> objects.
 
The class clsFlight is a class that just holds the data associated with a flight.
 
Commonly Missed Items
- Your business logic is behind the UI.  There shouldn't be any SQL statements behind the UI.  Requirements say "A good way to make sure no business logic is behind the UI is to create no database code (SQL or DataSet) behind the UI.  For instance, to get the flights in the combo box, the UI should call a separate method in another class, that gets the flights, creates an object for each flight, adds each object to a list, returns that list to the UI, then that list is bound to the combo box to display the data"
- All attributes and methods need XML comments.
- Need try catch blocks
- Try catch blocks not implemented correctly.  Top level methods, such as button clicks, should handle the exception, and all lower level methods should throw the exception.
- Didn't meet requirement "In the combo box, both the Flight Number and Aircraft Type should be displayed."
- Didn't meet requirement "When the user selects a flight from the “Choose Flight” combo box two things should happen.  The first is that the appropriate flight should be displayed on the left of the program".
- Didn't meet the requirement "When the user selects a flight from the “Choose Flight” combo box the “Choose Passenger” combo box should be enabled and loaded with the passengers on the selected flight from the database."
- Your business logic classes should not be referencing the the UI like in method SetupPassengerSelectionBox in class Flight.  This method should be returning a list of flight objects that is then bound to the combo box
- Didn't meet requirement "Two flights will need to be graphically created, each with a different seating arrangement."
- Add passenger form not created.
- In the future just bind your list of flights and passengers to the combo boxes.
- Program should load flights and passengers from the database.
- The main window should not be using objects of type DataSet.  This should all be in the business logic where you query the flights/passengers, fill up a list of objects, then bind those lists to the combo boxes.
