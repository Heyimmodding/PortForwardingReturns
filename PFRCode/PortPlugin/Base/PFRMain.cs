using BepInEx;
using R2API;
using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Ivyl;
using BepInEx.Logging;

namespace PFR
{

    [BepInDependency(DamageAPI.PluginGUID)]
    [BepInDependency(LanguageAPI.PluginGUID)]
    [BepInDependency(ColorsAPI.PluginGUID)]
    [BepInDependency(RecalculateStatsAPI.PluginGUID)]

    [BepInPlugin("Heyimnoop.PortForwardReturns", "PFR", "0.1.0")]


    public class PFRMain : BaseUnityPlugin<PFRMain>
    {
        public AssetBundle PFRassets;

        public ExpansionPackage PFRexpansion;

        public void Awake()
        {
            PFRassets = MiscellaneousExtensions.LoadAssetBundle(this, "ReturnsAssets.bundle", true);
            PFRexpansion = new ExpansionPackage("PFRexpansion", "PFR").SetIconSprite(PFRassets.LoadAsset<Sprite>("Monp.png"));
            PFRexpansion.AddEntityStatesFromAssembly(typeof(PFRMain).Assembly);

        }

        [PluginComponent(typeof(PFRMain), PluginComponent.Flags.ConfigAll)]
        public abstract class PFRBehavior : MonoBehaviour
        {
            public static AssetBundle Assets => Instance.PFRassets;
            public static ExpansionPackage Expansion => Instance.PFRexpansion;      
            public static ManualLogSource PFRlog=> Instance.Logger;
        }
    }
    
}
