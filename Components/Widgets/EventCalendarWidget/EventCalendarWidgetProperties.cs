using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Xperience.Core.Events
{
    public class EventCalendarWidgetProperties : IWidgetProperties
    {
        [EditingComponent(PathSelector.IDENTIFIER, Label = "Load calendars from", ExplanationText = "Loads all calendars under the selected parent page")]
        [EditingComponentProperty(nameof(PathSelectorProperties.Required), true)]
        public IEnumerable<PathSelectorItem> Parent { get; set; } = Enumerable.Empty<PathSelectorItem>();

        [VisibilityCondition(nameof(Parent), ComparisonTypeEnum.IsEqualTo, "apaththatwillneverexist", StringComparison = StringComparison.OrdinalIgnoreCase)]
        public string WidgetGUID { get; set; } = Guid.NewGuid().ToString();

        public EventCalendarWidgetProperties()
        {
            
        }
    }
}
