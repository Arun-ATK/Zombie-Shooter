using UnityEngine;

namespace Weapon {
    public class Pistol : Gun {
        bool isPressed = false;

        public Pistol() : base("Pistol", 17, 17, 65)
        {

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