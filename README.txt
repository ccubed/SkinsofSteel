Skins of Steel Change Log
Type: Full Release
Version: Alpha 2

--------------
Bugs Fixed
Bug ID - Response
--------------
#2 - No response, Closed as Won't Fix until response received. Could not duplicate.
#3 - Removing from installed modules was incorrectly adding to spent and removing from balance.
#4 - Some costs were not numbers and were breaking the program. These have been fixed with
	 the introduction of the MATH, SPECIAL and MULTI types.
#5 - MULTI now allows proper handling of items which have an increasing or multistage cost (Such as a 1 and 3 ap version).
	 Not all modules may have been updated for this. I will update the XML for this purpose.

--------------
Features Added
Feature Code - Description
--------------
#A - Beginning new interface work, on hold until AI, TARS and WARDS systems are made.
#B - Selected Systems and subsystems now actually ascribe to their hierarchy.
#C - Checks to see if you can afford systems you purchase instead of allowing negative
	 points.
#D - Module description now includes AP Cost because it was annoying
	 not knowing how much something cost.

	 
--------------
Features Planned for Partial Release Alpha 2.1
Feature Code - Description
--------------	
#FA - TARS Creator
#FB - WARDS Creator
#FC - XML Updates to accommodate all Multicost Modules
