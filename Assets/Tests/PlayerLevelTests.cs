using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using PlayerLevel;
using UnityEngine;

namespace Tests
{
    public class PlayerLevelTests
    {
        private PlayerLevelBehaviour _comp;

        [SetUp]
        public void Setup()
        {
            var go = new GameObject("Player");
            _comp = go.AddComponent<PlayerLevelBehaviour>();
            _comp.settings = ScriptableObject.CreateInstance<PlayerLevelSettings>();
        }

        [Test]
        public void ExperienceAndLevel()
        {
            _comp.settings.experiencePerLevel = new AnimationCurve(
                new Keyframe(0, 0),
                new Keyframe(1, 3),
                new Keyframe(2, 10)
            );

            _comp.Experience = 3;
            Assert.AreEqual(1, _comp.Level);

            _comp.Experience = 6;
            Assert.AreEqual(1, _comp.Level);

            _comp.Experience = 0;
            Assert.AreEqual(0, _comp.Level);

            _comp.Experience = 15;
            Assert.AreEqual(2, _comp.Level);

            // dont allow overflow (dont farm experience for future levels)
            // TODO is this as intended?
            Assert.AreEqual(10, _comp.Experience);
        }

        [Test]
        public void IsMaxLevel()
        {
            _comp.settings.experiencePerLevel = new AnimationCurve(
                new Keyframe(0, 0),
                new Keyframe(1, 3),
                new Keyframe(2, 10)
            );

            _comp.Experience = 3;
            Assert.IsFalse(_comp.IsMaxLevel);

            _comp.Experience = 0;
            Assert.IsFalse(_comp.IsMaxLevel);

            _comp.Experience = 10;
            Assert.IsTrue(_comp.IsMaxLevel);
        }

        [Test]
        public void Events_withoutDelay()
        {
            _comp.settings.experiencePerLevel = new AnimationCurve(
                new Keyframe(0, 0),
                new Keyframe(1, 3),
                new Keyframe(2, 10)
            );

            _comp.Experience = 3;

            var expChanged = false;
            var levelChanged = false;
            _comp.ExperienceChanged += (sender, tuple) =>
            {
                var (before, after) = tuple;
                Assert.AreEqual(3, before);
                Assert.AreEqual(10, after);
                expChanged = true;
            };
            _comp.LevelChanged += (sender, tuple) =>
            {
                var (before, after) = tuple;
                Assert.AreEqual(1, before);
                Assert.AreEqual(2, after);
                levelChanged = true;
            };

            _comp.Experience = 10;
            Assert.IsTrue(expChanged);
            Assert.IsTrue(levelChanged);
        }
    }
}