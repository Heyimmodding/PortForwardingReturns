using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using RoR2;
using R2API;
using static PFR.PFRMain;
using Ivyl;

namespace PFR.Buffs
{
    class Wound : PFRMain.PFRBehavior
    {
        public DamageColorIndex woundColor;

        public void Awake()
        {
            Content.Buffs.woundBuff = Expansion.DefineBuff<BuffDef>("WoundBuff");
            var wound = Content.Buffs.woundBuff;

            wound.iconSprite = PFRBehavior.Assets.LoadAsset<Sprite>("wound.png");
            wound.isDebuff = true;
            wound.canStack = false;
            wound.buffColor = new Color32(195, 33, 72, 255);

            woundColor = ColorsAPI.RegisterDamageColor(new Color32(176, 48, 96, 255));
        }

        public void OnEnable()
        {
            Events.GlobalEventManager.onHitEnemyAcceptedServer += GlobalEventManager_onHitEnemyAcceptedServer; 
        }
        
        public void OnDisable()
        {
            Events.GlobalEventManager.onHitEnemyAcceptedServer -= GlobalEventManager_onHitEnemyAcceptedServer;
        }
        private void GlobalEventManager_onHitEnemyAcceptedServer(DamageInfo damageInfo, GameObject victim, uint? dotMaxStacksFromAttacker)
        {
            if (victim)
            {
                victim.TryGetComponent(out CharacterBody body);

                if (body && body.HasBuff(Content.Buffs.woundBuff) && body.healthComponent)
                {
                    float incomingDamage = damageInfo.damage;
                    
                    if (incomingDamage > 0)
                    {
                        var woundInfo = new DamageInfo();
                        woundInfo.damageColorIndex = woundColor;
                        woundInfo.attacker = damageInfo.attacker;
                        woundInfo.inflictor = damageInfo.attacker;
                        woundInfo.position = body.transform.position;
                        woundInfo.crit = false;
                        woundInfo.damage = incomingDamage * 0.5F;
                        woundInfo.force = Vector3.zero;
                        woundInfo.procChainMask = default(ProcChainMask);
                        woundInfo.procCoefficient = 0f;

                        body.healthComponent.TakeDamage(woundInfo);
                    }

                }
            }
        }
    }
}
