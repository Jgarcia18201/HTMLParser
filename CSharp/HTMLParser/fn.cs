using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fn
{
    public class s
    {
        public static bool AreEqual(string ur_value1, string ur_value2)
        {
            return string.Equals(ur_value1, ur_value2, StringComparison.CurrentCultureIgnoreCase);


        }
    }

    public class rfl
    {
        public static void AssignStrings(System.Collections.Generic.List<string> ret_list, object ur_obj)
        {
            var prop_list = new System.Collections.Generic.List<string>();

            foreach (var property_def in ret_list.GetType().GetProperties())
            {
                prop_list.Add(property_def.Name);
            }

            foreach (var property_def in ur_obj.GetType().GetProperties())
            {
                foreach (var desired_name in 
                    (from desired_name in prop_list
                     where s.AreEqual(desired_name, property_def.Name)
                     select desired_name)
                    )
                {
                    //notify.appendline($"{property_def.name}: {property_def.getvalue(assembly_version, null).tostring()}");
                    ret_list.Add(property_def.GetValue(ur_obj).ToString());
                }
            }
        }
    }
}
