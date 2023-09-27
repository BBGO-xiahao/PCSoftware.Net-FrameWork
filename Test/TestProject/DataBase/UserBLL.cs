using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.DataBase
{
   
        /// <summary>
        /// user
        /// </summary>
        public partial class UserBLL
    {
            private readonly UserDAL dal = new UserDAL();
            public UserBLL()
            { }
            #region  BasicMethod

            /// <summary>
            /// 增加一条数据
            /// </summary>
            public bool Add(User model)
            {
                return dal.Add(model);
            }

            /// <summary>
            /// 更新一条数据
            /// </summary>
            public bool Update(User model)
            {
                return dal.Update(model);
            }

            /// <summary>
            /// 删除一条数据
            /// </summary>
            public bool Delete(long id)
            {
                //该表无主键信息，请自定义主键/条件字段
                return dal.Delete(id);
            }

            /// <summary>
            /// 得到一个对象实体
            /// </summary>
            public User GetModel()
            {
                //该表无主键信息，请自定义主键/条件字段
                return dal.GetModel();
            }

          

            /// <summary>
            /// 获得数据列表
            /// </summary>
            public DataSet GetList(string strWhere)
            {
                return dal.GetList(strWhere);
            }
            /// <summary>
            /// 获得数据列表
            /// </summary>
            public List<User> GetModelList(string strWhere)
            {
                DataSet ds = dal.GetList(strWhere);
                return DataTableToList(ds.Tables[0]);
            }
            /// <summary>
            /// 获得数据列表
            /// </summary>
            public List<User> DataTableToList(DataTable dt)
            {
                List<User> modelList = new List<User>();
                int rowsCount = dt.Rows.Count;
                if (rowsCount > 0)
                {
                    User model;
                    for (int n = 0; n < rowsCount; n++)
                    {
                        model = dal.DataRowToModel(dt.Rows[n]);
                        if (model != null)
                        {
                            modelList.Add(model);
                        }
                    }
                }
                return modelList;
            }

            /// <summary>
            /// 获得数据列表
            /// </summary>
            public DataSet GetAllList()
            {
                return GetList("");
            }

            /// <summary>
            /// 分页获取数据列表
            /// </summary>
            public int GetRecordCount(string strWhere)
            {
                return dal.GetRecordCount(strWhere);
            }
            /// <summary>
            /// 分页获取数据列表
            /// </summary>
            public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
            {
                return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
            }
            /// <summary>
            /// 分页获取数据列表
            /// </summary>
            //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
            //{
            //return dal.GetList(PageSize,PageIndex,strWhere);
            //}

            #endregion  BasicMethod
            #region  ExtensionMethod

            #endregion  ExtensionMethod
        }
    
}
