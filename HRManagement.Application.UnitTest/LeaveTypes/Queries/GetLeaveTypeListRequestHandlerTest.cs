using AutoMapper;
using HRManagement.Application.Contract.Persistence;
using HRManagement.Application.DTOs.LeaveTypeDtos;
using HRManagement.Application.Features.LeaveTypes.Handlers.Queries;
using HRManagement.Application.Features.LeaveTypes.Requests.Queries;
using HRManagement.Application.Profiles;
using HRManagement.Application.UnitTest.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Application.UnitTest.LeaveTypes.Queries
{
    public class GetLeaveTypeListRequestHandlerTest
    {
        private IMapper _mapper;

        private Mock<ILeaveTypeRepository> _leaveTypes;
        public GetLeaveTypeListRequestHandlerTest()
        {
            _leaveTypes = MockLeaveTypeRepository.GetLeaveTypeRepository();

            var mapconfig = new MapperConfiguration(s => s.AddProfile<ProfileMapping>());

            _mapper = mapconfig.CreateMapper();
        }

        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new GetLeaveTypeListRequestHandler(_leaveTypes.Object, _mapper);

            var result = await handler.Handle(new GetLeaveTypesListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<LeaveTypeDto>>();
            
            result.Count.ShouldBe(2);
        }
    }
}
