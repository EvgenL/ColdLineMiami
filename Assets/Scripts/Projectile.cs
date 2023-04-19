using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Projectile : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);

            TryDealDamage(collision.gameObject);
        }

        private void TryDealDamage(GameObject other)
        {
            if (other.TryGetComponent<CharacterRagdoller>(out var ragdoller))
            {
                ragdoller.DoRagdoll();
            }
            if (other.TryGetComponent<AimInput>(out var aim))
            {
                aim.enabled = false;
            }
            if (other.TryGetComponent<PlayerInput>(out var input))
            {
                input.enabled = false;
            }
        }
    }
}