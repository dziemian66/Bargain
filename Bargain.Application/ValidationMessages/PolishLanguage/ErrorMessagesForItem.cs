using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargain.Application.ValidationMessages.PolishLanguage
{
    public static class ErrorMessagesForItem
    {
        public static string EarlierPriceBeNotGreaterThanCurrentPrice { get; set; } = "Poprzednia cena nie może być niższa niż cena promocji";
        public static string IncorrectUrlForm { get; set; } = "Niepoprawny format linku";
        public static string FileIsNull { get; set; } = "Dodaj grafikę przedstawiającą okazję";
        public static string IncorrectCountOfFiles { get; set; } = "Dodaj maksymalnie 6 obrazów";
        public static string IncorrectFileSize { get; set; } = "Maksymalna wielkosć obrazka wynosi 1 MB";
        public static string IncorrectFileContentType { get; set; } = "Próbujesz przesłać niepoprawny rodzaj pliku";
    }
}
