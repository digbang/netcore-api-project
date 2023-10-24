using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using MyProject.Data;
using MyProject.Views;

namespace MyProject.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        [NonAction]
        protected ObjectResult Respond(ObjectResult response, PaginateResult? paginateResult = null)
        {
            dynamic data = new System.Dynamic.ExpandoObject();

            data.data = response.Value;

            if (paginateResult != null)
            {
                data.pagination = PaginationView.MakeOne(paginateResult);
            }

            return new (data)
            {
                StatusCode = response.StatusCode,
                ContentTypes = new MediaTypeCollection
                {
                    "application/json",
                }
            };
        }
    }
}
