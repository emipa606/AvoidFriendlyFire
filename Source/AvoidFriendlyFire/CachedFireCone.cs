﻿using System.Collections.Generic;
using Verse;

namespace AvoidFriendlyFire
{
    public class CachedFireCone
    {
        public readonly HashSet<int> FireCone;

        private int _expireAt;

        public CachedFireCone(HashSet<int> fireCone)
        {
            FireCone = fireCone;
            Prolong();
        }

        public bool IsExpired()
        {
            return Find.TickManager.TicksGame >= _expireAt;
        }

        public void Prolong()
        {
            _expireAt = Find.TickManager.TicksGame + 2000;
        }
    }
}