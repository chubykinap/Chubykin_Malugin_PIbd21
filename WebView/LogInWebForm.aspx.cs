using Classes.ViewModels;
using System;
using System.Threading.Tasks;
using System.Web.UI;

namespace WebView
{
    public partial class LogInForm : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {}

        protected void EnterButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LoginTextBox.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Введите логин');</script>");
                return;
            }
            if (string.IsNullOrEmpty(PasswordTextBox.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Введите пароль');</script>");
                return;
            }
            Task task = Task.Run(() => APIClient.PostRequestData("http://localhost:6253/api/Admin/TryEnter", new AdminViewModel
            {
                Login = LoginTextBox.Text,
                Password = PasswordTextBox.Text
            }));
            task.ContinueWith((prevTask) => Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>('Успешно');</script>"),
            TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith((prevTask) =>
            {
                var ex = (Exception)prevTask.Exception;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }, TaskContinuationOptions.OnlyOnFaulted);
            Server.Transfer("MainWebForm.aspx");
        }

        protected void RegButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("RegistrationWebForm.aspx");
        }
    }
}