using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public static class SDKEnvWrapper
{

    private static ISDKInit nullSDK = new NullSDK();
    private static ISDKInit _sdkInstance = nullSDK;
    public static ISDKInit Empty => nullSDK;
    public static void SDKInitCallBack(string arg)
    {
        UnityEngine.Debug.Log($"SDKInitCallBack:{arg}");
    }

    public static void Init(ISDKInit sdkInstance)
    {
        _sdkInstance = sdkInstance ?? nullSDK;
    }

    public static void Init(string content)
    {
        _sdkInstance.Init(content);
    }

    public static void SDKLog(string logType, string content)
    {
        UnityEngine.Debug.Log($"SDKLog logType:{logType},content:{content}");
        _sdkInstance.SDKLog(logType, content);
    }

    private class NullSDK : ISDKInit
    {
        public void Init(string content)
        {
        }

        public void SDKLog(string logType, string content)
        {
        }
    }
}
