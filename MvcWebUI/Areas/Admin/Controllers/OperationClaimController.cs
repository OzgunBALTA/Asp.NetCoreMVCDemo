using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OperationClaimController : Controller
    {
        IOperationClaimService _operationClaimManager;

        public OperationClaimController(IOperationClaimService operationClaimManager)
        {
            _operationClaimManager = operationClaimManager;
        }

        public IActionResult Index()
        {
            var result = _operationClaimManager.GetAll();
            return View(result.Data);
        }
    }
}
