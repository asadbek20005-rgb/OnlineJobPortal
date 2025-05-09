using Microsoft.AspNetCore.Mvc.ModelBinding;
using StatusGeneric;

namespace OnlineJobPortal.Service.Extensions;

public static class ErrorExtension
{
    public static void CopyToModelState(this IStatusGeneric statusGeneric, ModelStateDictionary modelState)
    {
        if (!statusGeneric.HasErrors)
            return;

        foreach (var error in statusGeneric.Errors)
        {
            modelState.AddModelError(error.ErrorResult.MemberNames.Count() == 1 ? error.ErrorResult.MemberNames.First() : string.Empty,
                error.ToString());
        }
    }
}