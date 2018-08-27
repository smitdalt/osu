// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Game.Graphics;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Osu.Objects;
using OpenTK;
using osu.Game.Rulesets.Osu.UI;

namespace osu.Game.Rulesets.Osu.Mods
{
    public class OsuModRotate : Mod, IApplicableToDrawableHitObjects
    {
        public override string Name => "Rotate";
        public override string ShortenedName => "RO";
        public override FontAwesome Icon => FontAwesome.fa_refresh;
        public override ModType Type => ModType.Fun;
        public override string Description => @"Don't get dizzy!";
        public override double ScoreMultiplier => 1.0;
        public override bool Ranked => false;
        //Speed of the rotation in rads/second.
        private const float rotationSpeed = (float)Math.PI/4;
        private Vector2 center = OsuPlayfield.BASE_SIZE / 2;

        public void ApplyToDrawableHitObjects(IEnumerable<DrawableHitObject> drawables)
        {  
            foreach(var drawable in drawables)
            {
                OsuHitObject hitObject = (OsuHitObject) drawable.HitObject;

                double appearTime = hitObject.StartTime - hitObject.TimePreempt;

                float radius = Vector2.Distance(center, hitObject.Position);
                float X = (float)(center.X + radius * Math.Cos(hitObject.StartTime * rotationSpeed));
                float Y = (float)(center.Y + radius * Math.Sin(hitObject.StartTime * rotationSpeed));

                float appearX = (float)(center.X + radius * Math.Cos(appearTime * rotationSpeed));
                float appearY = (float)(center.Y + radius * Math.Sin(appearTime * rotationSpeed));

                Vector2 actualPos = new Vector2(X, Y);
                Vector2 appearPos = new Vector2(appearX, appearY);

                hitObject.Position = actualPos;

                using (drawable.BeginAbsoluteSequence(appearTime, true))
                {
                    drawable
                        .MoveToOffset(appearPos)
                        .MoveTo(actualPos, hitObject.TimePreempt, Easing.InOutCirc);
                }
            }
        }
    }
}
