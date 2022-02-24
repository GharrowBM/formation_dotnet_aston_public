namespace Exercice10
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int v = 5, v2 = 10;
            Console.WriteLine($"Avant la fonction, valeur vaut : {v} et valeur2 vaut : {v2}");
            var (somme, produit) = MultiplyAndAdd(ref v, ref v2);
            Console.WriteLine($"Après la fonction, valeur vaut : {v} et valeur2 vaut : {v2}");
            Console.WriteLine($"La somme des deux vaut : {somme} et leur produit : {produit}");
        }

        private static (int, int) MultiplyAndAdd(ref int valeur, ref int valeur2)
        {
            valeur++;
            valeur2++;
            Console.WriteLine($"Dans la fonction, valeur vaut : {valeur} et valeur2 vaut : {valeur2}");
            return (valeur + valeur2, valeur * valeur2);
        }
    }
}