using System;
using Microsoft.AspNetCore.Mvc;

namespace ZO1.Tutorials.WebUI.Controllers
{
    public class BlogController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Article()
        {
            const string @string = "Article method get called";
            return Ok(@string);
        }

        /// <summary>
        /// This method return status code
        /// <para>Ok() return code 200</para>
        /// <para>Created() return code 201</para>
        /// <para>NoContent() return code 204 - No Content</para>
        /// <para>BadRequest() return code 400 - Bad Request</para>
        /// <para>Unauthorized() return code 401 - Unauthorized</para>
        /// <para>NotFound() return code 404 - Not Found</para>
        /// <para>
        /// UnsupportedMediaTypeResult() return code 415
        /// - Unsupported MediaType
        /// </para>
        /// </summary>
        /// <returns></returns>
        public IActionResult StatusCodeResult()
        {
            #region 200

            //return Ok();

            #endregion

            #region 201 (2 params)

            //return Created("https://www.youtube.com/", new{item = "item"});

            #endregion

            #region 204

            //return NoContent();

            #endregion

            #region 400 - Bad Request

            //return BadRequest();

            #endregion

            #region 401 - UnAuthorize

            //return Unauthorized();

            #endregion

            #region 404 - Not Found

            //return NotFound();

            #endregion

            #region 415 - UnsupportMediaType

            return new UnsupportedMediaTypeResult();

            #endregion
        }

        public IActionResult ActionResult()
        {
            var pdfBytes = System.IO.File.ReadAllBytes("wwwroot/assets/files/pdfs/Test.pdf");

            return new FileContentResult(pdfBytes, "application/pdf");
        }
    }   
}