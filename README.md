# sleepplan
Sleep Cycle Planner written in C#

This sleep cycle planner is an exercise for me to learn C# and OOP programming

Current features:
- Calculate optimal wake-up times for current time
- Change amount of time it takes to fall asleep
- Calculate optimal bedtimes for a certain wake-up time
- Calculate optimal wake-up times for a certain bedtime

Usage:

After running sleepplan.exe, optimal wakeup times will be generated with a default fall-asleep offset of 15 minutes.
Then, you can enter in any number of options:
- "h" or "-h" (when entered in as an argument) to show command help.
- "o" or "-o" to change the fall asleep offset. 
- "l" or "-l" (later) to calculate optimal wakeup times for a certain bed time.
- "b" or "-b" to calculate optimal bed times for a certain wakeup time.
- "e" or "-e" to exit.

The offset option can added to any other option, so "ol" or "-ol" will allow you to change the offset, and then generate wakeup times with that offset.
