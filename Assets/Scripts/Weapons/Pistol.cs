using UnityEngine;

namespace Weapons {
    public class Pistol : Gun {
        //bool isPressed = false;

        public Pistol() : base("Pistol", 17, 17, 65)
        {

        }

        private void FixedUpdate()
        {
            Ray ray = new(transform.position, transform.forward);
            if (IsPressed) {
                if (Physics.Raycast(ray, out RaycastHit hit, 100f)) {
                    HitLocation = hit.point;

                    // TODO: Enemy interaction logic
                }
            }
        }

        public override void OnPress(GameObject gunGameObject)
        {
            IsPressed = true;
            Debug.Log("Fire pressed on Pistol");
        }

        public override void OnRelease(GameObject gunGameObject)
        {
            IsPressed = false;
            Debug.Log("Fire released on Pistol");
        }
    }
}