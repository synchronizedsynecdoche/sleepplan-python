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

    timeToEndArr = timeToEnd.split(":")
    timeToEndHour = int(timeToEndArr[0])
    timeToEndMin = int(timeToEndArr[1])

    hourDiff = abs(timeToEndHour - startPointHour)
    minDiff = timeToEndMin - startPointMin #make sure to do mod arithmetic for this and add to hour!

    if(timeToEndMin + startPointMin  >= 60):
        temp = timeToEndMin + startPointMin
        hourDiff -= int(temp / 60)
        minDiff = abs(timeToEndMin - startPointMin) # I feel like this is wrong

#need to handle cases like this:
#5:50
#7:40