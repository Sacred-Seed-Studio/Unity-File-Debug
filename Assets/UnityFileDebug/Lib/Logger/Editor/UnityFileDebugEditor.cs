using UnityEngine;
using UnityEditor;

namespace SSS
{
    namespace UnityFileDebug
    {
        [CustomEditor(typeof(UnityFileDebug))]
        public class UnityFileDebugEditor : Editor
        {
            UnityFileDebug instance;

            SerializedProperty showAbsolute;
            SerializedProperty absolutePath;
            GUIContent absolutePathContent;

            SerializedProperty fileName;
            GUIContent fileNameContent;

            SerializedProperty filePath;
            SerializedProperty filePathFull;

            SerializedProperty fileType;
            GUIContent fileTypeContent;

            string copyPath;

            void OnEnable()
            {
                instance = (UnityFileDebug)target;

                absolutePathContent = new GUIContent
                {
                    text = "Absolute Path",
                    tooltip = "The absolute system path to store the outputted log files"
                };

                fileNameContent = new GUIContent
                {
                    text = "Export File Name",
                    tooltip = "The filename (without extension) you would like to save logs as"
                };

                fileTypeContent = new GUIContent
                {
                    text = "Export File Type",
                    tooltip = "Export file type"
                };

                // Update references to serialized objects
                showAbsolute = serializedObject.FindProperty("useAbsolutePath");
                absolutePath = serializedObject.FindProperty("absolutePath");
                fileName = serializedObject.FindProperty("fileName");
                filePath = serializedObject.FindProperty("filePath");
                filePathFull = serializedObject.FindProperty("filePathFull");
                fileType = serializedObject.FindProperty("fileType");
            }

            public override void OnInspectorGUI()
            {
                serializedObject.Update();
                instance.UpdateFilePath();

                // Filename
                EditorGUILayout.PropertyField(fileName, fileNameContent);

                // File Type
                EditorGUILayout.PropertyField(fileType, fileTypeContent);

                // Output path type
                EditorGUILayout.PropertyField(showAbsolute);
                if (showAbsolute.boolValue)
                {
                    EditorGUILayout.PropertyField(absolutePath, absolutePathContent);
                }
                else
                {
                    EditorGUILayout.LabelField("using Application.persistentDataPath:\t" + Application.persistentDataPath);
                }

                // Open output path, copy html to output path
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button("Open Output Path"))
                {
                    OpenInFileBrowser.Open(filePath.stringValue);
                }
                if (GUILayout.Button("Copy HTML to Output Path"))
                {
                    copyPath = filePath.stringValue.Replace('\\', '/');
                    if (!copyPath.EndsWith("/")) { copyPath += "/"; }
                    copyPath += "UnityFileDebugViewer.html";
                    FileUtil.ReplaceFile("Assets/UnityFileDebug/Lib/Viewer/UnityFileDebugViewer.html", copyPath);
                }
                EditorGUILayout.EndHorizontal();

                // If running, show full output path and count
                if (Application.isPlaying)
                {
                    EditorGUILayout.Separator();
                    EditorGUILayout.Separator();
                    EditorGUILayout.Separator();
                    EditorGUILayout.Separator();
                    EditorGUILayout.Separator();

                    EditorGUILayout.BeginHorizontal();
                    if (GUILayout.Button("Copy Output Filepath"))
                    {
                        EditorGUIUtility.systemCopyBuffer = filePathFull.stringValue;
                    }
                    EditorGUILayout.LabelField(filePathFull.stringValue);
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.LabelField("Logs added: " + instance.count);
                }

                EditorGUILayout.Separator();
                EditorGUILayout.Separator();
                EditorGUILayout.Separator();
                EditorGUILayout.Separator();
                EditorGUILayout.Separator();

                // Tell the user what its about
                EditorGUILayout.HelpBox("Unity File Debug is made by Sacred Seed Studio and is MIT Licensed. Please feel free to use, modify, contribute, report bugs, and suggest features", MessageType.Info, true);
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button("Source"))
                {
                    Application.OpenURL("https://github.com/Sacred-Seed-Studio/Unity-File-Debug");
                }
                if (GUILayout.Button("Readme"))
                {
                    Application.OpenURL("https://github.com/Sacred-Seed-Studio/Unity-File-Debug/blob/master/README.md");
                }
                if (GUILayout.Button("Bugs / Feature Request"))
                {
                    Application.OpenURL("https://github.com/Sacred-Seed-Studio/Unity-File-Debug/issues");
                }
                EditorGUILayout.EndHorizontal();

                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}