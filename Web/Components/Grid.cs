
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Components
{
    [HtmlTargetElement("grid")]
    public class Grid : TagHelper
    {
        public string ReadUrl { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string EditUrl { get; set; }
        public string DeleteUrl { get; set; }
        public string CreateUrl { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            context.Items.Add("GridContext", new GridContext());
            var gridContext = context.Items["GridContext"] as GridContext;

            var table = new TagBuilder("table");
            table.Attributes.Add("class", "table table-sm table-striped");

            table.MergeAttribute("read-url", ReadUrl, true);
            table.MergeAttribute("edit-url", EditUrl, true);
            table.MergeAttribute("delete-url", DeleteUrl, true);
            table.MergeAttribute("create-url", CreateUrl, true);

            table.MergeAttribute("page-size", 5.ToString(), true);
            table.MergeAttribute("page", 1.ToString(), true);

            var tr = new TagBuilder("tr");
            var thead = new TagBuilder("thead");

            await output.GetChildContentAsync();

            foreach (var column in gridContext.Columns)
            {
                tr.InnerHtml.AppendHtml(column);
            }

            thead.InnerHtml.AppendHtml(tr);
            table.InnerHtml.AppendHtml(thead);

            table.InnerHtml.AppendHtml(new TagBuilder("tbody"));

            output.Content.AppendHtml(table);


        }
    }

    [HtmlTargetElement("column", ParentTag = "grid")]
    public class Column : TagHelper
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool Sortable { get; set; }
        public bool CustomProperty { get; set; }
        public bool Hidden { get; set; }
        public string Format { get; set; } 



        [HtmlAttributeName("for")]
        public ModelExpression FieldExpression { get; set; }
        public Column()
        {
            Sortable = true;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var gridContext = context.Items["GridContext" ] as GridContext;


            if (FieldExpression != null)
            {
                if (string.IsNullOrEmpty(Name))
                {
                    Name = FieldExpression.Name;
                }
                if (string.IsNullOrEmpty(DisplayName))
                {
                    DisplayName = FieldExpression.Metadata.DisplayName;
                }
            }
            var column = new TagBuilder("th");
            column.InnerHtml.AppendHtml(DisplayName);

            foreach (var item in output.Attributes)
            {
                column.MergeAttribute(item.Name, item.Value?.ToString(), true);
            }
            column.MergeAttribute("class", "text-nowrap");
            column.MergeAttribute("field", Name);
            column.MergeAttribute("order", Sortable ? "1" : "0");
            column.MergeAttribute("custom-property", CustomProperty ? "1" : "0");
            column.MergeAttribute("data-hidden", Hidden ? "1" : "0");

            if (Hidden)
            {
                column.AddCssClass("d-none");
            }

            if (CustomProperty)
            {
                column.InnerHtml.AppendHtml(new HtmlString("<i class=\"fas fa-check\"></i>"));
                column.MergeAttribute("style", "padding-left: 24px;");
            }
            if (!string.IsNullOrEmpty(Format))
            {
                column.MergeAttribute("format", Format, true);
            }

            gridContext.Columns.Add(column);

            output.SuppressOutput();
        }
    }
    public class GridContext
    {
        public List<IHtmlContent> Columns { get; set; }

        public GridContext()
        {
            Columns = new List<IHtmlContent>();
        }
    }
}


