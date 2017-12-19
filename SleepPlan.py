#have these be parameters passed in the CLI but that's a nightmare in python
#maybe create a datatype for date?
debugBool = True

def debug(arg):
    if(debugBool):
        print("[DEBUG] {}".format(arg))


startTime = input("When will you go to bed?\n>>>")

startArr = startTime.split(":")
startHour = startArr[0]
startMin = startArr[1]

debug("startHour: {} , startMin: {}".format(startHour,startMin))


def endTime(startPoint, timeToEnd): #24 hour time
    if( not ((isinstance(startPoint, str)) and (isinstance(timeToEnd, str )))):
        raise Exception("Passed invalid datatypes for time")

    startPointArr = startPoint.split(":")
    startPointHour = int(startPointArr[0])
    startPointMin = int(startPointArr[1])
