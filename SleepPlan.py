#have these be parameters passed in the CLI but that's a nightmare in python
#maybe create a datatype for date?
debugBool = False

def debug(arg):
    if(debugBool):
        print("[DEBUG] {}".format(arg))


###startTime = input("When will you go to bed?\n>>>")

#startArr = startTime.split(":")
#startHour = startArr[0]
#startMin = startArr[1]
###
#debug("startHour: {} , startMin: {}".format(startHour,startMin))


def timeElapsed(startPoint, timeToEnd): #24 hour time because it is superior
    if( not ((isinstance(startPoint, str)) and (isinstance(timeToEnd, str )))):
        raise Exception("Passed invalid datatypes for time")

    startPointArr = startPoint.split(":")
    startPointHour = int(startPointArr[0])
    startPointMin = int(startPointArr[1])

    timeToEndArr = timeToEnd.split(":")
    timeToEndHour = int(timeToEndArr[0])
    timeToEndMin = int(timeToEndArr[1])

    if(startPointHour > timeToEndHour):
        raise Exception("Over 24 hours")

    if(startPointHour == timeToEndHour and startPointMin >= timeToEndMin):
        raise Exception("Over 24 hours")


    hourDiff = abs(timeToEndHour - startPointHour)
    minDiff = timeToEndMin - startPointMin #make sure to do mod arithmetic for this and add to hour!

    if(startPointHour+1 == timeToEndHour ): #edge case
        return "0:"+str((60 - startPointMin) + timeToEndMin)

    if(timeToEndMin + startPointMin  >= 60):
        temp = timeToEndMin + startPointMin
        hourDiff += int(temp / 60)
        minDiff = timeToEndMin + (60 - startPointMin)  # should be fixed

    return str(hourDiff) +":"+str(minDiff)

#testing
#userInA = input("Enter time 1\n>>>")
#userInB = input("Enter time 2\n>>>")

#print(timeElapsed(userInA, userInB))

#need to handle cases like this:
#5:50
#7:40
#I think it's fixed

class Time(object):
    #class for overloading addition

    def __init__(self,time):

        if (not isinstance(time, str)):
            raise Exception("Passed invalid datatypes for Time constructor")

        timeArr = time.split(":")
        min = int(timeArr[0])
        hour = int(timeArr[1])
    def __add__(self, other):

        self.hour += other.hour
        # add minutes
    def toString(self):

