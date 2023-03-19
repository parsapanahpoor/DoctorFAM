using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using Microsoft.AspNetCore.Mvc;
using ZNetCS.AspNetCore.ResumingFileResults.Extensions;

namespace DoctorFAM.Web.Controllers
{
    public class BookController : SiteBaseController
    {
        #region Ctor

        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        #endregion

        #region Index 

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            #region Fill Model

            var model = await _bookService.LastestBookForShowOnLandingPage();

            #endregion

            return View(model);
        }

        #endregion

        #region Download Attachment File

        public IActionResult DownloadAttachmentFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return NotFound();
            }

            var webRoot = PathTools.BookAttachmentFilesServerPath;

            if (!System.IO.File.Exists(Path.Combine(webRoot, fileName)))
            {
                return NotFound();
            }

            var stream = System.IO.File.OpenRead(Path.Combine(webRoot, fileName));

            var download = this.ResumingFile(stream, "application/octet-stream", fileName);

            return download;
        }

        #endregion

    }
}
