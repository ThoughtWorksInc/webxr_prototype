mergeInto(LibraryManager.library, {
  BrowserCopyToClipboard: function (textToCopy) {
    var body = document.getElementsByTagName("body");
    navigator.clipboard.writeText(UTF8ToString(textToCopy));
  },

  BrowserPasteToClipboard: function (callbackObjectName, callbackMethodName) {
    // Strings received from C# must be decoded from UTF8
    FileCallbackObjectName = UTF8ToString(callbackObjectName);
    FileCallbackMethodName = UTF8ToString(callbackMethodName);

    var body = document.getElementsByTagName("body");
    navigator.clipboard.readText().then((value) => {
      console.log(
        "Value: " +
          value +
          "\nObjectName: " +
          FileCallbackObjectName +
          ";\nMethodName: " +
          FileCallbackMethodName +
          ";"
      );
      SendMessage(FileCallbackObjectName, FileCallbackMethodName, value);
    });
  },
});
