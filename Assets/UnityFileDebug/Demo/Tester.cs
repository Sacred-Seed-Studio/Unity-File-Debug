using UnityEngine;

public class Tester : MonoBehaviour
{
    private void Start()
    {
        throw new System.Exception("Even regular exceptions are logged");
    }
    void Update()
    {
        Debug.Log("CPU 1 has done action a", DLogType.AI);
        Debug.Log("Assertion created with Debug.Log", DLogType.Assert);
        Debug.Log("Song1 has started playing", DLogType.Audio);
        Debug.Log("Asset1 has loaded", DLogType.Content);
        Debug.Log("Couldn't find save file", DLogType.Error);
        Debug.Log("Database couldn't load", DLogType.Exception);
        Debug.Log("Showing game over UI", DLogType.GUI);
        Debug.Log("Player 1 pressed A", DLogType.Input);
        Debug.Log("Nearby enemy count: 3", DLogType.Log);
        Debug.Log("Condition 42 has been met", DLogType.Logic);
        Debug.Log("Connected to Player 2 at 192.168.0.0", DLogType.Network);
        Debug.Log("Physics collision with Ball1", DLogType.Physics);
        Debug.Log("Running on mobile", DLogType.System);
        Debug.Log("This is a bad thing that you should be aware of", DLogType.Warning);
        Debug.Log("Warning future me, this log will perplex you as it has me. It will depend on XYZ to be fixed before ABC can be implemented which where this log is from depends on to function properly. Thanks, past me", DLogType.Log);

        Debug.Assert(true == false);
        Debug.Assert(true == false, "true equals false");
        Debug.LogWarning("Warning");
        Debug.LogError("Error");
        Debug.LogAssertion("Conditionless assertion");
        Debug.LogFormat("<color=green>This is a green message!</color>");
    }
}
