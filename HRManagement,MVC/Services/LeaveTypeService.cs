using AutoMapper;
using HRManagement.MVC.Contracts;
using HRManagement.MVC.Models;
using HRManagement.MVC.Services.Base;

namespace HRManagement.MVC.Services
{
    public class LeaveTypeService : BaseHttpClientService, ILeaveTypeService
    {
        private readonly IMapper _mapper;

        private readonly ILocalStorageService _localStorage;

        private readonly IClient _client;

        public LeaveTypeService(IMapper mapper, ILocalStorageService localStorage, IClient client):base(client, localStorage)
        {
            _mapper = mapper;
            _localStorage = localStorage;
            _client = client;
        }

        public async Task<Response<int>> CreateleaveTypeVm(CreateLeaveTypeVM command)
        {
            try
            {
                var respone = new Response<int>();
                var CreateCommand = _mapper.Map<CreateLeaveTypeDto>(command);

                var apiResponse = await _client.LeaveTypePOSTAsync(CreateCommand);

                if (apiResponse.Success)
                {
                    respone.Data = apiResponse.Id;
                    respone.Succedded = true;
                }
                else
                {
                    respone.Succedded = false;
                    foreach(var err in apiResponse.Errors)
                    {
                        respone.ValidationError += err + Environment.NewLine;
                    }
                }
                return respone;

            }catch (ApiException ex)
            {
                return  ConvertApiExeption<int>(ex);
            }
        }

        public async Task<Response<int>> DeleteLeaveType(int id)
        {
            try
            {
                
                await _client.LeaveTypeDELETEAsync(id);
                var respone = new Response<int> {Succedded = true };
                return respone;
            }
            catch(ApiException ex)
            {
                return ConvertApiExeption<int>(ex);
            }
          
        }

        public async Task<List<LeaveTypeVM>> GetLeaveTypes()
        {
            var leaveTypes =await _client.LeaveTypeAllAsync();
            var leavetypeVM = _mapper.Map<List<LeaveTypeVM>>(leaveTypes);
            return leavetypeVM;
        }

        public async Task<LeaveTypeVM> GetLeaveTypeVM(int id)
        {
            var leaveType = await _client.LeaveTypeGETAsync(id);
            var leaveTypeVM = _mapper.Map<LeaveTypeVM>(leaveType);
            return leaveTypeVM;
        }

        public async Task<Response<int>> UpdateLeaveType(LeaveTypeVM command)
        {
            try
            {
                var leaveTypeDto = _mapper.Map<LeaveTypeDto>(command);
                await _client.LeaveTypePUTAsync(leaveTypeDto.Id, leaveTypeDto);
                var respone = new Response<int> { Succedded = true };
                return respone;


            }
            catch(ApiException ex)
            {
                return ConvertApiExeption<int>(ex);
            }
        }
    }
}
