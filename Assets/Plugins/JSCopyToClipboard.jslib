// Assets/Plugins/WebGL/JSFileUploader.jslib
mergeInto(LibraryManager.library,
    {
        BrowserCopyToClipboard: function (textToCopy) {
            var h2Element = document.createElement('h2');
            document.getElementsByTagName('body')[0].appendChild(h2Element);
            navigator.clipboard.writeText(UTF8ToString(textToCopy));
        }
    });