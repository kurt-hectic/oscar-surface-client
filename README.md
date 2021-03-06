# The OSCAR/Surface client

1. You can download the Visual Studio project and compile it yourself (I used Visual Studio 2017 community)
2. Or you [download](https://github.com/kurt-hectic/oscar-surface-client/releases/download/0.1/Release.zip) the binary release in form of a zipfile 
3. Run the software. To produce XML files from a Excel file, select an Excel file with the right format, an output directory and press "process"
4. Note that the [Excel file](https://github.com/kurt-hectic/oscar-surface-client/blob/master/OSCARclient/resources/StationList.xlsx) needs to be in the right format and expects the right *headers* to be present. 
5. Also note that Station type and Schedule needs to correspond to the worsheet *Definitions* and that the variables that are linked with the Station type are also defined in *Definitions*
6. The column "AWS" results in additional observations being added to the station to model the situation where there is an additional AWS at a site
7. The [template](https://github.com/kurt-hectic/oscar-surface-client/blob/master/OSCARclient/resources/observing_facility.xslt) used for generating XML is contained in the folder "resources" and is actually an XSLT stylesheet.
