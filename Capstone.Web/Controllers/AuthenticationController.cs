using Capstone.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using Capstone.Core.Entities;

namespace Capstone.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationRepository _authRepository;

        public AuthenticationController(IAuthenticationRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpGet]
        [Route("/[controller]")]
        public IActionResult Index()
        {
            var loginResults = _authRepository.GetAll();
            return View(loginResults.Data);
        }

        [HttpGet]
        [Route("/[controller]/{id}")]
        public IActionResult Get(Guid id)
        {
            var agency = _authRepository.Get(id);

            if (agency.Success)
            {
                return View(agency.Data);
            }
            else
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }
        }

        [HttpGet]
        [Route("[controller]/update")]
        public IActionResult Update(Guid id)
        {
            var loginResult = _authRepository.Get(id);

            return View(loginResult.Data);
        }

        [HttpPost]
        [Route("[controller]/update/{id}")]
        public IActionResult Update(LoginItem model)
        {
            var agency = _authRepository.Update(model);

            if (agency.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }
        }

        [HttpGet]
        [Route("[controller]/add")]
        public IActionResult Add()
        {
            var loginItem = new LoginItem();
            return View(loginItem);
        }

        [HttpPost]
        [Route("[controller]/add")]
        public IActionResult Add(LoginItem model)
        {
            var agency = _authRepository.Create(model);

            if (agency.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }
        }

        [HttpGet]
        [Route("[controller]/remove/{id}")]
        public IActionResult Delete(Guid id)
        {
            var agency = _authRepository.Get(id);
            return View(agency.Data);
        }

        [HttpPost]
        [Route("[controller]/remove/{id}")]
        public IActionResult Delete(LoginItem model)
        {
            var agency = _authRepository.Delete(model.Id);

            if (agency.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }
        }

        [Route("[controller]/NotFound")]
        public ViewResult NotFound()
        {
            Response.StatusCode = 404;  //you may want to set this to 200
            return View("NotFound");
        }
    }
}
