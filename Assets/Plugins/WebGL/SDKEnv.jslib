var SDKEnvPlugin = {
    $SDKEnvPlugin: {
        callBackDict: {},
        JhweappBufferTool: function (res) {
            var returnStr = JSON.stringify(res);
            var bufferSize = lengthBytesUTF8(returnStr || "") + 1;
            var buffer = _malloc(bufferSize);
            stringToUTF8(returnStr, buffer, bufferSize);
            return buffer;
        }
    },

    SDKEnvInit: function (content, callBack) {
        const callBackKey = "login";
        SDKEnvPlugin.callBackDict[callBackKey] = callBack;
        if (typeof Runtime === "undefined")
            Runtime = { dynCall: dynCall }
        console.log("SDK.SDKEnvInit", content);
        GameGlobal.SDKEnv.Init(function (res) {
            console.log("SDKLogin");
            var buffer = SDKEnvPlugin.JhweappBufferTool(res);
            var tmpCallBack = SDKEnvPlugin.callBackDict[callBackKey];
            if (tmpCallBack) {
                Runtime.dynCall('vi', tmpCallBack, [buffer])
            }
            SDKEnvPlugin.callBackDict[callBackKey] = null;
        })
    },

    LogToConsole: function (logType, content) {
        var typePtr = UTF8ToString(logType);
        var contentPtr = JSON.parse(Pointer_stringify(content));
        GameGlobal.SDKEnv.Log(typePtr, contentPtr);
    }
}

autoAddDeps(SDKEnvPlugin, "$SDKEnvPlugin")
mergeInto(LibraryManager.library, SDKEnvPlugin)