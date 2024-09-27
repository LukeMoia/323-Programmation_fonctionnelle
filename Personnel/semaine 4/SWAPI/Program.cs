using SharpTrooper.Core;
using SharpTrooper.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SWAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            APISWAPI();
            Console.ReadLine();
        }

        static public async void APISWAPI()
        {
            /*var client = new HttpClient();

            // Create the HttpContent for the form to be posted.
            var requestContent = new FormUrlEncodedContent(new[] {
            new KeyValuePair<string, string>("text", "This is a block of text"),
            });

            // Get the response.
            HttpResponseMessage response = await client.GetAsync("https://swapi.dev/api/people/1/");

            // Get the response content.
            HttpContent responseContent = response.Content;

            // Get the stream of the content.
            using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
            {
                // Write the output.
                Console.WriteLine(await reader.ReadToEndAsync());
            }*/

            var core = new SharpTrooperCore();

            var AllFilm = core.GetAllFilms().results;
            AllFilm.ForEach(x => { Console.Write(x.title + " "); Console.WriteLine(x.episode_id); });
            Film LongestNameFilm = AllFilm.Aggregate(core.GetFilm("1"), (bouc, actual) => bouc.title.Length < actual.title.Length ? actual : bouc);
            Console.WriteLine($"Question 1: {LongestNameFilm.episode_id}");

            var AllPeople = core.GetAllPeople().results;
            var MostPeople = AllPeople.Aggregate((actu, listpeople) => actu.films.Count < listpeople.films.Count ? listpeople : actu);
            Console.WriteLine($"Question 2: {MostPeople.name}");

            var AllPlanete = core.GetAllPlanets().results;
            var MostPeupledPlanete = AllPlanete.Aggregate((peupled, actulist) => { int a = 0; int b = 0; int.TryParse(peupled.population, out a); int.TryParse(actulist.population, out b); return a > b ? peupled : actulist; });
            Console.WriteLine($"Question 3: {MostPeupledPlanete.name}");

            var AllStarship = core.GetAllStarships().results;
            Starship StarDestroyer = new Starship();
            Starship XWing = new Starship();
            AllStarship.ForEach(x => { if (x.name == "Star Destroyer") { StarDestroyer = x; } else if (x.name == "X-wing") { XWing = x; } });
            var NumberStarship = Convert.ToInt32(StarDestroyer.cost_in_credits) / Convert.ToInt32(XWing.cost_in_credits);
            Console.WriteLine($"Question 4: {NumberStarship}");

            var BoolConduct = false;
            var ObiWan = core.GetPeople("10");
            ObiWan.starships.ForEach(x => { string[] str = x.Split('/'); var vehicule = core.GetStarship(str[str.Length - 2]); if (vehicule.name == "Millennium Falcon") { BoolConduct = true; } });
            Console.WriteLine($"Question 5: {BoolConduct}");

            var FasterShip = AllStarship.Aggregate((p, next) => { double a = 0; double b = 0; double c = 0; double d = 0; double.TryParse(p.max_atmosphering_speed, out a); double.TryParse(p.hyperdrive_rating, out b); double.TryParse(next.max_atmosphering_speed, out c); double.TryParse(next.hyperdrive_rating, out d); return a * b > c * d ? p : next; });
            Console.WriteLine($"Question 6: {FasterShip.name}");
        }
    }
}
