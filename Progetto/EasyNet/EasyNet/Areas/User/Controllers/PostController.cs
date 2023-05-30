using EasyNet.DataAccess.Repository.IRepository;
using EasyNet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EasyNet.Controllers
{
    public class PostController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PostController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
           
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Post.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Post creato con successo";
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var postFromDbFirst = _unitOfWork.Post.GetFirstOrDefault(u => u.IdPost == id);
            if (postFromDbFirst == null)
            {
                return NotFound();
            }
            return View(postFromDbFirst);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Post obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Post.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Post modificato con successo";
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var postFromDbFirst = _unitOfWork.Post.GetFirstOrDefault(u => u.IdPost == id);
            if (postFromDbFirst == null)
            {
                return NotFound();
            }
            return View(postFromDbFirst);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id, [Bind("IdPost")] Post post)
        {
            if (id != post.IdPost)
            {
                return NotFound();
            }
            var postSpettacoloFromDbFirst = _unitOfWork.Post.GetFirstOrDefault(u => u.IdPost == id);
            if (postSpettacoloFromDbFirst == null)
            {
                return NotFound();
            }
            _unitOfWork.Post.Remove(postSpettacoloFromDbFirst);
            _unitOfWork.Save();
            TempData["Success"] = "Post eliminato con successo";
            return RedirectToAction(nameof(Index));
        }
    }
}