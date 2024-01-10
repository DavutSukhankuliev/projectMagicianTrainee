using UnityEngine;

namespace MagicianTrainee.Spells
{
    public class BasicSpellController : MonoBehaviour
    {
        protected Transform _rightHand;
        protected Transform _leftHand;

        private void Start()
        {
            _leftHand = GameObject.Find("OculusHand_L").transform;
            _rightHand = GameObject.Find("OculusHand_R").transform;
        }
    }
}