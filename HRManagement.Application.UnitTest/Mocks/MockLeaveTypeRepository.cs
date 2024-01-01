using HRManagement.Application.Contract.Persistence;
using HRManagement.Domain;
using Moq;

namespace HRManagement.Application.UnitTest.Mocks
{
    public class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
        {
            var leaveTypes = new List<LeaveType>
            {
             new LeaveType {
                  Id = 1,
                  DeafultDay = 5,
                Name = "Vacations"
             },
            new LeaveType {
                Id = 2,
                DeafultDay = 6,
                Name = "Sickness"
                },
            };

            var repository = new Mock<ILeaveTypeRepository>();

            repository.Setup(x => x.GetAll()).ReturnsAsync(leaveTypes);
            repository.Setup(x => x.Add(It.IsAny<LeaveType>())).ReturnsAsync((LeaveType leavetype) =>
            {
                leaveTypes.Add(leavetype);
                return leavetype;
            });

            return repository;
        }
    }
}
