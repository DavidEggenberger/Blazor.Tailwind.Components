using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Components.Base;

namespace Components.Forms
{
    public class BaseInput<T> : BaseComponent
    {
        [CascadingParameter]
        protected EditContext CascadedEditContext { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public string Label { get; set; }

        [Parameter] 
        public T Value { get; set; }

        [Parameter] 
        public EventCallback<T> ValueChanged { get; set; }

        [Parameter] 
        public Expression<Func<T>> ValueExpression { get; set; }

        [Parameter]
        public Expression<Func<T>> ValidationFor { get; set; }

        protected FieldIdentifier _fieldIdentifier;

        protected override void OnInitialized()
        {
            _fieldIdentifier = FieldIdentifier.Create(ValueExpression);
        }

        private string _id = "";
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = $"{Guid.NewGuid()}";
            }
        }

        protected async Task HandleInput(ChangeEventArgs args)
        {
            await ValueChanged.InvokeAsync(ConvertTo(args.Value));
            CascadedEditContext?.NotifyFieldChanged(_fieldIdentifier);
        }

        protected bool CanValidate => CascadedEditContext is not null && ValidationFor is not null;

        protected string _fieldCssClasses => CascadedEditContext?.FieldCssClass(_fieldIdentifier) ?? "";

        private T ConvertTo(object value)
        {
            var returnValue = default(T);

            if (value is T)
            {
                returnValue = (T)value;
            }
            else
            {
                try
                {
                    returnValue = (T)Convert.ChangeType(value, typeof(T));
                }
                catch (InvalidCastException)
                {
                    returnValue = default(T);
                }
            }

            return returnValue;
        }
    }
}
