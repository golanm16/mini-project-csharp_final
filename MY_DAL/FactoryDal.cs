namespace DAL
{
    public class FactoryDal
    {
        protected static Idal instance = null;
        public static Idal GetInstance()
        {
            if (instance == null)
            {
                instance = new Dal_XML_imp();
            }
            return instance;
        }
    }
}
