using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ButterfliesHunter.Models
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Butterflies.Any())
            {
                context.AddRange(
                    new Butterfly { Name = "Flame Falconrock", Range = "Europe and Asia", Ranking = 14, AuthorId = 1, IsProtected = false, ImgURL = "/img/img01.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. " }

                // , "Moonbeam Garlicbees", "Mercury Littlestripe", "Frostbite Flickerrose", "Flare Elmbutter", "Moonbean Cozyfall", "Jeremy Daisybug", "Ginko Pollenflash", "Midnight Birdthorn", "Tangy Oakmuddle", "Happy Lemoncliff", "Aphid Mangosplash", "Tori Cedarweather", "Flax Hazelflame", "Frostbite Treemuddle", "Aed Twinklefoot", "Bryla Bumbleplume", "Fantasia Hazellight", "Leaf Speedyvalley", "Eupherbia Tuliprose", "Venus Mapletwinkle", "Parsley Fernflash", "Tangy Lovelymint", "Tinkerbell Iceberry"

                );
            }
            context.SaveChanges();
        }
    }
}
