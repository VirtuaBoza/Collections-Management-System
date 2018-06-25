using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CoraCorpCM.Web.ViewModels.CollectionViewModels;
using Microsoft.AspNetCore.Identity;
using CoraCorpCM.Common.Membership;
using CoraCorpCM.Web.Services.Collection;
using CoraCorpCM.Application.Pieces.Queries;
using System.Threading.Tasks;
using CoraCorpCM.Application.Pieces.Commands.CreatePiece;
using CoraCorpCM.Web.Mappers;

namespace CoraCorpCM.Web.Controllers
{
    [Authorize]
    public class PieceController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IGetPieceListQuery getPieceListQuery;
        private readonly ICreatePieceCommand createPieceCommand;
        private readonly ICreatePieceViewModelFactory createPieceViewModelFactory;
        private readonly ICreatePieceMapper mapper;

        public PieceController(
            UserManager<ApplicationUser> userManager,
            ICreatePieceViewModelFactory createPieceViewModelFactory,
            IGetPieceListQuery getPieceListQuery,
            ICreatePieceCommand createPieceCommand,
            ICreatePieceMapper mapper)
        {
            this.userManager = userManager;
            this.createPieceViewModelFactory = createPieceViewModelFactory;
            this.getPieceListQuery = getPieceListQuery;
            this.createPieceCommand = createPieceCommand;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);
            var pieces = getPieceListQuery.Execute(user.MuseumId);

            return View(pieces);
        }

        [Authorize(Roles = Role.Contributor)]
        public async Task<IActionResult> Create()
        {
            var user = await userManager.GetUserAsync(User);
            var viewModel = createPieceViewModelFactory.Create(user.MuseumId);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Role.Contributor)]
        public async Task<IActionResult> Create(CreatePieceViewModel viewModel)
        {
            var user = await userManager.GetUserAsync(User);

            if (ModelState.IsValid)
            {
                createPieceCommand.Execute(mapper.Map(viewModel, user.Id, user.MuseumId));

                return RedirectToAction(nameof(Index));
            }

            var newViewModel = createPieceViewModelFactory.Create(user.MuseumId, viewModel);
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
