using CarDealership.UI.Data.Repositories;
using CarDealership.UI.Models;
using CarDealership.UI.Models.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        readonly IVehicleRepository _vehicleRepository;
        readonly IMakeRepository _makeRepository;
        readonly IModelRepository _modelRepository;
        readonly IColorRepository _colorRepository;
        readonly IStyleRepository _styleRepository;
        readonly ITransmissionRepository _transmissionRepository;

        public AdminController()
        {
            _vehicleRepository = VehicleManager.Create();
            _makeRepository = MakeManager.Create();
            _modelRepository = ModelManager.Create();
            _colorRepository = ColorManager.Create();
            _styleRepository = StyleManager.Create();
            _transmissionRepository = TransmissionManager.Create();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Makes()
        {
            MakeViewModel makeVM = new MakeViewModel
            {
                MakeList = _makeRepository.GetAllMakes()
            };
            return View(makeVM);
        }

        [HttpPost]
        public ActionResult Makes(MakeViewModel makeViewModel)
        {
            if (string.IsNullOrWhiteSpace(makeViewModel.Make.Name))
            {
                ModelState.AddModelError("Make.Name", "Please enter make name.");
            }

            makeViewModel.Make.UserId = User.Identity.GetUserId();

            using (var context = new ApplicationDbContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == makeViewModel.Make.UserId);
                makeViewModel.Make.UserName = user.Email;
            }

            makeViewModel.Make.DateAdded = DateTime.Today;
            makeViewModel.MakeList = _makeRepository.GetAllMakes();

            if (ModelState.IsValid)
            {
                _makeRepository.AddMake(makeViewModel.Make);
            }
            return View(makeViewModel);
        }

        public ActionResult Models()
        {
            ModelViewModel modelVM = new ModelViewModel
            {
                ModelList = _modelRepository.GetAllModels()
            };
            modelVM.SetMakeItems(_makeRepository.GetAllMakes());

            return View(modelVM);
        }

        [HttpPost]
        public ActionResult Models(ModelViewModel modelViewModel)
        {
            if (string.IsNullOrWhiteSpace(modelViewModel.Model.Name))
            {
                ModelState.AddModelError("Model.Name", "Please enter model name.");
            }

            modelViewModel.Model.DateAdded = DateTime.Today;
            modelViewModel.Model.UserId = User.Identity.GetUserId();
            modelViewModel.SetMakeItems(_makeRepository.GetAllMakes());
            modelViewModel.Model.MakeName = modelViewModel.MakeItems.Find(i => i.Value.Equals(modelViewModel.Model.MakeId.ToString())).Text;

            using (var context = new ApplicationDbContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == modelViewModel.Model.UserId);
                modelViewModel.Model.UserName = user.Email;
            }

            if (ModelState.IsValid)
            {
                _modelRepository.AddModel(modelViewModel.Model);
                return RedirectToAction("Models", "Admin");
            }
        
            modelViewModel.ModelList = _modelRepository.GetAllModels();

            return View(modelViewModel);
        }

        public ActionResult Users()
        {
            ViewBag.Title = "Admin";
            ViewBag.Page = "Admin";

            var context = new ApplicationDbContext();

            var usersWithRoles = (from user in context.Users
                                  select new
                                  {
                                      UserId = user.Id,
                                      Username = user.UserName,
                                      Email = user.Email,
                                      RoleNames = (from userRole in user.Roles
                                                   join role in context.Roles on userRole.RoleId
                                                   equals role.Id
                                                   select role.Name).ToList()
                                  }).ToList().Select(p => new UserViewModel()

                                  {
                                      UserId = p.UserId,
                                      UserName = p.Username,
                                      Email = p.Email,
                                      Role = string.Join(",", p.RoleNames)
                                  });

            return View(usersWithRoles.ToList());
        }

        public ActionResult AddUser()
        {
            var context = new ApplicationDbContext();
            UserViewModel userViewModel = new UserViewModel();
            userViewModel.SetRoleItems(context.Roles);
            return View(userViewModel);
        }

        [HttpPost]
        public ActionResult AddUser(UserViewModel userViewModel)
        {
            string Email = "", UserName = "", Password = "", ConfirmPassword = "";
            ModelState.Clear();
            if (string.IsNullOrWhiteSpace(userViewModel.Email))
            {
                ModelState.AddModelError("Email", "Please enter email.");
            }
            else
            {
                Email = userViewModel.Email.Trim();
            }

            if (string.IsNullOrWhiteSpace(userViewModel.UserName))
            {
                ModelState.AddModelError("UserName", "Please enter username.");
            }
            else
            {
                UserName = userViewModel.UserName.Trim();
            }

            if (string.IsNullOrWhiteSpace(userViewModel.Role))
            {
                ModelState.AddModelError("Role", "Please select roles.");
            }

            if (string.IsNullOrWhiteSpace(userViewModel.Password))
            {
                ModelState.AddModelError("Password", "Please enter password.");
            }
            else
            {
                Password = userViewModel.Password.Trim();
            }

            if (string.IsNullOrWhiteSpace(userViewModel.ConfirmPassword))
            {
                ModelState.AddModelError("ConfirmPassword", "Please enter confirm password.");
            }
            else
            {
                ConfirmPassword = userViewModel.ConfirmPassword.Trim();
            }

            if (!Password.Equals(ConfirmPassword))
            {
                ModelState.AddModelError("ConfirmPassword", "Password doesn't match.");
            }

            var context = new ApplicationDbContext();
            userViewModel.SetRoleItems(context.Roles);

            if (!ModelState.IsValid)
            {
                return View(userViewModel);
            }

            Email = Email.ToLower();
            // Create user
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser
            {
                UserName = UserName,
                Email = Email,
            };

            var result = manager.Create(user, userViewModel.Password);

            if (result.Succeeded == true)
            {
                if (!string.IsNullOrEmpty(userViewModel.Role))
                {
                    // Put user in role
                    manager.AddToRole(user.Id, userViewModel.RoleItems.Find(i => i.Value.Equals(userViewModel.Role)).Text);

                    if (userViewModel.Role.Equals("Disabled"))
                    {
                        manager.SetLockoutEnabledAsync(user.Id, true);
                        manager.SetLockoutEndDateAsync(user.Id, DateTime.Today.AddYears(100));
                    }
                    else
                    {
                        manager.SetLockoutEnabledAsync(user.Id, false);
                    }
                }
                return RedirectToAction("Users", "Admin");
            }
            else
            {
                foreach (string err in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, err);
                }
                return View(userViewModel);
            }
        }

        public ActionResult EditUser(string id)
        {
            ViewBag.Title = "Admin";
            ViewBag.Page = "Admin";

            var context = new ApplicationDbContext();

            var foundUser = (from user in context.Users
                             select new
                             {
                                 UserId = user.Id,
                                 Username = user.UserName,
                                 Email = user.Email,
                                 RoleNames = (from userRole in user.Roles
                                              join role in context.Roles on userRole.RoleId
                                              equals role.Id
                                              select role.Name).ToList()
                             }).ToList().Select(p => new UserViewModel()

                             {
                                 UserId = p.UserId,
                                 UserName = p.Username,
                                 Email = p.Email,
                                 Role = string.Join(",", p.RoleNames)
                             }).Where(i => i.UserId == id).FirstOrDefault();

            foundUser.SetRoleItems(context.Roles);
            if (!string.IsNullOrWhiteSpace(foundUser.Role))
            {
                foundUser.Role = foundUser.RoleItems.Find(i => i.Text.Equals(foundUser.Role)).Value;
            }
            return View(foundUser);
        }

        [HttpPost]
        public ActionResult EditUser(UserViewModel userVM)
        {
            string Email = "", UserName = "", Password = "", ConfirmPassword = "";
            ModelState.Clear();
            if (string.IsNullOrWhiteSpace(userVM.Email))
            {
                ModelState.AddModelError("Email", "Please enter email.");
            }
            else
            {
                Email = userVM.Email.Trim();
            }
            if (string.IsNullOrWhiteSpace(userVM.UserName))
            {
                ModelState.AddModelError("UserName", "Please enter user name.");
            }
            else
            {
                UserName = userVM.UserName.Trim();
            }

            if (string.IsNullOrWhiteSpace(userVM.Role))
            {
                ModelState.AddModelError("Role", "Please select roles.");
            }

            if (!string.IsNullOrWhiteSpace(userVM.Password))
            {
                Password = userVM.Password.Trim();
            }
            if (!string.IsNullOrWhiteSpace(userVM.ConfirmPassword))
            {
                ConfirmPassword = userVM.ConfirmPassword.Trim();
            }

            if (!Password.Equals(ConfirmPassword))
            {
                ModelState.AddModelError("ConfirmPassword", "Password doesn't match.");
            }


            var context = new ApplicationDbContext();
            userVM.SetRoleItems(context.Roles);

            if (!ModelState.IsValid)
            {
                return View(userVM);
            }

            Email = Email.ToLower();

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = manager.FindById(userVM.UserId);

            if (user == null)
            {
                // Don't reveal that the user does not exist
                return View(userVM);
            }

            user.UserName = UserName;
            user.Email = Email;

            var result = manager.Update(user);

            if (result.Succeeded == true)
            {
                if (!string.IsNullOrEmpty(userVM.Role))
                {
                    // Get existing roles for users..
                    var roles = (from userRole in user.Roles
                                 join role in context.Roles on userRole.RoleId
                                 equals role.Id
                                 select role.Name).ToArray();

                    // Remove existing roles      
                    manager.RemoveFromRoles(user.Id, roles);

                    string roleText = userVM.RoleItems.Find(i => i.Value.Equals(userVM.Role)).Text;
                    manager.AddToRole(user.Id, roleText);

                    if (roleText.Equals("Disabled"))
                    {
                        manager.SetLockoutEnabledAsync(user.Id, true);
                        manager.SetLockoutEndDateAsync(user.Id, DateTime.Today.AddYears(100));
                    }
                    else
                    {
                        manager.SetLockoutEnabledAsync(user.Id, false);
                    }
                }
                if (!string.IsNullOrWhiteSpace(Password))
                {
                    var resultPasswordChange = manager.ResetPasswordAsync(user.Id, "", Password);
                }
                return RedirectToAction("Users", "Admin");
            }
            else
            {
                foreach (string err in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, err);
                }
                return View(userVM);
            }
        }

        public ActionResult Vehicles()
        {
            ViewBag.Title = "Admin";
            ViewBag.Page = "Admin";
            return View();
        }

        public ActionResult EditVehicle(string id)
        {
            ViewBag.Title = "Edit Vehicle";
            ViewBag.Page = "EditVehicle";

            AddEditVehicleViewModel addEditVehicleVM = new AddEditVehicleViewModel
            {
                Vehicle = _vehicleRepository.GetVehicleByVin(id)
            };

            addEditVehicleVM.SetMakeItems(_makeRepository.GetAllMakes());
            addEditVehicleVM.SetModelItems(_modelRepository.GetAllModels());
            addEditVehicleVM.SetBodyStyleItems(_styleRepository.GetAllStyles());
            addEditVehicleVM.SetColorItems(_colorRepository.GetAllColors());
            addEditVehicleVM.SetTransmissionItems(_transmissionRepository.GetAllTransmissions());
            addEditVehicleVM.SetTypeItems();

            addEditVehicleVM.MakeId = Convert.ToInt32(addEditVehicleVM.MakeItems.Find(i => i.Text.Equals(addEditVehicleVM.Vehicle.MakeName)).Value);
            addEditVehicleVM.ModelId = Convert.ToInt32(addEditVehicleVM.ModelItems.Find(i => i.Text.Equals(addEditVehicleVM.Vehicle.ModelName)).Value);
            addEditVehicleVM.Vehicle.BodyStyle = addEditVehicleVM.BodyStyleItems.Find(i => i.Text.Equals(addEditVehicleVM.Vehicle.BodyStyle)).Value;
            addEditVehicleVM.Vehicle.InteriorColor = addEditVehicleVM.ColorItems.Find(i => i.Text.Equals(addEditVehicleVM.Vehicle.InteriorColor)).Value;
            addEditVehicleVM.Vehicle.ExteriorColor = addEditVehicleVM.ColorItems.Find(i => i.Text.Equals(addEditVehicleVM.Vehicle.ExteriorColor)).Value;
            addEditVehicleVM.Vehicle.TransmissionText = addEditVehicleVM.TransmissionItems.Find(i => i.Text.Equals(addEditVehicleVM.Vehicle.TransmissionText)).Value;

            if (addEditVehicleVM.Vehicle.IsNew)
            {
                addEditVehicleVM.TypeId = 1;
            }
            else
            {
                addEditVehicleVM.TypeId = 2;
            }
            return View(addEditVehicleVM);
        }

        [HttpPost]
        public ActionResult EditVehicle(AddEditVehicleViewModel editVehicleVM, HttpPostedFileBase file)
        {
            ViewBag.Title = "Edit Vehicle";
            ViewBag.Page = "EditVehicle";

            ValidationForAddEditVehicle(editVehicleVM);

            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var extension = Path.GetExtension(fileName);
                    var imageFileName = "Inventory-" + editVehicleVM.Vehicle.Vin + extension;
                    var path = Path.Combine(Server.MapPath("~/Images"), imageFileName);
                    file.SaveAs(path);

                    //Call save again to update the filename in database
                    editVehicleVM.Vehicle.ImageFile = imageFileName;
                }

                // Add Vehicle
                editVehicleVM.Vehicle.BodyStyle = _styleRepository.GetStyle(Convert.ToInt32(editVehicleVM.Vehicle.BodyStyle)).Description;
                editVehicleVM.Vehicle.MakeName = _makeRepository.GetMake(editVehicleVM.MakeId).Name;
                editVehicleVM.Vehicle.ModelName = _modelRepository.GetModel(editVehicleVM.ModelId).Name;
                editVehicleVM.Vehicle.InteriorColor = _colorRepository.GetColor(Convert.ToInt32(editVehicleVM.Vehicle.InteriorColor)).Name;
                editVehicleVM.Vehicle.ExteriorColor = _colorRepository.GetColor(Convert.ToInt32(editVehicleVM.Vehicle.ExteriorColor)).Name;
                editVehicleVM.Vehicle.TransmissionText = _transmissionRepository.GetTransmission(Convert.ToInt32(editVehicleVM.Vehicle.TransmissionText)).Description;

                editVehicleVM.Vehicle.UserId = User.Identity.GetUserId();

                _vehicleRepository.EditVehicle(editVehicleVM.Vehicle);
                return RedirectToAction("Details", "Inventory", new { id = editVehicleVM.Vehicle.Vin });
            }
            else
            {
                editVehicleVM.SetMakeItems(_makeRepository.GetAllMakes());
                editVehicleVM.SetModelItems(_modelRepository.GetAllModels());
                editVehicleVM.SetBodyStyleItems(_styleRepository.GetAllStyles());
                editVehicleVM.SetColorItems(_colorRepository.GetAllColors());
                editVehicleVM.SetTransmissionItems(_transmissionRepository.GetAllTransmissions());
                editVehicleVM.SetTypeItems();

                return View(editVehicleVM);
            }
        }

        public ActionResult AddVehicle()
        {
            ViewBag.Title = "Add Vehicle";
            ViewBag.Page = "Admin";

            AddEditVehicleViewModel addEditVehicleVM = new AddEditVehicleViewModel();
            addEditVehicleVM.SetMakeItems(_makeRepository.GetAllMakes());
            addEditVehicleVM.SetModelItems(_modelRepository.GetAllModels());
            addEditVehicleVM.SetBodyStyleItems(_styleRepository.GetAllStyles());
            addEditVehicleVM.SetColorItems(_colorRepository.GetAllColors());
            addEditVehicleVM.SetTransmissionItems(_transmissionRepository.GetAllTransmissions());
            addEditVehicleVM.SetTypeItems();

            return View(addEditVehicleVM);
        }

        [HttpPost]
        public ActionResult AddVehicle(AddEditVehicleViewModel addVehicleVM ,HttpPostedFileBase file)
        {
            ViewBag.Title = "Add Vehicle";
            ViewBag.Page = "Admin";

            // Validation ....
            ValidationForAddEditVehicle(addVehicleVM);

            if (file == null || file.ContentLength <= 0)
            {
                ModelState.AddModelError("Vehicle.ImageFile", "Please select picture");
            }
            if (file != null && file.ContentLength > 0)
            {
                var allowedExtensions = new[] { ".png", ".jpg", ".jpeg" };
                var fileName = Path.GetFileName(file.FileName);
                var extension = Path.GetExtension(fileName).ToLower();
                if (!allowedExtensions.Contains(extension)) //check what type of extension  
                {
                    ModelState.AddModelError("Vehicle.ImageFile", "Allowed extensions are .png, .jpg and .jpeg");
                }
            }

            if (ModelState.IsValid)
            {
                //TO DO : Image add part...
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var extension = Path.GetExtension(fileName);
                    var imageFileName = "Inventory-" + addVehicleVM.Vehicle.Vin + extension;
                    var path = Path.Combine(Server.MapPath("~/Images"), imageFileName);
                    file.SaveAs(path);

                    //Call save again to update the filename in database
                    addVehicleVM.Vehicle.ImageFile = imageFileName;
                }
                else
                {
                    addVehicleVM.Vehicle.ImageFile = "icon.png";
                }

                // Add Vehicle
                addVehicleVM.Vehicle.BodyStyle = _styleRepository.GetStyle(Convert.ToInt32(addVehicleVM.Vehicle.BodyStyle)).Description;
                addVehicleVM.Vehicle.MakeName = _makeRepository.GetMake(addVehicleVM.MakeId).Name;
                addVehicleVM.Vehicle.ModelName = _modelRepository.GetModel(addVehicleVM.ModelId).Name;
                addVehicleVM.Vehicle.InteriorColor = _colorRepository.GetColor(Convert.ToInt32(addVehicleVM.Vehicle.InteriorColor)).Name;
                addVehicleVM.Vehicle.ExteriorColor = _colorRepository.GetColor(Convert.ToInt32(addVehicleVM.Vehicle.ExteriorColor)).Name;
                addVehicleVM.Vehicle.TransmissionText = _transmissionRepository.GetTransmission(Convert.ToInt32(addVehicleVM.Vehicle.TransmissionText)).Description;

                addVehicleVM.Vehicle.UserId = User.Identity.GetUserId();
                addVehicleVM.Vehicle.InStock = true;
                bool isAdded = _vehicleRepository.AddVehicle(addVehicleVM.Vehicle);
                if (isAdded)
                {
                    return Redirect("/Admin/EditVehicle/" + addVehicleVM.Vehicle.Vin);
                }
                else
                {
                    ModelState.AddModelError(nameof(addVehicleVM.Vehicle.Vin), "Vin is already present in inventory");

                    addVehicleVM.SetMakeItems(_makeRepository.GetAllMakes());
                    addVehicleVM.SetModelItems(_modelRepository.GetAllModels());
                    addVehicleVM.SetBodyStyleItems(_styleRepository.GetAllStyles());
                    addVehicleVM.SetColorItems(_colorRepository.GetAllColors());
                    addVehicleVM.SetTransmissionItems(_transmissionRepository.GetAllTransmissions());
                    addVehicleVM.SetTypeItems();
                    return View(addVehicleVM);
                }
            }
            else
            {
                addVehicleVM.SetMakeItems(_makeRepository.GetAllMakes());
                addVehicleVM.SetModelItems(_modelRepository.GetAllModels());
                addVehicleVM.SetBodyStyleItems(_styleRepository.GetAllStyles());
                addVehicleVM.SetColorItems(_colorRepository.GetAllColors());
                addVehicleVM.SetTransmissionItems(_transmissionRepository.GetAllTransmissions());
                addVehicleVM.SetTypeItems();

                return View(addVehicleVM);
            }
        }

        private void ValidationForAddEditVehicle(AddEditVehicleViewModel addEditVehicleVM)
        {
            if (addEditVehicleVM.TypeId.HasValue)
            {
                if (addEditVehicleVM.TypeId == 1)
                {
                    addEditVehicleVM.Vehicle.IsNew = true;
                }
                else
                {
                    addEditVehicleVM.Vehicle.IsNew = false;
                }
            }
            else
            {
                ModelState.AddModelError("TypeId", "Please select type.");
            }

            if (string.IsNullOrWhiteSpace(addEditVehicleVM.Vehicle.BodyStyle))
            {
                ModelState.AddModelError("Vehicle.BodyStyle", "Please select body style.");
            }


            if (!addEditVehicleVM.Vehicle.Year.HasValue)
            {
                ModelState.AddModelError("Vehicle.Year", "Please enter valid year");
            }
            else
            {
                if ((addEditVehicleVM.Vehicle.Year < 2000) || (addEditVehicleVM.Vehicle.Year > DateTime.Today.Year + 1))
                {
                    ModelState.AddModelError("Vehicle.Year", $"Please enter year between (2000-{DateTime.Today.Year + 1})");
                }
            }

            if (string.IsNullOrWhiteSpace(addEditVehicleVM.Vehicle.TransmissionText))
            {
                ModelState.AddModelError("Vehicle.TransmissionText", "Please select body style.");
            }

            if (string.IsNullOrWhiteSpace(addEditVehicleVM.Vehicle.InteriorColor))
            {
                ModelState.AddModelError("Vehicle.InteriorColor", "Please select color.");
            }

            if (string.IsNullOrWhiteSpace(addEditVehicleVM.Vehicle.ExteriorColor))
            {
                ModelState.AddModelError("Vehicle.ExteriorColor", "Please select exterior color.");
            }

            if (!(addEditVehicleVM.Vehicle.Mileage.HasValue))
            {
                ModelState.AddModelError("Vehicle.Mileage", "Please enter mileage.");
            }
            else
            {
                if (addEditVehicleVM.Vehicle.IsNew)
                {
                    if (addEditVehicleVM.Vehicle.Mileage < 0 || addEditVehicleVM.Vehicle.Mileage >= 1000)
                    {
                        ModelState.AddModelError("Vehicle.Mileage", "Mileage should be between 0 and 1000 for a New vehicle.");
                    }
                }
                else
                {
                    if (addEditVehicleVM.Vehicle.Mileage < 1000)
                    {
                        ModelState.AddModelError("Vehicle.Mileage", "Mileage should be greater than 1000 for a Used vehicle.");
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(addEditVehicleVM.Vehicle.Vin))
            {
                ModelState.AddModelError("Vehicle.Vin", "Please enter Vin.");
            }

            if (!addEditVehicleVM.Vehicle.SalesPrice.HasValue)
            {
                ModelState.AddModelError("Vehicle.SalesPrice", "Please enter sales price.");
            }

            if (!addEditVehicleVM.Vehicle.MSRP.HasValue)
            {
                ModelState.AddModelError("Vehicle.MSRP", "Please enter MSRP.");
            }

            if (addEditVehicleVM.Vehicle.MSRP.HasValue && addEditVehicleVM.Vehicle.SalesPrice.HasValue)
            {
                if (addEditVehicleVM.Vehicle.SalesPrice.Value <= 0)
                {
                    ModelState.AddModelError("Vehicle.SalesPrice", "Sale Price must be a positive number.");
                }
                if (addEditVehicleVM.Vehicle.MSRP.Value <= 0)
                {
                    ModelState.AddModelError("Vehicle.MSRP", "MSRP must be a positive number.");
                }
                if (addEditVehicleVM.Vehicle.SalesPrice.Value > addEditVehicleVM.Vehicle.MSRP.Value)
                {
                    ModelState.AddModelError("Vehicle.SalesPrice", "Sale Price shouldn't be greater than MSRP.");
                }
            }

            if (string.IsNullOrWhiteSpace(addEditVehicleVM.Vehicle.Description))
            {
                ModelState.AddModelError("Vehicle.Description", "Please enter description");
            }
        }

        public ActionResult DeleteVehicle(string id)
        {
            var vehicle = _vehicleRepository.GetVehicleByVin(id);
            _vehicleRepository.DeleteVehicle(id);

            if (!string.IsNullOrWhiteSpace(vehicle.ImageFile) && !vehicle.ImageFile.EndsWith("icon.png"))
            {
                if (System.IO.File.Exists(HttpContext.Server.MapPath("~/Images/" + vehicle.ImageFile)))
                {
                    System.IO.File.Delete(HttpContext.Server.MapPath("~/Images/" + vehicle.ImageFile));
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public JsonResult GetModelByMakeId(int id)
        {
            return Json(_modelRepository.GetModelsByMakeId(id), JsonRequestBehavior.AllowGet);
        }
    }
}