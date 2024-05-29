using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDKEnvBridge : MonoBehaviour
{
    public void BridgeCall(string content)
    {
        UnityEngine.Debug.Log("BridgeCall:"+content);
    }
}
