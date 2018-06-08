using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Combine_Sql.Core.Builders
{
    public class JsonBuilder
    {
        public JsonBuilder() { }

        private List<JProperty> _properties = new List<JProperty>();

        public JsonBuilder AddProperty(string propertyName, string value)
        {
            _properties.Add(new JProperty(propertyName, value));
            return this;
        }

        public override string ToString()
        {
            var jObject = new JObject();

            foreach (var property in _properties)
            {
                jObject.Add(property.Name, property.Value);
            }

            return jObject.ToString();
        }
    }
}
