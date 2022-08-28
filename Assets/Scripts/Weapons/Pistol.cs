namespace Weapon {
    public class Pistol : Gun {
        Pistol() : base("Pistol", 17, 17, 65)
        {

        }
        public override void OnHold()
        {
            throw new System.NotImplementedException();
        }

        public override void OnPress()
        {
            throw new System.NotImplementedException();
        }

        public override void OnTap()
        {
            throw new System.NotImplementedException();
        }
    }

}