namespace TP02.Models
{
    public class Avatar
    {
        public int Id { get; set; }
        public static int Compteur { get; set; }
        public string AvatarPath { get; set; }
        public Contact Contact { get; set; }

        public Avatar()
        {
            Id = ++Compteur;
        }
    }
}
