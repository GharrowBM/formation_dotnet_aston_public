using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TP01.Classes
{
    internal class IHM
    {
        private List<Album> _albums;
        private string savePath, xmlPath, jsonPath;

        public IHM()
        {
            savePath = Path.Combine(Environment.CurrentDirectory, "files");
            xmlPath = Path.Combine(savePath, "xml");
            if (!Directory.Exists(xmlPath)) Directory.CreateDirectory(xmlPath);
            jsonPath = Path.Combine(savePath, "json");
            if (!Directory.Exists (jsonPath)) Directory.CreateDirectory(jsonPath);

            _albums = new List<Album>();
        }
        public void Demarrer()
        {
            int choixMenuPrincipal = -1;

            do
            {
                Console.WriteLine("=== MENU PRINCIPAL ===\n");

                Console.WriteLine("1. Importer un fichier...");
                Console.WriteLine("2. Exporter un fichier...");
                Console.WriteLine("3. Voir les albums");
                Console.WriteLine("4. Ajouter un album");
                Console.WriteLine("5. Modifier un album");
                Console.WriteLine("6. Supprimer un album");
                Console.WriteLine("0. Quitter le programme");

                Console.Write("Votre choix : ");
                choixMenuPrincipal = int.Parse(Console.ReadLine());

                switch (choixMenuPrincipal)
                {
                    case 0:
                        break;
                    case 1:
                        ImporterFichier();
                        break;
                    case 2:
                        ExporterFichier();
                        break;
                    case 3:
                        VoirAlbums();
                        break;
                    case 4:
                        AjouterAlbum();
                        break;
                    case 5:
                        ModifierAlbum();
                        break;
                    case 6:
                        SupprimerAlbum();
                        break;
                    default:
                        break;
                }

                Console.WriteLine("");

            } while (choixMenuPrincipal != 0);

        }

        private void VoirAlbums()
        {
            Console.WriteLine("=== Liste des albums ===\n");

            _albums.ForEach(album =>
            {
                Console.WriteLine($"{album.Name} : {album.Description}");
                album.Songs.OrderBy(song => song.Numero).ToList().ForEach(song =>
                {
                    Console.WriteLine($"\t{song.Numero}. {song.Name} par {song.Singer}");
                });
            });
        }

        private void AjouterAlbum()
        {
            Console.WriteLine("=== Ajouter un album ===\n");

            Console.Write("Nom de l'album : ");
            string nom = Console.ReadLine();
            Console.Write("Description de  l'album : ");
            string description = Console.ReadLine();

            Album newAlbum = new Album()
            {
                Name = nom,
                Description = description
            };

            _albums.Add(newAlbum);

            Console.WriteLine($"{newAlbum.Name} ajouté avec succès !");

        }
        private void SupprimerAlbum()
        {
            Console.WriteLine("=== Supprimer un album ===\n");

            Console.Write("Nom de l'album : ");
            string nomCherche = Console.ReadLine();
            Album albumTrouve = _albums.FirstOrDefault(album => album.Name.ToUpper().StartsWith(nomCherche.ToUpper()));

            if (albumTrouve == null) Console.WriteLine("Il n'y a aucun album qui possède ce nom !");
            else
            {
                _albums.Remove(albumTrouve);

                Console.WriteLine($"{albumTrouve.Name} supprimé de la liste des albums !");
            }
        }

        private void ModifierAlbum()
        {

            Console.Write("Nom de l'album : ");
            string nomCherche = Console.ReadLine();
            Album albumTrouve = _albums.FirstOrDefault(album => album.Name.ToUpper().StartsWith(nomCherche.ToUpper()));

            if (albumTrouve == null) Console.WriteLine("Il n'y a aucun album qui possède ce nom !");
            else
            {
                int choixMenuAlbum = -1;

                do
                {
                    Console.WriteLine($"=== Modifier {albumTrouve.Name} ===\n");

                    Console.WriteLine("1. Ajouter une chanson");
                    Console.WriteLine("2. Retirer une chanson");
                    Console.WriteLine("3. Modifier une chanson");
                    Console.WriteLine("4. Modifier les détails de l'album");
                    Console.WriteLine("0. Retour au menu principal");

                    Console.Write("Votre choix : ");
                    choixMenuAlbum = int.Parse(Console.ReadLine());

                    switch (choixMenuAlbum)
                    {
                        case 0:
                            break;
                        case 1:
                            AjouterChanson(albumTrouve);
                            break;
                        case 2:
                            RetirerChanson(albumTrouve);
                            break;
                        case 3:
                            ModifierChanson(albumTrouve);
                            break;
                        case 4:
                            ModifierDetailsAlbum(albumTrouve);
                            break;
                        default:
                            break;
                    }

                    Console.WriteLine("");

                } while (choixMenuAlbum != 0);

                Console.WriteLine($"{albumTrouve.Name} supprimé de la liste des albums !");
            }
        }

        private void AjouterChanson(Album album)
        {
            Console.Write("Titre : ");
            string titre = Console.ReadLine();
            Console.Write("Chanteur : ");
            string chanteur = Console.ReadLine();

            Song newSong = new Song()
            {
                Numero = album.Songs.Count + 1,
                Name = titre,
                Singer = chanteur
            };

            album.Songs.Add(newSong);

            Console.WriteLine($"{newSong.Name} ajoutée à {album.Name} !");
        }

        private void RetirerChanson(Album album)
        {
            Console.Write("Titre de la chanson : ");
            string titreCherche = Console.ReadLine();

            Song chansonTrouvee = album.Songs.FirstOrDefault(song => song.Name.ToUpper().StartsWith(titreCherche.ToUpper()));
            if (chansonTrouvee == null) Console.WriteLine("Cet album ne contient pas cette chanson !");
            else
            {
                album.Songs.Remove(chansonTrouvee);

                int nouvelIndex = 1;

                album.Songs.OrderBy(song => song.Numero).ToList().ForEach(song =>
                {
                    song.Numero = nouvelIndex++;
                });

                Console.WriteLine($"{chansonTrouvee.Name} supprimée de {album.Name} !");
            }
        }

        private void ModifierChanson(Album album)
        {
            Console.Write("Titre de la chanson : ");
            string titreCherche = Console.ReadLine();

            Song chansonTrouvee = album.Songs.FirstOrDefault(song => song.Name.ToUpper().StartsWith(titreCherche.ToUpper()));
            if (chansonTrouvee == null) Console.WriteLine("Cet album ne contient pas cette chanson !");
            else
            {
                Console.Write("Nouveau Titre : ");
                string titre = Console.ReadLine();
                Console.Write("Nouveau Chanteur : ");
                string chanteur = Console.ReadLine();

                chansonTrouvee.Name = titre;
                chansonTrouvee.Singer = chanteur;

                Console.WriteLine("Chanson modifiée avec succès !");
            }
        }

        private void ModifierDetailsAlbum(Album album)
        {
            Console.Write("Nouveau nom : ");
            string nom = Console.ReadLine();
            Console.Write("Nouvelle description : ");
            string description = Console.ReadLine();

            album.Name = nom;
            album.Description = description;

            Console.WriteLine("Album modifié avec succès !");
        }

        private void ImporterFichier()
        {
            int choixImportation = -1;

            do
            {
                Console.WriteLine("=== Importation ===\n");

                Console.WriteLine("1. JSON");
                Console.WriteLine("2. XML");
                Console.WriteLine("0. Annuler l'importation");

                Console.Write("Votre choix : ");
                choixImportation = int.Parse(Console.ReadLine());

                switch (choixImportation)
                {
                    case 0:
                        break;
                    case 1:
                        ImporterJSON();
                        break;
                    case 2:
                        ImporterXML();
                        break;
                    default:
                        break;
                }

                Console.WriteLine("");

            } while (choixImportation != 0);
        }

        private void ImporterJSON()
        {
            Console.Write("Nom du .json : ");
            string filename = Console.ReadLine();

            string fullPath = Path.Combine(jsonPath, filename +".json");

            if (File.Exists(fullPath))
            {
                Console.WriteLine("Fichier trouvé ! Importation...");

                string json = File.ReadAllText(fullPath);
                List<Album> newList = JsonConvert.DeserializeObject<List<Album>>(json);

                _albums = newList;

                Console.WriteLine("Liste d'albums importée avec succès !");
            }
            else Console.WriteLine("Fichier introuvable ! Importation annulée...");
        }

        private void ImporterXML()
        {
            Console.Write("Nom du .xml : ");
            string filename = Console.ReadLine();

            string fullPath = Path.Combine(jsonPath, filename + ".xml");

            if (File.Exists(fullPath))
            {
                Console.WriteLine("Fichier trouvé ! Importation...");

                XmlSerializer xmlSerializer = new XmlSerializer(_albums.GetType());
                TextReader reader = new StreamReader(fullPath);
                _albums = (List<Album>) xmlSerializer.Deserialize(reader);
                reader.Close();

                if (_albums != null) Console.WriteLine("Liste d'albums importée avec succès !");
            }
            else Console.WriteLine("Fichier introuvable ! Importation annulée...");
        }

        private void ExporterFichier()
        {
            int choixExportation = -1;

            do
            {
                Console.WriteLine("=== Exportation ===\n");

                Console.WriteLine("1. JSON");
                Console.WriteLine("2. XML");
                Console.WriteLine("0. Annuler l'importation");

                Console.Write("Votre choix : ");
                choixExportation = int.Parse(Console.ReadLine());

                switch (choixExportation)
                {
                    case 0:
                        break;
                    case 1:
                        ExporterJSON();
                        break;
                    case 2:
                        ExporterXML();
                        break;
                    default:
                        break;
                }

                Console.WriteLine("");

            } while (choixExportation != 0);
        }

        private void ExporterJSON()
        {
            Console.Write("Nom du .json : ");
            string filename = Console.ReadLine();

            string fullPath = Path.Combine(jsonPath, filename + ".json");

            Console.WriteLine("Exportation...");

            string json = JsonConvert.SerializeObject(_albums);

            File.WriteAllText(fullPath, json);

            _albums = new List<Album>();

            Console.WriteLine("Liste d'albums exportée avec succès ! Nouvelle liste d'album créée...");
        }

        private void ExporterXML()
        {
            Console.Write("Nom du .xml : ");
            string filename = Console.ReadLine();

            string fullPath = Path.Combine(jsonPath, filename + ".xml");

            Console.WriteLine("Exportation...");

            XmlSerializer serializer = new XmlSerializer(_albums.GetType());

            TextWriter writer = new StreamWriter(fullPath);
            serializer.Serialize(writer, _albums);
            writer.Close();

            _albums = new List<Album>();

            Console.WriteLine("Liste d'albums exportée avec succès ! Nouvelle liste d'album créée...");

        }
    }
}
