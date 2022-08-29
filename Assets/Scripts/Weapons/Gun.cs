using UnityEngine;

// TODO: Check if it's possible to implement guns without extending MonoBehaviour

namespace Weapons { 
    public abstract class Gun : MonoBehaviour
    {
        protected readonly string gunType;
        protected readonly int magSize;
        protected int ammoInMag;
        protected int totalAmmo;

        protected bool IsPressed { get; set; } = false;
        protected Vector3 HitLocation { get; set; } = new Vector3();

        public Gun(string gunType, int ammoInMag, int magSize, int totalAmmo)
        {
            this.gunType = gunType;
            this.ammoInMag = ammoInMag;
            this.magSize = magSize;
            this.totalAmmo = totalAmmo;
        }

        public abstract void OnPress(GameObject gunGameObject);
        public abstract void OnRelease(GameObject gunGameObject);

        protected virtual void OnDrawGizmos()
        {
            if (IsPressed) {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position, HitLocation); 
            }
            else {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(transform.position, (transform.forward * 2) + transform.position);
            }
        }
        protected virtual void ConsumeAmmo(int ammoUsed = 1)
        {
            ammoInMag = (ammoInMag >= ammoUsed) ? ammoInMag - ammoUsed : 0;
        }

        protected virtual void Reload()
        {
            if (totalAmmo >= magSize) {
                ammoInMag = magSize;
                totalAmmo -= magSize;
            }
            else {
                ammoInMag = totalAmmo;
                totalAmmo = 0;
            }
        }

        public string GunType
        {
            get
            {
                return GunType;
            }
        }

        public int AmmoInMag
        {
            get
            {
                return ammoInMag;
            }
            set
            {
                if (value > 0) ammoInMag = value;
            }
        }

        public int MagSize
        {
            get
            {
                return magSize;
            }
        }

        public int TotalAmmo
        {
            get
            {
                return totalAmmo;
            }
            set
            {
                if (value > 0) totalAmmo = value;
            }
        }
    }
}
