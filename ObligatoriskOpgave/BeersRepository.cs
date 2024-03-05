using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatoriskOpgave
{
    public class BeersRepository
    {
        private List<Beer>? beers = new();
        private int nextId = 1;

        public BeersRepository() 
        {
            beers.Add(new Beer() {id = nextId++, name = "Carlsberg Classic", alcoholProcent = 4 });
            beers.Add(new Beer() {id = nextId++, name = "Tuborg Classic", alcoholProcent = 5 });
            beers.Add(new Beer() {id = nextId++, name = "Fynsk Forår", alcoholProcent = 3 });
            beers.Add(new Beer() {id = nextId++, name = "Hoegarden", alcoholProcent = 4 });
            beers.Add(new Beer() {id = nextId++, name = "Svaneke bryghus", alcoholProcent = 5 });  
        }
        public IEnumerable<Beer> Get(int? alcoholProcent = null, string? orderBy = null)
        {
            IEnumerable<Beer> result = new List<Beer>(beers);

            if(alcoholProcent != null)
            {
                result = result.Where(a => a.alcoholProcent == alcoholProcent);
            }
            if(orderBy != null) 
            {
                orderBy = orderBy.ToLower();

                switch (orderBy)
                {
                    case "name":
                    case "name_asc": 
                        result = result.OrderBy(n => n.name); 
                        break;
                    case "name_desc":
                        result = result.OrderByDescending(n => n.name);
                        break;
                    case "alcoholprocent":
                    case "alcoholprocent_asc":
                        result = result.OrderBy(a => a.alcoholProcent);
                        break;
                    case "alcoholprocent_desc":
                        result = result.OrderByDescending(a => a.alcoholProcent);
                        break;
                    default:
                        break;
                }
            }
            return result;
        }

        public Beer? GetById(int id)
        {
            return beers.Find(beer => beer.id == id);   
        }

        public Beer Add(Beer beer)
        {
            beer.Validate(); 
            beer.id = nextId++;
            beers.Add(beer);
            return beer;
        }

        public Beer? Delete(int id)
        {
            Beer beerToDelete = GetById(id);
            if (beerToDelete == null)
            {
                return null;
            }
            beers.Remove(beerToDelete);
            return beerToDelete;
        }

        public Beer? Update(int id, Beer beer)
        {
            beer.Validate();
            Beer? beerToUpdate = GetById(id);   
            if(beerToUpdate == null)
            {
                return null;
            }
            beerToUpdate.name = beer.name;  
            beerToUpdate.alcoholProcent = beer.alcoholProcent;  
            return beerToUpdate;
        }
    }
}
