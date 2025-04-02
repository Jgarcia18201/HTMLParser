using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
            var desired_name_list = new System.Collections.Generic.List<string>();

            foreach (var property_def in ret_list.GetType().GetProperties())
            {
                desired_name_list.Add(property_def.Name);
            }

            foreach (var property_def in ur_obj.GetType().GetProperties())
            {
                foreach (var desired_name in 
                    (from desired_name in desired_name_list
                     where s.AreEqual(desired_name, property_def.Name)
                     select desired_name)
                    )
                {
                    //notify.appendline($"{property_def.name}: {property_def.getvalue(assembly_version, null).tostring()}");
                    ret_list.Add(property_def.GetValue(ur_obj).ToString());
                }
            }
        }

        public static string format_object(object ur_obj)
        {
            var property_list = ur_obj.GetType().GetProperties();
            var output = new StringBuilder();
            var first_row = true;
            foreach (var property_def in
                property_list
                 )
            {
                if (first_row == false)
                {
                    output.Append("\t");
                }
                output.Append(property_def.Name);
                first_row = false;
            }
            output.AppendLine();
            first_row = true;
            foreach (var property_def in property_list)
            {
                if (first_row == false)
                {
                    output.Append("\t");
                }
                output.Append(property_def.GetValue(ur_obj).ToString());
                first_row = false;
            }
            return output.ToString();
        }

        public static string format_table(System.Collections.Generic.List<string> ret_list)
        {
            var output = new StringBuilder();
            var first_row = true;
            foreach (var property_def in
                (from property_def in ret_list.GetType().GetProperties()
                 where property_def.DeclaringType == ret_list.GetType()
                 select property_def)
                 )
            {
                if (first_row == false)
                {
                    output.Append("\t");
                }
                output.Append(property_def.Name);
                first_row = false;
            }
            output.AppendLine();
            first_row = true;
            foreach (var value in ret_list)
            {
                if (first_row == false)
                {
                    output.Append("\t");
                }
                output.Append(value);
                first_row = false;
            }
            return output.ToString();
        }

    }
    public class rfl<T>
    {
        public static string FormatObjectList(System.Collections.Generic.List<T> ret_list)
        {
            var output = new StringBuilder();
            var first_column = true;
            foreach (var property_def in typeof(T).GetProperties())
            {
                if (first_column == false)
                {
                    output.Append("\t");
                }
                output.Append(property_def.Name);
                first_column = false;
            }
            output.AppendLine();
            var first_row = true;
            foreach (var row in ret_list)
            {
                if (first_row == false)
                {
                    output.AppendLine();
                }
                first_column = true;
                foreach (var property_def in typeof(T).GetProperties())
                {
                    if (first_column == false)
                    {
                        output.Append("\t");
                    }
                    output.Append($"\"{property_def.GetValue(row).ToString().Replace("\"", "\"\"")}\"");
                    first_column = false;
                }
                first_row = false;
            }
            return output.ToString();
        }

    }
}
