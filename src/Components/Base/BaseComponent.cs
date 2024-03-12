using Components.Base.Configuration;
using Microsoft.AspNetCore.Components;

namespace Components.Base
{
    public class BaseComponent : ComponentBase
    {
        /// <summary>
        /// The size of the component, defaults to <see cref="ComponentSize.Medium"/>
        /// </summary>
        [Parameter]
        public ComponentSize Size { get; set; } = ComponentSize.Medium;

        /// <summary>
        /// Classes to add extra styles.
        /// </summary>
        [Parameter]
        public string CssClasses { get; set; } = "";

        /// <summary>
        /// Dictionary for setting the HTML attributes. 
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> InputAttributes { get; set; }

        /// <summary>
        /// Defines the color of the Components border
        /// </summary>
        [Parameter]
        public string BorderColorClass { get; set; } = string.Empty;

        /// <summary>
        /// Defines the color of the Components background
        /// </summary>
        [Parameter]
        public string BackgroundColorClass { get; set; } = string.Empty;

        /// <summary>
        /// Defines the color of the Components background when hovered over
        /// </summary>
        [Parameter]
        public string HoveredBackgroundColorClass { get; set; } = string.Empty;

        /// <summary>
        /// Defines the color of the Components Text
        /// </summary>
        [Parameter]
        public string TextColorClass { get; set; } = string.Empty;

        public string Border_Background_Color_SizeStyling
        {
            get
            {
                var componentSizeStyling = Size switch
                {
                    ComponentSize.Small => "px-2 py-1 text-sm",
                    ComponentSize.Medium => "px-3 py-2 text-base",
                    ComponentSize.Large => "px-4 py-3 text-lg",
                    ComponentSize.XLarge => "px-4 py-3 text-xl",
                };

                return componentSizeStyling + $"border-{BorderColorClass} bg-{BackgroundColorClass} hover:bg-{HoveredBackgroundColorClass} text-{TextColorClass}";
            }
        }
    }
}
