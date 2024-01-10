using UnityEngine;

namespace MagicianTrainee.Spells
{
    public class TeleportController : BasicSpellController
    {
        public void ShootSphere()
        {
            var rigidbody = gameObject.GetComponent<Rigidbody>();
            rigidbody.isKinematic = false;
            rigidbody.useGravity = true;
            rigidbody.AddForce((_rightHand.transform.up.normalized - _rightHand.transform.right.normalized)*10f, ForceMode.Impulse);
            
            
        }
    }
}