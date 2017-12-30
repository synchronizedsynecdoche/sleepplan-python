#have these be parameters passed in the CLI but that's a nightmare in python
#maybe create a datatype for date?
debugBool = False

def debug(arg):
    if(debugBool):
        print("[DEBUG] {}".format(arg))

def timeElapsed(startPoint, timeToEnd): #24 hour time because it is superior
    if( not ((isinstance(startPoint, Time)) and (isinstance(timeToEnd, Time )))):
        raise Exception("Passed invalid datatypes for time")


    startPointHour = startPoint.hour
    startPointMin = startPoint.min

    timeToEndHour = timeToEnd.hour
    timeToEndMin = startPoint.min

    if(startPointHour > timeToEndHour):
        raise Exception("Over 24 hours")


    hourDiff = abs(timeToEndHour - startPointHour)
    minDiff = timeToEndMin - startPointMin #make sure to do mod arithmetic for this and add to hour!

    if(startPointHour+1 == timeToEndHour ): #edge case
        return "0:"+str((60 - startPointMin) + timeToEndMin)

    if(timeToEndMin + startPointMin  >= 60):
        temp = timeToEndMin + startPointMin
        hourDiff += int(temp / 60)
        minDiff = timeToEndMin + (60 - startPointMin)  # should be fixed

    return Time(str(hourDiff) +":"+str(minDiff))

def minToTime(alpha):

    return Time(str(int(alpha/60))+":"+alpha % 60)


class Time(object):

    min = -1
    hour = -1

    def __init__(self,time):

        if (not isinstance(time, str)):
            raise Exception("Passed invalid datatypes for Time constructor")

        timeArr = time.split(":")
        self.hour = int(timeArr[0])
        self.min = int(timeArr[1])

    def add(self, other):

            elapsedObj = Time(other)
            self.hour += elapsedObj.hour

            if(self.min + elapsedObj.min > 60):
                self.min += elapsedObj.min - 60
                self.hour += 1
            else:
                self.min += elapsedObj.min

    def sub(self,other):
        elapsedObj = Time(other)
        self.hour -= elapsedObj.hour

        if (self.min + elapsedObj.min < 60):
            self.min -= 60  - elapsedObj.min
            self.hour -= 1

    def toString(self):
        return str(self.hour) + ":" + str(self.min)


test = Time("6:00")


for i in range(0,8):
    test.add("")

print(test.toString()) #fixed


