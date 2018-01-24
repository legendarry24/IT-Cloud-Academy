using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionExample
{
    static class PermissionsValidator
    {
        public static bool ValidateAccess(string userName, string methodName = null)
        {
            var type = typeof(Phone);

            var attributes = type.GetCustomAttributes(false);
            //TODO
            foreach (PermissionsAttribute permission in attributes)
            {
                if (permission.RoleName == userName)
                    return true;
            }

            if (!string.IsNullOrEmpty(methodName))
            {
                var methods = type
                    .GetMethod(methodName)
                    .GetCustomAttributes(false)
                    .Any(x => (x as PermissionsAttribute)?.RoleName == userName);
            }

            return false;
        }
    }
}
