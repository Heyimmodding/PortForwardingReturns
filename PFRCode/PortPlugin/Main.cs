using BepInEx;
using R2API;
using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Returns
{

    [BepInDependency(ItemAPI.PluginGUID)]
    [BepInDependency(LanguageAPI.PluginGUID)]

    [BepInPlugin("Heyimnoop.PortForwardReturns", "PFR", "0.1.0")]

   
    public class Main : BaseUnityPlugin
    {  

        public void Awake()
        {
           
        }
    }
}
