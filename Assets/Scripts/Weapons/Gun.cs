using UnityEngine;

// TODO: Check if it's possible to implement guns without extending MonoBehaviour

namespace Weapons { 
    public abstract class Gun : MonoBehaviour
    {
        //-------------------------//
        //       ATTRIBUTES        // 
        //-------------------------//
        protected readonly string gunType;
        protected readonly int magSize;
        protected int ammoInMag;
        protected int totalAmmo;
        protected int damagePerBullet;
        protected bool FirePressed { get; set; } = false;

        //--------------------------------------//
        //             CONSTRUCTOR              //
        //--------------------------------------//
        public Gun(string gunType, int ammoInMag, int magSize, int totalAmmo, int damage)
        {
            this.gunType = gunType;
            this.ammoInMag = ammoInMag;
            this.magSize = magSize;
            this.totalAmmo = totalAmmo;
            this.damagePerBullet = damage;
        }

        //--------------------------//
        //      VIRTUAL METHODS     //
        //--------------------------//
        //protected virtual void OnDrawGizmos()
        //{
        //    if (IsPressed) {
        //        Gizmos.color = Color.green;
        //        Gizmos.DrawLine(transform.position, HitLocation); 
        //    }
        //    else {
        //        Gizmos.color = Color.red;
        //        Gizmos.DrawLine(transform.position, (transform.forward * 2) + transform.position);
        //    }
        //}

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

        //---------------------------//
        //      ABSTRACT METHODS     //
        //---------------------------//
        public abstract void OnPress();
        public abstract void OnRelease();

        //------------------------------//
        //      GETTERS & SETTERS       //
        //------------------------------//
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
