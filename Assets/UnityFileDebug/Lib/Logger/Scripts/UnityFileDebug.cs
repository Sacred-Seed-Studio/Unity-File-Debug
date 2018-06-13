using UnityEngine;

namespace SSS
{
    namespace UnityFileDebug
    {
        // short keynames are used to make json output small
        [System.Serializable]
        public class LogOutput
        {
            public string t;  //type
            public string tm; //time
            public string l;  //log
            public string s;  //stack
        }

        public enum FileType
        {
            CSV,
            JSON,
            TSV,
            TXT
        }

        [ExecuteInEditMode]
        public class UnityFileDebug : MonoBehaviour
        {
            public bool useAbsolutePath = false;
            public string fileName = "MyGame";
            public FileType fileType = FileType.CSV;

            public string absolutePath = "c:\\";

            public string filePath;
            public string filePathFull;
            public int count = 0;

            System.IO.StreamWriter fileWriter;

            string FileExtensionFromType(FileType type)
            {
                switch (type)
                {
                    case FileType.JSON: return ".json";
                    case FileType.CSV: return ".csv";
                    case FileType.TSV: return ".tsv";
                    case FileType.TXT:
                    default: return ".txt";
                }
            }

            void OnEnable()
            {
                UpdateFilePath();
                if (Application.isPlaying)
                {
                    count = 0;
                    fileWriter = new System.IO.StreamWriter(filePathFull, false);
                    fileWriter.AutoFlush = true;
                    switch (fileType)
                    {
                        case FileType.CSV:
                            fileWriter.WriteLine("type,time,log,stack");
                            break;
                        case FileType.JSON:
                            fileWriter.WriteLine("[");
                            break;
                        case FileType.TSV:
                            fileWriter.WriteLine("type\ttime\tlog\tstack");
                            break;
                    }
                    Application.logMessageReceived += HandleLog;
                }
            }

            public void UpdateFilePath()
            {
                filePath = useAbsolutePath ? absolutePath : Application.persistentDataPath;
                filePathFull = System.IO.Path.Combine(filePath, fileName + "." + System.DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss") + FileExtensionFromType(fileType));
            }

            void OnDisable()
            {
                if (Application.isPlaying)
                {
                    Application.logMessageReceived -= HandleLog;

                    switch (fileType)
                    {
                        case FileType.JSON:
                            fileWriter.WriteLine("\n]");
                            break;
                        case FileType.CSV:
                        case FileType.TSV:
                        default:
                            break;
                    }
                    fileWriter.Close();
                }
            }

            void HandleLog(string logString, string stackTrace, LogType type)
            {
                LogOutput output = new LogOutput();
                if (type == LogType.Assert)
                {
                    output.t = "Assert";
                    output.l = logString;
                }
                else if (type == LogType.Exception)
                {
                    output.t = "Exception";
                    output.l = logString;
                }
                else
                {
                    int end = logString.IndexOf("]");
                    if (end > 1)
                    {
                        output.t = logString.Substring(1, end - 1);
                        output.l = logString.Substring(end + 2);
                    }
                    else
                    {
                        output.t = type.ToString();
                        output.l = logString;
                    }
                }

                output.s = stackTrace;
                output.tm = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                switch (fileType)
                {
                    case FileType.CSV:
                        fileWriter.WriteLine(output.t + "," + output.tm + "," + output.l.Replace(",", " ").Replace("\n", "") + "," + output.s.Replace(",", " ").Replace("\n", ""));
                        break;
                    case FileType.JSON:
                        fileWriter.Write((count == 0 ? "" : ",\n") + JsonUtility.ToJson(output));
                        break;
                    case FileType.TSV:
                        fileWriter.WriteLine(output.t + "\t" + output.tm + "\t" + output.l.Replace("\t", " ").Replace("\n", "") + "\t" + output.s.Replace("\t", " ").Replace("\n", ""));
                        break;
                    case FileType.TXT:
                        fileWriter.WriteLine("Type: " + output.t);
                        fileWriter.WriteLine("Time: " + output.tm);
                        fileWriter.WriteLine("Log: " + output.l);
                        fileWriter.WriteLine("Stack: " + output.s);
                        break;
                }

                count++;
            }
        }
    }
}
