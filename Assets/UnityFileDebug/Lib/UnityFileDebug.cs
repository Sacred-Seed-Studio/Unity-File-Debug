using UnityEngine;

[System.Serializable]
public class LogJSON
{
    public string t;  //type
    public string tm; //time
    public string l;  //log
    public string s;  //stack
}

[ExecuteInEditMode]
public class UnityFileDebug : MonoBehaviour
{
    public bool showTime = false;
    public bool useAbsolutePath = false;
    public string fileName = "MyGame";
    
    public string absolutePath = "c:\\";
    
    public string filePath;
    public string filePathFull;
    public int count = 0;

    System.IO.StreamWriter fileWriter;
    string text;

    void OnEnable()
    {
        UpdateFilePath();
        if (Application.isPlaying)
        {
            count = 0;
            fileWriter = new System.IO.StreamWriter(filePathFull, false);
            fileWriter.AutoFlush = true;
            fileWriter.WriteLine("[");
            Application.logMessageReceived += HandleLog;
        }
    }

    public void UpdateFilePath()
    {
        filePath = useAbsolutePath ? absolutePath : Application.persistentDataPath;
        filePathFull = System.IO.Path.Combine(filePath, fileName + "." + System.DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss") + ".json"); ;
    }

    void OnDisable()
    {
        if (Application.isPlaying)
        {
            Application.logMessageReceived -= HandleLog;
            fileWriter.WriteLine("\n]");
            fileWriter.Close(); 
        }
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        LogJSON j = new LogJSON();
        text = "";
        if (type == LogType.Assert)
        {
            j.t = "Assert";
            j.l = logString;
        }
        else if (type == LogType.Exception)
        {
            j.t = "Exception";
            j.l = logString;
        }
        else
        {
            int end = logString.IndexOf("]");
            j.t = logString.Substring(1, end-1);
            j.l = logString.Substring(end + 2);
        }
        
        j.s = stackTrace;
        j.tm = System.DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss");

        if (count == 0)
        {
            fileWriter.Write(JsonUtility.ToJson(j));
        }
        else
        {
            fileWriter.Write(",\n" + JsonUtility.ToJson(j));
        }
        count++;
    }
}

public enum DLogType
{
    Assert,
    Error,
    Exception,
    Warning,
    System,
    Log,
    AI,
    Audio,
    Content,
    Logic,
    GUI,
    Input,
    Network,
    Physics
}

public static class Debug
{
    #region Assert
    public static void Assert(bool condition) { UnityEngine.Debug.Assert(condition); }
    public static void Assert(bool condition, Object context) { UnityEngine.Debug.Assert(condition, context); }
    public static void Assert(bool condition, object message) { UnityEngine.Debug.Assert(condition, message); }
    public static void Assert(bool condition, object message, Object context) { UnityEngine.Debug.Assert(condition, message, context); }
    public static void AssertFormat(bool condition, string format, params object[] args) { UnityEngine.Debug.AssertFormat(condition, format, args); }
    public static void AssertFormat(bool condition, Object context, string format, params object[] args) { UnityEngine.Debug.AssertFormat(condition, context, format, args); }
    public static void LogAssertion(object message) { UnityEngine.Debug.LogAssertion(message); }
    public static void LogAssertion(object message, Object context) { UnityEngine.Debug.LogAssertion(message, context); }
    public static void LogAssertionFormat(string format, params object[] args) { UnityEngine.Debug.LogAssertionFormat(format, args); }
    public static void LogAssertionFormat(Object context, string format, params object[] args) { UnityEngine.Debug.LogAssertionFormat(context, format, args); }
    #endregion

    #region Helper
    public static void Break() { UnityEngine.Debug.Break(); }
    public static void ClearDeveloperConsole() { UnityEngine.Debug.ClearDeveloperConsole(); }
    #endregion

    #region Draw
    public static void DrawRay(Vector3 start, Vector3 dir) { UnityEngine.Debug.DrawRay(start, dir); }
    public static void DrawRay(Vector3 start, Vector3 dir, Color color) { UnityEngine.Debug.DrawRay(start, dir, color); }
    public static void DrawRay(Vector3 start, Vector3 dir, Color color, float duration) { UnityEngine.Debug.DrawRay(start, dir, color, duration); }
    public static void DrawRay(Vector3 start, Vector3 dir, Color color, float duration, bool depthTest) { UnityEngine.Debug.DrawRay(start, dir, color, duration, depthTest); }
    public static void DrawLine(Vector3 start, Vector3 end) { UnityEngine.Debug.DrawLine(start, end); }
    public static void DrawLine(Vector3 start, Vector3 end, Color color) { UnityEngine.Debug.DrawLine(start, end, color); }
    public static void DrawLine(Vector3 start, Vector3 end, Color color, float duration) { UnityEngine.Debug.DrawLine(start, end, color, duration); }
    public static void DrawLine(Vector3 start, Vector3 end, Color color, float duration, bool depthTest) { UnityEngine.Debug.DrawLine(start, end, color, duration, depthTest); }
    #endregion

    #region Log
    public static void Log(object message, DLogType type = DLogType.Log) { UnityEngine.Debug.Log("[" + type + "] " + message); }
    public static void Log(object message, Object context, DLogType type = DLogType.Log) { UnityEngine.Debug.Log("[" + type + "] " + message, context); }
    public static void LogFormat(string format, DLogType type = DLogType.Log, params object[] args) { UnityEngine.Debug.LogFormat("[" + type + "] " + format, args); }
    public static void LogFormat(Object context, string format, DLogType type = DLogType.Log, params object[] args) { UnityEngine.Debug.LogFormat(context, "[" + type + "] " + format, args); }
    #endregion

    #region Error
    public static void LogError(object message, DLogType type = DLogType.Error) { UnityEngine.Debug.LogError("[" + type + "] " + message); }
    public static void LogError(object message, Object context, DLogType type = DLogType.Error) { UnityEngine.Debug.Log("[" + type + "] " + message, context); }
    public static void LogErrorFormat(string format, params object[] args) { UnityEngine.Debug.LogErrorFormat(format, args); }
    public static void LogErrorFormat(Object context, string format, params object[] args) { UnityEngine.Debug.LogErrorFormat(context, format, args); }
    #endregion

    #region Exception
    public static void LogException(System.Exception exception) { UnityEngine.Debug.LogException(exception); }
    public static void LogException(System.Exception exception, Object context) { UnityEngine.Debug.LogException(exception, context); }
    #endregion

    #region Warning
    public static void LogWarning(object message, DLogType type = DLogType.Warning) { UnityEngine.Debug.LogWarning("[" + type + "] " + message); }
    public static void LogWarning(object message, Object context, DLogType type = DLogType.Warning) { UnityEngine.Debug.LogWarning("[" + type + "] " + message, context); } 
    #endregion
}
