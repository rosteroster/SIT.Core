﻿using EFT;
using SIT.Tarkov.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SIT.Coop.Core.LocalGame
{
    internal class LocalGameBotWaveSystemPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            var t = LocalGamePatches.LocalGameInstance.GetType().BaseType;
            //var t = LocalGamePatches.LocalGameInstance.GetType();

            var method = PatchConstants.GetAllMethodsForType(t)
                .FirstOrDefault(x => x.GetParameters().Length == 2
                && x.GetParameters()[0].Name.Contains("wavesSettings")
                && x.GetParameters()[1].Name.Contains("waves")
                );
            return method;
        }

        [PatchPrefix]
        public static bool PatchPrefix(object wavesSettings, WildSpawnWave[] waves, ref WildSpawnWave[] __result)
        {
            return true;
            //if (!Matchmaker.MatchmakerAcceptPatches.IsClient)
            //    return true;

            //__result = new WildSpawnWave[0];

            //return false;
        }
    }
}
