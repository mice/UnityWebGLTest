using System.Collections;
using UnityEngine;

public static class Boostrap
{
    private static Transform _root;
    public static void Init(Transform root)
    {
        UnityEngine.Debug.Log($"Boostrap Init:{root}");
        _root = root;
    }

    public static IEnumerator Start()
    {
        UnityEngine.Debug.Log("Boostrap Start");
        yield return null;
        InitSDK();
    }

    private static void InitSDK()
    {
        var instance = SDKEnvWrapper.Empty;
#if !UNITY_EDITOR && UNITY_WEBGL
         instance = new WebGLSDKInit();
#endif
        var gTfm = _root.Find(nameof(SDKEnvBridge));
        if (gTfm == null)
        {
            gTfm = new GameObject(nameof(SDKEnvBridge)).transform;
            gTfm.gameObject.AddComponent<SDKEnvBridge>();
        }
        else
        {
            var bridge = gTfm.GetComponent<SDKEnvBridge>();
            if (bridge == null)
            {
                bridge.gameObject.AddComponent<SDKEnvBridge>();
            }
        }
        gTfm.parent = _root;
        SDKEnvWrapper.Init(instance);
        SDKEnvWrapper.Init("hello");
    }
}