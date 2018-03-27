using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CoraCorpCM.Web.ViewModels.CollectionViewModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using CoraCorpCM.App.Membership;
using CoraCorpCM.Web.Services.Collection;
using CoraCorpCM.App.Pieces.Queries;

namespace CoraCorpCM.Web.Controllers
{
    [Authorize]
    public class CollectionController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICreatePieceViewModelFactory createPieceViewModelFactory;
        private readonly IGetPieceListQuery getPieceListQuery;
        private readonly IGetPieceQuery getPieceQuery;

        public CollectionController(
            UserManager<ApplicationUser> userManager,
            ICreatePieceViewModelFactory createPieceViewModelFactory,
            IGetPieceListQuery getPieceListQuery,
            IGetPieceQuery getPieceQuery)
        {
            this.userManager = userManager;
            this.createPieceViewModelFactory = createPieceViewModelFactory;
            this.getPieceListQuery = getPieceListQuery;
            this.getPieceQuery = getPieceQuery;
        }

        public IActionResult Index()
        {
            // TODO replace code below with factory creation of some new IndexPieceViewModel
            var pieces = getPieceListQuery.Execute(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(pieces);
        }

        [Authorize(Roles = Role.Contributor)]
        public IActionResult Create()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var viewModel = createPieceViewModelFactory.Create(userId);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Role.Contributor)]
        public IActionResult Create(CreatePieceViewModel viewModel)
        {
            // TODO Validate piece

            if (ModelState.IsValid)
            {
                // TODO Add the piece and associated info to the repository/database

                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        [Authorize(Roles = Role.Contributor)]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // TODO Create EditPieceViewModel and return that via View(viewModel);
            return null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Role.Contributor)]
        public IActionResult Edit(int id/* TODO Replace this second param with viewModel, [Bind("Id,RecordNumber,AccessionNumber,Title,CreationDate,Height,Width,Depth,EstimatedValue,Subject,CopyrightYear,CopyrightOwner,IsFramed,Created,LastModified")] Piece piece*/)
        {
            //if (id != piece.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        museumRepository.Update(piece);
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!museumRepository.EntityExists<Piece>(piece.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(piece);
            return null;
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Role.Contributor)]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO Delete piece
            return RedirectToAction(nameof(Index));
        }
    }
}
