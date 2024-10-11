
using Newtonsoft.Json;

namespace Shared.Extension;

public static class Extensions
{
    public static T? DeepClone<T>(this object obj) where T : class
    {
        string json = JsonConvert.SerializeObject(obj);
        return JsonConvert.DeserializeObject<T>(json);
    }
}