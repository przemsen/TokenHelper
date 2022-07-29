# JWT Token Helper

  - It sits in the system tray and has a context menu accessible with right-click
  - The application extracts a token from a text in the clipboard and copies it back to the clipboard
  - It assumes it finds in the clipboard a text containing `Bearer token"` or `Bearer token'`
  - This way we can very quickly extract a token by copying a request from a browser as CURL command in the Developer Tools 
  - If extraction succeeds, there is no message to make the workflow as easy as possible. If it fails, there is a message
  - Written in .NET Framework 4.8, because this way it guarantees no extra dependencies
  - The compiled EXE file can be downloaded from the Releases section on the right-hand side 
