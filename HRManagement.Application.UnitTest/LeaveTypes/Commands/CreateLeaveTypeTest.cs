using AutoMapper;
using HRManagement.Application.Contract.Persistence;
using HRManagement.Application.DTOs.LeaveTypeDtos;
using HRManagement.Application.Features.LeaveTypes.Handlers.Commands;
using HRManagement.Application.Features.LeaveTypes.Requests.Commands;
using HRManagement.Application.Profiles;
using HRManagement.Application.UnitTest.Mocks;
using HRManagement.Persitence.Repositores;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Application.UnitTest.LeaveTypes.Commands
{
    public class CreateLeaveTypeTest 
    {

        private IMapper _mapper;

        private Mock<ILeaveTypeRepository> _leaveTypeRepository;

        private CreateLeaveTypeDto _leaveTypeDto;
        public CreateLeaveTypeTest() {

            _leaveTypeRepository = MockLeaveTypeRepository.GetLeaveTypeRepository();

            var mapconfig = new MapperConfiguration(x => x.AddProfile<ProfileMapping>());

            _mapper = mapconfig.CreateMapper();

            _leaveTypeDto = new CreateLeaveTypeDto()
            {
                DeafultDay = 43,
                Name = "Name",
            };
        }

        [Fact]

        public async Task CreateTest()
        {
            var Create = new CreateLeaveTypeCommandHandler(_leaveTypeRepository.Object,_mapper);

            var Result = Create.Handle(new CreateLeaveTypeCommand()
            { leaveTypeDto = _leaveTypeDto}
                , CancellationToken.None);

            await Result.ShouldBeOfType<Task<int>>();

            

           
        }
    }
}
