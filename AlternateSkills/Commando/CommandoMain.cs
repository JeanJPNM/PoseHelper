using Mono.Cecil.Cil;
using MonoMod.Cil;
using RoR2;
using System.Collections.Generic;
using UnityEngine;
using BepInEx;
using BepInEx.Configuration;
using R2API.Utils;
using System;
using EntityStates;
using R2API;
using RoR2.Skills;
using AlternateSkills.Modules;

namespace AlternateSkills.Commando
{
    public class CommandoMain : SurvivorMain
    {
        public override string CharacterName => "Commando";
        public string TokenPrefix = "DCALTSKILLS_COMMANDO";

        public override void SetupSpecial()
        {
            var mySkillDef = ScriptableObject.CreateInstance<SkillDef>();
            mySkillDef.activationState = new SerializableEntityStateType(typeof(ESReinforcement));
            mySkillDef.activationStateMachineName = "Weapon";
            mySkillDef.baseMaxStock = 1;
            mySkillDef.baseRechargeInterval = 20;
            mySkillDef.beginSkillCooldownOnSkillEnd = true;
            mySkillDef.canceledFromSprinting = false;
            mySkillDef.fullRestockOnAssign = true;
            mySkillDef.interruptPriority = InterruptPriority.Frozen;
            mySkillDef.isCombatSkill = true;
            mySkillDef.mustKeyPress = true;
            mySkillDef.rechargeStock = 1;
            mySkillDef.requiredStock = 1;
            mySkillDef.stockToConsume = 1;
            mySkillDef.icon = SurvivorSkillLocator.special.skillDef.icon;
            mySkillDef.skillName = TokenPrefix+"_SPECIAL";
            mySkillDef.skillNameToken = $"{mySkillDef.skillName}_NAME";
            mySkillDef.skillDescriptionToken = $"{mySkillDef.skillName}_DESC";
            (mySkillDef as ScriptableObject).name = mySkillDef.skillName;
            mySkillDef.keywordTokens = new string[]{};
            utilitySkillDefs.Add(mySkillDef);
            base.SetupSpecial();
        }
    }
    public class DCAS_ReinforcementModule : MonoBehaviour
    {
        public CharacterBody casterBody;
        public CharacterBody targetBody;

        public void FireBullet(BulletAttack bulletAttack)
        {
            if (!targetBody)
                return;
            bulletAttack.origin = targetBody.corePosition;
            bulletAttack.Fire();
        }
    }
}
