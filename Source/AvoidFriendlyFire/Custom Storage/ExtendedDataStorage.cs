﻿using System.Collections.Generic;
using RimWorld;
using RimWorld.Planet;
using Verse;

namespace AvoidFriendlyFire
{
    public class ExtendedDataStorage : WorldComponent
    {
        private List<ExtendedPawnData> _extendedPawnDataWorkingList;

        private List<int> _idWorkingList;

        private Dictionary<int, ExtendedPawnData> _store =
            new Dictionary<int, ExtendedPawnData>();

        public ExtendedDataStorage(World world) : base(world)
        {
        }


        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Collections.Look(
                ref _store, "store",
                LookMode.Value, LookMode.Deep,
                ref _idWorkingList, ref _extendedPawnDataWorkingList);
        }

        // Return the associate extended data for a given Pawn, creating a new association
        // if required.
        public ExtendedPawnData GetExtendedDataFor(Pawn pawn)
        {
            var id = pawn.thingIDNumber;
            if (_store.TryGetValue(id, out var data))
            {
                return data;
            }

            var newExtendedData = new ExtendedPawnData();

            _store[id] = newExtendedData;
            return newExtendedData;
        }

        public bool CanTrackPawn(Pawn pawn)
        {
            return pawn?.Faction != null && pawn.Faction == Faction.OfPlayer;
        }

        public bool ShouldPawnAvoidFriendlyFire(Pawn pawn)
        {
            if (!CanTrackPawn(pawn))
            {
                return false;
            }

            if (!GetExtendedDataFor(pawn).AvoidFriendlyFire)
            {
                return false;
            }

            if (!FireConeOverlay.HasValidWeapon(pawn))
            {
                return false;
            }

            return true;
        }

        public void DeleteExtendedDataFor(Pawn pawn)
        {
            _store.Remove(pawn.thingIDNumber);
        }
    }
}