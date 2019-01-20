using ApplicationCore.Entities.Accounts;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Accounts;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Contracts.Accounts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services.Accounts
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Tenant> _tenantRepository;
        private readonly IRepository<Office> _officeRepository;
        private readonly IRepository<OfficeUser> _officeUserRepository; // the way to add many to many relation in ef core; at least for now
        private readonly IMapper _mapper;

        public UserService(
            IRepository<User> userRepository,
            IRepository<Tenant> tenantRepository,
            IRepository<Office> officeRepository,
            IRepository<OfficeUser> officeUserRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _tenantRepository = tenantRepository;
            _officeRepository = officeRepository;
            _officeUserRepository = officeUserRepository;
            _mapper = mapper;
        }

        public async Task<IList<UserDto>> GetAllUsers()
        {            
            return await _userRepository.List().Include(u => u.OfficeUsers).ThenInclude(ou => ou.Office).ProjectTo<UserDto>().ToListAsync();
        }

        public async Task<IList<UserDto>> GetTenantUsers(string TenantId)
        {
            var guidId = Guid.Parse(TenantId);
            var result = _officeUserRepository.List().Include(uo => uo.User).Include(uo => uo.Office).ThenInclude(o => o.Tenant).Where(uo => uo.Office.TenantId == guidId).GroupBy(r => r.OfficeId, (u, g) => g.Select(ou => ou.User).ToList()).FirstOrDefault();
            return await Task.FromResult(_mapper.Map<List<UserDto>>(result));
        }

        public async Task<IList<UserDto>> GetOfficeUsers(string OfficeId)
        {
            var guidId = Guid.Parse(OfficeId);
            var result = _officeUserRepository.List().Include(uo => uo.User).Include(uo => uo.Office).ThenInclude(o => o.Tenant).Where(uo => uo.Office.Id == guidId).GroupBy(r => r.OfficeId, (u, g) => g.Select(ou => ou.User).ToList()).FirstOrDefault();
            return await Task.FromResult(_mapper.Map<List<UserDto>>(result));
        }

        public async Task<UserDto> GetUser(string userId)
        {
            return _mapper.Map<UserDto>(await _userRepository.GetByIdAsync(userId));
        }

        public async Task<UserDto> CreateUser(UserDto userDto, string officeId)
        {
            userDto.Id = Guid.NewGuid();
            userDto.UpdatedOn = DateTimeOffset.Now;
            var user = _mapper.Map<User>(userDto);
            _userRepository.Add(user);
            await _userRepository.SaveAsync();
            // it would be null or empty when the first office user be added; he is the one who will create the tenant and so the first office
            if (!string.IsNullOrEmpty(officeId))
            {
                return await AddUser(userDto.Id.ToString(), officeId);
            }
            
            return _mapper.Map<UserDto>(await _userRepository.GetByIdAsync(userDto.Id));
        }

        public async Task<UserDto> AddUser(string userId, string officeId)
        {
            var user = await _userRepository.GetByIdAsync(Guid.Parse(userId));
            var office = await _officeRepository.GetByIdAsync(Guid.Parse(officeId));
            _officeUserRepository.Add(new OfficeUser { User = user, Office = office });
            return _mapper.Map<UserDto>(await _userRepository.GetByIdAsync(user.Id));
        }

        public async Task<TenantDto> CreateTenant(TenantDto tenantDto)
        {
            var userId = "d352c6eb-8ead-449d-8bb1-da7eda819c8d";  // this user would be get from the context
            var user = await _userRepository.GetByIdAsync(Guid.Parse(userId));
            // a tenant should has at least one office           
            var officeDtos = (tenantDto.Offices == null || !tenantDto.Offices.Any()) ? new List<OfficeDto>() : tenantDto.Offices;
            tenantDto.Offices = null; // unable to set the automapper to ignore this list; so it ends up added twice during the save.
            tenantDto.Id = Guid.NewGuid();
            tenantDto.UpdatedOn = DateTimeOffset.Now;
            if (!officeDtos.Any())
            {
                officeDtos.Add(new OfficeDto
                {
                    TenantId = tenantDto.Id,
                    OfficeCode = tenantDto.TenantCode,
                    OfficeName = tenantDto.TenantName,
                    NickName = tenantDto.TenantName
                });
            }
            var tenant = _mapper.Map<Tenant>(tenantDto);
            _tenantRepository.Add(tenant);
            foreach (var officeDto in officeDtos)
            {
                officeDto.Id = Guid.NewGuid();
                officeDto.UpdatedOn = DateTimeOffset.Now;
                var office = _mapper.Map<Office>(officeDto);
                _officeRepository.Add(office);
                // the current user would be added to the office; so that the office at least has one user
                // when we add Roles in the future this user would be the admin of the office
                _officeUserRepository.Add(new OfficeUser { User = user, Office = office });
            }
            await _tenantRepository.SaveAsync();

            return await GetTenant(tenantDto.Id.ToString());
        }


        public async Task<OfficeDto> CreateOffice(OfficeDto officeDto)
        {
            ValidateOffice(officeDto);
            var userId = "d352c6eb-8ead-449d-8bb1-da7eda819c8d";
            var user = await _userRepository.GetByIdAsync(Guid.Parse(userId));
                      
            officeDto.Id = Guid.NewGuid();
            officeDto.UpdatedOn = DateTimeOffset.Now;
            var office = _mapper.Map<Office>(officeDto);
            _officeRepository.Add(office);
            // the current user would be added to the office; so that the office at least has one user
            // when we add Roles in the future this user would be the admin of the office
            _officeUserRepository.Add(new OfficeUser { User = user, Office = office });
            
            await _tenantRepository.SaveAsync();

            return await GetOffice(officeDto.Id.ToString());
        }
        

        public async Task<IList<TenantDto>> GetAllTenants()
        {
            return await _tenantRepository.List().Include(u => u.Offices).ProjectTo<TenantDto>().ToListAsync();
        }

        public async Task<IList<TenantDto>> GetUserTenants(string userId)
        {
            var guidId = Guid.Parse(userId);
            var result = _officeUserRepository.List().Include(uo => uo.Office).ThenInclude(o => o.Tenant).Where(uo => uo.UserId == guidId).GroupBy(r => r.UserId, (u, g) => g.Select(ou => ou.Office.Tenant).ToList()).FirstOrDefault();
            return await Task.FromResult(_mapper.Map<List<TenantDto>>(result));
        }


        public async Task<TenantDto> GetTenant(string tenantId)
        {
            return _mapper.Map<TenantDto>(await _tenantRepository.List().Include(u => u.Offices).FirstOrDefaultAsync(t => t.Id == Guid.Parse(tenantId)));
        }
      
        
        public async Task<IList<OfficeDto>> GetAllOffices()
        {
            return await _officeRepository.List().Include(u => u.Tenant).Include(o => o.ParentOffice).ProjectTo<OfficeDto>().ToListAsync();
        }

        public async Task<IList<OfficeDto>> GetTenantOffices(string tenantId)
        {
            var guidId = Guid.Parse(tenantId);
            return await _officeRepository.List().Include(u => u.Tenant).Include(o => o.ParentOffice).Where(o => o.TenantId == guidId).ProjectTo<OfficeDto>().ToListAsync();
        }

        public async Task<IList<OfficeDto>> GetUserOffices(string userId)
        {
            var guidId = Guid.Parse(userId);
            var result = _officeUserRepository.List().Include(uo => uo.Office).ThenInclude(o => o.Tenant).Where(uo => uo.UserId == guidId).GroupBy(r => r.UserId, (u, g) => g.Select(ou => ou.Office).ToList()).FirstOrDefault();
            return await Task.FromResult(_mapper.Map<List<OfficeDto>>(result));
        }

        public async Task<OfficeDto> GetOffice(string officeId)
        {
            return _mapper.Map<OfficeDto>(await _officeRepository.List().Include(u => u.Tenant).Include(o => o.ParentOffice).FirstOrDefaultAsync(t => t.Id == Guid.Parse(officeId)));
        }

        public async Task<string> DeleteUser(string userId)
        {
            _userRepository.Delete(await _userRepository.GetByIdAsync(Guid.Parse(userId)));
            await _userRepository.SaveAsync();
            return await Task.FromResult(userId);
        }

        public Task<string> DeleteTenant(string tenantId)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteOffice(string officeId)
        {
            throw new NotImplementedException();
        }

        #region Validation

        private void ValidateOffice(OfficeDto officeDto)
        {
            // make sure that the Tenant in of the officeDto.TenantId is there;
            throw new NotImplementedException();
        }
        
        #endregion
    }
}
