// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using osu.Framework.Timing;
using osu.Game.Graphics;

namespace osu.Game.Rulesets.Mods
{
    public abstract class ModTripleTime : Mod, IApplicableToClock
    {
        public override string Name => "Triple Time";
        public override string ShortenedName => "TT";
        public override FontAwesome Icon => FontAwesome.fa_osu_mod_doubletime;
        public override ModType Type => ModType.Fun;
        public override string Description => "Soooooo fast...";
        public override bool Ranked => false;
        public override Type[] IncompatibleMods => new[] { typeof(ModHalfTime), typeof(ModDoubleTime) };

        public virtual void ApplyToClock(IAdjustableClock clock)
        {
            clock.Rate = 2;
        }
    }
}
