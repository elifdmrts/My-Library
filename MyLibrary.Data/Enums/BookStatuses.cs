using System.ComponentModel;

namespace MyLibrary.Data.Enums
{
    public enum BookStatuses
    {
        [Description("Rafta")]
        OnTheShelf = 1,
        [Description("Kullanıcıda")]
        InUser = 2,
        [Description("Kullanım Dışı")]
        OutOfUse = 3
    }
}
