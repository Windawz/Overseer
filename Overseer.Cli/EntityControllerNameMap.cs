using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overseer.Cli;
internal class EntityControllerNameMap {
    public EntityControllerNameMap() : this(new Dictionary<Type, string>()) { }

    public EntityControllerNameMap(IDictionary<Type, string> nameOverrides) {
        _nameOverrides = nameOverrides;
    }

    private readonly IDictionary<Type, string> _nameOverrides;

    public string GetControllerName(Type entityType) {
        if (_nameOverrides.TryGetValue(entityType, out var name)) {
            return name;
        }
        return GetDefaultName(entityType);
    }

    private static string GetDefaultName(Type entityType) {
        return entityType.Name + "s";
    }
}
