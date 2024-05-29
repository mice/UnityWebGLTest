using System.Collections;
using UnityEngine;

public class WebGLSDKInit : ISDKInit
{

#if !UNITY_EDITOR && UNITY_WEBGL
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void SDKEnvInit(string content,System.Action<string> callBack);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void LogToConsole(string logType, string content);
#endif

    [AOT.MonoPInvokeCallback(typeof(System.Action<string>))]
    private static void SDKInitCallBack(string content)
    {
        UnityEngine.Debug.Log($"SDKInitCallBack::{content}");
    }

    public void Init(string content)
    {
        UnityEngine.Debug.Log($"WebGLSDKInit Init::");
#if !UNITY_EDITOR && UNITY_WEBGL
        SDKEnvInit(content,SDKInitCallBack);
#endif
    }

    public void SDKLog(string logType, string content)
    {
        UnityEngine.Debug.Log($"WebGLSDKInit SDKLog: logType:{logType},content:{content}");
#if !UNITY_EDITOR && UNITY_WEBGL
        LogToConsole(logType, content);
#endif
    }
}