using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace TestingAPI2
{
    class ParsingReceipt
    {

        public static string RemoveInternationalLetters(string receipt)
        {
            string normalizedReceipt = String.Join("", receipt.Normalize(NormalizationForm.FormD).Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark));
            return normalizedReceipt;
        }


        public static Shop GetShopName(string receipt)
        {
            Dictionary<Shop, string[]> ShopNames = new Dictionary<Shop, string[]>();
            ShopNames.Add(Shop.IKI, new string[] { @"iki" });
            ShopNames.Add(Shop.MAXIMA, new string[] { @"maxim[^u]\w+)" });
            ShopNames.Add(Shop.NORFA, new string[] { @"norfa\w+" });
            ShopNames.Add(Shop.RIMI, new string[] { @"rimi\w+" });
           

            foreach (KeyValuePair<Shop, string[]> ShopData in ShopNames) 
            {
                foreach (string shopEstablish in ShopData.Value)
                {
                    string shopText = shopEstablish.ToLower(); 
                    Shop currentShopName = ShopData.Key;

                    bool IsMatch = Regex.IsMatch(receipt, shopText, RegexOptions.IgnoreCase);
                    if (IsMatch)
                    {
                        return currentShopName; 
                    }
                }
            }
            return Shop.UNRECOGNIZED;
        }

    }
}
