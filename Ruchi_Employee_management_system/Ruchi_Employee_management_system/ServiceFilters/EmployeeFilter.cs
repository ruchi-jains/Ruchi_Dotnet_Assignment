using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Ruchi_Employee_management_system.Common;
using Ruchi_Employee_management_system.Entity;

namespace Ruchi_Employee_management_system.ServiceFilters
{
    public class EmployeeFilter : IAsyncActionFilter
    {
         
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var param = context.ActionArguments.SingleOrDefault(p => p.Value is EmployeeFilterCriteria);
            if (param.Value == null)
            {
                context.Result = new BadRequestObjectResult("Onject is null here");
                return;
            }
            EmployeeFilterCriteria filterCriteria = (EmployeeFilterCriteria)param.Value;
            var statusFilter = filterCriteria.Filters.Find(a => a.FieldName == "role");
            if (statusFilter != null)
            {
                statusFilter = new FilterCriteria();
                statusFilter.FieldName = "role";
                statusFilter.FieldValue = "student";
                filterCriteria.Filters.Add(statusFilter);
            }
            filterCriteria.Filters.RemoveAll(a => string.IsNullOrEmpty(a.FieldName));

            var result = await next();
        }
    }
}
