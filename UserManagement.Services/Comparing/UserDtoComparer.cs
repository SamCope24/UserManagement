using System;
using System.Collections.Generic;
using System.Reflection;

namespace UserManagement.Services.Comparing;

public class UserDtoComparer : Common.Comparing.IComparer<UserDto>
{
    public IDictionary<string, (object oldValue, object newValue)> Compare(UserDto oldUser, UserDto newUser)
    {
        if (oldUser is null)
        {
            throw new ArgumentNullException(nameof(oldUser));
        }

        if (newUser is null)
        {
            throw new ArgumentNullException(nameof(newUser));
        }

        var changes = new Dictionary<string, (object oldValue, object newValue)>();

        foreach (var property in typeof(UserDto).GetProperties(BindingFlags.Instance | BindingFlags.Public))
        {
            var oldValue = property.GetValue(oldUser);
            var newValue = property.GetValue(newUser);

            if (!Equals(oldValue, newValue))
            {
                changes.Add(property.Name, (oldValue!, newValue!));
            }
        }

        return changes;
    }
}
