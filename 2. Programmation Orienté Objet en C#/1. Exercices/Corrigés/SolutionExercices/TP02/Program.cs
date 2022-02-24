using TP02.Classes;

namespace TP02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Chaise chaise1 = new Chaise();
            Chaise chaise2 = new Chaise(2, "Noire", "Métal");
            Chaise chaise3 = new Chaise() { NbPieds = 6, Materiaux="Plastique", Couleur="Bleue" };

            AffichageChaise(chaise1);
            AffichageChaise(chaise2);
            AffichageChaise(chaise3);
        }

        public static void AffichageChaise(Chaise chaise)
        {
            Console.WriteLine($"Je suis une Chaise, avec {chaise.NbPieds} pieds en {chaise.Materiaux} et de couleur {chaise.Couleur}");
        }
    }
}

