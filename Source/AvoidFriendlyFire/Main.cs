﻿using System;
using System.Linq;
using HarmonyLib;
using HugsLib;
using HugsLib.Settings;
using HugsLib.Utils;
using Verse;

namespace AvoidFriendlyFire
{
    public class Main : ModBase
    {
        private SettingHandle<bool> _enableAccurateMissRadius;

        private SettingHandle<bool> _enableWhenUndrafted;

        private ExtendedDataStorage _extendedDataStorage;

        private FireConeOverlay _fireConeOverlay;

        private FireManager _fireManager;

        private SettingHandle<bool> _ignoreShieldedPawns;

        private SettingHandle<bool> _modEnabled;

        private SettingHandle<bool> _protectColonyAnimals;

        private SettingHandle<bool> _protectPets;

        private SettingHandle<bool> _showOverlay;

        public Main()
        {
            Instance = this;
        }

        public override string ModIdentifier => "AvoidFriendlyFire";

        internal static Main Instance { get; private set; }

        internal new ModLogger Logger => base.Logger;

        public PawnStatusTracker PawnStatusTracker { get; } = new PawnStatusTracker();

        public override void Tick(int currentTick)
        {
            base.Tick(currentTick);
            if (!IsModEnabled())
            {
                return;
            }

            _fireManager?.RemoveExpiredCones(currentTick);
            PawnStatusTracker.RemoveExpired();
        }

        public override void WorldLoaded()
        {
            base.WorldLoaded();
            _extendedDataStorage =
                Find.World.GetComponent<ExtendedDataStorage>();

            // Ticks appear to be run before MapLoaded, so we need a FireManager available
            _fireManager = new FireManager();
        }

        public override void MapLoaded(Map map)
        {
            base.MapLoaded(map);
            _fireManager = new FireManager();
            _fireConeOverlay = new FireConeOverlay();
            PawnStatusTracker.Reset();
        }

        public override void DefsLoaded()
        {
            base.DefsLoaded();

            _modEnabled = Settings.GetHandle(
                "enabled", "FALCFF.EnableMod".Translate(), "FALCFF.EnableModDesc".Translate(), true);

            _showOverlay = Settings.GetHandle(
                "showOverlay", "FALCFF.ShowTargetingOverlay".Translate(),
                "FALCFF.ShowTargetingOverlayDesc".Translate(), true);

            _protectPets = Settings.GetHandle(
                "protectPets", "FALCFF.ProtectPets".Translate(),
                "FALCFF.ProtectPetsDesc".Translate(),
                true);

            _protectColonyAnimals = Settings.GetHandle(
                "protectColonyAnimals", "FALCFF.ProtectColonyAnimals".Translate(),
                "FALCFF.ProtectColonyAnimalsDesc".Translate(),
                false);

            _ignoreShieldedPawns = Settings.GetHandle(
                "ignoreShieldedPawns", "FALCFF.IgnoreShieldedPawns".Translate(),
                "FALCFF.IgnoreShieldedPawnsDesc".Translate(),
                true);

            _enableWhenUndrafted = Settings.GetHandle(
                "enableWhenUndrafted", "FALCFF.EnableWhenUndrafted".Translate(),
                "FALCFF.EnableWhenUndraftedDesc".Translate(),
                false);

            _enableAccurateMissRadius = Settings.GetHandle(
                "enableAccurateMissRadius", "FALCFF.EnableAccurateMissRadius".Translate(),
                "FALCFF.EnableAccurateMissRadiusDesc".Translate(),
                true);

            try
            {
                var ceVerb = GenTypes.GetTypeInAnyAssembly("CombatExtended.Verb_LaunchProjectileCE");
                if (ceVerb == null)
                {
                    return;
                }

                Logger.Message("Patching CombatExtended methods");
                var vecType = GenTypes.GetTypeInAnyAssembly("Verse.IntVec3");
                var ltiType = GenTypes.GetTypeInAnyAssembly("Verse.LocalTargetInfo");

                var original = ceVerb.GetMethod("CanHitTargetFrom",
                    new[] {vecType, ltiType});

                var postfix = typeof(Verb_CanHitTargetFrom_Patch).GetMethod("Postfix");
                HarmonyInst.Patch(original, null, new HarmonyMethod(postfix));
            }
            catch (Exception e)
            {
                Logger.Error("Exception while trying to detect CombatExtended:");
                Logger.Error(e.Message);
                Logger.Error(e.StackTrace);
            }
        }

        public void UpdateFireConeOverlay(bool enabled)
        {
            _fireConeOverlay?.Update(_showOverlay && enabled);
        }

        public bool ShouldProtectPets()
        {
            return _protectPets;
        }

        public bool ShouldProtectAllColonyAnimals()
        {
            return _protectColonyAnimals;
        }

        public bool ShouldIgnoreShieldedPawns()
        {
            return _ignoreShieldedPawns;
        }

        public bool ShouldEnableWhenUndrafted()
        {
            return _enableWhenUndrafted;
        }

        public bool ShouldEnableAccurateMissRadius()
        {
            return _enableAccurateMissRadius;
        }

        public static Pawn GetSelectedPawn()
        {
            var selectedObjects = Find.Selector.SelectedObjects;
            if (selectedObjects == null || selectedObjects.Count != 1)
            {
                return null;
            }

            return selectedObjects.First() as Pawn;
        }

        public ExtendedDataStorage GetExtendedDataStorage()
        {
            return _extendedDataStorage;
        }

        public FireManager GetFireManager()
        {
            return _fireManager;
        }

        public bool IsModEnabled()
        {
            return _modEnabled;
        }
    }
}