using R2API;
using RoR2;
using UnityEngine;
using System.Collections.Generic;
using BepInEx.Configuration;
using UnityEngine.AddressableAssets;

namespace AlternatePods
{
    public class CrocoMain : PodModCharBase
    {
        public override GameObject bodyPrefab => 
            Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Croco/CrocoBody.prefab").WaitForCompletion();
        public override void AddPodsToPodChar()
        {
            podBases.Add(new PaintJob());
        }

        public override void Init()
        {
            base.Init();
        }
    }
}