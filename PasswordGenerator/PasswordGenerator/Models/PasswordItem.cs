namespace PasswordGenerator.Models
{
    public class PasswordItem
    {
        #region Properties

        public string Password { get; set; }

        #endregion Properties

        #region Constructor

        public PasswordItem()
        { }
        #endregion Constructor

        public override string ToString()
        {
            return Password;
        }
    }
}