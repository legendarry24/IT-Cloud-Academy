using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionExample
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    class PermissionsAttribute : Attribute
    {
        public string RoleName { get; set; }

        public PermissionsAttribute() { }

        public PermissionsAttribute(string roleName)
        {
            RoleName = roleName;
        }
    }
}
