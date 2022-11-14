using System.Data;
using Npgsql;
using DAL.Entities;
using System.Reflection;
using Core.Dal.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.AppDBContext.SQL
{
    /// <summary>
    /// Базовый репозиторий для работы с SQL
    /// </summary>
    public abstract class AppDBContext<TModel, TType> : DbContext, IRepository<TModel, TType>
        where TModel : BaseSqlModelDal<TType>
    {

        private readonly DalSetting _dalSetting;

        private IDbConnection _dbConnection;

        private DbSet<TModel> Model { get; set; }

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

        protected string TableName =>
        typeof(TModel).GetCustomAttribute<CustomTableNameAttribute>(true)?.Name
        ?? typeof(TModel).Name.ToLowerInvariant();

        public void Dispose()
        {
            if (_dbConnection != null)
            {
                _dbConnection.Dispose();
            }
        }

        public void Delete(TType id)
        {
            throw new NotImplementedException();
        }
        
        public void Save()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TModel> GetAll(IDbTransaction transaction = null)
        {
            return Model.ToList();
        }

        public TModel GetItem(TType id)
        {
            var item = Model.Find(id);
            return item;
        }

        public void Create(TModel item)
        {
            Model.Add(item);
            SaveChanges();
        }

        public void Update(TModel item)
        {
            Model.Update(item);
            SaveChanges();
        }
    }
}
