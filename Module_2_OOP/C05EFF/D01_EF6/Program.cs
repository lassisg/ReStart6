using D01_EF6.Models;

namespace D01_EF6;

internal class Program
{
    static void Main(string[] args)
    {
        // Cria a instância do DBContext (connectionstring name)
        var db = new NorthwindContext();
        
        // Usa a instância
        using (db)
        {
            #region New Region (1)

            var region = new Models.Region();
            region.RegionId = db.Regions.Max(r => r.RegionId) + 1; // <=====
            region.RegionDescription = "Ilhas";

            db.Regions.Add(region);
            int countRegions = db.SaveChanges();

            Console.WriteLine($"Success! You just inserted {countRegions} new region!\n");

            db.Regions
                .ToList()
                .ForEach(r => Console.WriteLine($"{r.RegionId}: {r.RegionDescription}")); // <=====

            // var queryRegions = db.Regions.Select(r => r).OrderBy(r => r.RegionId);
            // foreach (var item in queryRegions)
            // {
            //     Console.WriteLine($"{item.RegionId}: {item.RegionDescription}");
            // }

            #endregion

            #region New Territory (Location) in the new region (n)

            Territory territories = new Territory();
            territories.TerritoryId = "00003";
            territories.TerritoryDescription = "Gaia";
            territories.RegionId = db.Regions.FirstOrDefault(r => r.RegionDescription == "Norte").RegionId; // <=====

            db.Territories.Add(territories);

            int countTerritories = db.SaveChanges();

            Console.WriteLine($"\nSuccess! You just inserted {countTerritories} new territory!\n");


            db.Territories
                .ToList()
                .ForEach(t => Console.WriteLine($"{t.TerritoryId}: {t.RegionId} - {t.TerritoryDescription}")); // <=====

            // var queryTerritories = db.Territories.Select(t => t).OrderByDescending(t=>t.TerritoryId);
            // foreach (var item in queryTerritories)
            // {
            //     Console.WriteLine($"{item.TerritoryId}: {item.RegionId} - {item.TerritoryDescription}");
            // }

            #endregion

            Console.ReadLine();
        }
    }
}
