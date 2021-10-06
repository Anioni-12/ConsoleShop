using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleOnlineShop
{
    class User
    {

        public string login { get; set; }

        public string password { get; set; }

        public List<UserItem> itemsForCurrentUser { get; set; }

        [JsonIgnore]
        public bool isAuthorized = false;

        public User()
        {
            this.login = String.Empty;
            this.password = String.Empty;
        }

        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public void LogInUser()
        {
            User[] usersData;
            usersData = JsonSerializer.Deserialize<User[]>(File.ReadAllText("usersData.json"));

            foreach (User currentUser in usersData)
            {
                if (currentUser.login == this.login && currentUser.password == this.password)
                {
                    this.itemsForCurrentUser = currentUser.itemsForCurrentUser;
                    this.isAuthorized = true;
                    return;
                }
            }
        }

        public async void RegisterUser()
        {
            using (FileStream fStream = new FileStream("usersData.json", FileMode.OpenOrCreate))
            {
                List<User> users = new List<User>(await JsonSerializer.DeserializeAsync<User[]>(fStream));
                users.Add(this);
                fStream.SetLength(0);
                await JsonSerializer.SerializeAsync<User[]>(fStream, users.ToArray());
            }
        }
    }
}
