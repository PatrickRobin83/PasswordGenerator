/*
 * -----------------------------------------------------------------------------
 *	 
 *   Filename		:   PasswordItem.cs
 *   Date			:   2024-06-21
 *   All rights reserved
 * 
 * -----------------------------------------------------------------------------
 * @author Patrick Robin <support@rietrob.de>
 */

namespace PasswordGenerator.Models
{
    public class PasswordItem
    {
        #region Properties

        public string? Password { get; set; }

        #endregion Properties

        #region Constructor

        internal PasswordItem()
        { }
        #endregion Constructor

        public override string? ToString()
        {
            return Password;
        }
    }
}