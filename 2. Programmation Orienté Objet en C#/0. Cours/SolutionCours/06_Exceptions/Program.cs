/*
 * Un exemple type d'utilisation d'exception concernerait l'ouverture d'une connexion extérieure avec assurance que celle-ci se voie être fermée quel que soit le déroulement du programme, 
 * 
 * Nous allons simplifier la chose en utilisant des lignes de texte représentant les tâches et en montrant que la connexion serait fermée quel que soit le déroulement du programme :
 * 
 */

int choix = -1;

/*
 * Ma section TRY sert à executer le code métier, qui doit normalement se dérouler du début à la fin sans erreur...
 * 
 * Néanmoins, il se peut que l'utilisateur fasse une manipulation non prévue, et l'on se sert alors d'un bloc CATCH pour la gérer
 * 
 * Enfin, le bloc FINALLY va s'executer peut importe si le programme a été au bout du bloc TRY ou si une exception a été repérée. Dans le cadre de notre exemple, c'est ici que l'on s'assurera de la fermeture de la connexion
 * 
 */

try
{
    Console.WriteLine("Ouverture de la connexion !\n");

    do
    {
        Console.Write("Veuillez entrer l'Id d'un contact (0 pour quitter) : ");
        choix = Convert.ToInt32(Console.ReadLine());
        if (choix == 0) break;

        Console.WriteLine();
        Console.WriteLine("=== Modification d'un contact ===\n");

        Console.Write("Nouveau nom du contact : ");
        string lastName = Console.ReadLine();

        Console.Write("Nouveau prénom du contact : ");
        string firstName = Console.ReadLine();

        Console.WriteLine($"L'Id {choix} a été modifié ! Nouveau contact : {firstName} {lastName}");

    } while (true);

}
catch (OverflowException)
{
    Console.WriteLine("EXCEPTION !");
    Console.WriteLine("La valeur est trop grande pour être contenue dans un Int32 !");
}
catch (Exception ex)
{
    Console.WriteLine("EXCEPTION !");
    Console.WriteLine($"{ex.GetType()} : {ex.Message}");
}
finally
{
    Console.WriteLine();
    Console.WriteLine("La connexion est désormais fermée !");
}
