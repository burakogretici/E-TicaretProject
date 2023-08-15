using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static partial class Messages
    {
        public static string ShipperAdded => "Kargo eklendi ";
        public static string ShipperNameInvalid => "Kargo ismi geçersiz";
        public static string ShipperListed => "Kargolar listelendi";
        public static string ShipperDeleted => "Kargo silindi";
        public static string ShipperUpdated => "Kargo güncellendi";
        public static string ShipperNameAlreadyExists => "Kargo adı zaten var";
        public static string ShipperNotFound => "Kargo bulunamadı";
    }
}
