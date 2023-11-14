using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using RoR2;
using R2API;
using static PFR.PFRMain;


namespace PFR.Buffs
{
    class Wound : PFRMain.PFRBehavior
    {
        public void Awake()
        {
            Content.Buffs.woundBuff = Expansion.DefineBuff<BuffDef>("WoundBuff");
            var wound = Content.Buffs.woundBuff;

            wound.iconSprite = PFRBehavior.Assets.LoadAsset<Sprite>("wound.png");
            wound.isDebuff = true;
            wound.canStack = false;
            wound.buffColor = new Color32(195, 33, 72, 255);
                
        }
        public void init()
    }
}
