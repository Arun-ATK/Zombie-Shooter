using UnityEngine;

namespace Weapons {
    public class Pistol : Gun {
        
        private bool hasFired = false;

        public Pistol() : base("Pistol", 17, 17, 65, 10)
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
            Ray ray = new(transform.position, transform.forward);
            if (FirePressed && !hasFired) {
                if (Physics.Raycast(ray, out RaycastHit hit, 100f)) {
                    if (hit.transform.gameObject.CompareTag("Zombie")) {
                        ZombieController zombie = hit.transform.gameObject.GetComponent<ZombieController>();
                        zombie.HitByBullet(damagePerBullet);
                    }
                }

                hasFired = true;
            }
        }

        public override void OnPress()
        {
            FirePressed = true;
            Debug.Log("Fire pressed on Pistol");
        }

        public override void OnRelease()
        {
            FirePressed = false;
            hasFired = false;
            Debug.Log("Fire released on Pistol");
        }
    }
}