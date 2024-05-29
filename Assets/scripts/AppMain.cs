using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppMain : MonoBehaviour
{
    private void Awake()
    {
        Boostrap.Init(transform);
    }

    private IEnumerator Start()
    {
        UnityEngine.Debug.Log("Start");
        yield return Boostrap.Start();
    }
}
