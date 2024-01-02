#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 命名空间：UpperComputerSoftware
 * 文件名：Test
 * 
 * 创建者：夏浩
 * 电子邮箱：🤮🤮🤮🤮
 * 创建时间：2023/3/7 20:37:00
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 修改人：夏浩
 * 时间：2023/3/7 20:37:00
 * 修改说明：
 *
 * 版本：V1.0.1
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>

using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;
<<<<<<< HEAD
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
=======
>>>>>>> 47918044a81170e4fe7c9b34c2884e25f3dfd583

namespace TestProject
{

    public class Test
    {
        #region 零碎知识

        /* sealed(密封的)
       * sealed(密封的) :阻止别的类继承
       */

        #region ref out

        /* ref需要初始化(先定义变量且赋值)
         *  int a = 6;
         *  int b = 66;
         * Fun(ref a,ref b);
         * 
         * out不需要初始化(先定义变量不需赋值)
         *  int a=100;
         *  int b;
         *  Fun(out a, out b);
         */

        #endregion

        #region 字符串转时间
        //DateTime dateTime = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
        #endregion

        #endregion

        #region 命名规范
        //类名和结构体名：使用帕斯卡命名法（PascalCase），每个单词的首字母大写，不包含下划线或连字符。例如：StringBuilder。
        //接口名：使用帕斯卡命名法（PascalCase），以大写字母 “I” 开头。例如：IDisposable。
        //枚举类型名：使用帕斯卡命名法（PascalCase），单数形式。例如：DayOfWeek。
        //委托名：使用帕斯卡命名法（PascalCase），以 “Delegate” 结尾。例如：Action。
        //方法名：使用帕斯卡命名法（PascalCase）或驼峰命名法（camelCase）。例如：GetString、getConfiguration。
        //属性名：使用帕斯卡命名法（PascalCase）或驼峰命名法（camelCase）。例如：Length、firstName。
        //变量名：使用驼峰命名法（camelCase）。例如：totalCount。
        //常量名：使用大写字母和下划线命名法（UPPER_CASE_WITH_UNDERSCORES）。例如：MAX_LENGTH。
        //私有字段名：使用带有下划线的驼峰命名法（camelCase），以一个下划线开头，后续单词的首字母大写。例如：_privateField。
        //参数名：使用驼峰命名法（camelCase）。例如：inputString。
        //事件名：使用帕斯卡命名法（PascalCase），以 “Event” 结尾。例如：ClickEvent。
        //委托实例名：使用驼峰命名法（camelCase），以一个 “handler” 后缀结尾。例如：buttonClickHandler。
        #endregion

        #region UML图六种箭头的含义(泛化、实现、依赖、关联、聚合、组合)(https://blog.csdn.net/qq_20936333/article/details/86773664)

        /*泛化(继承)—▹
         * 一般与特殊、一般与具体
         * 表示:用实线空心三角箭头表示
         */

        /*实现---▹
         * 类与接口的关系
         * 表示:空心三角形箭头的虚线，实现类指向接口
         */

        /*依赖--->
         * 是一种使用的关系，即一个类的实现需要另一个类的协助
         * 表示:虚线箭头，类A(有方法的类)指向类B
         */

        /*关联—>
         * 表示类与类之间的联接,它使一个类知道另一个类的属性和方法，这种关系比依赖更强、不存在依赖关系的偶然性、关系也不是临时性的，一般是长期性的
         * 表示:实线箭头，类A(主使用类)指向类B
         * 一个类的全局变量引用了另一个类，就表示关联了这个类
         */

        /*聚合◇—
         * 聚合关联关系的一种特例，是强的关联关系。聚合是整体和个体之间的关系，即has-a的关系，整体与个体可以具有各自的生命周期，部分可以属于多个整体对象，也可以为多个整体对象共享。程序中聚合和关联关系是一致的，只能从语义级别来区分；
         * 表示:尾部为空心菱形的实线箭头（也可以没箭头），类A(被聚合的类)指向类B
         */

        /*组合◆—
         * 组合也是关联关系的一种特例。组合是一种整体与部分的关系，即contains-a的关系，比聚合更强。部分与整体的生命周期一致，整体的生命周期结束也就意味着部分的生命周期结束，组合关系不能共享。程序中组合和关联关系是一致的，只能从语义级别来区分。
         * 表示:尾部为实心菱形的实现箭头（也可以没箭头），类A(被组合的类)指向类B
         * 
         */

        #endregion

        #region 软件设计七大原则
        /*开闭原则
         * 当应用的需求改变时，在不修改软件实体的源代码或者二进制代码的前提下，可以扩展模块的功能，使其满足新的需求
         */

        /*里氏转化原则
         * 任何基类可以出现的地方，子类一定可以出现
         */

        /*依赖倒置原则
         * 针对接口编程，依赖于抽象而不依赖于具体
         */

        /*单一职责原则
         * 就一个类而言，应该仅有一个引起它变化的原因。简而言之，就是功能要单一。
         */

        /*接口隔离原则
         * 使用多个隔离的接口，比使用单个接口要好
         */

        /*迪米特原则
         * 一个实体应当尽量少地与其他实体之间发生相互作用
         */

        /*合成复用原则
         * 尽量使用合成/聚合的方式，而不是使用继承
         */


        #endregion

        #region 软件设计23种设计模式(https://blog.csdn.net/A1342772/article/details/91349142)

        #region 创建型模式5(关注类的创建-怎么new 一个对象)

        /*工厂方法模式*/
        /*抽象工厂模式*/
        /*单例模式*/
        /*建造者模式*/
        /*原型模式*/

        #endregion

        #region 结构型模式7(关注类与类之间的关系-是继承还是组合)
        /*适配器模式*/
        /*装饰器模式*/
        /*代理模式*/
        /*外观模式*/
        /*桥接模式*/
        /*组合模式*/
        /*享元模式*/
        #endregion

        #region 行为型模式12(关注对象与行为的分离-合理的放置方法在哪个类)
        /*策略模式*/

        /*模板方法模式*/

        /*观察者模式*/

        /*迭代子模式*/

        /*责任链模式(击鼓传花)
         * 定义:请求的发送者和接受者解耦，请求沿着责任链传递，直到有一个对象处理了它为止
         * 使用:在处理消息的时候以过滤很多道
         */
        /*命令模式*/
        /*备忘录模式*/
        /*状态模式*/
        /*访问者模式*/
        /*中介者模式*/
        /*解释器模式*/
        #endregion

        #endregion

        #region 设计技巧

        #region 设置部分代码只在调试状态下运行的一种方法

#if DEBUG
        //这里写只在调试的时候才执行的代码。
#endif

        // 对于方法，在方法前面加上[Conditional("DEBUG")]
        [Conditional("DEBUG")]
        public static void DebugMethod()
        {
            Console.WriteLine("调试模式。");
        }
        #endregion


        #region 深拷贝
        public static T DeepCopyByReflection<T>(T obj)
        {
            if (obj is string || obj.GetType().IsValueType)
                return obj;

            object retval = Activator.CreateInstance(obj.GetType());
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            foreach (var field in fields)
            {
                try
                {
                    field.SetValue(retval, DeepCopyByReflection(field.GetValue(obj)));
                }
                catch { }
            }

            return (T)retval;
        }
        #endregion

        #endregion

        #region git技巧

        #endregion

        #region 基础知识

        #region C#异步编程
        //1.通过委托实现异步(BeginInvoke，EndInvoke)
        //2.通过 Task 实现异步
        //3.通过 await/async 实现异步
        //4.通过 BackgroundWorker 实现异步


        #endregion

        #region 线程同步
        // 锁 SpinLock(自旋锁) 、Mutex(互斥锁)、Monitor、lock
        #endregion

        #region 控件绑定数据源

        #region DataBindings
        /* 引用控件.DataBindings.Add("控件属性", 实例对象, "属性名", true);
         * 修改tbName的Text值时_people的Name值也会改变，但是修改_people的Nam值时tbName的Text值并不会改变
         * 
         */
        #region MyRegion
        public class People : INotifyPropertyChanged
        {
            string _name;
            int _age;

            public string Name
            {
                get { return _name; }
                set
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }

            public int Age
            {
                get { return _age; }
                set
                {
                    _age = value;
                    OnPropertyChanged(nameof(Age));
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)  //属性变更通知
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
        #endregion

        //People _people = new People();
        //tbName.DataBindings.Add("Text", _people, "Name");
        #endregion

        #region Binding

        /*代表某对象属性值和某控件属性值之间的简单绑定
         */
        public void databing()
        {
<<<<<<< HEAD
            System.Windows.Forms.TextBox tbAge = new System.Windows.Forms.TextBox();
=======
            TextBox tbAge = new TextBox();
>>>>>>> 47918044a81170e4fe7c9b34c2884e25f3dfd583
            //tbAge.DataBindings.Add(nameof(tbAge.Text), _people, nameof(_people.Age), true, DataSourceUpdateMode.OnPropertyChanged, "0", "X4");
        }


        #endregion

        #region BindingSource
        /* BindingSource：封装窗体的数据源 
         * IList接口（包括一维数组，ArrayList等）
         * IListSource接口（DataTable、DataSet等）
         * IBindingList接口（如BindingList类）
         * IBindingListView接口（如BindingSource类）
         * 自定义控件用来显示或者设置某个对象的属性值，就可以用到BindingSource
         */
        //public partial class UserControl1 : UserControl
        //{
        //    public UserControl1()
        //    {
        //        this.bindingSource1.DataSource = typeof(People);
        //        People p = this.bindingSource1.DataSource as People;
        //        this.tbName.DataBindings.Add(nameof(this.tbName.Text), this.bindingSource1, nameof(p.Name));
        //        this.tbAge.DataBindings.Add(nameof(this.tbAge.Text), this.bindingSource1, nameof(p.Age), true, DataSourceUpdateMode.OnValidation);
        //        this.errorProvider1.DataSource = this.bindingSource1;
        //    }

        //    public People People
        //    {
        //        get { return this.bindingSource1.DataSource as People; }
        //        set
        //        {
        //            this.bindingSource1.DataSource = value;
        //        }
        //    }
        //}

        public partial class UserControl1 : UserControl
        {
            UserControl userControl = new UserControl();
            BindingSource bindingSource1 = new BindingSource();//创建BindingSource
            DataGridView dataGridView1 = new DataGridView();//创建BindingSource

            public UserControl1()
            {
                List<People> listPeople = new List<People>
        {
            new People{ Name = "A", Age = 1 },
            new People{ Name = "B", Age = 2 },
            new People{ Name = "C", Age = 3 },
        };
                this.bindingSource1.DataSource = listPeople;
                this.dataGridView1.DataSource = this.bindingSource1;
            }

            private void btnAdd_Click(object sender, EventArgs e)
            {
                //this.bindingSource1.AddNew();
                this.bindingSource1.Add(new People { Name = "GG", Age = 34 });
            }

            private void btnUpdate_Click(object sender, EventArgs e)
            {
                People p = this.bindingSource1.Current as People;
                p.Name = "U";
            }

            private void btnDelete_Click(object sender, EventArgs e)
            {
                //this.bindingSource1.RemoveCurrent();   //移除资源当前项
                foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
                {
                    this.bindingSource1.Remove(row.DataBoundItem);
                }
            }

            private void btnSort_Click(object sender, EventArgs e)
            {
                this.bindingSource1.Sort = "Name desc";
                this.bindingSource1.RemoveSort();  //去除排序，恢复显示
            }

            private void btnSelect_Click(object sender, EventArgs e)
            {
                this.bindingSource1.Filter = "Age = '2'";
                this.bindingSource1.RemoveFilter();  //去除筛选，恢复显示
            }
        }

<<<<<<< HEAD
        System.Windows.Forms.ComboBox comboBox1 = new System.Windows.Forms.ComboBox();
=======
        ComboBox comboBox1 = new ComboBox();
>>>>>>> 47918044a81170e4fe7c9b34c2884e25f3dfd583
        private void InitialComboboxByObject()
        {

            Dictionary<int, string> kvDictonary = new Dictionary<int, string>();
            kvDictonary.Add(1, "11111");
            kvDictonary.Add(2, "22222");
            kvDictonary.Add(3, "333333");

            BindingSource bs = new BindingSource();
            bs.DataSource = kvDictonary;
            comboBox1.DataSource = bs;
            comboBox1.ValueMember = "Key";
            comboBox1.DisplayMember = "Value";

        }


        #endregion

        #region fody控件绑定
        /*fody使用流程
         * 1.安装Fody包（只能安装包）
         * 2.安装PropertyChanged.Fody包（只能安装包）
         * 
         */
        [AddINotifyPropertyChangedInterface]
        public class Person
        {
            [AlsoNotifyFor(nameof(FullName))]//通知属性
            public string GivenName { get; set; }


            public string FamilyName { get; set; }

            [DependsOn(nameof(FullName), nameof(FamilyName))]//依赖
            public string FullName => $"{GivenName} {FamilyName}";


            [DoNotNotify]//不添加
            [DoNotCheckEquality]//不检测相等
            public int Age { get; set; }


            void myMethod()
            {

            }


            [OnChangedMethod(nameof(myMethod))]
            public int AgeChange { get; set; }
        }


        #endregion

        #endregion

        /*堆和栈
         * 栈空间比较小，但是读取速度快
         * 栈的特征：
         * 数据只能从栈的顶端插入和删除
         * 把数据放入栈顶称为入栈（push）
         * 从栈顶删除数据称为出栈（pop）
         * 堆空间比较大，但是读取速度慢
         * 与栈不同，堆里的内存能够以任意顺序存入和移除
         */

        /*const和readonly
         * const关键字限定一个变量不允许被改,使用const在一定程度上可以提高程序的安全性和可靠性。
         * readonly是在计算时执行的，所以它可以用某些常量初始化
         */

        /*默认值
         *var mm = default(int);
         */

        #region 标准的单例

        /*写双重判断的原因如下
        在极低的几率下，通过if(instance == NULL)的线程才会有进入锁定临界区的可能性，这种几率还是比较低的，
        不会阻塞太多的线程，但为了防止一个线程进入临界区创建实例，另外的线程也进去临界区创建实例，
        又加上了一道防御if(instance == NULL)，这样就确保不会重复创建了。
        */
        private static Test instance = null;

        private static readonly object Lock_instance = new object();

        public static Test GetInstance()
        {
            if (instance == null)
            {
                lock (Lock_instance)
                {
                    if (instance == null)
                    {
                        instance = new Test();
                    }
                }
            }
            return instance;
        }

        #endregion


        /* 索引器
         * 使用索引器可以用类似于数组的方式为对象建立索引。
         * get 取值函数返回值。 set 取值函数分配值。
         * this 关键字用于定义索引器。
         * value 关键字用于定义由 set 访问器分配的值。
         * 索引器不必根据整数值进行索引；由你决定如何定义特定的查找机制。
         * 索引器可被重载。
         * 索引器可以有多个形参，例如当访问二维数组时
         * 访问多个数据成员，就需要使用索引器
         */
        #region 索引器示例
        private string name;
        private string sex;
        private string tel;
        //索引器
        public string this[int index]//【访问修饰符】 数据类型 this【索引器类型 index】   语法格式
        {
            get
            {
                switch (index)
                {
                    case 1://由于return就有返回功能和结束功能所以这里的break可以省略因为写了运行不到这句代码
                        return name;
                    case 2:
                        return sex;
                    case 3:
                        return tel;
                    default:
                        throw new ArgumentOutOfRangeException("index");//抛出异常
                }
            }
            set
            {
                switch (index)
                {
                    case 1://这里必须要有break结束语句，因为每个case的功能语句都是赋值且没有结束语句所以这里需要break
                        name = value;
                        break;
                    case 2:
                        sex = value;
                        break;
                    case 3:
                        tel = value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("index");//抛出异常
                }
            }
        }

        public void indexer()
        {
            Test test = new Test();
            var teststring = test[0];

        }

        #endregion


        /*静态方法
         * 特点：1.生命周期-一旦创建到应用程序结束才会结束
         *       2.全局性质
         *       3.效率高
         * 用处：用户登录，系统配置，SQLHelper
         * 坏处：静态的东西会占用很大内存
         */

        /*构造方法
        * 特点：1.默认是有的
        *       2.默认无参数，支持重载
        *       3.效率高
        * 用处：初始化对象，加载初始数据
        */

        /*析构方法
        * 特点：1.GC垃圾回收器在调用
        *       2.99%不需要调用
        * 用处：1.释放对象(窗口句柄，数据库对象，GDI对象，文件锁)
        */
        #region 析构方法示例
        ~Test()
        {

        }
        #endregion


        /*virtual 
         * 关键字用于修改方法、属性、索引器或事件声明，并使它们可以在派生类中被重写
         * 对应的是override (重写)
         */

        /*虚方法(virtual)
        * 特点：1.好维护，不改源代码
        * 用处：1.允许子类重写，实现不一样的功能
        */

        /*abstract(抽象)
         * abstract 修饰符可用于类、方法(可以是虚方法，或者实体方法)、属性、索引和事件
         * 抽象类可能包含抽象方法和访问器与sealed相对
         * 派生自抽象类的非抽象类，必须包含全部已继承的抽象方法和访问器的实际实现
         * 对应的是override (重写)
         * 抽象类只能单继承
         */
        #region 抽象类示例
        public abstract class AbstractTest
        {

            public abstract string this[int index] { get; set; }
            public abstract void Run();

            public abstract event EventHandler Event_Test;
            public abstract string StrStack { get; set; }
            public virtual string VirtualStack1 { get; set; }
        }
        public void mmik()
        {
            AbstractTest abstractTest = new AbstractTestInherit();
            abstractTest.Run();
        }
        public class AbstractTestInherit : AbstractTest
        {
            public override string this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public override string StrStack { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public override event EventHandler Event_Test;

            public override void Run()
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        /*接口(Interface)
          * 特点：1.可以多继承
          *       2.可以当行为上的规范
          *       3.内部可以定义方法、属性、索引和事件
          * 用处：1.里士转化如接口转实体类
         */
        #region 接口示例
        interface InterfaceTest
        {
            void SampleMethod();

            event EventHandler Event_Test;
            string this[int index] { get; set; }
            string StrTest { get; set; }
        }
        #endregion

        /*抽象类和接口区别
         * 当个性大于共性时选接口-个性占主要功能
         * 共性大于个性选抽象类共性占主要功能
         * 当在差异较大的对象间寻求功能上的共性时，使用接口
         * 当在共性较多的对象间寻求功能上的差异时，使用抽象基类
         */

        /*扩展方法(静态类的静态方法-ExtendMethod)
        * 特点：1.对密封类的方法的扩展
        * 用处：1.增加类的作用
        *       2.扩展接口
        */
        #region 扩展方法示例
        public static class ExtendMethod
        {
            //public static string ExtendMethodTest(this string str)
            //{
            //    return "";
            //}
            //public static void ExtendMethod_Test(string str)
            //{
            //    var strtest = str.ExtendMethodTest();
            //}

            //public static void ExtendInterface(this InterfaceTest str)
            //{

            //}
        }
        #endregion


        /*泛型
         * 与object的区别object不指定类型，传进去非特定的类型会报错
         * T可以指定类型，这样就避免错误类型的输入
         * 最重要的用处 让泛型类，泛型方法，泛型接口，泛型为委托更加的通用
         * 可以约束，太通用的话就造成类型传入错误
         */
        /*协变
         *  使你能够使用比原始指定的类型派生程度更大的类型
         *  IEnumerable<Derived> d = new List<Derived>();
         *  IEnumerable<Base> b = d;
         *逆变
         *  使你能够使用比原始指定的类型更泛型（派生程度更小）的类型
         *  Action<Base> b = (target) => { Console.WriteLine(target.GetType().Name); };
         *  Action<Derived> d = b;
         *  d(new Derived());
         *不变性
         *只能使用最初指定的类型。 固定泛型类型参数既不是协变，也不是逆变
         */

        /*AOP
         * 面向切面编程
         * AOP是能够让我们在不影响原有功能的前提下，为软件横向扩展功能。
         */

        /*反射
         * 反射的类型有exe/dll(exe有入口)--metadata（元数据：描述exe/dll文件的一个数据清单）
         *反射(Reflection)用来操作元数据(metadata) 
         * [1]更新程序时(更新自己的dll)
         * [2]读取别人私有的东西
         */

        #region 反射
        /**Assembly(集会)*/
        public void ReflectionTest()
        {
            //加载dll
            #region 第一种加载方式
            //Assembly assembly = Assembly.Load("GeneralClassLibrary");
            //foreach (var item in assembly.GetTypes())
            //{
            //    //名称
            //    Console.WriteLine( $"{item.Name}//{item.FullName}");

            //    //方法
            //    foreach (var itemMethod in item.GetMethods())
            //    {
            //        Console.WriteLine($"{itemMethod.Name}");

            //    }
            //}
            #endregion

            #region 第二种加载方式
            //Assembly assemblyFile = Assembly.LoadFile(@"C:\Users\BBGO\source\repos\UpperComputerSoftware\bin\Debug\GeneralClassLibrary.dll");
            //foreach (var item in assemblyFile.GetTypes())
            //{
            //    //名称
            //    Console.WriteLine($"{item.Name}//{item.FullName}");

            //    //方法
            //    foreach (var itemMethod in item.GetMethods())
            //    {
            //        Console.WriteLine($"{itemMethod.Name}");

            //    }
            //}
            #endregion

            #region 第三种加载方式(推荐)
            //可以是完全路径或者文件名
            //Assembly assemblyFile = Assembly.LoadFrom("GeneralClassLibrary.dll");
            //foreach (var item in assemblyFile.GetTypes())
            //{
            //    //名称
            //    Console.WriteLine($"{item.Name}//{item.FullName}");

            //    //方法
            //    foreach (var itemMethod in item.GetMethods())
            //    {
            //        Console.WriteLine($"{itemMethod.Name}");

            //    }
            //}
            #endregion

            #region 使用反射创建对象
            //可以是完全路径或者文件名
            //Assembly assemblyFile = Assembly.LoadFrom("GeneralClassLibrary.dll");
            //Type type = assemblyFile.GetType("GeneralClassLibrary.Form1");//获取类型(完整的路径)
            //Form mllll = Activator.CreateInstance(type) as Form;//获取实例
            //mllll.Show();
            #endregion

            #region 使用反射创建对象(带参数)
            //Assembly assemblyFile = Assembly.LoadFrom("GeneralClassLibrary.dll");
            //Type type = assemblyFile.GetType("CommomLibrary.PDFHelper");//获取类型(完整的路径)
            #endregion

            #region 获取参数类型和具有参数的构造函数


            //foreach (ConstructorInfo item in type.GetConstructors())
            //{
            //    Console.WriteLine(item.Name);
            //    foreach (var item12 in item.GetParameters())
            //    {
            //        Console.WriteLine(item12.ParameterType);
            //    }
            //}
            //object  mllll = Activator.CreateInstance(type,new object[] { "12352"}) ;
            #endregion

            #region 调用私有构造函数
            //Assembly assemblyFile = Assembly.LoadFrom("GeneralClassLibrary.dll");
            //Type type = assemblyFile.GetType("CommomLibrary.PDFHelper");//获取类型(完整的路径)
            //object mllll = Activator.CreateInstance(type,true) ;//获取实例 

            #endregion

            #region 调用构造函数(泛型)
            //Assembly assemblyFile = Assembly.LoadFrom("GeneralClassLibrary.dll");
            //Type type = assemblyFile.GetType("CommomLibrary.PDFHelper`3");//获取类型(完整的路径)
            //Type newType = type.MakeGenericType(new Type[] { typeof(int) });
            //object mllll = Activator.CreateInstance(newType);//获取实例 

            #endregion

            #region 调用方法
            //Assembly assemblyFile = Assembly.LoadFrom("GeneralClassLibrary.dll");
            //Type type = assemblyFile.GetType("CommomLibrary.PDFHelper`3");//获取类型(完整的路径)
            //object mllll = Activator.CreateInstance(type);//获取实例 
            //foreach (var methods in type.GetMethods())
            //{
            //    Console.WriteLine(methods.Name);
            //    foreach (var item in methods.GetParameters())
            //    {
            //        Console.WriteLine(item.ParameterType);
            //    }
            //}

            //MethodInfo methodInfo = type.GetMethod("方法名");
            //methodInfo.Invoke(mllll,null);//无参数
            //methodInfo.Invoke(mllll,new object[] { 123});//有参数

            //多态
            //methodInfo = type.GetMethod("方法名",new Type[] { typeof(int)});//重载方法
            //methodInfo.Invoke(mllll,new object[] { 123});//有参数

            //泛型方法的调用
            //MethodInfo methodInfo = type.GetMethod("方法名");
            //MethodInfo methodInfoGeneric = methodInfo.MakeGenericMethod(new Type[] { typeof(int) });
            //methodInfoGeneric.Invoke(mllll, new object[] { 123 });

            //泛型类-泛型方法的调用
            //Assembly assemblyFile = Assembly.LoadFrom("GeneralClassLibrary.dll");
            //Type type = assemblyFile.GetType("CommomLibrary.PDFHelper`3");//获取类型(完整的路径)
            //Type newType = type.MakeGenericType(new Type[] { typeof(int) });
            //object mllll = Activator.CreateInstance(newType);//获取实例 
            //MethodInfo methodInfo = newType.GetMethod("方法名");
            //MethodInfo methodInfoGeneric = methodInfo.MakeGenericMethod(new Type[] { typeof(int) });
            //methodInfoGeneric.Invoke(mllll, new object[] { 123 });
            #endregion

            #region 通过反射操作字段和属性成员

            #region 属性/字段


            //属性
            //var m = new { id = 1 };//匿名类型
            //PDFHelper pdfHelper = new PDFHelper() {int id=1 };
            //Assembly assemblyFile = Assembly.LoadFrom("GeneralClassLibrary.dll");
            //Type type = assemblyFile.GetType("CommomLibrary.PDFHelper");//获取类型(完整的路径)
            //object oStudent = Activator.CreateInstance(type);//获取实例 
            //foreach (var item in type.GetProperties())
            //{
            //    Console.WriteLine(item.PropertyType+item.Name+item.GetValue(pdfHelper));
            //    item.SetValue(pdfHelper, oStudent);
            //}
            #endregion
            #endregion

            #region 特性

            /*特性(贴标签产生新的功能)
             * 就是一个类继承自Attribute,只要继承这个类就是特性
             * 标记：类、方法、结构、枚举、组件，属性，参数，返回值
             * 特性分类：1.系统自带（可能会影响编译器的运行） 2.自定义的
             * 特性用处：数据验证，
             */

            AttributeTest2 AttributeTest1 = new AttributeTest2();
            var CC = AttributeTest1.getRemark(enumAttributeTest.id);
            Type type = typeof(AttributeTest2);
            object[] customAttribute = type.GetCustomAttributes(typeof(AttributeTest2), true);
            foreach (var item in customAttribute)
            {
                AttributeTest itemtest = item as AttributeTest;
                if (itemtest != null)
                {
                    itemtest.DoMathod();
                }
            }

            #endregion

        }

        #endregion

        #region 特性实例

        public class AttributeTest2
        {
            public void DoMathod()
            {
                Console.WriteLine("test");
            }
            public string getRemark(enumAttributeTest enumAttr)
            {
                Type type = enumAttr.GetType();
                var filed = type.GetField(enumAttr.ToString());
                if (filed.IsDefined(typeof(Remark), true))
                {
                    Remark RemarkAttributetest = (Remark)filed.GetCustomAttribute(typeof(Remark), true);
                    return RemarkAttributetest.Des;
                }
                return null;
            }
        }
        public class AttributeTest : Attribute
        {
            [DebuggerStepThrough]
            [Obsolete("过时", false)]
            public void DoMathod()
            {
                Console.WriteLine("test");
            }

        }
        [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
        public class Remark : Attribute
        {

            public Remark(string des)
            {
                this.Des = des;
                Console.WriteLine(des);
            }


            public string Des { get; private set; }
        }
        public enum enumAttributeTest
        {
            [Remark("1233")]
            id
        }

        #endregion

        #region 委托

        #region 常规委托

        public delegate void DelMethod();

        public void delMethodM() { }

        public void delMethodUtil()
        {
<<<<<<< HEAD
            DelMethod delMethod = new DelMethod(delMethodM);
=======
            DelMethod delMethod=new  DelMethod(delMethodM);
>>>>>>> 47918044a81170e4fe7c9b34c2884e25f3dfd583
        }


        #endregion


        #region 泛型委托实例
        delegate void DelGeneric<T>(T t);

        public class GenericDelegate
        {
            public static void InvoleDelgate()
            {
                DelGeneric<string> delGeneric = new DelGeneric<string>(Method);
                delGeneric.Invoke("adv");
            }

            public static void Method(string str)
            {
                Console.WriteLine(str);
            }


            public string MethodFunc(string str)
            {

                Console.WriteLine(str);
                return "ok";
            }

        }
        #endregion

        public static class GenericDelegate1
        {
            public static string MethodFunc(string str)
            {
                Console.WriteLine(str);
                return "ok";
            }
            static event DelGeneric<string> DelGeneric;
            public static void EventTest(string str)
            {
                DelGeneric?.Invoke(str);
                func += MethodFunc;
                func += MethodFunc;
                func.Invoke(str);
            }

            static Func<string, string> func = new Func<string, string>(MethodFunc);

            //static Action<string, string> actin = new Action<string, string>(MethodFunc);
        }

        #region 多播委托(MulticastDelegate)

        //委托链 一个委托可以触发多个委托(+=,-=)

        #endregion
        #endregion

        #region 事件
        /*事件是委托的安全版本
         * 只能用+=不能用=
         * 事件的特性是在哪个类里面就得在哪个类里面调用（只能在该类中Invoke，防止借刀杀人）
         * 委托可以直接invoke
         * 事件是在委托前面加个Event
         */
        public delegate void DelTest(string str);
        public event DelTest Event_Test;

        public void EvenTest(string str)
        {
            Event_Test.Invoke(str);
            Event_Test += EvenTest2;
        }
        public void EvenTest2(string str)
        {

        }
        #endregion

        #region winform事件

        /*
         *   private void TestProject_Load(object sender, EventArgs e)
         *   sender 表示控件  e表示事件参数
         *   this.Load += new System.EventHandler(this.TestProject_Load);
         *   EventHandler就是一个委托
         */
        #endregion

        #region 自定义标准事件

        /*发布者在+=左边
         * 订阅者在发布者右边
         */

        /*下面实例参数是针对控件参数
         */


        /// <summary>
        /// 发布者
        /// </summary>
        public class Publiser
        {
            public event EventHandler<CustomEventArgs> CustomEvent;

            protected virtual void OnCustomEvent(CustomEventArgs eventArgs)
            {
                CustomEvent.Invoke(this, eventArgs);
            }

            public void DoSomethings()
            {
                OnCustomEvent(new CustomEventArgs("事件参数"));
            }


        }

        public class CustomEventArgs : EventArgs
        {
            public CustomEventArgs(string message)
            {
                Message = message;
            }
            public string Message { set; get; }
        }

        /// <summary>
        /// 订阅者
        /// </summary>
        public class Subsciber
        {
            public Subsciber(string str, Publiser publiser)
            {
                Str = str;
                publiser.CustomEvent += HanderCustomEvent;
            }

            private readonly string Str;
            private void HanderCustomEvent(object sender, CustomEventArgs e)
            {
                Console.WriteLine($"发布者：{sender.GetType()}{nameof(e)}");
            }
        }
        #endregion

        /*Lambda:匿名方法
         * 
         */
        #region Lambda
        public void Lambda()
        {
            Action action = () => Console.WriteLine();
            Action<string> action1 = d => Console.WriteLine(d);
            Func<string> func = () => { return ""; };
            Func<string, string> func1 = d => { return d; };
            string mm = func();

        }
        #endregion

        #region Linq
        /*Linq(Language Integrated Query)语言继承查询
         * Linq to object 对象查询
         * Linq to XML XML查询
         * Linq to ADO.NET 数据库查询
         * Linq 核心就是对数据源查询的操作
         */


        /*普通查询*/
        List<object> listObject = new List<object>();
        public void Linq()
        {
            var listobject = listObject.Where(x => x != null).ToList();
            var listobjects = from s in listobject
                              where s != null
                              select s;

        }
        //public static List<T> LinqExtend<T>(this List<T> objects, Func<object, bool> func)
        //{
        //    var list = new List<T>();
        //    foreach (var item in objects)
        //    {
        //        if (func.Invoke(item))
        //        {
        //            list.Add(item);

        //        }
        //    }
        //    return list;
        //}
        #endregion

        #endregion

        #region 数据结构

        public class DataStruct
        {
            List<object> list;

            public DataStruct()
            {
            }
            /*
             * 数据
             * 数据元素
             * 数据项
             * 数据对象
             */

            /*CLR=Common Language Runtime 公共语言运行时
             *BCL=Base Class Library，基底类别库
             *DLL=Dynamic Link Library 动态链接库 元件=CLR+BCL
             *Assembly=程序集=.exe+.dll
             */

            /*数据结构：集合，线性结构，树形结构，图状结构
             */

            /*算法：解题步骤
             * 评价标准：运行时间，占用空间，正确性，可读性，健壮性
             */

            /*线性表（List<T>）
             * 
             */
        }


        #endregion
<<<<<<< HEAD


        #region 技术服务

        #region 组合键使用

        //窗体属性设置=>   keyPreview=true
        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData == (Keys.Control | Keys.H | Keys.M))
        //    {
        //        // 执行保存操作
        //        return true; // 返回true表示已经处理了按键事件
        //    }
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}
        #endregion

        #endregion


        #region 计算机知识
        //Windows API三大模块KERNEL32.DLL、USER32.DLL和GDI32.DLL
        //user32.dll
        //是Windows用户界面相关应用程序接口，用于包括Windows处理，基本用户界面等特性，如创建窗口和发送消息

        //gdi32.dll
        //gdi32.dll是Windows GDI图形用户界面相关程序，包含的函数用来绘制图像和显示文字

        //kernel32.dll
        //控制着系统的内存管理、数据的输入输出操作和中断处理

        //微软就是靠这三个模块起家的
        //Windows SDK只利用这三个模块就能构建基本的Windows程序。

        #endregion
=======
>>>>>>> 47918044a81170e4fe7c9b34c2884e25f3dfd583
    }




}
