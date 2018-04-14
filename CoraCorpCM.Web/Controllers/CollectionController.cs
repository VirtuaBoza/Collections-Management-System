using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CoraCorpCM.Web.ViewModels.CollectionViewModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using CoraCorpCM.App.Membership;
using CoraCorpCM.Web.Services.Collection;
using CoraCorpCM.App.Pieces.Queries;
using CoraCorpCM.App.Pieces.Commands.CreatePiece;
using System.Threading.Tasks;

namespace CoraCorpCM.Web.Controllers
{
    [Authorize]
    public class CollectionController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICreatePieceViewModelFactory createPieceViewModelFactory;
        private readonly IGetPieceListQuery getPieceListQuery;
        private readonly IGetPieceQuery getPieceQuery;
        private readonly ICreatePieceCommand createPieceCommand;
        private readonly ICreatePieceViewModelValidator createPieceViewModelValidator;

        public CollectionController(
            UserManager<ApplicationUser> userManager,
            ICreatePieceViewModelFactory createPieceViewModelFactory,
            IGetPieceListQuery getPieceListQuery,
            IGetPieceQuery getPieceQuery,
            ICreatePieceCommand createPieceCommand,
            ICreatePieceViewModelValidator createPieceViewModelValidator)
        {
            this.userManager = userManager;
            this.createPieceViewModelFactory = createPieceViewModelFactory;
            this.getPieceListQuery = getPieceListQuery;
            this.getPieceQuery = getPieceQuery;
            this.createPieceCommand = createPieceCommand;
            this.createPieceViewModelValidator = createPieceViewModelValidator;
        }

        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);
            var pieces = getPieceListQuery.Execute(user.MuseumId);

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
        public async Task<IActionResult> Create(CreatePieceViewModel viewModel)
        {
            createPieceViewModelValidator.Validate(viewModel, ModelState);

            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(User);
                viewModel.Piece.MuseumId = user.MuseumId;
                createPieceCommand.Execute(viewModel.Piece);

                return RedirectToAction(nameof(Index));
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var newViewModel = createPieceViewModelFactory.Create(userId);
            newViewModel.Piece = viewModel.Piece;
            return View(newViewModel);
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
