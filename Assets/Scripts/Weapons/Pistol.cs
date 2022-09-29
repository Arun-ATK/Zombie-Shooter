using UnityEngine;

namespace Weapons {
    public class Pistol : Gun {
        
        private bool hasFired = false;

        public Pistol() : base(6, 65, 10, 3.0f)
        {

        }

        private void OnDrawGizmos()
        {
            if (FirePressed) {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position, transform.forward * 10 + transform.position);
            }
            else {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(transform.position, (transform.forward * 2) + transform.position);
            }
        }

        private void FixedUpdate()
        {
            if (AmmoInMag <= 0) {
                Reload();
                
                return;
            }

            Ray ray = new(transform.position, transform.forward);
            if (FirePressed && !hasFired) {
                if (Physics.Raycast(ray, out RaycastHit hit, 100f)) {
                    if (hit.transform.gameObject.CompareTag("Zombie")) {
                        ZombieController zombie = hit.transform.gameObject.GetComponent<ZombieController>();
                        zombie.HitByBullet(DamagePerBullet);
                    }
                }

                hasFired = true;
                ConsumeAmmo();
            }
        }

        public override void OnPress()
        {
            FirePressed = true;
        }

        public override void OnRelease()
        {
            FirePressed = false;
            hasFired = false;
        }
    }
}