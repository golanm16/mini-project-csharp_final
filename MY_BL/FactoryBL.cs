namespace BL
{
    public class FactoryBL
    {
        protected static IBL instance = null;
        public static IBL GetInstance()
        {
            if (instance == null)
            {
                instance = new Bl_imp();
            }
            return instance;
        }
    }
}
