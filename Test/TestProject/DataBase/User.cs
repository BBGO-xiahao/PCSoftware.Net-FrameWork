using System;
using System.Security.Principal;

namespace TestProject
{
    //如果实体类名称和表名不一致可以加上SugarTable特性指定表名
    /// <summary>
    /// user:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class User
    {
        public User()
        { }
        #region Model
        private int _id;
        private string _name;
        private int? _age;
        /// <summary>
        ///
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        ///
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        ///
        /// </summary>
        public int? age
        {
            set { _age = value; }
            get { return _age; }
        }
        #endregion Model

    }
}