using System;
using UnityEngine;
using UnityEngine.Events;

namespace MagicianTrainee.Spells 
{
    public class SphereController : BasicSpellController
    {
        [NonSerialized] public UnityEvent DestroySphereEvent;

        public void OnUnselectSphere()
        {
            DestroySphereEvent?.Invoke();
        
            gameObject.GetComponent<Rigidbody>().AddForce(-_rightHand.transform.up.normalized * 25f, ForceMode.Impulse);
        }
    }
}
