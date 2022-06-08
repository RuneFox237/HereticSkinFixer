using UnityEngine;
using RoRSkinBuilder.Data;
using System.Collections.Generic;
using RuneFoxMods.RoRSkinBuilderExtension;

namespace RuneFoxMods.HereticFixExtension
{

  [AddComponentMenu("RoR Skins/Heretic Fix Extension")]
  public class HereticFixExtensionInfo : ExtensionBase
  {
    ////////////////////////////////////////////////
    /// Inherited Override
    private static readonly string _name = "HereticFix";
    public override string Name { get { return _name; } }
    ///
    ////////////////////////////////////////////////

    public SkinModInfo modInfo;
    public AssetsInfo assetInfo;

    //Put Extension Info here
    public List<SkinDefinition> HereticSkins;

    public HereticFixExtensionInfo(HereticFixExtensionInfo info)
    {
      modInfo = info.modInfo;
      InitializeAssetInfo();
    }
    public void InitializeAssetInfo()
    {
      assetInfo = new AssetsInfo(modInfo);
    }

  }

}