namespace ConsoleOnlineShop
{
    class UserItem
    {
        private string name, expirationDate;
        private int count;

        UserItem(string name, int count, string expirationDate)
        {
            this.name = name;
            this.count = count;
            this.expirationDate = expirationDate;
        }
    }
}
