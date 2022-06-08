using UnityEngine;
using UnityEditor;
using System.IO;


namespace RuneFoxMods.HereticFixExtension
{
  [CustomEditor(typeof(HereticFixExtensionInfo))]
  public class HereticFixExtensionInfoPropertyDrawer : Editor
  {

    public override void OnInspectorGUI()
    {
      base.OnInspectorGUI();

      if (GUILayout.Button("Build"))
      {
        Build(serializedObject.targetObject as HereticFixExtensionInfo);  
      }
    }


    //TODO: DaisyChain the DynamicSkins and CustomItemDisplay stuff on build
    private void Build(HereticFixExtensionInfo info)
    {
      if (info.assetInfo == null) info.InitializeAssetInfo();

      //Generate file from template
      var path = Path.Combine(info.assetInfo.modFolder, info.modInfo.name + "HereticFixExtension.cs");
      var ExtensionCode = new HereticFixExtensionTemplate(info);
      File.WriteAllText(path, ExtensionCode.TransformText());
      AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);

      //copy files from Copy Path
      //com.exampleauthor.examplename is the package name in package.json
      CopyFilesToModFolder(info, "Packages/com.runefoxmods.HereticFixExtension/Editor/CopyPath/", "RuneFox_Utils.cs");
      CopyFilesToModFolder(info, "Packages/com.runefoxmods.HereticFixExtension/Editor/CopyPath/", "HereticFix.cs");

      Debug.Log("HereticFix Extension Finished");
    }

    void CopyFilesToModFolder(HereticFixExtensionInfo info, string PackagePath, string filename, bool overwrite = true)
    {
      var destPath = Path.Combine(info.assetInfo.modFolder, filename);
      var sourcePath = Path.Combine(PackagePath, filename);
      File.Copy(sourcePath, destPath, overwrite);

      AssetDatabase.ImportAsset(destPath, ImportAssetOptions.ForceUpdate);
    }
  }
}
