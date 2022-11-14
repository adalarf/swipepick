using DAL.Repository.Interfaces;
using System.Data;
using Npgsql;
using System.Data.Common;

namespace DAL.AppDBContext
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

        public void Save()
        {
            throw new NotImplementedException();
        }

        void IRepository<TModel, TType>.Create(TModel item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TModel> IRepository<TModel, TType>.GetAll(IDbTransaction transaction)
        {
            throw new NotImplementedException();
        }

        TModel IRepository<TModel, TType>.GetItem(TType id)
        {
            throw new NotImplementedException();
        }

        void IRepository<TModel, TType>.Update(TModel item)
        {
            throw new NotImplementedException();
        }
    }
}
