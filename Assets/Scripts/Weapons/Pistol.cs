using UnityEngine;

namespace Weapon {
    public class Pistol : Gun {
        bool isPressed = false;

        public Pistol() : base("Pistol", 17, 17, 65)
        {

        }

        // TODO: Replace Debug.Drawline with Gizmos
        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(transform.position, transform.forward * 2 + transform.position);
        }

        private void FixedUpdate()
        {
            Ray ray = new(transform.position, transform.forward);
            if (isPressed) {
                if (Physics.Raycast(ray, out RaycastHit hit, 100f)) {
                    Debug.DrawLine(transform.position, hit.point, Color.red);
                }
            }
            else {
                if (Physics.Raycast(ray, out RaycastHit hit, 2f)) {
                    Debug.DrawLine(transform.position, hit.point, Color.green);
                }
                Debug.DrawRay(transform.position, transform.forward * 2, Color.green);
            }
        }



        public override void OnPress(GameObject gunGameObject)
        {
            isPressed = true;
            Debug.Log("Fire pressed on Pistol");
            //Ray ray = new(gunGameObject.transform.position, gunGameObject.transform.forward);

            //if (Physics.Raycast(ray, out RaycastHit hit, 100f)) {
            //    Debug.Log(hit.transform.gameObject.name);
            //    Debug.DrawLine(gunGameObject.transform.position, hit.point, Color.red);
            //}
            //else {
            //    Debug.Log("Should this happen???");
            //}

        }

        public override void OnRelease(GameObject gunGameObject)
        {
            isPressed = false;
            Debug.Log("Fire released on Pistol");
        }
    }

}