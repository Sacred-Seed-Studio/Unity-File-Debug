using UnityEditor;

public class PackageAsset
{
    [MenuItem("SSS/Util/Package/Unity File Debug")]
    static void UpdatePackage()
    {
        AssetDatabase.ExportPackage("Assets/UnityFileDebug", "UnityFileDebug.unitypackage", ExportPackageOptions.Recurse);
        UnityEngine.Debug.Log("Saved package in root");
    }
}
