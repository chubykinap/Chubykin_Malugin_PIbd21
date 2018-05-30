using Classes.BindingModels;
using Classes.Interfaces;
using System;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class AdminController : ApiController
    {
        private readonly IAdminService _service;

        public AdminController(IAdminService service)
        {
            _service = service;
        }

        [HttpGet]
        public IHttpActionResult GetList()
        {
            var list = _service.GetList();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var element = _service.GetElement(id);
            if (element == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(element);
        }

        [HttpPost]
        public void AddElement(AdminBindingModel model)
        {
            _service.AddElement(model);
        }

        [HttpPost]
        public void UpdElement(AdminBindingModel model)
        {
            _service.UpdElement(model);
        }

        [HttpPost]
        public void DelElement(AdminBindingModel model)
        {
            _service.DelElement(model.ID);
        }

        [HttpPost]
        public void TryEnter(AdminBindingModel model)
        {
            _service.TryEnter(model);
        }
    }
}
