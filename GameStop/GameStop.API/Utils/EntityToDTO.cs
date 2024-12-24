using System.Net.Http.Headers;
using System.Reflection;
using GameStop.API.DTO;

namespace GameStop.API.Utils;

public class EntityToDTO<E, D>
{
    public static void ToDTO(E entity, D dto)
    {
        if (entity == null || dto == null) throw new ArgumentException("Entity or dto object cannot be null");

        Type entityType = typeof(E);
        Type dtoType = typeof(D);

        PropertyInfo[] entityProperties = entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (PropertyInfo entityProperty in entityProperties)
        {
            PropertyInfo dtoProperty = dtoType.GetProperty(entityProperty.Name)!;

            object value = entityProperty.GetValue(entity)!;

            if (value != null) dtoProperty.SetValue(dto, value);
        }
    }
}