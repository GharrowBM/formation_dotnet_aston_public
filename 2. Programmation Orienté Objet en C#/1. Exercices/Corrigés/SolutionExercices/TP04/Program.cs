using TP04.Classes;

Salarie salarieA = new Salarie("Cadre", "Finances", "Albert", 45000);
Salarie salarieB = new Salarie("Technicienne", "Maintenance", "Chloé", 24000);
Salarie salarieC = new Salarie("Commerciale", "Assurances", "Emma", 30000);
Salarie salarieD = new Salarie("Technicien", "Maintenance", "Georges", 26000);

Salarie[] salaries = new Salarie[] { salarieA, salarieB, salarieC, salarieD};

foreach(Salarie s in salaries) s.AfficherSalaire();

Console.WriteLine($"Le montant total des salaires des {Salarie.NombreSalaries} employés est de {Salarie.TotalSalaires} euros");

Salarie.ChangerCompteurA(2);

Console.WriteLine($"Il y a {Salarie.NombreSalaries} salariés");