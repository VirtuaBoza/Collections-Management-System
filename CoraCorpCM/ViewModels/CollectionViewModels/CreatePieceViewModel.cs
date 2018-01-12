using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoraCorpCM.ViewModels.CollectionViewModels
{
    public class CreatePieceViewModel
    {
        // Piece Info
        public string Title { get; set; }

        // Artist Info
        public string ArtistKnownAs { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }

        // Acquisition Info
    }
}
