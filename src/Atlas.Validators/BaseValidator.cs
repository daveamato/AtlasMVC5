using Atlas.Components.Alerts;
using Atlas.Components.Mvc;
using Atlas.Data.Core;
using Atlas.Objects;
using Atlas.Resources;
using Atlas.Resources.Form;
using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Atlas.Validators
{
    public abstract class BaseValidator : IValidator
    {
        public ModelStateDictionary ModelState { get; set; }
        public Int32 CurrentAccountId { get; set; }
        public AlertsContainer Alerts { get; set; }
        protected IUnitOfWork UnitOfWork { get; }

        protected BaseValidator(IUnitOfWork unitOfWork)
        {
            ModelState = new ModelStateDictionary();
            Alerts = new AlertsContainer();
            UnitOfWork = unitOfWork;
        }

        protected Boolean IsSpecified<TView>(TView view, Expression<Func<TView, Object>> property) where TView : BaseView
        {
            Boolean isSpecified = property.Compile().Invoke(view) != null;

            if (!isSpecified)
            {
                UnaryExpression unary = property.Body as UnaryExpression;
                if (unary == null)
                    ModelState.AddModelError(property, Validations.Required, ResourceProvider.GetPropertyTitle(property));
                else
                    ModelState.AddModelError(property, Validations.Required, ResourceProvider.GetPropertyTitle(unary.Operand));
            }

            return isSpecified;
        }

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}
