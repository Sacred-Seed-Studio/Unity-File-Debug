using UnityEngine;
using System.Collections;
using System;

public class Tester : MonoBehaviour
{
    void Update()
    {
        Debug.Log("Test", DLogType.AI);
        Debug.Log("Test", DLogType.Assert);
        Debug.Log("Test", DLogType.Audio);
        Debug.Log("Test", DLogType.Content);
        Debug.Log("Test", DLogType.Error);
        Debug.Log("Test", DLogType.Exception);
        Debug.Log("Test", DLogType.GUI);
        Debug.Log("Test", DLogType.Input);
        Debug.Log("Test", DLogType.Log);
        Debug.Log("Test", DLogType.Logic);
        Debug.Log("Test", DLogType.Network);
        Debug.Log("Test", DLogType.Physics);
        Debug.Log("Test", DLogType.System);
        Debug.Log("Test", DLogType.Warning);
        Debug.Log("Test with a super dooper long name akjlsdf klajsd lfkjads flkjasd flkjasdf ljkasdl fkjasl kfjasdlkf jasl fjaslk fjasldjf klasjfd lkasjdf klasjfd klsjadf klasjfd lkasjdf klasjdf ;lkasjfd lksajd fk", DLogType.Log);

        Debug.Assert(true == false);
        Debug.Assert(true == false, "true equals false");
        Debug.LogWarning("Warning");
        Debug.LogError("Error");
        Debug.LogAssertion("Conditionless assertion");

        Debug.LogFormat("<color=green>This is a green message!</color>");
    }
}
