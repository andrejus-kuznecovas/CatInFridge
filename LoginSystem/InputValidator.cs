using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Text.RegularExpressions;

namespace LoginSystem
{
    public class InputValidator
    {
        /// <summary>
        /// Checks if entered name is in correct form ( any character from a to Z)
        /// </summary>
        /// <param name="value"> user input</param>
        /// <returns></returns>
        public bool CheckName(string value)
        {
            string pattern = @"[A-Z]?[a-z]+";
            Match result = Regex.Match(value, pattern);
            return result.Success;
        }
        /// <summary>
        /// Checks if entered password is in correct form ( any character and special symbols [from 8 to 20 chars])
        /// </summary>
        /// <param name="value">user input</param>
        /// <returns></returns>
        public bool CheckPassword(string value)
        {
            string pattern = @"[\w\d\+-., !@#$%^&*();\/|<>]{8,20}";
            Match result = Regex.Match(value, pattern);
            return result.Success;
        }

        /// <summary>
        /// Checks if entered Email is in correct form (text + @ + text + . + text) 
        /// </summary>
        /// <param name="value">user input</param>
        /// <returns></returns>
        public bool CheckEmail(string value)
        {
            string pattern = @"[\w\d\._-]+@([\w]+\.[\w]+)(\.[\w]+)*";
            Match result = Regex.Match(value, pattern);
            return result.Success;
        }

    }
}
