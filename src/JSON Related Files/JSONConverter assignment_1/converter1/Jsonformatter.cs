using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace converter1
{
    public class Jsonformatter
    {
        public static string Convert(object item)
        {
            if (item == null)
            {
                return "{}"; // Return an empty JSON object for null input
            }

            StringBuilder json = new StringBuilder();
            json.Append("{");

            PropertyInfo[] properties = item.GetType().GetProperties();

            foreach (PropertyInfo prop in properties)
            {
                object value = prop.GetValue(item);
                // Check if the value is null
                if (value != null)
                {
                    if (prop.PropertyType.IsClass && prop.PropertyType != typeof(string))
                    {
                        //Handling Nested Object
                        json.Append($"\"{prop.Name}\": {Convert(value)}, ");
                    }
                    
                    else
                    {
                        json.Append($"\"{prop.Name}\": \"{value}\", ");
                    }
                }
                else
                {
                    // If the value is null, append "null" to the JSON string
                    json.Append($"\"{prop.Name}\": null, ");
                }
            }

            // Remove the last comma and space
            if (json.Length > 1)
            {
                json.Length -= 2;
            }

            json.Append("}");

            return json.ToString();
        }
    }
}
