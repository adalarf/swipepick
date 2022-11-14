using System.Data;
using Npgsql;
using DAL.Entities;
using System.Reflection;
using Core.Dal.Repository.Interfaces;

namespace DAL.AppDBContext.SQL
{
    public abstract class AppDBContext<TModel, TType> : IRepository<TModel, TType>
        where TModel : BaseSqlModelDal<TType>
    {

        private readonly DalSetting _dalSetting;

        private IDbConnection _dbConnection;

        public AppDBContext(DalSetting dalSetting)
        {
            _dalSetting = dalSetting;
        }

        public IDbTransaction BeginTransaction(IsolationLevel il = IsolationLevel.Serializable)
        {
            return DbConnection.BeginTransaction();
        }

        public IDbConnection DbConnection
        {
            get
            {
                if (_dbConnection == null)
                {
                    _dbConnection = new NpgsqlConnection(_dalSetting.ConnectionString);
                    return _dbConnection;
                }

                return _dbConnection;
            }
        }

        public void Delete(TType id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (_dbConnection != null)
            {
                _dbConnection.Dispose();
            }
        }

        protected string TableName =>
        typeof(TModel).GetCustomAttribute<CustomTableNameAttribute>(true)?.Name
        ?? typeof(TModel).Name.ToLowerInvariant();

        public void Save()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TModel> GetAll(IDbTransaction transaction = null)
        {
            throw new NotImplementedException();
        }

        public TModel GetItem(TType id)
        {
            throw new NotImplementedException();
        }

        public void Create(TModel item)
        {
            throw new NotImplementedException();
        }

        public void Update(TModel item)
        {
            throw new NotImplementedException();
        }
    }
}
