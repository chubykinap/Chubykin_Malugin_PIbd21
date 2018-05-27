using Classes.BindingModels;
using Classes.ViewModels;
using System;
using System.Threading.Tasks;
using System.Web.UI;

namespace WebView
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private AdminViewModel element;
        private int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                element = Task.Run(() => APIClient.GetRequestData<AdminViewModel>("api/Admin/Get" + id)).Result;
                TextBox1.Text = element.Mail;
                TextBox2.Text = element.Login;
                TextBox3.Text = element.Password;
            }
            catch (Exception e)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ScriptAllertLoad", "<script>alert('" + e.Message + "');</script>");
            }
        }

        protected void ButtonReg_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox1.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Введите почту');</script>");
                return;
            }
            if (string.IsNullOrEmpty(TextBox2.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Введите логин');</script>");
                return;
            }
            if (string.IsNullOrEmpty(TextBox3.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Введите пароль');</script>");
                return;
            }
            Task task;
            if (Int32.TryParse((string)Session["id"], out id))
            {
                task = Task.Run(() => APIClient.PostRequestData("api/Admin/UpdElement", new AdminBindingModel
                {
                    ID = id,
                    Mail = TextBox1.Text,
                    Login = TextBox2.Text,
                    Password = TextBox3.Text
                }));
            }
            else
            {
                task = Task.Run(() => APIClient.PostRequestData("api/Admin/AddElement", new AdminBindingModel
                {
                    Mail = TextBox1.Text,
                    Login = TextBox2.Text,
                    Password = TextBox3.Text
                }));
            }
            task.ContinueWith((prevTask) => Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>('Сохранение прошло успешно');</script>"),
               TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith((prevTask) =>
            {
                var ex = (Exception)prevTask.Exception;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            Server.Transfer("LogInWebForm.aspx");
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Server.Transfer("LogInWebForm.aspx");
        }
    }
}