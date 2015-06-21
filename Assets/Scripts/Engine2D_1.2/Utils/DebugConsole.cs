namespace Engine.Utils {
  using System;
  using System.Collections.Generic;
  using UnityEngine;
  using System.Linq;

  public class DebugConsole: MonoBehaviour {

    private static DebugConsole _Current;

    private Rect _WindowRect = new Rect(Screen.width - 5 - 500, 5, 500, 150);
    private Queue<LogRecord> RecordQueue;

    public static void Instantiate() {
      if(_Current == null && Debug.isDebugBuild) {
        var obj = new GameObject("DebugConsole", typeof(DebugConsole)).GetComponent<DebugConsole>();
        _Current = obj;
        obj.RecordQueue = new Queue<LogRecord>();
        DontDestroyOnLoad(obj.gameObject);
      }
      DebugConsole.Log("DebugConsole started");
      DebugConsole.LogWarning("It's very dangerous now!!!");
      DebugConsole.LogError("NullReferenceException");
      DebugConsole.LogError("NullReferenceException");
      DebugConsole.LogError("NullReferenceException");
      DebugConsole.LogError("NullReferenceException");
      DebugConsole.LogError("NullReferenceException");
      DebugConsole.LogError("NullReferenceException");
      DebugConsole.LogError("NullReferenceException");
      DebugConsole.LogError("NullReferenceException");
    }

    #region Debug override
    public static new void Log(object message) {
      DebugConsole.AddLog(new LogRecord() { Message = message.ToString(), Color = "white" });
      UnityEngine.Debug.Log(message.ToString());
    }

    public static new void Log(object message, UnityEngine.Object context) {
      DebugConsole.AddLog(new LogRecord() { Message = message.ToString(), Color = "white" });
      UnityEngine.Debug.Log(message.ToString(), context);
    }

    public static new void LogError(object message) {
      DebugConsole.AddLog(new LogRecord() { Message = message.ToString(), Color = "red" });
      UnityEngine.Debug.LogError(message.ToString());
    }

    public static new void LogError(object message, UnityEngine.Object context) {
      DebugConsole.AddLog(new LogRecord() { Message = message.ToString(), Color = "red" });
      UnityEngine.Debug.LogError(message.ToString(), context);
    }

    public static new void LogWarning(object message) {
      DebugConsole.AddLog(new LogRecord() { Message = message.ToString(), Color = "yellow" });
      UnityEngine.Debug.LogWarning(message.ToString());
    }

    public static new void LogWarning(object message, UnityEngine.Object context) {
      DebugConsole.AddLog(new LogRecord() { Message = message.ToString(), Color = "yellow" });
      UnityEngine.Debug.LogWarning(message.ToString(), context);
    }
    #endregion

    private static void AddLog(LogRecord record) {
      if(_Current != null) {
        _Current.RecordQueue.Enqueue(record);
        if(_Current.RecordQueue.Count > 10)
          _Current.RecordQueue.Dequeue();
      }
    }

    void OnGUI() {
      _WindowRect = GUILayout.Window(0, _WindowRect, UpdateWindow, "My Window");
    }

    private void UpdateWindow(int id) {
      GUIStyle style = new GUIStyle();
      style.richText = true;
      GUI.UnfocusWindow();
      for(int i = 0; i < RecordQueue.Count; i++) {
        var element = RecordQueue.ElementAt(i);
        GUILayout.Label("<color=" + element.Color + ">" + element.Message + "</color>", style);
      }
    }
  }

  public struct LogRecord {
    public string Message;
    public string Color;
  }
}
