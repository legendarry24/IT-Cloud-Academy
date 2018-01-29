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

            foreach (PermissionsAttribute permission in attributes)
            {
                if (permission.RoleName == userName)
                    return true;
            }
            // can convert into LINQ expression
            //if (attributes.Cast<PermissionsAttribute>().Any(permission => permission.RoleName == userName))
            //{
            //    return true;
            //}

            if (!string.IsNullOrEmpty(methodName))
            {
                var methodAttributes = type
                    .GetMethod(methodName)
                    .GetCustomAttributes(false);

                foreach (PermissionsAttribute permission in methodAttributes)
                {
                    if (permission.RoleName == userName)
                        return true;
                }
                // can convert into LINQ expression
                //return methodAttributes.Cast<PermissionsAttribute>().Any(permission => permission.RoleName == userName);
            }

            return false;
        }
    }
}
