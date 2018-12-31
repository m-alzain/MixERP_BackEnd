using Contracts.ApplicationState.Models;
using ApplicationCore.Forms.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Interfaces.Forms;
using ApplicationCore.Services.Forms;
using System.Threading.Tasks;

namespace Infrastructure.Data.Forms
{
    public class FormRepository : IFormRepository
    {
        private readonly EntityViews _entityViews;
        public FormRepository(EntityViews entityViews)
        {
            _entityViews = entityViews;
        }
        //public sealed override string _ObjectNamespace { get; }
        public string _ObjectNamespace { get; set; }
        //public sealed override string _ObjectName { get; }
        public string _ObjectName { get; set; }
        public string FullyQualifiedObjectName { get; set; }
        public string PrimaryKey { get; set; }
        public string IdentityColumn { get; set; }
        public string LookupField { get; set; }
        public string NameColumn { get; set; }
        public string Database { get; set; }
        public int UserId { get; set; }
        public bool IsValid { get; set; }
        public long LoginId { get; set; }
        public int OfficeId { get; set; }

        private string GetTableName()
        {
            string tableName = this._ObjectName.Replace("-", "_");
            return tableName;
        }

        private string GetCandidateKey()
        {
            string candidateKey = Inflector.MakeSingular(this._ObjectName);
            if (!string.IsNullOrWhiteSpace(candidateKey))
            {
                candidateKey += "_id";
            }

            candidateKey = candidateKey ?? "";

            return Sanitizer.SanitizeIdentifierName(candidateKey);
        }

        private string GetLookupField()
        {
            string candidateKey = Inflector.MakeSingular(this._ObjectName);
            if (!string.IsNullOrWhiteSpace(candidateKey))
            {
                candidateKey += "_code";
            }

            candidateKey = candidateKey?.Replace("_code_code", "_code") ?? "";

            return Sanitizer.SanitizeIdentifierName(candidateKey);
        }

        private string GetNameColumn()
        {
            string nameKey = Inflector.MakeSingular(this._ObjectName);

            if (!string.IsNullOrWhiteSpace(nameKey))
            {
                nameKey += "_name";
            }

            return nameKey?.Replace("_name_name", "_name") ?? "";
        }

        public async Task<EntityView> GetMetaAsync(string schemaName, string tableName, string tenant, long loginId, int userId)
        {
            //if (string.IsNullOrWhiteSpace(this.Database))
            //{
            //    return null;
            //}

            //if (!this.SkipValidation)
            //{
            //    if (!this.Validated)
            //    {
            //        await this.ValidateAsync(AccessTypeEnum.Read, this.LoginId, this.Database, false).ConfigureAwait(false);
            //    }
            //    if (!this.HasAccess)
            //    {
            //        Log.Information($"Access to view meta information on entity \"{this.FullyQualifiedObjectName}\" was denied to the user with Login ID {this.LoginId}");
            //        throw new UnauthorizedException(Resources.AccessIsDenied);
            //    }
            //}

            //try
            //{
            //    return await EntityView.GetAsync(this.Database, this.PrimaryKey, this._ObjectNamespace, this.GetTableName()).ConfigureAwait(false);
            //}
            //catch (DbException ex)
            //{
            //    Log.Error(ex.Message);
            //    throw new DataAccessException(this.Database, ex.Message, ex);
            //}
            SetValues(schemaName, tableName, tenant, loginId, userId);
            return await _entityViews.GetAsync(this.Database, this.PrimaryKey, this._ObjectNamespace, this.GetTableName());
        }

        private void SetValues(string schemaName, string tableName, string database, long loginId, int userId)
        {
            //var me = AppUsers.GetCurrentAsync().GetAwaiter().GetResult();
            var me = new LoginView
            {
                UserId = 1,
                IsAdministrator = true,
                LoginId = 1,
                OfficeId = 1,
                RoleId = 1,
                CurrencyCode = "USD"
            };

            this._ObjectNamespace = Sanitizer.SanitizeIdentifierName(schemaName);
            this._ObjectName = Sanitizer.SanitizeIdentifierName(tableName.Replace("-", "_"));
            this.LoginId = me.LoginId;
            this.OfficeId = me.OfficeId;
            this.UserId = me.UserId;
            this.Database = database;
            this.LoginId = loginId;
            this.UserId = userId;

            if (!string.IsNullOrWhiteSpace(this._ObjectNamespace) &&
                !string.IsNullOrWhiteSpace(this._ObjectName))
            {
                this.FullyQualifiedObjectName = this._ObjectNamespace + "." + this._ObjectName;
                this.PrimaryKey = this.GetCandidateKey();
                this.LookupField = this.GetLookupField();
                this.NameColumn = this.GetNameColumn();
                this.IsValid = true;
            }
        }
    }
}
