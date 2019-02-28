using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Auth;
using ApplicationCore.Entities.Core;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Accounts;
using ApplicationCore.Utilities.Extensions;
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

        public async Task<IList<UserDto>> GetOfficeUsers(string OfficeId) //in use
        {
            var guidId = Guid.Parse(OfficeId);
            //var users = await _officeUserRepository.List().Include(uo => uo.User).Include(uo => uo.Office).ThenInclude(o => o.Tenant).Where(uo => uo.Office.Id == guidId).GroupBy(r => r.OfficeId, (u, g) => g.Select(ou => ou.User).ToList()).FirstOrDefaultAsync();           
            var users = await _officeUserRepository.List().Include(uo => uo.User).ThenInclude(u => u.RoleUsers).ThenInclude(ru => ru.Role).Where(uo => uo.Office.Id == guidId).GroupBy(r => r.OfficeId, (u, g) => g.Select(ou => ou.User).ToList()).FirstOrDefaultAsync();
            
            var userDtos =   _mapper.Map<List<UserDto>>(users);
            userDtos.ForEach(udto => { udto.Offices = new List<OfficeDto> (); udto.Roles = udto.Roles.Where(r => r.OfficeId == guidId).ToList();  });
            return userDtos;
        }

        public async Task<UserDto> GetUser(string userId)
        {
            return _mapper.Map<UserDto>(await _userRepository.List().Include(u => u.OfficeUsers).ThenInclude(ou => ou.Office).Include(u => u.RoleUsers).ThenInclude(ur => ur.Role).ProjectTo<UserDto>().FirstOrDefaultAsync(u => u.Id == Guid.Parse(userId)));
        }


        public async Task<UserDto> GetUserByEmail(string email) // in use
        {
            return _mapper.Map<UserDto>(await _userRepository.List().Include(u => u.OfficeUsers).ThenInclude(ou => ou.Office).Include(u => u.RoleUsers).ThenInclude(ur => ur.Role).FirstOrDefaultAsync(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)));
        }

        public async Task<UserDto> GetAuthContext() // in use
        {
            return await Task.FromResult(_authContext.CurrentUser);
        }

        public async Task<UserDto> CreateInitialUser(UserDto userDto) // in use
        {
            ValidateUser(userDto);
            userDto.CreatedOn = DateTime.Now;  // the current user may add himself for the first time
            userDto.UpdatedOn = DateTimeOffset.Now;
            var user = _mapper.Map<User>(userDto);
            user = _userRepository.Add(user);
            
            await _userRepository.SaveAsync();          
                        
            return await GetUser(user.Id.ToString());
        }

        public async Task<UserDto> UpdateContextUser(UserDto userDto) // in use
        {
            var user = await _userRepository.GetByIdAsync(userDto.Id);
            if(user != null)
            {                
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

        public async Task<UserDto> UpdateUser(UserDto userDto, string officeId) // in use
        {
            // a user should has at most one role for an office 
            var roleId = userDto.Roles.FirstOrDefault()?.Id;           
            var role = (roleId != null) ? _roleRepository.List().FirstOrDefault(r => r.OfficeId == _authContext.CurrentOffice.Id && r.Id == roleId) : null;

            var user = await _userRepository.GetByIdAsync(userDto.Id);
            if (user != null)
            {
                _mapper.Map<UserDto, User>(userDto, user);
                _userRepository.Update(user);

                if (role != null)
                {
                    var roleUser = _roleUserRepository.List().Include(ru => ru.Role).Where(ru => ru.UserId == user.Id && ru.Role.OfficeId == _authContext.CurrentOffice.Id).FirstOrDefault();
                    if (roleUser != null)
                    {
                        _roleUserRepository.Delete(roleUser);
                    }

                    _roleUserRepository.Add(new RoleUser { UserId = user.Id, RoleId = role.Id });
                }
                await _userRepository.SaveAsync();
                return (await GetOfficeUsers(_authContext.CurrentOffice.Id.ToString())).First(u => u.Id == user.Id);
            }
            else
            {
                throw new Exception("The user does not exist");
            }
        }

        public async Task<UserDto> CreateUser(UserDto userDto, string officeId)  // in use
        {
            var existingUser = await _userRepository.List().Where(u => u.Email.Equals(userDto.Email, StringComparison.OrdinalIgnoreCase)).FirstOrDefaultAsync();
            if(existingUser != null)
            {
                throw new Exception("This user already created; you can add him to the office.");
            }
            ValidateUser(userDto);
            var user = _mapper.Map<User>(userDto);
            user = _userRepository.Add(user);

            // it would be null or empty when the first office user be added; he is the one who will create the tenant and so the first office
            if (!string.IsNullOrEmpty(officeId))
            {
                _officeUserRepository.Add(new OfficeUser { UserId = user.Id, OfficeId = Guid.Parse(officeId) });
            }

            // a user should has at most one role for an office 
            var roleId = userDto.Roles.FirstOrDefault()?.Id;
            var role = (roleId != null) ? _roleRepository.List().FirstOrDefault(r => r.OfficeId == _authContext.CurrentOffice.Id && r.Id == roleId) : null;
            if (role != null)
            {
                var roleUser = _roleUserRepository.List().Include(ru => ru.Role).Where(ru => ru.UserId == user.Id && ru.Role.OfficeId == _authContext.CurrentOffice.Id).FirstOrDefault();
                if (roleUser != null)
                {
                    _roleUserRepository.Delete(roleUser);
                }

                _roleUserRepository.Add(new RoleUser { UserId = user.Id, RoleId = role.Id });
            }

            await _userRepository.SaveAsync();
            return (await GetOfficeUsers(_authContext.CurrentOffice.Id.ToString())).First(u => u.Id == user.Id);
        }


        public async Task<string> DeleteUser(string userId)
        {
            _userRepository.Delete(await _userRepository.GetByIdAsync(Guid.Parse(userId)));
            await _userRepository.SaveAsync();
            return await Task.FromResult(userId);
        }

        #endregion

        #region Tenant part

        public async Task<IList<TenantDto>> GetAllTenants() // for super admin
        {
            return await _tenantRepository.List().Include(u => u.Offices).ProjectTo<TenantDto>().ToListAsync();
        }

        public async Task<IList<TenantDto>> GetUserTenants() // in use
        {
            var tenantIds = _authContext.CurrentUser.Offices.Select(o => o.TenantId).ToArray();
            var officeIds = _authContext.CurrentUser.Offices.Select(o => o.Id).ToArray();
            var tenants = await _tenantRepository.List().Include(u => u.Offices).Where(t => tenantIds.Contains(t.Id))              
                .ProjectTo<TenantDto>().ToListAsync();
            tenants.ForEach(t => t.Offices = t.Offices.Where(o => officeIds.Contains(o.Id)).ToList());
            return tenants;
            //var result = _officeUserRepository.List().Include(uo => uo.Office).ThenInclude(o => o.Tenant).Where(uo => uo.UserId == _authContext.CurrentUser.Id).GroupBy(r => r.UserId, (u, g) => g.Select(ou => ou.Office.Tenant).ToList()).FirstOrDefault();
            //return await Task.FromResult(_mapper.Map<List<TenantDto>>(result));
        }


        public async Task<TenantDto> GetTenant(string tenantId) // in use
        {
            return _mapper.Map<TenantDto>(await _tenantRepository.List().Include(u => u.Offices).FirstOrDefaultAsync(t => t.Id == Guid.Parse(tenantId)));
        }

        public async Task<TenantDto> CreateTenant(TenantDto tenantDto) // in use
        {
            // a tenant should has at least one office           
            var officeDtos = (tenantDto.Offices == null || !tenantDto.Offices.Any()) ? new List<OfficeDto>() : tenantDto.Offices;
            tenantDto.Offices = null; // unable to set the automapper to ignore this list; so it ends up added twice during the save.
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
                _officeUserRepository.Add(new OfficeUser { UserId = _authContext.CurrentUser.Id, OfficeId = office.Id });

                var adminRole = new Role { RoleName = $"Admin of {officeDto.OfficeName}", IsAdministrator = true, OfficeId = office.Id };
                _roleRepository.Add(adminRole);

                // this user would be the admin of the office
                _roleUserRepository.Add(new RoleUser { UserId = _authContext.CurrentUser.Id, RoleId = adminRole.Id });
            }
            await _tenantRepository.SaveAsync();

            return await GetTenant(tenant.Id.ToString());
        }

        public async Task<TenantDto> UpdateTenant(TenantDto tenantDto) // in use
        {
            //https://github.com/aspnet/EntityFrameworkCore/issues/10954
            //https://github.com/AutoMapper/AutoMapper/issues/1792
            //https://github.com/AutoMapper/AutoMapper/issues/1695

            var tenant =  await _tenantRepository.List().Include(t => t.Offices).FirstOrDefaultAsync(t => t.Id == tenantDto.Id);
            var officeDtos = (tenantDto.Offices == null || !tenantDto.Offices.Any()) ? new List<OfficeDto>() : tenantDto.Offices;
            // var offices = tenant.Offices;                     
            // tenantDto.Offices = null; // unable to set the automapper to ignore this list; so it ends up added twice during the save.

            // a tenant should has at least one office 
            if (!officeDtos.Any() && !tenant.Offices.Any())
            {
                officeDtos.Add(new OfficeDto
                {
                    TenantId = tenantDto.Id,
                    OfficeCode = tenantDto.TenantCode,
                    OfficeName = tenantDto.TenantName,
                    NickName = tenantDto.TenantName
                });
            }
            //_mapper.Map<TenantDto,Tenant>(tenantDto, tenant);
            tenant.MappTenantDto(tenantDto);
            _tenantRepository.Update(tenant);
            foreach (var officeDto in officeDtos)
            {
                officeDto.TenantId = tenant.Id;
                // ef addorupdate causes some kind of troubles               
                var office = tenant.Offices.FirstOrDefault(o => o.Id == officeDto.Id); // _mapper.Map<Office>(officeDto);
                if(office == null)
                {
                    office = _mapper.Map<Office>(officeDto);
                    office = _officeRepository.Add(office);
                    // the current user would be added to the office; so that the office at least has one user
                    _officeUserRepository.Add(new OfficeUser { UserId = _authContext.CurrentUser.Id, OfficeId = office.Id });
                    var adminRole = new Role { RoleName = $"Admin of {officeDto.OfficeName}", IsAdministrator = true, OfficeId = office.Id };
                    adminRole = _roleRepository.Add(adminRole);
                    // this user would be the admin of the office
                    _roleUserRepository.Add(new RoleUser { UserId = _authContext.CurrentUser.Id, RoleId = adminRole.Id });
                }
                else
                {
                    //_mapper.Map<OfficeDto,Office>(officeDto,office);
                    office.MappOfficeDto(officeDto);
                    _officeRepository.Update(office);
                }

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

        public async Task<UserDto> AddOfficeUser(UserDto userDto, string officeId)  // in use
        {                      
            var roleId = userDto.Roles.FirstOrDefault()?.Id;
            var role = (roleId != null) ? _roleRepository.List().FirstOrDefault(r => r.OfficeId == _authContext.CurrentOffice.Id && r.Id == roleId) : null;

            var user = await _userRepository.List().Include(u => u.OfficeUsers).FirstOrDefaultAsync(u => u.Email.Equals(userDto.Email, StringComparison.OrdinalIgnoreCase));
            if (user != null)
            {               
                if (user.OfficeUsers.FirstOrDefault(ou => ou.OfficeId == _authContext.CurrentOffice.Id) != null)
                {
                    throw new Exception("This user already added to the office.");
                }

                _officeUserRepository.Add(new OfficeUser { OfficeId = _authContext.CurrentOffice.Id, UserId = user.Id });
                if (role != null)
                {
                    var roleUser = _roleUserRepository.List().Include(ru => ru.Role).Where(ru => ru.UserId == user.Id && ru.Role.OfficeId == _authContext.CurrentOffice.Id).FirstOrDefault();
                    if (roleUser != null)
                    {
                        _roleUserRepository.Delete(roleUser);
                    }

                    _roleUserRepository.Add(new RoleUser { UserId = user.Id, RoleId = role.Id });
                }
                await _userRepository.SaveAsync();
                return (await GetOfficeUsers(_authContext.CurrentOffice.Id.ToString())).First(u => u.Id == user.Id);
            }
            else
            {
                throw new Exception("The user does not exist");
            }

        }

        public async Task<UserDto> DeleteOfficeUser(string officeId, string userId)  // in use
        {
           
            var user = await _userRepository.List().Include(u => u.OfficeUsers).Include(u => u.RoleUsers).ThenInclude(ur => ur.Role).FirstOrDefaultAsync(u => u.Id == Guid.Parse(userId));
            if (user != null)
            {
                if (user.RoleUsers.FirstOrDefault(ru => ru.Role.OfficeId == _authContext.CurrentOffice.Id && ru.Role.IsAdministrator) != null)
                {
                    throw new Exception("Admin can not be deleted.");
                }

                var officeUser = user.OfficeUsers.FirstOrDefault(ru => ru.OfficeId == _authContext.CurrentOffice.Id);
                var roleUser = user.RoleUsers.FirstOrDefault(ru => ru.Role.OfficeId == _authContext.CurrentOffice.Id);
                if(officeUser != null)
                {
                    _officeUserRepository.Delete(officeUser);
                }
                if (roleUser != null)
                {
                    _roleUserRepository.Delete(roleUser);
                }
               
                await _userRepository.SaveAsync();
                return _mapper.Map<UserDto>(user);
            }
            else
            {
                throw new Exception("The user does not exist");
            }

        }


        public Task<string> DeleteOffice(string officeId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Role part

        public async Task<IList<RoleDto>> GetOfficeRoles(string officeId) // in use
        {
            return await _roleRepository.List().Include(r => r.GroupEntityAccessPolicies).ThenInclude(g => g.EntityType).Where(r => r.OfficeId == _authContext.CurrentOffice.Id).ProjectTo<RoleDto>().ToListAsync();
        }

        public async Task<RoleDto> GetRole(string roloeId) // in use
        {
            return _mapper.Map<RoleDto>(await _roleRepository.List().Include(r => r.GroupEntityAccessPolicies).ThenInclude(g => g.EntityType).FirstOrDefaultAsync(t => t.Id == Guid.Parse(roloeId)));
        }

        public async Task<RoleDto> CreateRole(RoleDto roleDto, string officeId) // in use
        {            
            var existingRole = await _roleRepository.List().FirstOrDefaultAsync(r => r.RoleName.Equals(roleDto.RoleName,StringComparison.OrdinalIgnoreCase) && r.OfficeId == _authContext.CurrentOffice.Id);
            if (existingRole != null)
            {
                throw new Exception("The office already has a role with the same name.");
            }
            var groupPolicyDtos = (roleDto.GroupEntityAccessPolicies == null || !roleDto.GroupEntityAccessPolicies.Any()) ? new List<GroupEntityAccessPolicyDto>() : roleDto.GroupEntityAccessPolicies;
            roleDto.GroupEntityAccessPolicies = null; // unable to set the automapper to ignore this list; so it ends up added twice during the save.

            var role = _mapper.Map<Role>(roleDto);
            role.OfficeId = _authContext.CurrentOffice.Id;
            role = _roleRepository.Add(role);

            foreach (var groupPolicyDto in groupPolicyDtos)
            {

                groupPolicyDto.RoleId = role.Id;
                groupPolicyDto.EntityType = null;
                var groupPolicy = _mapper.Map<GroupEntityAccessPolicy>(groupPolicyDto);
                groupPolicy = _groupEntityAccessPolicyRepository.Add(groupPolicy);                
            }

            await _roleRepository.SaveAsync();

            return await GetRole(role.Id.ToString());

        }

        public async Task<RoleDto> UpdateRole(RoleDto roleDto, string officeId) // in use
        {
            /////https://github.com/aspnet/EntityFrameworkCore/issues/10954
            //https://github.com/AutoMapper/AutoMapper/issues/1792
            //https://github.com/AutoMapper/AutoMapper/issues/1695

            var existingRole = await _roleRepository.List().FirstOrDefaultAsync(r => r.RoleName.Equals(roleDto.RoleName, StringComparison.OrdinalIgnoreCase) && r.OfficeId == _authContext.CurrentOffice.Id && r.Id != roleDto.Id);
            if (existingRole != null)
            {
                throw new Exception("The office already has a role with the same name.");
            }
            
            var role = await _roleRepository.List().Include(t => t.GroupEntityAccessPolicies).FirstOrDefaultAsync(t => t.Id == roleDto.Id);
            var groupPolicyDtos = (roleDto.GroupEntityAccessPolicies == null || !roleDto.GroupEntityAccessPolicies.Any()) ? new List<GroupEntityAccessPolicyDto>() : roleDto.GroupEntityAccessPolicies;
            //_mapper.Map<RoleDto,Role>(roleDto, role);
            role.MappRoleDto(roleDto);
            _roleRepository.Update(role);
            _groupEntityAccessPolicyRepository.DeleteRange(role.GroupEntityAccessPolicies);

            if(!roleDto.IsAdministrator)
            {
                // make sure that an office has at least one admin
                var otherAdminRole = await _roleRepository.List().FirstOrDefaultAsync(r => r.Id != roleDto.Id && r.OfficeId == _authContext.CurrentOffice.Id && r.IsAdministrator);
                if (otherAdminRole == null)
                {
                    throw new Exception("The office should has at least one admin.");
                }
                foreach (var groupPolicyDto in groupPolicyDtos)
                {
                    groupPolicyDto.RoleId = role.Id;
                    groupPolicyDto.EntityType = null;
                    var groupPolicy = _mapper.Map<GroupEntityAccessPolicy>(groupPolicyDto);
                    groupPolicy = _groupEntityAccessPolicyRepository.Add(groupPolicy);
                }
            }
            
            await _roleRepository.SaveAsync();
            return await GetRole(role.Id.ToString());
        }



        //public async Task<UserDto> UpdateRoleUser(string officeId, string userId, string roleId)
        //{
        //    // a user should has at most one role for an office 
        //    var role = _roleRepository.List().FirstOrDefault(r => r.OfficeId == _authContext.CurrentOffice.Id && r.Id == Guid.Parse(roleId));
        //    var user = _officeUserRepository.List().FirstOrDefault(ou => ou.OfficeId == _authContext.CurrentOffice.Id && ou.UserId == Guid.Parse(userId));
        //    if (role == null)
        //    {
        //        throw new Exception("The Office doesn't has such role.");
        //    }
        //    if (user == null)
        //    {
        //        throw new Exception("The Office doesn't has such user.");
        //    }
        //    var roleUser = _roleUserRepository.List().Include(ru => ru.Role).Where(ru => ru.UserId == Guid.Parse(userId) && ru.Role.OfficeId == _authContext.CurrentOffice.Id).FirstOrDefault();
        //    if(roleUser != null)
        //    {
        //        _roleUserRepository.Delete(roleUser);
        //    }
              
        //    _roleUserRepository.Add(new RoleUser { UserId = Guid.Parse(userId), RoleId = Guid.Parse(roleId) });
        //    await _roleRepository.SaveAsync();
            
        //    return (await GetOfficeUsers(_authContext.CurrentOffice.Id.ToString())).First(u => u.Id == Guid.Parse(userId));
        //}

        public async Task<RoleDto> DeleteRole(string officeId, string roleId) // in use
        {
            var role = await _roleRepository.List().FirstOrDefaultAsync(r => r.Id == Guid.Parse(roleId) && r.OfficeId == _authContext.CurrentOffice.Id);
            if(role == null)
            {
                throw new Exception("The office does not has such role.");
            }
            // make sure that an office has at least one admin
            var otherAdminRole = await _roleRepository.List().FirstOrDefaultAsync(r => r.Id != Guid.Parse(roleId) && r.OfficeId == _authContext.CurrentOffice.Id && r.IsAdministrator);
            if (otherAdminRole == null)
            {
                throw new Exception("The office should has at least one admin.");
            }

            _roleRepository.Delete(role);
            await _roleRepository.SaveAsync();
            return _mapper.Map<RoleDto>(role);
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
