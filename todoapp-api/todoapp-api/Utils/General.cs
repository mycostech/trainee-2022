using todoapp_api.Models;

namespace todoapp_api.Utils
{
    public static class General
    {

        public static bool IsNull(this int? number)
        {
            if (number == null)
                return true;
            return false;
        }
    }
}
