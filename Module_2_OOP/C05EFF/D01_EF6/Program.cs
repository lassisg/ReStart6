using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D01_EF6
{

    internal class Program
    {

        static void Main(string[] args)
        {

            // Cria a instância do DBContext (connectionstring name)
            var db = new NorthwindEntities();

            // Usa a instância
            using (db)
            {

                #region New Region (1)

                Region region = new Region();
                region.RegionID = db.Region.Max(r => r.RegionID) + 1;                                               // <=====
                region.RegionDescription = "Ilhas";

                db.Region.Add(region);
                int countRegions = db.SaveChanges();

                Console.WriteLine($"Success! You just inserted {countRegions} new region!\n");

                
                db.Region
                    .ToList()
                    .ForEach(r => Console.WriteLine($"{r.RegionID}: {r.RegionDescription}"));                        // <=====

                //var queryRegions = db.Region.Select(r => r).OrderBy(r => r.RegionID);
                //foreach (var item in queryRegions)
                //{
                //    Console.WriteLine($"{item.RegionID}: {item.RegionDescription}");
                //}

                #endregion

                #region New Territory (Location) in the new region (n)

                Territories territories = new Territories();
                territories.TerritoryID = "00003";
                territories.TerritoryDescription = "Gaia";
                territories.RegionID = db.Region.FirstOrDefault(r=>r.RegionDescription == "Norte").RegionID;        // <=====

                db.Territories.Add(territories);

                int countTerritories = db.SaveChanges();

                Console.WriteLine($"\nSuccess! You just inserted {countTerritories} new territory!\n");


                db.Territories
                    .ToList()
                    .ForEach(t => Console.WriteLine($"{t.TerritoryID}: {t.RegionID} - {t.TerritoryDescription}"));  // <=====

                //var queryTerritories = db.Territories.Select(t => t).OrderByDescending(t=>t.TerritoryID);
                //foreach (var item in queryTerritories)
                //{
                //    Console.WriteLine($"{item.TerritoryID}: {item.RegionID} - {item.TerritoryDescription}");
                //}

                #endregion

                Console.ReadLine();

            }
        }

    }

}
