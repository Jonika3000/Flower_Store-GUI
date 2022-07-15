namespace Flower_Store
{
    public partial class Login : Form
    {
        string logintmp;
        string passwordtmp;
      public  List<User> users = new List<User>();
        public FlowerStor  flowerStore = new FlowerStor();
      public  List<Order> orders = new List<Order>();
      public  User adm = new User("Admin", "Admin");
        public Login()
        {
            InitializeComponent();
            users.Add(adm);
            Text = "Sing in";
            button1.Click += ButtonLogin;
            button2.Click += ButtonRegister;
        }
        void ButtonLogin(object sender, EventArgs e)
        {
            User r = new User();
            r.Login = textBox1.Text;
            r.Password = textBox2.Text;
            
            var d = users.Where(a => a.Login == r.Login && a.Password == r.Password).FirstOrDefault();//search user
            if (textBox1 == null && textBox2 == null)
            {
                Error("All fields are not filled");
            }
            else if (d != null)
            {
               if (d.Login == adm.Login && d.Password ==adm.Password)
                {
                    //admin menu
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    label3.Text = string.Empty;
                    this.Hide();
                    Admin_Menu admin_Menu = new Admin_Menu(d);
                    admin_Menu.ShowDialog();
                }
               else
                {
                    //simple user login
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    label3.Text = string.Empty;
                    this.Hide();
                    User_Menu m = new User_Menu(d);
                    m.ShowDialog();
                }
            }
            else
            {
                Error("There is no such user");
            }
        }
        void ButtonRegister(object sender, EventArgs e)
        {
            User r = new User();
            r.Login = textBox1.Text;
            r.Password = textBox2.Text;
            if (textBox2.Text.Length >= 6)
            {
                var d = users.Where(a => a.Login == r.Login).FirstOrDefault();

                if (d == null && r.Password != string.Empty && r.Login != string.Empty)
                {
                    users.Add(r);
                    label3.Visible = true;
                    label3.Text = "You have registered successfully";
                    this.label3.ForeColor = System.Drawing.Color.Green;
                }
                else if (d != null)
                {
                    Error("This user already exists");
                }

                else if (r.Password == null && r.Login == null)
                {
                    Error("Not all fields are filled");
                }
            }
            else
            {
                Error("Password is too small");
            }
        }
        void Error (string ex) //errors 
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}