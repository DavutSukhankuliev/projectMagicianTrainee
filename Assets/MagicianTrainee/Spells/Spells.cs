using System;
using System.Collections.Generic;
using MagicianTrainee.Spells.Configs;
using TMPro;
using UnityEngine;

namespace MagicianTrainee.Spells
{
    [Serializable]
    public struct Hands
    {
        public Transform LeftHand;
        public Transform LeftHandSpellCastTransform;
        public Transform RightHand;
        public Transform RightHandSpellCastTransform;
    }
    public class Spells : MonoBehaviour
    {
        [SerializeField] private Hands _hands;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private DummyBehaviour _dummy;
        [SerializeField] private SpellActivationConfig[] _spellActivationConfigs;

        private float _currentDistanceBetweenHands;
        private Dictionary<string, SpellActivationConfig> _spellDict = new Dictionary<string, SpellActivationConfig>();
        private TeleportController _teleportSphere;

        private void Start()
        {
            if (_spellDict.Count != 0)
            {
                return;
            }
            foreach (var config in _spellActivationConfigs)
            {
                _spellDict.Add(config.Name,config);
            }
            
            
        }

        public void AimToTeleport()
        {
            if (_teleportSphere != null)
            {
                return;
            }
            var config = _spellDict["spell_aimToTeleport"];
            if (config.Hands != ActiveHands.RightHand)
            {
                return;
            }
            var rightHandPos = _hands.RightHandSpellCastTransform.position;
            _teleportSphere = Instantiate(config.BasicSpellController,
                rightHandPos,
                Quaternion.identity) as TeleportController;
        }

        public void DoTeleport()
        {
            if (_teleportSphere == null)
            {
                return;
            }
            _teleportSphere.ShootSphere();
        }

        public void CreateFireBall()
        {
            var config = _spellDict["spell_fireball"];
            if (config.Hands != ActiveHands.BothHands)
            {
                return;
            }
            if (!(_currentDistanceBetweenHands >= config.DistanceBetweenHands.x - 0.05f) ||
                !(_currentDistanceBetweenHands < config.DistanceBetweenHands.x + 0.05f))
            {
                return;
            }
            var rightHandPos = _hands.RightHandSpellCastTransform.position;
            var leftHandPos = _hands.LeftHandSpellCastTransform.position;
            var controller = Instantiate(config.BasicSpellController,
                new Vector3((rightHandPos.x + leftHandPos.x)/2, (rightHandPos.y + leftHandPos.y)/2, (rightHandPos.z + leftHandPos.z)/2), 
                Quaternion.identity);

            _dummy.SetSphereController(controller);
        }

        private void FixedUpdate()
        {
            _currentDistanceBetweenHands = Vector3.Distance(_hands.LeftHand.position, _hands.RightHand.position);
        }

        private void Update()
        {
            _text.text = _currentDistanceBetweenHands.ToString();
        }
    }
}

