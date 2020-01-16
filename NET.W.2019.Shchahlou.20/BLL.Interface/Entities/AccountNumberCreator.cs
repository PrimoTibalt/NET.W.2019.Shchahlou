namespace BLL.Interface.Entities
{
    using BLL.Interface.Interfaces;

    public class AccountNumberCreator : IAccountNumberCreateService
    {
        /// <summary>
        /// Creates number by HashCode of name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetNextNumber(string name)
        {
            return name.GetHashCode();
        }
    }
}
