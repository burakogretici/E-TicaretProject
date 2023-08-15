using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Web.Components
{
    [HtmlTargetElement("filters")]
    public class FiltersTagHelper : TagHelper
    {
        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", "m-0 p-2 form-row");


            var filterTags = await output.GetChildContentAsync();
            output.Content.AppendHtml(filterTags);

            var buttonTag = new TagBuilder("button");
            buttonTag.Attributes.Add("class", "btn btn-sm btn-warning");
            buttonTag.Attributes.Add("type", "submit");
            buttonTag.Attributes.Add("id", "searchButton");
            buttonTag.InnerHtml.Append("Ara");

            var textRightDiv = new TagBuilder("div");
            textRightDiv.Attributes.Add("class", "text-right col-12");
            textRightDiv.InnerHtml.AppendHtml(buttonTag);

            output.Content.AppendHtml(textRightDiv);

        }
    }
    [HtmlTargetElement("filter", ParentTag = "filters")]
    public class FilterTagHelper : TagHelper
    {

        [HtmlAttributeName("placeholder")]
        public string Placeholder { get; set; }

        [HtmlAttributeName("label")]
        public string Label { get; set; }

        [HtmlAttributeName("value")]
        public string Value { get; set; }

        [HtmlAttributeName("operator")]
        public string Operator { get; set; }

        [HtmlAttributeName("type")]
        public string Type { get; set; }


        [HtmlAttributeName("for")]
        public ModelExpression FieldExpression { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", "col-lg-4 col-md-8 mt-md-1 form-group filter");

            if (FieldExpression != null)
            {
                if (string.IsNullOrEmpty(Label))
                {
                    Label = FieldExpression.Metadata.DisplayName;
                }
            }

            var labelTag = new TagBuilder("label");
            labelTag.AddCssClass("font-weight-semibold");
            labelTag.InnerHtml.Append(Label);
            output.Content.AppendHtml(labelTag);

            var inputTag = new TagBuilder("input");
            inputTag.Attributes.Add("type", Type);
            inputTag.Attributes.Add("class", "form-control form-control-sm");
            inputTag.Attributes.Add("placeholder", Placeholder);
            inputTag.Attributes.Add("value", FieldExpression.Model?.ToString());
            inputTag.Attributes.Add("field", FieldExpression.Name);
            inputTag.Attributes.Add("operator", Operator);
            output.Content.AppendHtml(inputTag);
        }
    }
}

