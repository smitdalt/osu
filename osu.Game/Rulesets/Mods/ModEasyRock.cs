// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using osu.Game.Beatmaps;
using osu.Game.Graphics;

namespace osu.Game.Rulesets.Mods
{
    public abstract class ModEasyRock : Mod, IApplicableToDifficulty
    {
        public override string Name => "Easy Rock";
        public override string ShortenedName => "ER";
        public override FontAwesome Icon => FontAwesome.fa_osu_mod_hardrock;
        public override ModType Type => ModType.Fun;
        public override string Description => "Everything just got a bit harder... I think?";
        public override bool Ranked => false;
        public override Type[] IncompatibleMods => new[] { typeof(ModEasy), typeof(ModHardRock) };

        public void ApplyToDifficulty(BeatmapDifficulty difficulty)
        {
            const float easyRatio = 0.5f;
            const float hardRatio = 1.4f;
            difficulty.CircleSize = difficulty.CircleSize * easyRatio;
            difficulty.ApproachRate = Math.Min(difficulty.ApproachRate * hardRatio, 10.0f);
            difficulty.DrainRate = Math.Min(difficulty.DrainRate * hardRatio, 10.0f);
            difficulty.OverallDifficulty = difficulty.OverallDifficulty * easyRatio;
        }
    }
}
