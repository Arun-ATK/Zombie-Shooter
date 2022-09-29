using System.Collections;

using UnityEngine;

// TODO: Check if it's possible to implement guns without extending MonoBehaviour

namespace Weapons { 
    public abstract class Gun : MonoBehaviour
    {
        //-------------------------//
        //       ATTRIBUTES        // 
        //-------------------------//
        protected readonly int magSize;
        [SerializeField] protected int totalAmmo;
        [SerializeField] protected int ammoInMag;
        protected int DamagePerBullet { get; set; }
        protected bool FirePressed { get; set; } = false;
        protected float ReloadTimer { get; set; }

        private bool reloading = false;

        //--------------------------------------//
        //             CONSTRUCTOR              //
        //--------------------------------------//
        public Gun(int magSize, int totalAmmo, int damage, float reloadTimer)
        {
            this.ammoInMag = magSize;
            this.magSize = magSize;
            this.totalAmmo = totalAmmo;
            this.DamagePerBullet = damage;
            this.ReloadTimer = reloadTimer;
        }

        //--------------------------//
        //      VIRTUAL METHODS     //
        //--------------------------//
        protected virtual void ConsumeAmmo(int ammoUsed = 1)
        {
            ammoInMag = (ammoInMag >= ammoUsed) ? ammoInMag - ammoUsed : 0;
        }

        protected virtual void Reload()
        {
            if (totalAmmo > 0 && !reloading) StartCoroutine(StartReload(ReloadTimer));
        }

        //------------------//
        //      METHODS     //
        //------------------//
        private IEnumerator StartReload(float timer)
        {
            reloading = true;
            yield return new WaitForSeconds(timer);

            if (totalAmmo >= magSize) {
                ammoInMag = magSize;
                totalAmmo -= magSize;
            }
            else {
                ammoInMag = totalAmmo;
                totalAmmo = 0;
            }

            reloading = false;
            yield return null;
        }

        //---------------------------//
        //      ABSTRACT METHODS     //
        //---------------------------//
        public abstract void OnPress();
        public abstract void OnRelease();

        //------------------------------//
        //      GETTERS & SETTERS       //
        //------------------------------//
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
