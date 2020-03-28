using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Documentos
{
    public class ConstroiDocumento : IConstroiDocumento
    {
        public string ConstroiTemplate<T>(T modelo)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().SingleOrDefault(str => str.EndsWith($"{modelo.GetType().Name}.txt"));

            if (string.IsNullOrEmpty(resourceName))
                return string.Empty;

            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            using StreamReader reader = new StreamReader(stream);
            var textoDoTemplate = reader.ReadToEnd();

            var properties = modelo.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (var prop in properties)
            {
                var templateProp = $"{{{prop.Name}}}";

                if (!textoDoTemplate.Contains(templateProp))
                    continue;

                textoDoTemplate = textoDoTemplate.Replace(templateProp, Convert.ToString(prop.GetValue(modelo)));
            }

            return textoDoTemplate;
        }
    }
}
