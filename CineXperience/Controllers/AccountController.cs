using CineXperience.DataBase;
using CineXperience.Helpers;
using CineXperience.Models;
using CineXperience.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CineXperience.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly CineXperienceContext _context;
        public AccountController(UserManager<Usuario> userManager, SignInManager<Usuario>signInManager, CineXperienceContext context) 
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
           this._context = context;
        }
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar([Bind("Nombre, Apellido, Dni, Email, Password, ConfirmPassword")]Register model)
        {
            if (ModelState.IsValid)
            {
                Cliente cliente = new Cliente()
                {
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    Dni = model.Dni,
                    Email = model.Email,
                    UserName = model.Email,

                };
                var resultado = await _userManager.CreateAsync(cliente, model.Password);


                if (resultado.Succeeded)
                {
                    var resultadoRol = await _userManager.AddToRoleAsync(cliente, Displays.RolCliente);
                    if (resultadoRol.Succeeded)
                    {
                        await _signInManager.SignInAsync(cliente, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(String.Empty, $"No se pudo agregar el rol de {Displays.RolCliente}");
                    }
                }
                foreach(var error in resultado.Errors)
                {
                    ModelState.AddModelError(String.Empty, error.Description);
                }
            }
            return View();
        }

        public IActionResult Login(string returnUrl)
        {
            TempData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            string returnUrl = TempData["ReturnUrl"] as string;

            if (ModelState.IsValid)
            {             
                var resultado = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.Recuerdame, false);

                if (resultado.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("Password", "fallo de contraseña");
            }
            return View(model);
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccesoDenegado(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        public IActionResult TestCurrentUser()
        {
            if (_signInManager.IsSignedIn(User))
            {
                string nombreUsuario = User.Identity.Name;
                Usuario usuario = _context.Usuarios.FirstOrDefault(u => u.NormalizedUserName == nombreUsuario.ToUpper());
                int usuarioId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
            return View();
        }
    }
}
