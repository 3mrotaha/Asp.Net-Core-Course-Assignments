using ControllersSection.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ModelBindingAndValidationSection.CustomModelBinders
{
    public class PersonModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            Person person = new Person();
            if(bindingContext.ValueProvider.GetValue("FirstName").Count() > 0)
            {
                person.Name = bindingContext.ValueProvider.GetValue("FirstName").FirstValue;
            }
            
            if (bindingContext.ValueProvider.GetValue("LastName").Count() > 0)
            {
                person.Name += " ";
                person.Name += bindingContext.ValueProvider.GetValue("LastName").FirstValue;
            }

            if (bindingContext.ValueProvider.GetValue(nameof(Person.Email)).Count() > 0)
            {
                person.Email = bindingContext.ValueProvider.GetValue(nameof(Person.Email)).FirstValue;
            }

            if (bindingContext.ValueProvider.GetValue(nameof(Person.Phone)).Count() > 0)
            {
                person.Phone = bindingContext.ValueProvider.GetValue(nameof(Person.Phone)).FirstValue;
            }

            if (bindingContext.ValueProvider.GetValue(nameof(Person.Password)).Count() > 0)
            {
                person.Password = bindingContext.ValueProvider.GetValue(nameof(Person.Password)).FirstValue;
            }

            if (bindingContext.ValueProvider.GetValue(nameof(Person.ConfirmPassword)).Count() > 0)
            {
                person.ConfirmPassword = bindingContext.ValueProvider.GetValue(nameof(Person.ConfirmPassword)).FirstValue;
            }

            if (bindingContext.ValueProvider.GetValue(nameof(Person.Age)).Count() > 0)
            {
                person.Age = Convert.ToInt32(bindingContext.ValueProvider.GetValue(nameof(Person.Age)).FirstValue);
            }

            if (bindingContext.ValueProvider.GetValue(nameof(Person.Salary)).Count() > 0)
            {
                person.Salary = Convert.ToDouble(bindingContext.ValueProvider.GetValue(nameof(Person.Salary)).FirstValue);
            }

            if (bindingContext.ValueProvider.GetValue(nameof(Person.DateOfBirth)).Count() > 0)
            {
                person.DateOfBirth = Convert.ToDateTime(bindingContext.ValueProvider.GetValue(nameof(Person.DateOfBirth)).FirstValue);
            }

            bindingContext.Result = ModelBindingResult.Success(person);
            return Task.CompletedTask;
        }
    }
}
