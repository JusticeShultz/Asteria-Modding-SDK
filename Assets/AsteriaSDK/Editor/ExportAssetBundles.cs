//This simply creates a new menu item in the Unity Editor that allows you to build asset bundles.

using System.Diagnostics;
using UnityEditor;
using UnityEngine;

public class ExportAssetBundles
{
    [MenuItem("Assets/Build Asset Bundles")]
    [MenuItem("Tools/Build Asset Bundles")]
    [MenuItem("Window/Build Asset Bundles")]
    [MenuItem("Window/General/Build Asset Bundles")]
    [MenuItem("Asteria/Deploy Mod")]
    [MenuItem("Tools/Deploy Mod")]
    static void BuildAllAssetBundles()
    {
        UnityEngine.Debug.Log("Building asset bundles...");
        string assetBundleDirectory = "Assets/AssetBundles";
        if (!System.IO.Directory.Exists(assetBundleDirectory))
        {
            System.IO.Directory.CreateDirectory(assetBundleDirectory);
            UnityEngine.Debug.Log("Created asset bundle directory: " + assetBundleDirectory);
        }

        try
        {
            BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
            UnityEngine.Debug.Log("Asset bundles/mod built successfully. Please make sure your bundles file name ends in .assetbundle");
        }
        catch (System.Exception e)
        {
            UnityEngine.Debug.LogError("Failed to build asset bundles/deploy mod: " + e.Message);
        }
    }
}