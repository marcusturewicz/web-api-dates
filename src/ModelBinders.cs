using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Logging;

namespace WebApiDates
{
    public class IsoDateModelBinder : IModelBinder
    {
        private readonly IModelBinder _baseBinder;

        public IsoDateModelBinder(ILoggerFactory loggerFactory)
        {
            _baseBinder = new SimpleTypeModelBinder(typeof(DateTime), loggerFactory);
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueProviderResult != ValueProviderResult.None)
            {
                bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);

                var valueAsString = valueProviderResult.FirstValue;

                var dateTimeParsed = DateTime.TryParseExact(valueAsString, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTimeResult);
                if (dateTimeParsed)
                {
                    bindingContext.Result = ModelBindingResult.Success(dateTimeResult);
                    return Task.CompletedTask;
                }
            }

            return _baseBinder.BindModelAsync(bindingContext);
        }
    }
}