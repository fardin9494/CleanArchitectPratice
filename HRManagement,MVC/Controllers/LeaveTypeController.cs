using HRManagement.MVC.Contracts;
using HRManagement.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRManagement.MVC.Controllers
{
    public class LeaveTypeController : Controller
    {
        private readonly ILeaveTypeService _leaveTypeService;

        public LeaveTypeController(ILeaveTypeService leaveTypeService)
        {
            _leaveTypeService = leaveTypeService;
        }

        public async Task<ActionResult> Index()
        {
            var leaveTypes = await _leaveTypeService.GetLeaveTypes();
            return View(leaveTypes);
        }

        // GET: LeaveTypeController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var selected =  await _leaveTypeService.GetLeaveTypeVM(id);
            return View(selected);
        }

        // GET: LeaveTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLeaveTypeVM leaveTypeVM)
        {
            try
            {
              var response = await _leaveTypeService.CreateleaveTypeVm(leaveTypeVM);
                if (!response.Succedded)
                {
                    ModelState.AddModelError("", response.ValidationError);
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(leaveTypeVM);
        }

        // GET: LeaveTypeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var selectedLeaveType = await _leaveTypeService.GetLeaveTypeVM(id);
            return View(selectedLeaveType);
        }

        // POST: LeaveTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(LeaveTypeVM VM)
        {
            try
            {
                
                var response = await _leaveTypeService.UpdateLeaveType(VM);
                if (!response.Succedded)
                {
                    ModelState.AddModelError("", response.ValidationError);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(VM);
        }

       // GET: LeaveTypeController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var selectedLeaveType = await _leaveTypeService.GetLeaveTypeVM(id);
            return View(selectedLeaveType);
        }

        // POST: LeaveTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id,LeaveTypeVM vm)
        {
            try
            {
               // var selectedLeaveType = await _leaveTypeService.GetLeaveTypeVM(id);
                var response = await _leaveTypeService.DeleteLeaveType(id);
                if (!response.Succedded)
                {
                    ModelState.AddModelError("", response.ValidationError);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(vm);
        }
    }
}
