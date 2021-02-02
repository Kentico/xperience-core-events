using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Xperience.Core.Events
{
    public class EventRegistrationFormWidgetProperties : IWidgetProperties
    {
        [EditingComponent(RadioButtonsComponent.IDENTIFIER, Label = "Submit action", ExplanationText = "Action taken after successful registration", Order = 1)]
        [EditingComponentProperty(nameof(RadioButtonsProperties.DataSource), "text;Display text\r\nredirect;Redirect to page")]
        public string SubmitAction { get; set; } = "text";

        [VisibilityCondition(nameof(SubmitAction), ComparisonTypeEnum.IsEqualTo, "text", StringComparison = StringComparison.OrdinalIgnoreCase)]
        [EditingComponent(TextAreaComponent.IDENTIFIER, Label = "Text to display", Order = 2)]
        public string Text { get; set; }

        [VisibilityCondition(nameof(SubmitAction), ComparisonTypeEnum.IsEqualTo, "redirect", StringComparison = StringComparison.OrdinalIgnoreCase)]
        [EditingComponent(PathSelector.IDENTIFIER, Label = "Redirect to page", Order = 3)]
        public IEnumerable<PathSelectorItem> RedirectTo { get; set; } = Enumerable.Empty<PathSelectorItem>();

        public EventRegistrationFormWidgetProperties()
        {

        }
    }
}
