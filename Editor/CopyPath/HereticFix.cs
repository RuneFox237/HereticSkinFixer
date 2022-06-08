using UnityEngine;
using System.Collections.Generic;
using System;
using RoR2;
using BepInEx.Logging;

namespace RuneFoxMods.HereticFixExtension
{
  public class HereticFixManager
  {
    public ManualLogSource InstanceLogger;

    static List<SkinDef> hereticSkinDefs = new List<SkinDef>();
    static Transform[] boneorder;
    static string[] list = new string[] {
    "Root_M", "FrontTabard1_M", "FrontTabard2_M", "FrontTabard3_M", "FrontTabard4_M", "FrontTabard5_M", "FrontTabard6_M", "Hip_L", "HipPart1_L", "HipPart2_L", "Knee_L", "Ankle_L", "Toes_L", "BigToe_0_L", "BigToe_1_L", "InnerToes_0_L", "InnerToes_1_L", "InnerToes_2_L", "MidToes_0_L", "MidToes_1_L", "MidToes_2_L", "OuterToes_0_L", "OuterToes_1_L", "OuterToes_2_L", "ToesEnd_L", "Hip_R", "HipPart1_R", "HipPart2_R", "Knee_R", "Ankle_R", "Toes_R", "BigToe_0_R", "BigToe_1_R", "InnerToes_0_R", "InnerToes_1_R", "InnerToes_2_R", "MidToes_0_R", "MidToes_1_R", "MidToes_2_R", "OuterToes_0_R", "OuterToes_1_R", "OuterToes_2_R", "ToesEnd_R", "Spine1_M", "RearTabard1_M", "RearTabard2_M", "RearTabard3_M", "RearTabard4_M", "RearTabard5_M", "RearTabard6_M", "RearTabard7_M", "Spine2_M", "Chest_M", "Cape1_M", "Cape2_M", "Cape3_M", "Cape4_M", "Cape5_M", "Cape6_M", "Cape7_M", "Neck1_M", "Neck2_M", "Neck3_M", "Neck4_M", "Head_M", "BigFeathers_M", "BigFeathers1_M", "BigFeathers2_M", "BigFeathers3_M", "BigFeathers4_M", "FeatherA_R", "FeatherA1_R", "FeatherA2_L", "FeatherA3_L", "FeatherA4_L", "FeatherA5_L", "FeatherB_R", "FeatherB1_R", "FeatherB2_R", "FeatherB3_R", "FeatherB4_R", "FeatherB5_R", "FeatherB6_R", "FeatherC_L", "FeatherC1_L", "FeatherC2_L", "FeatherC3_L", "FeatherC4_L", "FeatherC5_L", "FeatherC6_L", "HeadEnd_M", "Jaw_M", "JawEnd_M", "Scapula_L", "Shoulder_L", "ShoulderPart1_L", "ShoulderPart2_L", "Elbow_L", "Elbow1_L", "Wrist_L", "Scapula_R", "Shoulder_R", "ShoulderPart1_R", "ShoulderPart2_R", "Elbow_R", "Elbow1_R", "Wrist_R"
    };
    public Transform[] GetBoneOrder()
    {
      return boneorder;
    }

    public List<SkinDef> GetHereticSkinDefs()
    {
      return hereticSkinDefs;
    }

    internal void SkinDefApply(Action<SkinDef, GameObject> orig, SkinDef self, GameObject modelObject)
    {
      orig(self, modelObject);

      Debug.Log("Example Extension: Skin Def Apply");
    }

    public static void initBoneOrder(SkinDef skinDef, GameObject body)
    {
      boneorder = new Transform[list.Length];
      for (int i = 0; i < list.Length; i++)
      {
        var bone = list[i];
        var child = Utils.FindChildInTree(body.transform, bone);
        if (child)
        {
          boneorder[i] = child;
        }
      }
    }

    public void TryAddSkinController()
    {
      try
      {
        var bodyPrefab = BodyCatalog.FindBodyPrefab("HereticBody");
        var modelLocator = bodyPrefab.GetComponent<ModelLocator>();
        var mdl = modelLocator.modelTransform.gameObject;
        var skinController = mdl ? mdl.GetComponent<ModelSkinController>() : null;
        if (!skinController)
        {
          skinController = mdl.AddComponent<ModelSkinController>();
          skinController.skins = Array.Empty<SkinDef>();
        }
      }
      catch (Exception e)
      {
        InstanceLogger.LogError("Error trying to add ModelSkinController to HereticBody: " + e);
      }
    }

    internal void AddSkinDef(SkinDef skinDef)
    {
      if (hereticSkinDefs.Contains(skinDef) == false)
      {
        hereticSkinDefs.Add(skinDef);
      }
    }
  }
}