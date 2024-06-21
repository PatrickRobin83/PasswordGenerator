/*
*----------------------------------------------------------------------------------
*          Filename:	CreatePasswordService.cs
*          Date:		2024-06-21
*          All rights reserved
*
*----------------------------------------------------------------------------------
* @author Patrick Robin <support@rietrob.de>
*/

using System.Collections.ObjectModel;

using PasswordGenerator.Models;

namespace PasswordGenerator.Services
{
    public static class CreatePasswordService
    {
        #region Methods

        public static string CreateRandomPassword(bool isDigitalUseChecked, bool isCapitalUseChecked, bool isNonCapitalUseChecked, bool isSpecialCharacterUseChecked, int passwordLength)
        {
            string generatedPassword = string.Empty;
            char passwordChar = ' ';
            List<char> chars = new ();

               if (isDigitalUseChecked)
               {
                   chars.AddRange(_digits);
               }
               if (isCapitalUseChecked)
               {
                   chars.AddRange(_capitalLetters);
               }

               if (isNonCapitalUseChecked)
               {
                   chars.AddRange(_nonCapitalLetters);
               }

               if (isSpecialCharacterUseChecked)
               {
                   chars.AddRange(_specialCharacters);
               }

               for (int i = 0; i < passwordLength; i++)
               {
                   for (int j = 0; j < 20; j++)
                   {
                       passwordChar = chars[new Random().Next(0, chars.Count)];
                   }
                   generatedPassword += passwordChar;
               }

            return generatedPassword;
        }

        public static ObservableCollection<PasswordItem> CreatePasswords(int amount, bool isDigitalUseChecked, bool isCapitalUseChecked, bool isNonCapitalUseChecked, bool isSpecialCharacterUseChecked, int passwordLength)
        {
            ObservableCollection<PasswordItem> passwords = new();

            for (int i = 0; i < amount; i++)
            {
                PasswordItem passwordItem = new()
                {
                    Password = CreateRandomPassword(isDigitalUseChecked, isCapitalUseChecked, isNonCapitalUseChecked, isSpecialCharacterUseChecked, passwordLength)
                };
                passwords.Add(passwordItem);
            }

            return passwords;
        }

        #endregion Methods

        #region Events

        #endregion Events

        #region Properties

        #endregion Properties

        #region Fields
        private static List<char> _specialCharacters = new() { '!', '$', '%', '&', '/', '=', '?', '*', '#', '+', '-', '_', '@', '€' };
        private static List<char> _capitalLetters = new() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private static List<char> _nonCapitalLetters = new() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private static List<char> _digits = new() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        #endregion Fields
    }
}