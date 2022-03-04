using TP02.Models;

namespace TP02.Datas
{
    public class MockDatabase
    {
        public List<Contact> Contacts { get; set; }
        public List<Avatar > Avatars { get; set; }

        public MockDatabase()
        {
            Contacts = new List<Contact>();
            Avatars = new List<Avatar>();

            SeedDB();
        }

        private void SeedDB()
        {
            if(!Contacts.Any())
            {
                Contacts.AddRange(new List<Contact>()
                {
                    new Contact()
                    {
                        Firstname = "Hirohiko",
                        Lastname = "Araki",
                        Email = "jotaro.cujoh@yareyare.com",
                        Phone = "+33 123 456 789"
                    },
                    new Contact()
                    {
                        Firstname = "Akira",
                        Lastname = "Toriyama",
                        Email = "son.goku@nuage-magique.com",
                        Phone = "+33 900 000 000"
                    }, 
                    new Contact()
                    {
                        Firstname = "Rumiko",
                        Lastname = "Takahashi",
                        Email = "panda-father@justmarried.com",
                        Phone = "+33 121 212 121"
                    }, 
                    new Contact()
                    {
                        Firstname = "Tsukasa",
                        Lastname = "Hôjô",
                        Email = "gun-power@stillsingle.com",
                        Phone = "+33 100 000 000"
                    }, 
                    new Contact()
                    {
                        Firstname = "Masashi",
                        Lastname = "Kishimoto",
                        Email = "nine-tails@kurama-friend.com",
                        Phone = "+33 999 999 999"
                    }
                });
            }

            if (!Avatars.Any())
            {
                Avatars.AddRange(new List<Avatar>()
                {
                    new Avatar()
                    {
                        AvatarPath = "avatars/Hirohiko_Araki.jpeg",
                        Contact = Contacts[0]
                    },
                    new Avatar()
                    {
                        AvatarPath = "avatars/Akira_Toriyama.jpg",
                        Contact = Contacts[1]
                    }, 
                    new Avatar()
                    {
                        AvatarPath = "avatars/Rumiko_Takahashi.jpeg",
                        Contact = Contacts[2]
                    }, 
                    new Avatar()
                    {
                        AvatarPath = "avatars/Tsukasa_Hojo.jpg",
                        Contact = Contacts[3]
                    }, 
                    new Avatar()
                    {
                        AvatarPath = "avatars/Masashi_Kishimoto.jpg",
                        Contact = Contacts[4]
                    }
                });

                Contacts[0].Avatar = Avatars[0];
                Contacts[1].Avatar = Avatars[1];
                Contacts[2].Avatar = Avatars[2];
                Contacts[3].Avatar = Avatars[3];
                Contacts[4].Avatar = Avatars[4];
            }
        }
    }
}
