using AWM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWMWfm.Model
{
    public class AWMRepository
    {
        private AWMDBContext context;
        public AWMDBContext Context { get { return context; } }
        public AWMRepository(AWMDBContext dbContext)
        {
            context = dbContext;
        }
        public AWMRepository()
        {
            context = new AWMDBContext();
        }
        #region Library for Services

        #region-To get all Query details
        public List<Query> GetAllQueries()
        {
            List<Query> lstQueries = null;
            try
            {
                lstQueries = (from p in context.Query
                               orderby p.ID
                               select p).ToList();
            }
            catch (Exception)
            {
                lstQueries = null;
            }
            return lstQueries;
        }
        #endregion
        #region-To get a Query detail by using Query Id
        public Query GetQueryById(string QueryID)
        {
            Query query = new Query();
            try
            {
                query = (from p in context.Query
                           where p.ID.Equals(QueryID)
                           select p).FirstOrDefault();
            }
            catch (Exception)
            {
                query = null;
            }
            return query;
        }
        #endregion
        #region- To add a new Query Using Entity Models 
        public bool AddQuery(Query query)
        {
            bool status = false;
            try
            {
                context.Query.Add(query);
                context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        #endregion
        #region- To Update a new Query Using Entity Models 
        public bool UpdateQuery(Query query)
        {
            bool status = false;
            try
            {
                var queryUpdate = (from qry in context.Query
                               where qry.ID == query.ID
                               select qry).FirstOrDefault<Query>();
                if (queryUpdate != null)
                {
                    queryUpdate.ID = query.ID;
                    queryUpdate.CreatedDate = query.CreatedDate;
                    queryUpdate.CreatedBy = query.CreatedBy;
                    queryUpdate.QueryText = query.QueryText;
                    queryUpdate.TypeId = query.TypeId;
                    queryUpdate.Priority = query.Priority;
                    queryUpdate.IsAssigned = query.IsAssigned;
                    queryUpdate.AssginedTo = query.AssginedTo;
                    context.SaveChanges();
                    status = true;
                }
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        #endregion
        #region-To delete a existing query
        public bool DeleteQuery(string queryId)
        {
            bool status = false;
            try
            {
                var query = (from qry in context.Query
                               where qry.ID == queryId
                               select qry).FirstOrDefault<Query>();
                context.Query.Remove(query);
                context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        #endregion
        #region-To get a Customer detail by using ID
        public Customer GetCustomerById(string customerID)
        {
            Customer customer = new Customer();
            try
            {
                customer = (from p in context.Customer
                            where p.ID.Equals(customerID)
                            select p).FirstOrDefault();
            }
            catch (Exception)
            {
                customer = null;
            }
            return customer;
        }
        #endregion
        #region-To get a Customer detail by using Phone Number/Email
        public Customer GetCustomerByNumberEmail(string phNumber,string email)
        {
            Customer customer = new Customer();
            try
            {
                customer = (from p in context.Customer
                         where p.MobileNumber.Equals(phNumber)
                         select p).FirstOrDefault();
                if(customer == null)
                {
                    customer = (from p in context.Customer
                                where p.Email.Equals(email)
                                select p).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                customer = null;
            }
            return customer;
        }
        #endregion
        #region-To get a Type detail by using Type Id
        public QueryType GetTypeById(string TypeID)
        {
            QueryType type = new QueryType();
            try
            {
                type = (from p in context.QueryType
                            where p.Id.Equals(TypeID)
                            select p).FirstOrDefault();
            }
            catch (Exception)
            {
                type = null;
            }
            return type;
        }
        #endregion
        #region- To add/Update a new Query Type Using Entity Models 
        public bool SaveQueryType(QueryType type)
        {
            bool status = false;
            try
            {
                context.QueryType.Add(type);
                context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        #endregion
        #region- To add a new Customer Using Entity Models 
        public bool AddCustomer(Customer customer)
        {
            bool status = false;
            try
            {
                context.Customer.Add(customer);
                context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        #endregion
        #region- To Update a new Query Using Entity Models 
        public bool UpdateCustomer(Customer customer)
        {
            bool status = false;
            try
            {
                var cstmUpdate = (from cstm in context.Customer
                                   where cstm.ID == customer.ID
                                   select cstm).FirstOrDefault<Customer>();
                if (cstmUpdate != null)
                {
                    cstmUpdate.ID = customer.ID;
                    cstmUpdate.FirstName = customer.FirstName;
                    cstmUpdate.LastName = customer.LastName;
                    cstmUpdate.Email = customer.Email;
                    cstmUpdate.MobileNumber = customer.MobileNumber;
                    context.SaveChanges();
                    status = true;
                }
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        #endregion
        #region-To get User detail by using User Id
        public User GetUserById(string userID)
        {
            User user = new User();
            try
            {
                user = (from p in context.User
                        where p.Id.Equals(userID)
                        select p).FirstOrDefault();
            }
            catch (Exception)
            {
                user = null;
            }
            return user;
        }
        #endregion
        #region-To get a Platform Setting detail by using Setting Name
        public PlatformSettings GetSettingByName(string settingName)
        {
            PlatformSettings setting = new PlatformSettings();
            try
            {
                setting = (from p in context.PlatformSettings
                        where p.SettingName.Equals(settingName)
                        select p).FirstOrDefault();
            }
            catch (Exception)
            {
                setting = null;
            }
            return setting;
        }
        #endregion
        #region- To add a new PlatformSetting Using Entity Models 
        public bool AddSetting(PlatformSettings setting)
        {
            bool status = false;
            try
            {
                context.PlatformSettings.Add(setting);
                context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        #endregion
        #endregion
    }
}
