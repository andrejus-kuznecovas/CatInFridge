using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace TestingAPI2
{
    public class ParsingReceipt : IParser<List<Item>>
    {
        //Method removes Lithuanian letters and turns them into standart (ex. Ž -> Z)
        public static string RemoveInternationalLetters(string receipt)
        {
            string normalizedReceipt = String.Join("", receipt.Normalize(NormalizationForm.FormD).Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark));
            return normalizedReceipt;
        }

        //Method checks the receipt and tries to find a pattern to return the name of the Shop
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

 

        //searching for 8 digits and whatever (of reasonable amount) rubbish inbetween them
        private string dateRegex = @"(\d\D{0,3}\d\D{0,3}\d\D{0,3}\d\D{0,3}\d\D{0,3}\d\D{0,3}\d\D{0,3}\d)";

        public string RemoveNonDigits(string str)
        {
            return new String(str.Where(Char.IsDigit).ToArray());
        }


        //Lines ending with three numbers and tax groups A or M1 are what we consider items
        private string itemRegex = @"(.+)(\d.*\d.*\d.*)(?:A|M1)";


        public ParsingReceipt(string dateRegex, string itemRegex)
        {
            this.dateRegex = dateRegex;
            this.itemRegex = itemRegex;
        }

        public List<Item> Parse(string source)
        {
            List<Item> parsedItems = new List<Item>();

            var itemMatch = Regex.Match(source, itemRegex);

            while (itemMatch.Success)
            {
                parsedItems.Add(ParseItem(itemMatch));
                itemMatch = itemMatch.NextMatch();
            }

            return parsedItems;
        }

        public Item ParseItem(Match matchedItem)
        {
            //According to the specified regex, there are two matching groups (the last one is not matching)
            //Match.Group[0] is a full match
            //Match.Group[1] is the first matching group
            string itemName = matchedItem.Groups[1].Value.Trim();

            //Match.Group[2] is the second matching group
            int itemPrice;
            string itemPriceClean = matchedItem.Groups[2].Value.Trim();
            if (!int.TryParse(itemPriceClean, out itemPrice))
            {
                itemPrice = 0;
            }

            Item parsedItem = new Item(itemName, itemPrice);
            return parsedItem;
        }

    }
}
