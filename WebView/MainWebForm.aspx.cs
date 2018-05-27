using Classes.BindingModels;
using Classes.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebView
{
    public partial class MainWebForm : System.Web.UI.Page
    {
        List<FoodViewModel> list;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                list = Task.Run(() => APIClient.GetRequestData<List<FoodViewModel>>("api/Food/GetList")).Result;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ScriptAllertLoad", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void StorageButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("StorageWebForm.aspx");
        }

        protected void MailButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("MailWebForm.aspx");
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("AddFoodWebForm.aspx");
        }

        protected void ChangeButton_Click(object sender, EventArgs e)
        {
            if (GridView.SelectedIndex >= 0)
            {
                string id = list[GridView.SelectedIndex].ID.ToString();
                Session["FoodId"] = id;
                Server.Transfer("AddFoodFurniture.aspx");
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            if (GridView.SelectedIndex >= 0)
            {
                int id = list[GridView.SelectedIndex].ID;
                Task task = Task.Run(() => APIClient.PostRequestData("api/Furniture/DelElement", new FoodBindingModel { ID = id }));
                task.ContinueWith((prevTask) => Page.ClientScript.RegisterStartupScript(this.GetType(), "ScriptSuccessDelete", "<script>alert('Запись удалена. Обновите список');</script>"),
                TaskContinuationOptions.OnlyOnRanToCompletion);
                task.ContinueWith((prevTask) =>
                {
                    var ex = (Exception)prevTask.Exception;
                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ScriptAllertDelete", "<script>alert('" + ex.Message + "');</script>");
                }, TaskContinuationOptions.OnlyOnFaulted);
            }
        }

        protected void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}