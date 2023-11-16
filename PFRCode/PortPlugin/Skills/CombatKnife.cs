using System;
using System.Collections.Generic;
using System.Text;
using Ivyl;
using RoR2;
using R2API;
using UnityEngine;
using PFR;
using RoR2.Skills;
using EntityStates;

namespace PFR.Skills
{
    class CombatKnife : PFRMain.PFRBehavior
    {
        public static float damageCoefficient = 3f;

        public static DamageAPI.ModdedDamageType knifeWound { get; private set; }

        public void Awake()
        {
            using RoR2Asset<SkillFamily> commandoSecondaryFamily = "RoR2/Base/Commando/CommandoBodySecondaryFamily.asset";

            Content.Skills.combatKnife = Expansion.DefineSkill<SkillDef>("mandoKnife");
            var Knife = Content.Skills.combatKnife;

            Knife.SetIconSprite(Assets.LoadAsset<Sprite>("Knifetemp"));
            Knife.SetCooldown(5f);
            Knife.SetInterruptPriority(InterruptPriority.PrioritySkill);
            Knife.SetFlags(SkillFlags.Agile);
            Knife.SetKeywordTokens("KEYWORD_AGILE");

            knifeWound = DamageAPI.ReserveDamageType();

            Knife.SetActivationState(typeof(EntityStates.Commando.KnifeState), "weapon");





        }
    }
}
