using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestLogButton : MonoBehaviour
{
    public UnityEngine.Object target;
    // Start is called before the first frame update
    void Start()
    {
        var tfm = this.transform.Find("btnSubmit");
        if (tfm)
        {
            tfm.GetComponent<Button>()?.onClick.AddListener(_ClickHandler);
        }
    }

    private void _ClickHandler() {

        var tfm = this.transform.Find("iptName");
        if (tfm)
        {
            var iptName = tfm.GetComponent<TMPro.TMP_InputField>();
            if (iptName)
            {
                SDKEnvWrapper.SDKLog("Test",$"{{\"content\":{iptName.text}}}");
            }
        }
     
    }
}
