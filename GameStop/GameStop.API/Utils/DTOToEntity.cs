using System.Reflection;

namespace GameStop.API.Utils;

public class DTOToEntity<D, E>
{
    public static void ToEntity(D dto, E entity)
    {
        if (entity == null || dto == null) throw new ArgumentException("Entity or dto object cannot be null");

        Type entityType = typeof(E);
        Type dtoType = typeof(D);

        PropertyInfo[] dtoProperties = dtoType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (PropertyInfo dtoProperty in dtoProperties){
            PropertyInfo entityProperty = entityType.GetProperty(dtoProperty.Name)!;

            object value = dtoProperty.GetValue(dto)!;

            entityProperty.SetValue(entity, value);
        }
    }
}

