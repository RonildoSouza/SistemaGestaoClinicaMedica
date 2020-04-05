using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SistemaGestaoClinicaMedica.Dominio.Documentos
{
    public class ConstroiDocumento : IConstroiDocumento
    {
        public string ConstroiTemplate<T>(T modelo)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().SingleOrDefault(str => str.EndsWith($"{modelo.GetType().Name}.rns"));

            if (string.IsNullOrEmpty(resourceName))
                return string.Empty;

            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            using StreamReader reader = new StreamReader(stream);
            var textoDoTemplate = reader.ReadToEnd();

            var properties = modelo.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in properties)
            {
                var templateProp = $"{{{prop.Name}}}";

                if (!textoDoTemplate.Contains(templateProp))
                    continue;

                textoDoTemplate = textoDoTemplate.Replace(templateProp, Convert.ToString(prop.GetValue(modelo)));
            }

            return textoDoTemplate;
        }

        public string ConstroiTemplate<T>() => ConstroiTemplate(Activator.CreateInstance<T>());
    }
}
