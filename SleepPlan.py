#have these be parameters passed in the CLI but that's a nightmare in python
debugBool = True

def debug(arg):
    if(debugBool):
        print("[DEBUG] {}".format(arg))


startTime = input("When will you go to bed?\n>>>")

startArr = startTime.split(":")
startHour = startArr[0]
startMin = startArr[1]

debug("startHour: {} , startMin: {}".format(startHour,startMin))


