namespace UserManagement.Common.Comparing;

public interface IComparer<T>
{
    IDictionary<string, (object oldValue, object newValue)> Compare(T oldObject, T newObject);
}