using HRManagement.MVC.Models;
using HRManagement.MVC.Services.Base;

namespace HRManagement.MVC.Contracts
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeVM>> GetLeaveTypes();

        Task<LeaveTypeVM> GetLeaveTypeVM(int id);

        Task<Response<int>> CreateleaveTypeVm(CreateLeaveTypeVM command);

        Task<Response<int>> UpdateLeaveType(LeaveTypeVM command);
        
        Task<Response<int>> DeleteLeaveType(int id);

    }
}
