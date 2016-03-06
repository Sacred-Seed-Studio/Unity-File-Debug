using UnityEditor;

public class PackageAsset
{
    [MenuItem("Package/Update Package")]
    static void UpdatePackage()
    {
        AssetDatabase.ExportPackage("Assets/UnityFileDebug", "UnityFileDebug.unitypackage", ExportPackageOptions.Recurse);
        UnityEngine.Debug.Log("Saved package in root");
    }
}
