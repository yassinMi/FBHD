v 0.2.0-beta   (from 25-04-2021 4:48 to 28-04-2021 7:12AM )

bug fixes & minor edits:
- curl not following redirects :fixed with an aditional arg specifying whether to follow redirects
- search module poping up unecessary messages: removed the message
- new added tasks should get selected automatically: fixed
- messed up title text box behavior:fixed
- server icon not showing: fixed 2:00AM 
- clw start button handler works synchronouslly causing the UI to freez for a second : fxed
- search result item's copy to clip button not implemented: fixed
- copy video to clip method not implemented: fixed
- enhanced status messages module that implements a stack list, and provides more options: done
- include the py_server script file in the project 
- py_server script updtate v2.0.0 :any user requests are now prefixed wuth "mi_request: " before printed to the stdout, to help differentating between rqeuets and pythong errors
- py_server module should pre check wheather python is installed and show feedback: fixed 3:02PM 26-04-2021
- switched to using ListBox instead of ItemsControll for the tasks list; resultng in a more stable binding and selection system,
 this also involved deprecating the IsSelected FBHDTask property and everything that uses it 1:26AM 27-04-2021 , "comfy"
- auto scroll to view once a new task is aadded; 
- new listBox based resolution picker with enhanced visuals, 
  this included improving the behavior as the chosed resolution is now maintained after deselecting and reselecting a task : 7:~PM 27-04-2021
- unhandled exception raises when aborting ffmpeg: handled
- all ffmpeg process stuff is now done in the FFMPEG class, with enhanced control and error handeling  6:48AM 28-04-2021

major fixes
- fixed the "Connection was reset" erro 27-04-2021 11:23PM (the freezing issue remains unsolved)





