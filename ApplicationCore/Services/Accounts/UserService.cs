using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Auth;
using ApplicationCore.Entities.Core;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Accounts;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Contracts.Accounts;
using Contracts.Auth;
using Contracts.Core;
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
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<OfficeUser> _officeUserRepository; // the way to add many to many relation in ef core; at least for now
        private readonly IRepository<RoleUser> _roleUserRepository; // the way to add many to many relation in ef core; at least for now
        private readonly IRepository<EntityType> _entityTypeRepository;
        private readonly IRepository<GroupEntityAccessPolicy> _groupEntityAccessPolicyRepository;
        private readonly AuthContext _authContext;
        private readonly IMapper _mapper;

        public UserService(
            IRepository<User> userRepository,
            IRepository<Tenant> tenantRepository,
            IRepository<Office> officeRepository,
            IRepository<Role> roleRepository,
            IRepository<OfficeUser> officeUserRepository,
            IRepository<RoleUser> roleUserRepository,
            IRepository<EntityType> entityTypeRepository,
            IRepository<GroupEntityAccessPolicy> groupEntityAccessPolicyRepository,
            AuthContext authContext,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _tenantRepository = tenantRepository;
            _officeRepository = officeRepository;
            _roleRepository = roleRepository;
            _officeUserRepository = officeUserRepository;
            _roleUserRepository = roleUserRepository;
            _entityTypeRepository = entityTypeRepository;
            _groupEntityAccessPolicyRepository = groupEntityAccessPolicyRepository;
            _authContext = authContext;
            _mapper = mapper;
        }

        #region User part

        public async Task<IList<UserDto>> GetAllUsers()
        {            
            return await _userRepository.List().Include(u => u.OfficeUsers).ThenInclude(ou => ou.Office).Include(u => u.RoleUsers).ThenInclude(ur => ur.Role).ProjectTo<UserDto>().ToListAsync();
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
            return _mapper.Map<UserDto>(await _userRepository.List().Include(u => u.OfficeUsers).ThenInclude(ou => ou.Office).Include(u => u.RoleUsers).ThenInclude(ur => ur.Role).ProjectTo<UserDto>().FirstOrDefaultAsync(u => u.Id == Guid.Parse(userId)));
        }


        public async Task<UserDto> GetUserByEmail(string email)
        {
            return _mapper.Map<UserDto>(await _userRepository.List().Include(u => u.OfficeUsers).ThenInclude(ou => ou.Office).Include(u => u.RoleUsers).ThenInclude(ur => ur.Role).FirstOrDefaultAsync(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)));
        }

        public async Task<UserDto> GetAuthContext()
        {
            return await Task.FromResult(_authContext.CurrentUser);
        }

        public async Task<UserDto> CreateInitialUser(UserDto userDto)
        {
            ValidateUser(userDto);
            userDto.CreatedOn = DateTime.Now;  // the current user may add himself for the first time
            userDto.UpdatedOn = DateTimeOffset.Now;
            var user = _mapper.Map<User>(userDto);
            user = _userRepository.Add(user);
            
            await _userRepository.SaveAsync();          
                        
            return await GetUser(user.Id.ToString());
        }

        public async Task<UserDto> UpdateUser(UserDto userDto, string userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if(user != null)
            {
                userDto.Offices = null;
                userDto.Roles = null;
                _mapper.Map<UserDto, User>(userDto, user);
                _userRepository.Update(user);
                await _userRepository.SaveAsync();
                return await GetUser(user.Id.ToString());
            }
            else
            {
                throw new Exception("The user does not exist");
            }
        }

        public async Task<UserDto> CreateUser(UserDto userDto, string officeId)
        {
            ValidateUser(userDto);
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


        public async Task<string> DeleteUser(string userId)
        {
            _userRepository.Delete(await _userRepository.GetByIdAsync(Guid.Parse(userId)));
            await _userRepository.SaveAsync();
            return await Task.FromResult(userId);
        }

        #endregion

        #region Tenant part

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

        public async Task<TenantDto> CreateTenant(TenantDto tenantDto)
        {
            var userId = "FDDFF607-9C87-4CBC-93F9-8544D4B04B62";  // this user would be get from the context
            var user = await _userRepository.GetByIdAsync(Guid.Parse(userId));
            // a tenant should has at least one office           
            var officeDtos = (tenantDto.Offices == null || !tenantDto.Offices.Any()) ? new List<OfficeDto>() : tenantDto.Offices;
            tenantDto.Offices = null; // unable to set the automapper to ignore this list; so it ends up added twice during the save.
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
            tenant = _tenantRepository.Add(tenant);
            foreach (var officeDto in officeDtos)
            {
                officeDto.UpdatedOn = DateTimeOffset.Now;
                officeDto.TenantId = tenant.Id;
                var office = _mapper.Map<Office>(officeDto);
                office = _officeRepository.Add(office);
                // the current user would be added to the office; so that the office at least has one user
                _officeUserRepository.Add(new OfficeUser { User = user, Office = office });

                var adminRole = new Role { RoleName = $"Admin of {officeDto.OfficeName}", IsAdministrator = true, OfficeId = office.Id };
                _roleRepository.Add(adminRole);

                // this user would be the admin of the office
                _roleUserRepository.Add(new RoleUser { User = user, Role = adminRole });
            }
            await _tenantRepository.SaveAsync();

            return await GetTenant(tenant.Id.ToString());
        }

        public Task<string> DeleteTenant(string tenantId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Office part

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

        public async Task<OfficeDto> CreateOffice(OfficeDto officeDto)
        {
            ValidateOffice(officeDto);
            var userId = "FDDFF607-9C87-4CBC-93F9-8544D4B04B62";
            var user = await _userRepository.GetByIdAsync(Guid.Parse(userId));
                      
            officeDto.Id = Guid.NewGuid();
            officeDto.UpdatedOn = DateTimeOffset.Now;
            var office = _mapper.Map<Office>(officeDto);
            office = _officeRepository.Add(office);
            // the current user would be added to the office; so that the office at least has one user
            // when we add Roles in the future this user would be the admin of the office
            _officeUserRepository.Add(new OfficeUser { User = user, Office = office });

            var adminRole = new Role { RoleName = $"Admin of {officeDto.OfficeName}", IsAdministrator = true, OfficeId = office.Id };
            _roleRepository.Add(adminRole);

            _roleUserRepository.Add(new RoleUser { User = user, Role = adminRole });

            await _tenantRepository.SaveAsync();

            return await GetOffice(office.Id.ToString());
        }

        public Task<string> DeleteOffice(string officeId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Role part

        public async Task<IList<RoleDto>> GetAllRoles()
        {
            return await _roleRepository.List().Include(r => r.GroupEntityAccessPolicies).ProjectTo<RoleDto>().ToListAsync();
        }

        public Task<IList<RoleDto>> GetTenantRoles(string tenantId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<RoleDto>> GetOfficeRoles(string officeId)
        {
            throw new NotImplementedException();
        }

        public async Task<RoleDto> GetRole(string roloeId)
        {
            return _mapper.Map<RoleDto>(await _roleRepository.List().Include(r => r.GroupEntityAccessPolicies).FirstOrDefaultAsync(t => t.Id == Guid.Parse(roloeId)));
        }

        public async Task<RoleDto> CreateRole(RoleDto roleDto)
        {
            ValidateRole(roleDto);
            var userId = "d352c6eb-8ead-449d-8bb1-da7eda819c8d";
            var user = await _userRepository.GetByIdAsync(Guid.Parse(userId));

            var role = _mapper.Map<Role>(roleDto);
            role = _roleRepository.Add(role);
            
            await _roleRepository.SaveAsync();

            return await GetRole(role.Id.ToString());
        }

        

        public async Task<UserDto> AddRoleUser(string roleId, string userId)
        {
            var role = await _roleRepository.GetByIdAsync(Guid.Parse(roleId));
            var user = await _userRepository.GetByIdAsync(Guid.Parse(userId));
            _roleUserRepository.Add(new RoleUser { User = user, Role = role });
            await _roleRepository.SaveAsync();
            return await GetUser(user.Id.ToString());
        }

        public Task<string> DeleteRole(string roleId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region EntityType

        public async Task<IList<EntityTypeDto>> GetAllEntityTypes()
        {
            return await _entityTypeRepository.List().ProjectTo<EntityTypeDto>().ToListAsync();
        }

        public async Task<EntityTypeDto> GetEntityType(string entityTypeId)
        {
            return _mapper.Map< EntityTypeDto > (await _entityTypeRepository.GetByIdAsync(entityTypeId) );
        }

        public async Task<EntityTypeDto> CreateEntityType(EntityTypeDto entityTypeDto)
        {           
            ValidateEntityType(entityTypeDto);
            var entityType = _mapper.Map<EntityType>(entityTypeDto);
            entityType = _entityTypeRepository.Add(entityType);
            await _entityTypeRepository.SaveAsync();
            return _mapper.Map<EntityTypeDto>(await _entityTypeRepository.GetByIdAsync(entityType.Id));           
        }        

        public Task<EntityTypeDto> UpdateEntityType(EntityTypeDto entityTypeDto)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteEntityType(string entityTypeId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region GroupEntityAccessPolicy

        public async Task<GroupEntityAccessPolicyDto> CreateGroupEntityAccessPolicy(GroupEntityAccessPolicyDto groupEntityAccessPolicyDto)
        {
            ValidateGroupEntityAccessPolicy(groupEntityAccessPolicyDto);
            var groupEntityAccessPolicy = _mapper.Map<GroupEntityAccessPolicy>(groupEntityAccessPolicyDto);
            groupEntityAccessPolicy = _groupEntityAccessPolicyRepository.Add(groupEntityAccessPolicy);
            await _groupEntityAccessPolicyRepository.SaveAsync();
            return _mapper.Map<GroupEntityAccessPolicyDto>(await _groupEntityAccessPolicyRepository.GetByIdAsync(groupEntityAccessPolicy.Id));
        }
        
        public Task<GroupEntityAccessPolicyDto> UpdateGroupEntityAccessPolicy(GroupEntityAccessPolicyDto groupEntityAccessPolicyDto)
        {
            throw new NotImplementedException();
        }

        public Task<GroupEntityAccessPolicyDto> DeleteGroupEntityAccessPolicy(string groupEntityAccessPolicyId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Validation

        private void ValidateUser(UserDto userDto)
        {
            if(string.IsNullOrEmpty(userDto.Email))
            {
                throw new Exception($" the email is required.");
            }
            var existingUser = _userRepository.List().FirstOrDefault(u => u.Email.Equals(userDto.Email));
            if(existingUser != null)
            {
                throw new Exception($" the email : {userDto.Email} already been used.");
            }
        }

        private async void ValidateOffice(OfficeDto officeDto)
        {
            // make sure that the Tenant of the officeDto.TenantId is there;
            if (officeDto.TenantId == null)
            {
                throw new Exception($" TenantId is required.");
            }
            var tenant = await _tenantRepository.GetByIdAsync(officeDto.TenantId);
            if (tenant == null)
            {
                throw new Exception($" office should be added to an existing Tenant.");
            }
        }

        private void ValidateRole(RoleDto roleDto)
        {
            //throw new NotImplementedException();
        }

        private void ValidateEntityType(EntityTypeDto entityTypeDto)
        {
            //throw new NotImplementedException();
        }

        private void ValidateGroupEntityAccessPolicy(GroupEntityAccessPolicyDto groupEntityAccessPolicyDto)
        {
            //throw new NotImplementedException();
        }
       
        #endregion

    }
}
