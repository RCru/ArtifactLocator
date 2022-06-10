# ArtifactLocator

This a fun little project which solves a simple hypothetical problem detailed below.

The problem
------------

A series of images have been captured from a stationary camera, facing down into the pit of an archeological dig. Each image 
has been passed through a machine vision model, trained to detect potential areas of archeological interest. The model is
not 100 % reliable and results vary from image to image. Find the most promising areas to continue the excavation.


Requirements capture has highlighted the following points
---------------------------------------------------------

- The archeological team is expecting to find 3 artifacts in the dig
- Processing speed is not an issue as there will be week-long period in between image capture and further excavation

Further details
---------------

- The machine vision model results (1 result per images) are returned in the format of a 100x100 array of 0's and 1's following 
  the convention:

   0 - no artifacts likely
   1 - potential interest
   
   
   e.g.
   
   0000000000000
   0000000100000
   0000000000000
   0000000000010
   0001000000000
   0000000000000

- Some results contain all 3 of the artifacts, some have only picked up some of the artifacts, and some have picked up erroneous readings