using System;
using UnityEngine;

namespace MagicianTrainee.Spells.Configs
{
    [Serializable]
    public enum ActiveHands
    {
        LeftHand,
        RightHand,
        BothHands
    }
    
    [CreateAssetMenu(fileName = "SomeSpell", menuName = "Configs/SpellActivationConfig", order = 0)]
    public class SpellActivationConfig : ScriptableObject
    {
        public string Name;
        public ActiveHands Hands;
        public Vector3 DistanceBetweenHands;
        public BasicSpellController BasicSpellController;
    }
}