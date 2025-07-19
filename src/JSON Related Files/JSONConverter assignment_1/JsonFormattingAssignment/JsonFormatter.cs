using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JsonFormattingAssignment
{
    public class JsonFormatter
    {
        public static string Convert(object item)
        {
            if (item == null)
            {
                return "{}";                               // Return  {} brackets if null input
            }

            StringBuilder json = new StringBuilder();
            json.Append("{");                              //Initial { starting bracket    

            PropertyInfo[] properties = item.GetType().GetProperties();

            foreach (PropertyInfo prop in properties)
            {
                json.Append($"\"{prop.Name}\":");          //----------------------Start, KEy

                object value = prop.GetValue(item);        //Storing the items value to value
                if (value == null)
                {
                    json.Append("null,\n");     //++++++++++Beautify JSON              
                }

                //Testing For primitive, string and Date time (type)
                else if (prop.PropertyType.IsPrimitive || prop.PropertyType == typeof(string) || prop.PropertyType == typeof(DateTime))
                {
                    json.Append($"\"{value}\",\n");     //++++++++++Beautify JSON
                }

                //Checking Specific for Array type
                else if (prop.PropertyType.IsArray)
                {
                    Array array = (Array)value;       //Typecasting to Array
                    json.Append("[");
                    for (int i = 0; i < array.Length; i++)
                    {
                        json.Append($"\"{array.GetValue(i)}\"");
                        if (i < array.Length - 1)    //Omit the extra comma
                        {
                            json.Append(", ");
                        }
                    }
                    json.Append("],\n");     //++++++++++Beautify JSON
                }

                //Handling the cellectibles, List,
                //If collectible then pass value to enumerable variable
                else if (value is IEnumerable enumerable)
                {
                    json.Append("[");                        //Starting the structure of array with [ bracket
                    foreach (var element in enumerable)
                    {
                        if (element != null)
                        {
                            json.Append(Convert(element) + ","); //If the value is complex then another round of recursion
                        }
                        else
                        {
                            json.Append("null,\n");     //++++++++++Beautify JSON 
                        }
                        
                    }
                    // Remove the last comma and space
                    if (json[json.Length - 1] == ',')     //Removing the extra comma befor ] bracket, atlast
                    {
                        json.Length--;
                    }
                    json.Append("],\n");     //++++++++++Beautify JSON
                }
                else
                {
                    json.Append(Convert(value) + ",\n");     //Else continues to recursion     //++++++++++Beautify JSON
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
